using System;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Pilarometro.App.Portable.Utils.ServiceClients.Models;
using Pilarometro.App.Portable.Views.Cells;
using Pilarometro.App.Portable.Utils.ServiceClients;
using Pilarometro.App.Portable.Utils.Mappers;

namespace Pilarometro.App.Portable.Pages
{
	public class MapPage : BaseContentPage {

		private Map _map;
		private Entry _newComment;
		private ListView _comments;

		public void LoadMap (){
			var position = new Position (App.Instance.Latitude.Value, App.Instance.Longitude.Value);
			_map = new Map(MapSpan.FromCenterAndRadius (position, Distance.FromMiles (0.3))) {
				IsShowingUser = true,
				HeightRequest = 250,
				WidthRequest = 960,
				VerticalOptions = LayoutOptions.FillAndExpand
			};
			var stack = new StackLayout { Spacing = 0 };

			var search = new SearchBar { Placeholder = "Search topic" };

			search.SearchButtonPressed += (e, a) =>
			{
				//TODO: what to do here?
			};

			GetMessages ();

			_comments = new ListView
			{
				ItemTemplate = new DataTemplate(typeof(MessageCell))
			};

			_newComment = new Entry {
				Keyboard = Keyboard.Text,
				Placeholder = "Echo!"
			};
			var submitButton = new Button {
				Text = "Submit",
				FontSize = 20,
				HorizontalOptions = LayoutOptions.CenterAndExpand
			};
			submitButton.Clicked += SubmitMessage;

			stack.Children.Add(search);
			stack.Children.Add(_map);
			stack.Children.Add(_comments);
			stack.Children.Add(_newComment);
			stack.Children.Add(submitButton);
			Content = stack;
			OnPropertyChanged ("Content");
		}

		public void SubmitMessage(object sender, EventArgs args){
			var client = new ServiceClient();
			var app = App.Instance;
			client.PostMessage(MapperServiceClient.Map(app.User, _newComment.Text, app.Longitude, app.Latitude))
			.ContinueWith(c=>{
					GetMessages();
					_newComment.Text = string.Empty;
			});
		}

		public void GetMessages(){
			var echoingClient = new ServiceClient();
			echoingClient.GetMessages(MapperServiceClient.Map(App.Instance.User,
				App.Instance.Longitude, App.Instance.Latitude))
			.ContinueWith(c=>{
				if(c.Exception == null){
					var localizedMessages = (IList<LocalizedMessage>)c.Result;
					var commentsList = MapperServiceClient.Map(localizedMessages);
					_comments.ItemsSource = commentsList;
					AddPins(localizedMessages);
				}
			});
		}

		public void AddPins(IList<LocalizedMessage> messages){
			foreach (var message in messages) {
				var pin = new Pin {
					Position = new Position (message.Coordinates.Latitude.Value, message.Coordinates.Longitude.Value),
					Type = PinType.SearchResult
				};
				_map.Pins.Add (pin);
			}
		}

	}
}

