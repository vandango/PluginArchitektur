using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using PluginLib;

namespace CalculationPlugin
{
    public class CalculationPlugin : BasePlugin
    {
		public CalculationPlugin()
		{
			base.Info.Name = "CalculationPlugin";
			base.Info.Author = "Jonathan Naumann";
			base.Info.Description = "Betreibt ein paar Berechnungen.";
			base.Info.Version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
		}

		public override object DoWork(object parameter)
		{
			Console.WriteLine("Calculation -> {0}", parameter);

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
