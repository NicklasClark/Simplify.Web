﻿using Simplify.DI;

namespace Simplify.Web.Core.PageAssembly
{
	/// <summary>
	/// Represent context variables setter
	/// </summary>
	public interface IContextVariablesSetter
	{
		/// <summary>
		/// Sets the context variables to data collector
		/// </summary>
		/// <param name="containerProvider">The DI container provider.</param>
		void SetVariables(IDIContainerProvider containerProvider);
	}
}