﻿using System;
using System.Threading.Tasks;
using AcspNet.Bootstrapper;
using AcspNet.Diagnostics;
using DryIoc;
using Microsoft.Owin;

namespace AcspNet.Owin
{
	/// <summary>
	/// AcspNet engine root
	/// </summary>
	public class AcspNetOwinMiddleware : OwinMiddleware
	{
		private readonly BaseAcspNetBootstrapper _bootstrapper = BootstrapperFactory.CreateBootstrapper();

		/// <summary>
		/// Initializes a new instance of the <see cref="AcspNetOwinMiddleware"/> class.
		/// </summary>
		/// <param name="next"></param>
		public AcspNetOwinMiddleware(OwinMiddleware next)
			: base(next)
		{
		}

		/// <summary>
		/// Process an individual request.
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public override Task Invoke(IOwinContext context)
		{
			try
			{
				var request = _bootstrapper.Resolve<IRequestHandler>();
				request.ProcessRequest(context);
			}
			catch (Exception e)
			{
				return context.Response.WriteAsync(ExceptionInfoPageGenerator.Generate(e));
			}

			return Task.Delay(0);
		}
	}
}