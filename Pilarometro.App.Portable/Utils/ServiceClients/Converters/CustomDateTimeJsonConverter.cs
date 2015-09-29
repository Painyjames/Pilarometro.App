using System;
using Newtonsoft.Json.Converters;

namespace Pilarometro.App.Portable.Utils.ServiceClients.Converters
{
	public class CustomDateTimeJsonConverter : IsoDateTimeConverter
	{
		public CustomDateTimeJsonConverter()
		{
			base.DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
		}
	}
}

