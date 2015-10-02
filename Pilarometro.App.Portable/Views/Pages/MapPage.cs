using System;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Pilarometro.App.Portable.Views.Cells;
using Pilarometro.App.Portable.Utils.ServiceClients;
using Pilarometro.App.Portable.Utils.Mappers;
using Pilarometro.App.Portable.Requests;
using Pilarometro.App.Portable.DTOs;

namespace Pilarometro.App.Portable.Pages
{
	public class MapPage : BaseContentPage {

		private Map _map;

		public void LoadMap (){
			GetPointsOfInterest ();

			var position = new Position (App.Instance.Latitude.Value, App.Instance.Longitude.Value);
			_map = new Map(MapSpan.FromCenterAndRadius (position, Distance.FromMiles (0.3))) {
				IsShowingUser = true
			};
			var score = new StackLayout () {
				BackgroundColor = Color.FromHex("FF7F7F"),
				Children = {

					new Label() { 
						Text = string.Format("Puntuacion {0}", App.Instance.User.GetScore()),
						FontSize = 22,
						FontAttributes = FontAttributes.Bold,
						TextColor = Color.White,
						HorizontalOptions = LayoutOptions.Center,
						VerticalOptions = LayoutOptions.CenterAndExpand
					},
				}	
			};

			var relativeLayout = new RelativeLayout () {
				HeightRequest = 150
			};

			relativeLayout.Children.Add (
				_map,
				Constraint.Constant (0),
				Constraint.Constant (0),
				Constraint.RelativeToParent ((parent) => {
					return parent.Width;
				}),
				Constraint.RelativeToParent ((parent) => {
					//TODO: change it
					return 470;
				})
			);

			relativeLayout.Children.Add (
				score,
				Constraint.Constant (0),
				Constraint.RelativeToParent ((parent) => {
					return parent.Height - 50;
				}),
				Constraint.RelativeToParent ((parent) => {
					return parent.Width;
				}),
				Constraint.RelativeToParent ((parent) => {
					return 50;
				})
			);

			Content = relativeLayout;
			OnPropertyChanged ("Content");
		}

		public void GetPointsOfInterest(){
			var client = new ServiceClient();
			client.GetPointsOfInterest (new FindPointsOfInterestRequest {
				Latitude = App.Instance.Latitude.Value,
				Longitude = App.Instance.Longitude.Value,
				PageNumber = 0,
				PageSize = 200
			})
			.ContinueWith (c => {
				App.Instance.PointsOfInterest = c.Result.PointsOfInterest;
				App.Instance.CheckIfVisited ();
				Device.BeginInvokeOnMainThread(() => AddPins (App.Instance.PointsOfInterest));
			});
		}

		public void AddPins(IList<PointOfInterestDto> pointsOfInterest){
			foreach (var pointOfInterest in pointsOfInterest) {
				var pin = new Pin {
					Position = new Position (pointOfInterest.Coordinates.Lat.Value, pointOfInterest.Coordinates.Lon.Value),
					Type = PinType.SearchResult,
					Label = pointOfInterest.Name
				};
				_map.Pins.Add (pin);
			}
			OnPropertyChanged ("Content");
		}

	}
}

