using System;

namespace Pilarometro.App.Portable.Utils.Authentication
{
	public interface IUserInfo
	{
		string Name { get; set; }
		string Email { get; set; }
		string Picture { get; set; }
	}
}

