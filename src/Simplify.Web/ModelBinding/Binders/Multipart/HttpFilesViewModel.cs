using System.Collections.Generic;

namespace Simplify.Web.ModelBinding.Binders.Multipart
{
	/// <summary>
	/// Provides HTTP files view model
	/// </summary>
	public class HttpFilesViewModel
	{
		/// <summary>
		/// Gets the list of HTTP files.
		/// </summary>
		public IList<HttpFile> Files { get; private set; } = new List<HttpFile>();
	}
}