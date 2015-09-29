using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.App;
using System;
using Newtonsoft.Json;
using Pilarometro.App.Portable;
using Pilarometro.App.Portable.Pages;
using Pilarometro.App.Portable.Utils.Authentication;
using Pilarometro.App.Android.Renderers;
using Xamarin.Auth;

[assembly: ExportRenderer (typeof (LoginPage), typeof (LoginPageRenderer))]

namespace Pilarometro.App.Android.Renderers
{
	public class LoginPageRenderer : PageRenderer
	{

		protected override void OnElementChanged (ElementChangedEventArgs<Page> e)
		{
			base.OnElementChanged(e);

			var loginPage = e.NewElement as LoginPage;

			loginPage.FacebookLoginButton.Clicked += LoginButtonClicked;
			loginPage.GoogleLoginButton.Clicked += LoginButtonClicked;

		}

		public void LoginButtonClicked(object sender, EventArgs args){

			var activity = this.Context as Activity;
			var loginButton = sender as Button;

			var authenticatorType = (Oauth2AuthenticatorType) Enum.Parse (typeof(Oauth2AuthenticatorType), loginButton.Text);
			var oauthAuthenticationLogin = Oauth2AuthenticatorFactory.CreateAuthenticator(authenticatorType);

			var auth = new OAuth2Authenticator (
				clientId: oauthAuthenticationLogin.ClientId,
				scope: oauthAuthenticationLogin.Scope,
				authorizeUrl: oauthAuthenticationLogin.AuthorizeUrl,
				redirectUrl: oauthAuthenticationLogin.RedirectUrl);

			auth.Completed += async (s, ea) => {
				try{
					if (ea.IsAuthenticated) {
						var token = ea.Account.Properties["access_token"];
						var uri = oauthAuthenticationLogin.InfoUri;
						var request = new OAuth2Request ("GET", uri, null, ea.Account);
						var response = await request.GetResponseAsync();
						var user = JsonConvert.DeserializeObject(response.GetResponseText(), oauthAuthenticationLogin.UserInfoType);
						Pilarometro.App.Portable.App.Instance.SaveUser(user);
						Pilarometro.App.Portable.App.Instance.SuccessfulLoginAction.Invoke();
					} else {
						Console.WriteLine ("Not Authorised");
						return;
					}
				}catch(Exception ex){
					Console.WriteLine(ex.Message);
					throw;
				}
			};

			activity.StartActivity (auth.GetUI(activity));
		}
	}
}