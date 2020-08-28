using Buca.Application.iBigTime2020.Model.BusinessObjects.General;
using Buca.Application.iBigTime2020.View.General;

namespace Buca.Application.iBigTime2020.Presenter.General
{
    public class GLVoucherListParamatersPresenter : Presenter<IGLVoucherListParamatersView>
    {
        public GLVoucherListParamatersPresenter(IGLVoucherListParamatersView view) : base(view)
        {
        }

        public void Display()
        {
            View.GlVoucherListParamater = Model.GlVoucherListParamater(0);
        }
        
}
}
