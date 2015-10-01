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
			var position = new Position (App.Instance.Latitude.Value, App.Instance.Longitude.Value);
			_map = new Map(MapSpan.FromCenterAndRadius (position, Distance.FromMiles (0.3))) {
				IsShowingUser = true,
				HeightRequest = 250,
				WidthRequest = 960,
				VerticalOptions = LayoutOptions.FillAndExpand
			};
			var stack = new StackLayout { Spacing = 0 };

			GetPointsOfInterest ();

			stack.Children.Add(_map);
			Content = stack;
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
				Device.BeginInvokeOnMainThread(() => AddPins (c.Result.PointsOfInterest));
			});
		}

		public void AddPins(IList<PointOfInterestDto> pointsOfInterest){
			foreach (var pointOfInterest in pointsOfInterest) {
				var pin = new Pin {
					Position = new Position (pointOfInterest.Coordinates.Lat.Value, pointOfInterest.Coordinates.Lon.Value),
					Type = PinType.SearchResult,
					Label = pointOfInterest.Name
				};
				try{
				_map.Pins.Add (pin);
				}catch(Exception ex){
					var e = ex;
				}
			}
			OnPropertyChanged ("Content");
		}

	}
}

