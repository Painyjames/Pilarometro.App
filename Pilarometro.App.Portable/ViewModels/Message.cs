using System;
using Xamarin.Forms;

namespace Pilarometro.App.Portable.Utils.ServiceClients
{
	public class Message
	{
		public string Name { get; private set; }
		public string Body { get; set; }
		public UriImageSource Picture { get; private set; }
		public double? Longitude { get; set; }
		public double? Latitude { get; set; }

		public Message (string name, string message, string picture)
		{
			Name = name;
			Body = message;
			Picture = new UriImageSource { Uri = new Uri(picture)};
		}
	}
}

