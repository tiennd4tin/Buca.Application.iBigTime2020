using Buca.Application.iBigTime2020.View.Deposit;

namespace Buca.Application.iBigTime2020.Presenter.Deposit
{
    public class BADepositsPresenter:Presenter<IBADepositsView>
    {
        public BADepositsPresenter(IBADepositsView view) : base(view)
        {
        }

        public void Display()
        {
            View.BADeposits = Model.GetBADeposits();
        }
    }
}