﻿/***********************************************************************
 * <copyright file="XtraColumnCollectionEditor.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 13 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.ComponentModel.Design;

namespace Buca.Application.iBigTime2020.WindowsForm.Code.PropertyGrid
{
    public class XtraColumnCollectionEditor : CollectionEditor
    {
        public XtraColumnCollectionEditor(Type type)
            : base(type)
        {
        }

        protected override string GetDisplayText(object value)
        {
            return base.GetDisplayText("[Name=], [Caption=]");
        }
    }
}