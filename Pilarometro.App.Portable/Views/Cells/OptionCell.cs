using System;
using Xamarin.Forms;
using System.Diagnostics;

namespace Pilarometro.App.Portable.Views.Cells
{

	public class OptionCell: ViewCell
	{

		public string Name { get; private set; }
		public EventHandler TappedEvent { get; private set; }

		public OptionCell(){
			var lblName = new Label {
				FontSize = 20,
				FontFamily = Device.OnPlatform("HelveticaNeue-Medium","sans-serif-medium",null),
				VerticalOptions = LayoutOptions.Center
			};
			lblName.SetBinding (Label.TextProperty, "Name");

			View = new StackLayout {
				Orientation = StackOrientation.Horizontal,
				Children = {
					lblName
				}
			};

		}

		public OptionCell (string name, EventHandler tappedEventHandler)
		{
			Name = name;
			TappedEvent += tappedEventHandler;
		}

		protected override void OnBindingContextChanged() {
			var bindingContext = (OptionCell)BindingContext;
			Tapped += bindingContext.TappedEvent;
			base.OnBindingContextChanged ();
		}

	}
}

