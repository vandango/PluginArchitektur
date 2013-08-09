using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using PluginLib;
using System.IO;

namespace PluginSystem
{
	public class OurApplication : IPluginHost
	{
		// Lädt die Plugins und registriert sie
		public void OnLoad(string path)
		{
			Console.WriteLine("Lade Plugins von {0}", path);
			Console.WriteLine();

			List<string> files = new List<string>(
				Directory.GetFiles(path, "*.dll")
			);

			foreach(string file in files)
			{
				BasePlugin plugin = PluginLoader.LoadPlugin(file, this);

				plugin.Activate();

				Console.WriteLine(
					"Ist aktiviert? {0}",
					plugin.Info.Active
				);

				plugin.InternalDoWork("Hallo Welt!");

				Console.WriteLine();
				Console.WriteLine();
			}
		}

		// Registriere die Plugins
		public bool Register(IPlugin plugin)
		{
			Console.WriteLine("Plugin {0} wurde registriert.", plugin.Info.Name);
			Console.WriteLine(
				"\tAutor: {1}\n\tVersion: {2}\n\tBeschreibung: {3}\n\tIst aktiviert? {4}",
				plugin.Info.Name,
				plugin.Info.Author,
				plugin.Info.Version,
				plugin.Info.Description, 
				plugin.Info.Active
			);

			return true;
		}
	}
}
