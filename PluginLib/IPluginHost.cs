using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PluginLib
{
	public interface IPluginHost
	{
		// Implementiert eine Funnktion zum registrieren des Plugins
		bool Register(IPlugin ipi);
	}
}
