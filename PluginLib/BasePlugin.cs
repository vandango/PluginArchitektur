using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginLib
{
	public abstract class BasePlugin : IPlugin
	{
		// Erstellt eine Instance des Plugins
		public BasePlugin()
		{
			this.Info = new PluginInfo();
		}

		// Stellt Informationen über das Plugin bereit
		public PluginInfo Info { get; set; }

		// Führt die Arbeit des Plugins aus.
		public abstract object DoWork(object parameter);

		public object InternalDoWork(object parameter)
		{
			if(this.IsActive)
			{
				return this.DoWork(parameter);
			}

			return null;
		}

		// Zeigt ein Fenster des Plugins an
		public abstract void Show(object parameter);

		// Verknüpft die Hostanwendung mit dem Plugin und ruft die Register-Methode auf
		private IPluginHost __host;

		public IPluginHost Host
		{
			get { return this.__host; }
			set
			{
				this.__host = value;
				this.__host.Register(this);
			}
		}

		// Implementiert die Aktivierung und Deaktivierung des Plugins
		private bool __isActive = false;

		public bool IsActive
		{
			get { return this.__isActive; }
			set {
				this.__isActive = value;
				this.Info.Active = this.__isActive;
			}
		}

		public void Activate() {
			this.IsActive = true;
		}

		public void Deactivate() {
			this.IsActive = false;
		}
	}
}
