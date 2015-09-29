using System;
using System.Threading.Tasks;
using PCLStorage;

namespace Pilarometro.App.Portable.Utils.DataAccess
{
	/// <summary>
	/// Not to be used right now...
	/// This didn't work, so will consider to remove in the future
	///
	///			var dataFileStorage = new DataFileStorage ();
	///			dataFileStorage.GetDbFilePath ().ContinueWith (c => {
	///  				SQLiteConnection connection = new SQLiteConnection (App.SqlLitePlatform, c.Result);
	///				connection.CreateTable<UserInfo>();
	///				LoadApplication (App.Instance);
	///			});
	/// </summary>
	public class DataFileStorage
	{
		private static readonly string _DbFolder = "PilarometroData";
		private static readonly string _DbFile = "RF12G5td864.db3";

		public async Task<string> GetDbFilePath(){
			var rootFolder = FileSystem.Current.LocalStorage;
			IFolder folder = await rootFolder.CreateFolderAsync(_DbFolder,
				CreationCollisionOption.OpenIfExists);
			var dbFile = await folder.CreateFileAsync (_DbFile, CreationCollisionOption.OpenIfExists);
			return dbFile.Path;
		}
	}
}

