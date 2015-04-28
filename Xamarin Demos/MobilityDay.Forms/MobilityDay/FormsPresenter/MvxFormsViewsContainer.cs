using System;
using System.Collections.Generic;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.Views;

namespace MobilityDay.FormsPresenter
{
    public class MvxFormsViewsContainer : IMvxViewsContainer
    {
        private MvxViewsContainer _container = new InnerMvxViewsContainer();
        public Type GetViewType(Type viewModelType)
        {
            return _container.GetViewType(viewModelType);
        }

        public void AddAll(IDictionary<Type, Type> viewModelViewLookup)
        {
            _container.AddAll(viewModelViewLookup);
        }

        public void Add(Type viewModelType, Type viewType)
        {
            _container.Add(viewModelType, viewType);
        }

        public void Add<TViewModel, TView>()
            where TViewModel : IMvxViewModel
            where TView : IMvxView
        {
            _container.Add<TViewModel, TView>();
        }

        public void AddSecondary(IMvxViewFinder finder)
        {
            _container.AddSecondary(finder);
        }

        public void SetLastResort(IMvxViewFinder finder)
        {
            _container.SetLastResort(finder);
        }
    }

    internal class InnerMvxViewsContainer : MvxViewsContainer
    {
    }
}