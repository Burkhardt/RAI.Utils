using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace RaiUtilsCore
{
	public class ParameterDictionary : StringDictionary
	{
		/// <summary>
		/// Initialize with all lowercase items of the paramArray
		/// </summary>
		/// <param name="paramArray"></param>
		public ParameterDictionary(NameValueCollection paramArray)
		{
			foreach (string key in paramArray.AllKeys)
			{
				if (char.IsLower(key[0]))
					Add(key, paramArray[key]);
			}
		}
	}
}