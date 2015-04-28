using System;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.ViewModels;
using Xamarin.Forms;

namespace MobilityDay.FormsPresenter
{
    public class MvxFormsViewModelViewTypeFinder : MvxViewModelViewTypeFinder
    {
        public MvxFormsViewModelViewTypeFinder(IMvxViewModelByNameLookup viewModelByNameLookup, IMvxNameMapping viewToViewModelNameMapping) : base(viewModelByNameLookup, viewToViewModelNameMapping)
        {
        }

        protected override bool CheckCandidateTypeIsAView(Type candidateType)
        {
            if (typeof (Page).IsAssignableFrom(candidateType))
            {
                return true;
            }

            return base.CheckCandidateTypeIsAView(candidateType);
        }
    }
}
