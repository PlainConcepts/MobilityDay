using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Cirrious.MvvmCross.Touch.Views;
using Cirrious.MvvmCross.ViewModels;

namespace MobilityDay.iOS
{
    public class StoryboardBasedContainer : MvxTouchViewsContainer
    {
        protected override IMvxTouchView CreateViewOfType(Type viewType, MvxViewModelRequest request)
        {
            IMvxTouchView view;

            try
            {
                view = (IMvxTouchView)UIStoryboard.FromName("Storyboard", null)
                    .InstantiateViewController(viewType.Name);
            }
            catch (Exception e)
            {
                throw e;
            }

            return view;
        }
    }
}