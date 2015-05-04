// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace MobilityDay.iOS.Views
{
	[Register ("SessionView")]
	partial class SessionView
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel DateLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel DescriptionLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel FirstSpeakerDescriptionLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel FirstSpeakerFullnameLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIImageView FirstSpeakerImage { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel TitleLabel { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (DateLabel != null) {
				DateLabel.Dispose ();
				DateLabel = null;
			}
			if (DescriptionLabel != null) {
				DescriptionLabel.Dispose ();
				DescriptionLabel = null;
			}
			if (FirstSpeakerDescriptionLabel != null) {
				FirstSpeakerDescriptionLabel.Dispose ();
				FirstSpeakerDescriptionLabel = null;
			}
			if (FirstSpeakerFullnameLabel != null) {
				FirstSpeakerFullnameLabel.Dispose ();
				FirstSpeakerFullnameLabel = null;
			}
			if (FirstSpeakerImage != null) {
				FirstSpeakerImage.Dispose ();
				FirstSpeakerImage = null;
			}
			if (TitleLabel != null) {
				TitleLabel.Dispose ();
				TitleLabel = null;
			}
		}
	}
}
