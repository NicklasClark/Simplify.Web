using System.IO;

namespace Simplify.Web.ModelBinding.Binders.Multipart
{
	/// <summary>
	/// Provides access to individual files that have been uploaded by a client.
	/// </summary>
	public class HttpFile
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="HttpFile" /> class.
		/// </summary>
		/// <param name="name">The file name.</param>
		/// <param name="contentType">Type of the content.</param>
		/// <param name="contentLength">Length of the content.</param>
		/// <param name="data">The file data.</param>
		public HttpFile(string name, string contentType, string contentLength, Stream data)
		{
			Name = name;
			ContentType = contentType;
			ContentLength = contentLength;
			Data = data;
		}

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