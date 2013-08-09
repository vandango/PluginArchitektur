using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using PluginLib;

namespace PluginSystem
{
	public class PluginLoader
	{
		public static PluginInfo GetPluginInfo(string fileName)
		{
			BasePlugin obj = LoadPlugin(fileName, null);

			PluginInfo info = new PluginInfo();

			if(obj is IPlugin)
			{
				info = ((IPlugin)obj).Info;
			}
			else
			{
				throw new NotImplementedException(
					string.Format(
						"The type {0} is not implemented in file {1}.",
						fileName,
						typeof(BasePlugin).ToString()
					)
				);
			}

			return info;
		}

		public static BasePlugin LoadPlugin(string filename, IPluginHost host)
		{
			if(filename == null)
			{
				throw new ArgumentNullException("filename", "The parameter filename cannot be null.");
			}

			Assembly plugin = Assembly.LoadFrom(filename);
			string typeName = typeof(BasePlugin).ToString();

			Type[] types = plugin.GetTypes();
			List<Type> mytype = new List<Type>();

			bool typeFound = false;

			foreach(Type t in types)
			{
				if(t.BaseType != null
				&& t.BaseType.FullName == typeName)
				{
					mytype.Add(t);
					typeFound = true;
				}
			}

			if(!typeFound)
			{
				throw new NotImplementedException(
					string.Format(
						"The type {0} is not implemented in file {1}.",
						filename,
						typeName
					)
				);
			}

			List<BasePlugin> result = new List<BasePlugin>();

			foreach(Type type in mytype)
			{
				object obj = Activator.CreateInstance(type);
				result.Add((BasePlugin)obj);
			}

			if(result != null
			&& result.Count > 0)
			{
				if(host != null)
				{
					result[0].Host = host;
				}

				return result[0];
			}

			return null;
		}
	}
}
