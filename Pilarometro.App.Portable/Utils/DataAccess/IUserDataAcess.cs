using System;
using Pilarometro.App.Portable.Utils.Authentication;

namespace Pilarometro.App.Portable.Utils.DataAccess
{
	public interface IUserDataAccess
	{
		UserInfo GetUser();
		void SaveUser(UserInfo user);
		void DeleteAll();
		string DbPath { get; set; }
	}
}

