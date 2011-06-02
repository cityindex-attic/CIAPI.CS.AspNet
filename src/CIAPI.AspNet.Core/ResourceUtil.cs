using System;
using System.IO;

namespace CIAPI.AspNet.Core
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
