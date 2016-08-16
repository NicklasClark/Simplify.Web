﻿using Simplify.DI;
using Simplify.Web.Modules;
using Simplify.Web.Modules.Data;
using Simplify.Web.Modules.Data.Html;

namespace Simplify.Web.Core.AccessorsBuilding
{
	/// <summary>
	/// Provides builder for ModulesAccessor objects
	/// </summary>
	public class ModulesAccessorBuilder : ViewAccessorBuilder
	{
		/// <summary>
		/// Builds the modules accessor properties.
		/// </summary>
		/// <param name="modulesAccessor">The modules accessor.</param>
		/// <param name="containerProvider">The DI container provider.</param>
		protected void BuildModulesAccessorProperties(ModulesAccessor modulesAccessor, IDIContainerProvider containerProvider)
		{
			BuildViewAccessorProperties(modulesAccessor, containerProvider);

			modulesAccessor.Environment = containerProvider.Resolve<IEnvironment>();

			var stringTable = containerProvider.Resolve<IStringTable>();
			modulesAccessor.StringTable = stringTable.Items;
			modulesAccessor.StringTableManager = stringTable;

			modulesAccessor.TemplateFactory = containerProvider.Resolve<ITemplateFactory>();

			var htmlWrapper = new HtmlWrapper
			{
				MessageBox = containerProvider.Resolve<IMessageBox>(),
				ListsGenerator = containerProvider.Resolve<IListsGenerator>()
			};

			modulesAccessor.Html = htmlWrapper;
		}
	}
}