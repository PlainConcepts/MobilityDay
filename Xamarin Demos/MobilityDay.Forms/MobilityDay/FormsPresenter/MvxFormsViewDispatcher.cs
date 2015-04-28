using System;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.Views;
using Xamarin.Forms;

namespace MobilityDay.FormsPresenter
{
    public class MvxFormsViewDispatcher
        : MvxFormsMainThreadDispatcher, IMvxViewDispatcher
    {
        private readonly IMvxViewPresenter _presenter;

        public MvxFormsViewDispatcher(IMvxViewPresenter presenter)
        {
            _presenter = presenter;
        }

        public bool RequestMainThreadAction(Action action)
        {
            Device.BeginInvokeOnMainThread(action);
            return true;
        }

        public bool ShowViewModel(MvxViewModelRequest request)
        {
            return RequestMainThreadAction(() => _presenter.Show(request));
        }

        public bool ChangePresentation(MvxPresentationHint hint)
        {
            return RequestMainThreadAction(() => _presenter.ChangePresentation(hint));
        }
    }
}