using System;

namespace Simplify.Web.ModelBinding.Binders.Multipart
{
	/// <summary>
	/// Provides form multipart data to object binding
	/// </summary>
	/// <seealso cref="IModelBinder" />
	public class HttpMultipartFormModelBinder : IModelBinder
	{
		/// <summary>
		/// Binds the model.
		/// </summary>
		/// <typeparam name="T">Model type</typeparam>
		/// <param name="args">The <see cref="ModelBinderEventArgs{T}" /> instance containing the event data.</param>
		public void Bind<T>(ModelBinderEventArgs<T> args)
		{
			if (args.Context.Request.ContentType.Contains("multipart/form-data"))
			{
			}

			throw new NotImplementedException();
		}
	}
}