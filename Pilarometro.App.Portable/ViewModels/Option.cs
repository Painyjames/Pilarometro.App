using System;
using Xamarin.Forms;

namespace Pilarometro.App.Portable.Utils.ServiceClients
{
	public class Option
	{
		public string Name { get; private set; }
		public UriImageSource Picture { get; private set; }

		public Option (string name, string message, string picture)
		{
			Name = name;
			Picture = new UriImageSource { Uri = new Uri(picture)};
		}
	}
}

