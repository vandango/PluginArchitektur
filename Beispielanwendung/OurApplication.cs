using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using PluginLib;
using System.IO;
using System.Windows.Forms;

namespace Beispielanwendung
{
	public class OurApplication : IPluginHost
	{
		private MainForm __mainForm;
		private string __path;

		// Die global verfügbaren Plugins
		public static List<BasePlugin> LoadedPlugins { get; private set; }

		public OurApplication(MainForm mainForm, string path)
		{
			LoadedPlugins = new List<BasePlugin>();

			this.__mainForm = mainForm;
			this.__path = path;
		}

		// Lädt die Plugins und registriert sie
		public void OnLoad()
		{
			this.__mainForm.InfoBox.Items.Add(string.Format(
				"Lade Plugins von {0}", this.__path
			));

			List<string> files = new List<string>(
				Directory.GetFiles(this.__path, "*.dll")
			);

			foreach(string file in files)
			{
				BasePlugin plugin = PluginLoader.LoadPlugin(file, this);
				OurApplication.LoadedPlugins.Add(plugin);
			}
		}

		// Registriere die Plugins
		public bool Register(IPlugin plugin)
		{
			ToolStripMenuItem menuItem = new ToolStripMenuItem(
				plugin.Info.Name,
				null,
				new EventHandler(NewLoad)
			);

			this.__mainForm.InfoBox.Items.Add(string.Format(
				"Plugin {0} wurde registriert", plugin.Info.Name
			));

			this.__mainForm.PluginMenu.DropDownItems.Add(menuItem);

			return true;
		}

		// Click-Event für den neuen Menupunkt
		private void NewLoad(object sender, System.EventArgs e)
		{
			ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;

			foreach(IPlugin plugin in OurApplication.LoadedPlugins)
			{
				if(plugin.Info.Name == menuItem.Text)
				{
					plugin.Activate();
					plugin.Show(null);
					break;
				}
			}
		} 
	}
}
