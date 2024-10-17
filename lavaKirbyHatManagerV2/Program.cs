using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lKHM
{
	static class Program
	{
		private const string _version = "1.1.0";
		static public Version GetVersion()
		{
			return System.Version.Parse(_version);
		}
		static public string Version
		{
			get
			{
				Version programVer = GetVersion();
				return "v" + programVer.Major + "." + programVer.Minor + "." + programVer.Build;
			}
		}

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			try
			{
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.Run(new Form1());
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}
