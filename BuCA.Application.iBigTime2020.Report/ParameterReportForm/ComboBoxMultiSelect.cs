using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using System.Reflection;
using System.Reflection.Emit;

namespace BuCA.Application.iBigTime2020.Report.ParameterReportForm
{
    public partial class ComboBoxMultiSelect : PopupContainerEdit
    {
        /// <summary>
        /// Class name of datasource with namespace
        /// </summary>
        public string GenericClass { get; set; }
        public PopupContainerControl PopupContainerControl { get { return _popupContainerControl; } }
        public GridControl GridControl { get { return _gridControl; } }
        public GridView GridView { get { return _gridView; } }

        PopupContainerControl _popupContainerControl = new PopupContainerControl();
        GridControl _gridControl = new GridControl();
        GridView _gridView = new GridView();

        public ComboBoxMultiSelect()
        {
            InitControl();
        }

        private void InitControl()
        {
            _popupContainerControl.Controls.Add(_gridControl);

            _gridControl.Dock = DockStyle.Fill;
            _gridControl.MainView = _gridView;
            _gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { _gridView });

            _gridView.GridControl = _gridControl;
            _gridView.OptionsView.ShowGroupPanel = false;
            _gridView.OptionsView.ShowIndicator = false;
            _gridView.DataSourceChanged += _gridView_DataSourceChanged;

            this.Properties.PopupControl = _popupContainerControl;
        }

        private void _gridView_DataSourceChanged(object sender, EventArgs e)
        {
            var myType = Type.GetType(GenericClass);
            if (myType == null)
            {
                foreach (var a in AppDomain.CurrentDomain.GetAssemblies())
                {
                    myType = a.GetType(GenericClass);
                    if (myType != null)
                        break;
                }
            }

            if (myType != null)
            {
                var tb = GetTypeBuilder();
                CreateProperty(tb, "CheckSelectiton", typeof(bool));
                List<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());
                foreach (PropertyInfo prop in props)
                {
                    CreateProperty(tb, prop.Name, prop.PropertyType);
                }

                var type = tb.CreateType();
            }
        }

        private TypeBuilder GetTypeBuilder()
        {
            var typeSignature = GenericClass;
            var an = new AssemblyName(typeSignature);
            AssemblyBuilder assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(an, AssemblyBuilderAccess.Run);
            ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule("MainModule");
            TypeBuilder tb = moduleBuilder.DefineType(typeSignature,
                    TypeAttributes.Public |
                    TypeAttributes.Class |
                    TypeAttributes.AutoClass |
                    TypeAttributes.AnsiClass |
                    TypeAttributes.BeforeFieldInit |
                    TypeAttributes.AutoLayout,
                    null);
            return tb;
        }

        private void CreateProperty(TypeBuilder tb, string propertyName, Type propertyType)
        {
            FieldBuilder fieldBuilder = tb.DefineField("_" + propertyName, propertyType, FieldAttributes.Private);

            PropertyBuilder propertyBuilder = tb.DefineProperty(propertyName, System.Reflection.PropertyAttributes.HasDefault, propertyType, null);
            MethodBuilder getPropMthdBldr = tb.DefineMethod("get_" + propertyName, MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig, propertyType, Type.EmptyTypes);
            ILGenerator getIl = getPropMthdBldr.GetILGenerator();

            getIl.Emit(OpCodes.Ldarg_0);
            getIl.Emit(OpCodes.Ldfld, fieldBuilder);
            getIl.Emit(OpCodes.Ret);

            MethodBuilder setPropMthdBldr =
                tb.DefineMethod("set_" + propertyName,
                  MethodAttributes.Public |
                  MethodAttributes.SpecialName |
                  MethodAttributes.HideBySig,
                  null, new[] { propertyType });

            ILGenerator setIl = setPropMthdBldr.GetILGenerator();
            System.Reflection.Emit.Label modifyProperty = setIl.DefineLabel();
            System.Reflection.Emit.Label exitSet = setIl.DefineLabel();

            setIl.MarkLabel(modifyProperty);
            setIl.Emit(OpCodes.Ldarg_0);
            setIl.Emit(OpCodes.Ldarg_1);
            setIl.Emit(OpCodes.Stfld, fieldBuilder);

            setIl.Emit(OpCodes.Nop);
            setIl.MarkLabel(exitSet);
            setIl.Emit(OpCodes.Ret);

            propertyBuilder.SetGetMethod(getPropMthdBldr);
            propertyBuilder.SetSetMethod(setPropMthdBldr);
        }
    }
}