using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PluginLib;
using System.Reflection;
using System.IO;

namespace Beispielanwendung
{
	public partial class MainForm : Form
	{
		private OurApplication ourApplication;

		public MainForm()
		{
			InitializeComponent();

			Assembly self = Assembly.GetExecutingAssembly();
			string pluginPath = self.Location.Replace(
				self.ManifestModule.Name,
				""
			) + "..\\..\\..\\__Plugins\\";

			string path = Path.GetFullPath(pluginPath);

			this.ourApplication = new OurApplication(this, path);
		}

		private void beendenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		public ToolStripMenuItem PluginMenu
		{
			get
			{
				return this.pluginsToolStripMenuItem1;
			}
		}

		public ListBox InfoBox
		{
			get
			{
				return this.listBox1;
			}
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			this.ourApplication.OnLoad();
		}
	}
}
