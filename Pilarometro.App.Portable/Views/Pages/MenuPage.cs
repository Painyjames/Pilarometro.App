using System;
using Xamarin.Forms;
using System.Collections.Generic;
using Pilarometro.App.Portable.Views.Cells;
using Pilarometro.App.Portable.Views.Controls;

namespace Pilarometro.App.Portable.Pages
{
	public class MenuPage : BaseContentPage
	{
		public MenuPage ()
		{ 
			var logOutCell = new OptionCell ("Log out", (sender, eventArgs) => { 
				App.Instance.DeleteUser();
			});

			var lvMenu = new ListView ();
			lvMenu.ItemsSource = new List<OptionCell>(){ logOutCell };
			lvMenu.ItemTemplate = new DataTemplate(typeof(OptionCell));

			this.Content = new StackLayout {
				Children = {
					new UserInfoControl(),
					lvMenu
				}
			};
		}
	}
}

