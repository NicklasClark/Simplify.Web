using System.IO;

namespace Simplify.Web.ModelBinding.Binders.Multipart
{
	/// <summary>
	/// Provides access to individual files that have been uploaded by a client.
	/// </summary>
	public class HttpFile
	{
		/// <summary>
		/// Gets the fully qualified name of the file.
		/// </summary>
		public string Name { get; private set; }

		/// <summary>
		/// Gets the MIME content type of a file.
		/// </summary>
		public string ContentType { get; private set; }

		/// <summary>
		/// Gets the size of a file, in bytes.
		/// </summary>
		public string ContentLength { get; private set; }

		/// <summary>
		/// Gets a Stream object that points to an uploaded file to prepare for reading the contents of the file.
		/// </summary>
		public Stream Data { get; private set; }
	}
}