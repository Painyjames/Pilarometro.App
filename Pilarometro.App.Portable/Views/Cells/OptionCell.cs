using System;
using Xamarin.Forms;

namespace Pilarometro.App.Portable.Views.Cells
{
	public class OptionCell: ViewCell
	{

		public string Name { get; private set; }
		public string Picture { get; private set; }

		public OptionCell(){
			var lblName = new Label {
				FontSize = 20,
				VerticalOptions = LayoutOptions.Center
			};
			lblName.SetBinding (Label.TextProperty, "Name");
			var imgProfile = new Image();
			imgProfile.SetBinding (Image.SourceProperty, "Picture");

			View = new StackLayout {
				Orientation = StackOrientation.Horizontal,
				Children = {
					imgProfile,
					lblName
				}
			};
		}

		public OptionCell (string name, string picture)
		{
			Name = name;
			Picture = picture;
		}
	}
}

