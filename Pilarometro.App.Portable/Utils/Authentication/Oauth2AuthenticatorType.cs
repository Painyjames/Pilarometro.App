using System;
using System.Runtime.Serialization;

namespace Pilarometro.App.Portable.Utils.Authentication
{
	public enum Oauth2AuthenticatorType
	{
		[EnumMember(Value="Facebook")]
		Facebook,
		[EnumMember(Value="Google")]
		Google
	}
}

