using System;
using System.Collections.Generic;
using Pilarometro.App.Portable.Utils.ServiceClients.Models;
using Pilarometro.App.Portable.Utils.ServiceClients;
using Pilarometro.App.Portable.Utils.Authentication;

namespace Pilarometro.App.Portable.Utils.Mappers
{
	public class MapperServiceClient
	{
		public static LocalizedMessage Map(IUserInfo userInfo, string message, double? longitude, double? latitude){
			return new LocalizedMessage {
				Coordinates = new Coordinates { Latitude = latitude, Longitude = longitude },
				MessageContent = message,
				User = new Pilarometro.App.Portable.Utils.ServiceClients.Models.User { Email = userInfo.Email, UserId = 1 },
				Timestamp = DateTime.UtcNow,
				Uuid = DateTime.UtcNow.Ticks.ToString()
			};
		}

		public static Message Map(LocalizedMessage localizedMessage){
			return new Message (localizedMessage.User == null?"tochange@test.com":localizedMessage.User.Email, localizedMessage.MessageContent, "http://i.istockimg.com/file_thumbview_approve/37911674/3/stock-illustration-37911674-vector-user-icon.jpg") {
				Latitude = localizedMessage.Coordinates.Latitude,
				Longitude = localizedMessage.Coordinates.Longitude
			};
		}

		public static IList<Message> Map(IList<LocalizedMessage> localizedMessages){
			var messages = new List<Message> ();
			foreach(var localizedMessage in localizedMessages){
				messages.Add (Map (localizedMessage));
			}
			return messages;
		}

		public static UserPosition Map(IUserInfo userInfo, double? longitude, double? latitude){
			return new UserPosition {
				Coordinates = new Coordinates { Latitude = latitude, Longitude = longitude },
				User = new Pilarometro.App.Portable.Utils.ServiceClients.Models.User { Email = userInfo.Email, UserId = 1 }
			};
		}

	}
}

