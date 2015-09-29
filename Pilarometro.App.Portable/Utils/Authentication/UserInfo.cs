using System;

namespace Pilarometro.App.Portable.Utils.Authentication
{
	public class UserInfo : IUserInfo
	{
		public virtual string Name { get; set; }
		public virtual string Email { get; set; }
		public virtual string Picture {  get; set; }
	}
}

