using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PluginSystem
{
	class Program
	{
		private static OurApplication ourApplication = new OurApplication();

		static void Main(string[] args)
		{
			Assembly self = Assembly.GetExecutingAssembly();
			string pluginPath = self.Location.Replace(
				self.ManifestModule.Name,
				""
			) + "..\\..\\..\\__Plugins\\";

			string path = Path.GetFullPath(pluginPath);

			ourApplication.OnLoad(path);

			Console.Read();
		}
	}
}
