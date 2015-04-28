using Cirrious.MvvmCross.Views;

namespace Cheesebaron.MvxPlugins.FormsPresenters.Core
{
    public interface IMvxFormsPresenter : IMvxViewPresenter
    {
        MvxFormsApp MvxFormsApp { get; set; }
    }
}