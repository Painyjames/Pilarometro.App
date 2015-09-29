using System;

namespace Pilarometro.App.Portable.Utils.Authentication
{
	public class GoogleUserInfo : UserInfo
	{
		public string id { get; set; }
		public string email { get; set; }
		public bool verified_email { get; set; }
		public string name { get; set; }
		public string given_name { get; set; }
		public string family_name { get; set; }
		public string link { get; set; }
		public string picture { get; set; }
		public string gender { get; set; }
		public override string Name { get { return name;}	}
		public override string Email { get { return email;} }
		public override string Picture { get { return picture;} }
	}
}

