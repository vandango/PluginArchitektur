using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using PluginLib;

namespace LoggingPlugin
{
    public class LoggingPlugin : BasePlugin
    {
		public LoggingPlugin()
		{
			base.Info.Name = "LoggingPlugin";
			base.Info.Author = "Jonathan Naumann";
			base.Info.Description = "Betreibt ein bisschen Logging.";
			base.Info.Version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
		}

		public override object DoWork(object parameter)
		{
			Console.WriteLine("Logging -> {0}", parameter);
			
			return null;
		}

		public override void Show(object parameter)
		{
			System.Windows.Forms.Form form = new System.Windows.Forms.Form();
			form.Text = base.Info.Name;
			form.Show();
		}
    }
}
