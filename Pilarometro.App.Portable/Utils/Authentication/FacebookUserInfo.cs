using System;

namespace Pilarometro.App.Portable.Utils.Authentication
{
	public class FacebookUserInfo : UserInfo
	{
		public string id { get; set; }
		public string first_name { get; set; }
		public string gender { get; set; }
		public string last_name { get; set; }
		public string link { get; set; }
		public string locale { get; set; }
		public string name { get; set; }
		public string verified { get; set; }
		public int timezone { get; set; }
		public string updated_time { get; set; }
		public string email { get; set; }
		public string picture_address { 
			get{ return string.Format("https://graph.facebook.com/{0}/picture", id); }
		}
		public override string Name { get { return name;}	}
		public override string Email { get { return email;} }
		public override string Picture { get { return picture_address;} }
	}
}

