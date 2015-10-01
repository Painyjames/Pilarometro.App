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

	}
}

