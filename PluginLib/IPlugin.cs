using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginLib
{
	public interface IPlugin
	{
		// Stellt Informationen über das Plugin bereit
		PluginInfo Info { get; set; }

		// Führt die Arbeit des Plugins aus
		object DoWork(object parameter);

		// Zeigt ein Fenster des Plugins an
		void Show(object parameter);

		// Verknüpft das Plugin mit der Host-Anwendung
		IPluginHost Host { get; set; }

		// Informationen und Methoden zum aktivieren und deaktivieren des Plugins
		bool IsActive { get; }
		void Activate();
		void Deactivate();
	}
}
