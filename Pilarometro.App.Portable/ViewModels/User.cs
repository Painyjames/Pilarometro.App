using System;
using Xamarin.Forms;

namespace Pilarometro.App.Portable.Utils.ServiceClients
{
	public class User
	{
		public string Name { get; private set; }
		public UriImageSource Picture { get; private set; }

		public User (string name, string message, string picture)
		{
			Name = name;
			Picture = new UriImageSource { Uri = new Uri(picture)};
		}
	}
}

