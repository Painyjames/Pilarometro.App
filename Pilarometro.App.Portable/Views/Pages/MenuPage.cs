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
			var mapCell = new OptionCell ("Map", "http://www.frevvo.com/img/paper-plane-512.png");
			var logOutCell = new OptionCell ("Log out", "http://www.frevvo.com/img/paper-plane-512.png");

			var lvMenu = new ListView ();
			lvMenu.ItemsSource = new List<OptionCell>(){ mapCell, logOutCell };
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

