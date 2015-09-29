using System;
using Xamarin.Forms;

namespace Pilarometro.App.Portable.Pages
{
	public class LoginPage : ContentPage
	{

		public Button FacebookLoginButton { get; set; }
		public Button GoogleLoginButton { get; set; }

		public LoginPage ()
		{
			Title = "Login";

			var header = new ContentView
			{
				Padding = new Thickness(0,25),
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center,
				Content = new Label {
				Text = "Echoing",
				FontSize = 50,
				FontAttributes = FontAttributes.Bold,
				HorizontalOptions = LayoutOptions.Center
				}
			};

			var message = new ContentView
			{
				Padding = new Thickness(25,0),
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center,
				Content = new Label
				{
					Text = "Echoing is another messaging app " +
						"with briefly persistent messages only " +
						"visible for those that surrounds you.\n\nAnd it's gone...",
					FontSize = 20,
					HorizontalOptions = LayoutOptions.Center
				}
			};

			FacebookLoginButton = new Button{ Text = "Facebook", FontSize = 20 };
			GoogleLoginButton = new Button{ Text = "Google", FontSize = 20 };

			var loginButtons = new Grid {
				RowDefinitions = {
					new RowDefinition { Height = GridLength.Auto }
				},
				ColumnDefinitions = {
					new ColumnDefinition { Width = GridLength.Auto }, 
					new ColumnDefinition { Width = GridLength.Auto },
					new ColumnDefinition { Width = GridLength.Auto } 
				},
				VerticalOptions = LayoutOptions.CenterAndExpand
			};
			loginButtons.Children.Add (FacebookLoginButton, 0, 0);
			loginButtons.Children.Add (new Label { Text = "|", FontSize = 40 }, 1, 0);
			loginButtons.Children.Add (GoogleLoginButton, 2, 0);

			var login = new ContentView
			{
				Padding = new Thickness(10),
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				Content = new StackLayout {
					Children = {
						new Label
						{
							Text = "Log in",
							FontSize = 25,
							HorizontalOptions = LayoutOptions.Start,
							VerticalOptions = LayoutOptions.Center
						},
						loginButtons
					}
				}
			};

			this.Content = new StackLayout {
				Children = {
					header,
					message,
					login
				}
			};

		}

	}
}

