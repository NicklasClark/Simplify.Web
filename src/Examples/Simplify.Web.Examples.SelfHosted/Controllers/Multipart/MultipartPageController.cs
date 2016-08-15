using Simplify.Web.Attributes;
using Simplify.Web.Responses;

namespace Simplify.Web.Examples.SelfHosted.Controllers.Multipart
{
	[Get("multipart")]
	public class MultipartPageController : Controller
	{
		public override ControllerResponse Invoke()
		{
			return new StaticTpl("Multipart/Page");
		}
	}
}