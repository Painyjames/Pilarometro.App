using System;
using Xamarin.Forms;

namespace Pilarometro.App.Portable.Views.Cells
{
	public class MessageCell : ViewCell
	{
		public MessageCell ()
		{
			var lblName = new Label {
				FontSize = 10
			};
			lblName.SetBinding (Label.TextProperty, "Name");
			var imgProfile = new Image();
			imgProfile.SetBinding (Image.SourceProperty, "Picture");
			var lblComment = new Label {
					FontSize = 15
			};
			lblComment.SetBinding (Label.TextProperty, "Body");

			View = new StackLayout {
				Orientation = StackOrientation.Horizontal,
				Children = {
					new StackLayout {
						Orientation = StackOrientation.Vertical,
						Children = {
							imgProfile,
							lblName
						}
					},
					lblComment
				}
			};
		}
	}
}

