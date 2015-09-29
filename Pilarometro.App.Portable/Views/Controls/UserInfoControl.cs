using System;
using Xamarin.Forms;
using System.Collections.Generic;

namespace Pilarometro.App.Portable.Views.Controls
{
	public class UserInfoControl : StackLayout
	{
		public UserInfoControl ()
		{
			Orientation = StackOrientation.Horizontal;
			var profilePicture = new Image { 
				Source = new UriImageSource { Uri = new Uri (App.Instance.User.Picture) },
				HeightRequest = 48,
				WidthRequest = 48
			};
			Children.Add (profilePicture);
			Children.Add (new Label { FontSize = 20, Text = App.Instance.User.Name });
		}
	}
}

