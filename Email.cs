using System.Text.RegularExpressions;

namespace RaiUtilsCore
{
	/// <summary>
	/// Validates strings
	/// </summary>
	public class Email
	{
		public Email(string address)
		{
			this.address = address;
		}
		private readonly string address;
		public override string ToString()
		{
			return address;
		}
		/// <summary>
		/// true, if the constructor parameter passed the syntactical validation for a valid email address
		/// </summary>
		public bool Valid
		{
			get
			{
				return Regex.IsMatch(address, @"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$",
											RegexOptions.None);
			}
		}
		/// <summary>
		/// true, if the constructor parameter did not pass the syntactical validation for a valid email address
		/// </summary>
		public bool Invalid
		{
			get { return !Valid; }
		}
	}
}
