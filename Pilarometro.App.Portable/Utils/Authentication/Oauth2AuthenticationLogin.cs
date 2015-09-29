using System;

namespace Pilarometro.App.Portable.Utils.Authentication
{
	public class Oauth2AuthenticationLogin
	{
		public string ClientId { get; set; }
		public string Scope { get; set; }
		public Uri AuthorizeUrl { get; set; }
		public Uri RedirectUrl { get; set; }
		public Uri InfoUri { get; set; }
		public Type UserInfoType { get; set; }
	}
}

