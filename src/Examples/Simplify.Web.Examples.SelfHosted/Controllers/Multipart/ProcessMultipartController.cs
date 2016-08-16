using System;
using Simplify.Web.Attributes;
using Simplify.Web.ModelBinding.Binders.Multipart;

namespace Simplify.Web.Examples.SelfHosted.Controllers.Multipart
{
	[Post("multipart")]
	public class ProcessMultipartController : Controller<HttpFilesViewModel>
	{
		public override ControllerResponse Invoke()
		{
			//var file = Model.Files[0];
			throw new NotImplementedException();
		}
	}
}