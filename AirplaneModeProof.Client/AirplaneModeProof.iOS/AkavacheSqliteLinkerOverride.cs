//using System;
//namespace AirplaneModeProof.iOS
//{
//	public class AkavacheSqliteLinkerOverride
//	{
//		public AkavacheSqliteLinkerOverride()
//		{
//		}
//	}
//}


using System;
using Akavache.Sqlite3;

// Note: This class file is *required* for iOS to work correctly, and is 
// also a good idea for Android if you enable "Link All Assemblies".
namespace AirplaneModeProof.iOS
{
	[Preserve]
	public static class LinkerPreserve
	{
		static LinkerPreserve()
		{
			throw new Exception(typeof(SQLitePersistentBlobCache).FullName);
		}
	}


	public class PreserveAttribute : Attribute
	{
	}
}