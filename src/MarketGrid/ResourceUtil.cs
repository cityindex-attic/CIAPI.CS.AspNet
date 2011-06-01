using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CIAPI.AspNet.MarketGrid
{
	public static class ResourceUtil
	{
		public static string ReadText(Type type, string name)
		{
			var asm = type.Assembly;
			using (var stream = asm.GetManifestResourceStream(type, name))
			{
				if (stream == null)
					throw new ApplicationException("Resource not found: " + name);
				using (var reader = new StreamReader(stream))
				{
					var text = reader.ReadToEnd();
					return text;
				}
			}
		}
	}
}
