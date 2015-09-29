using System;
using Xamarin.Forms;

namespace Pilarometro.App.Portable.Pages
{
	public class RootPage : BaseMasterDetailPage
	{
		public RootPage ()
		{
			var menuPage = new MenuPage () { Title = "Menu" };

			Master = menuPage;
			Detail = new MapPage();

			if (Device.OS != TargetPlatform.iOS)
			{
				var tap = new TapGestureRecognizer();
				tap.Tapped += (sender, args) =>
				{
					this.IsPresented = true;
				};

				menuPage.Content.BackgroundColor = Color.Transparent;
				menuPage.Content.GestureRecognizers.Add(tap);
			}
		}

		public void PositionChanged(){
			var mapPage = Detail as MapPage;
			if (mapPage != null) {
				mapPage.LoadMap ();			
			}
		}

//		async void ShowLoginDialog()
//		{
//			var page = new LoginPage();

//			await Navigation.PushModalAsync(page);
//		}

//		void NavigateTo(OptionItem option)
//		{
//		}
//
//		Page PageForOption (OptionItem option)
//		{
//			// TODO: Refactor this to the Builder pattern (see ICellFactory).
//			if (option.Title == "Contacts")
//				return new MasterPage<Contact>(option);
//			if (option.Title == "Leads")
//				return new MasterPage<Lead>(option);
//			if (option.Title == "Accounts") {
//				var page = new MasterPage<Account>(option);
//				var cell = page.List.Cell;
//				cell.SetBinding(TextCell.TextProperty, "Company");
//				return page;
//			}
//			if (option.Title == "Opportunities") {
//				var page = new MasterPage<Opportunity>(option);
//				var cell = page.List.Cell;
//				cell.SetBinding(TextCell.TextProperty, "Company");
//				cell.SetBinding(TextCell.DetailProperty, new Binding("EstimatedAmount", stringFormat: "{0:C}"));
//				return page;
//			}
//			throw new NotImplementedException("Unknown menu option: " + option.Title);
//		}

	}
}

