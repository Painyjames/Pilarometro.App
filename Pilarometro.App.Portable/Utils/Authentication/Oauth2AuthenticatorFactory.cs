using System;

namespace Pilarometro.App.Portable.Utils.Authentication
{
	public static class Oauth2AuthenticatorFactory
	{
		public static Oauth2AuthenticationLogin CreateAuthenticator(Oauth2AuthenticatorType oauthAunteticatorTypes){
			switch(oauthAunteticatorTypes){
			case Oauth2AuthenticatorType.Facebook:
				return new Oauth2AuthenticationLogin () {
					Scope = string.Empty,
					ClientId = "1496157347325615",
					AuthorizeUrl = new Uri ("https://m.facebook.com/dialog/oauth/"),
					RedirectUrl = new Uri ("http://www.facebook.com/connect/login_success.html"),
					InfoUri = new Uri("https://graph.facebook.com/me"),
					UserInfoType = typeof(FacebookUserInfo)
				};
			default:
				return new Oauth2AuthenticationLogin () {
					Scope = "https://www.googleapis.com/auth/userinfo.email",
					ClientId = "49936451067-do0ul4v9clcep3os3nmp06p779eeuk8h.apps.googleusercontent.com",
					AuthorizeUrl = new Uri ("https://accounts.google.com/o/oauth2/auth"),
					RedirectUrl = new Uri ("https://www.example.com/oauth2callback"),
					InfoUri = new Uri("https://www.googleapis.com/oauth2/v2/userinfo"),
					UserInfoType = typeof(GoogleUserInfo)
				};
			}
		}
	}
}

