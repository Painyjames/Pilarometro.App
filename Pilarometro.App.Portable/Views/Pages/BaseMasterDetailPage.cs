using System;
using Xamarin.Forms;

namespace Pilarometro.App.Portable.Pages
{
	public class BaseMasterDetailPage : MasterDetailPage
	{
		protected override void OnAppearing ()
		{
			base.OnAppearing ();

			if (!App.Instance.IsLoggedIn) {
				Navigation.PushModalAsync(new LoginPage());
			}
		}
	}
}

