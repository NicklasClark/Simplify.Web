﻿using System;
using AcspNet.Core;
using AcspNet.Meta;
using AcspNet.Modules;
using AcspNet.Routing;
using Simplify.DI;
using Environment = AcspNet.Modules.Environment;

namespace AcspNet.Bootstrapper
{
	/// <summary>
	/// Base and default AcspNet bootstrapper
	/// </summary>
	public class BaseAcspNetBootstrapper
	{
		private Type _acspNetSettingsType;
		private Type _viewFactoryType;
		private Type _controllerFactoryType;
		private Type _controllerPathParserType;
		private Type _routeMatcherType;
		private Type _controllersAgentType;
		private Type _controllerResponseBuilderType;
		private Type _controllerResponseHandlerType;
		private Type _controllersHanderType;
		private Type _pageBuilderType;
		private Type _responseWriterType;
		private Type _requestHandlerType;
		private Type _stopwatchProviderType;
		private Type _contextVariablesSetterType;
		private Type _acspNetContextProviderType;

		/// <summary>
		/// Registers the types in container.
		/// </summary>
		public void Register()
		{
			// Registering AcspNet core types

			RegisterControllersMetaStore();
			RegisterViewsMetaStore();

			RegisterAcspNetSettings();
			RegisterViewFactory();
			RegisterControllerFactory();
			RegisterControllerPathParser();
			RegisterRouteMatcher();
			RegisterControllersAgent();
			RegisterControllerResponseBuilder();
			RegisterControllerResponseHandler();
			RegisterControllersHandler();
			RegisterEnvironment();
			RegisterLanguageManagerProvider();
			RegisterTemplateFactory();
			RegisterFileReader();
			RegisterStringTable();
			RegisterDataCollector();
			RegisterPageBuilder();
			RegisterResponseWriter();
			RegisterRequestHandler();
			RegisterStopwatchProvider();
			RegisterContextVariablesSetter();
			RegisterAcspNetContextProvider();

			// Registering controllers types
			foreach (var controllerMetaData in ControllersMetaStore.Current.ControllersMetaData)
				DIContainer.Current.Register(controllerMetaData.ControllerType, LifetimeType.Transient);

			// Registering views types
			foreach (var viewType in ViewsMetaStore.Current.ViewsTypes)
				DIContainer.Current.Register(viewType, LifetimeType.Transient);
		}

		#region Bootstrapper types

		/// <summary>
		/// Gets the type of the AcspNet settings.
		/// </summary>
		/// <value>
		/// The type of the AcspNet settings.
		/// </value>
		public Type AcspNetSettingsType
		{
			get { return _acspNetSettingsType ?? typeof(AcspNetSettings); }
		}

		/// <summary>
		/// Gets the type of the view factory.
		/// </summary>
		/// <value>
		/// The type of the view factory.
		/// </value>
		public Type ViewFactoryType
		{
			get { return _viewFactoryType ?? typeof(ViewFactory); }
		}

		/// <summary>
		/// Gets the type of the controller factory.
		/// </summary>
		/// <value>
		/// The type of the controller factory.
		/// </value>
		public Type ControllerFactoryType
		{
			get { return _controllerFactoryType ?? typeof(ControllerFactory); }
		}

		/// <summary>
		/// Gets the controller path parser.
		/// </summary>
		/// <value>
		/// The controller path parser.
		/// </value>
		public Type ControllerPathParser
		{
			get { return _controllerPathParserType ?? typeof(ControllerPathParser); }
		}

		/// <summary>
		/// Gets the type of the route matcher.
		/// </summary>
		/// <value>
		/// The type of the route matcher.
		/// </value>
		public Type RouteMatcherType
		{
			get { return _routeMatcherType ?? typeof(RouteMatcher); }
		}

		/// <summary>
		/// Gets the type of the controllers agent.
		/// </summary>
		/// <value>
		/// The type of the controllers agent.
		/// </value>
		public Type ControllersAgentType
		{
			get { return _controllersAgentType ?? typeof(ControllersAgent); }
		}

		/// <summary>
		/// Gets the type of the controller response builder.
		/// </summary>
		/// <value>
		/// The type of the controller response builder.
		/// </value>
		public Type ControllerResponseBuilderType
		{
			get { return _controllerResponseBuilderType ?? typeof(ControllerResponseBuilder); }
		}

		/// <summary>
		/// Gets the type of the controller response handler.
		/// </summary>
		/// <value>
		/// The type of the controller response handler.
		/// </value>
		public Type ControllerResponseHandlerType
		{
			get { return _controllerResponseHandlerType ?? typeof(ControllerResponseHandler); }
		}

		/// <summary>
		/// Gets the type of the controllers handler.
		/// </summary>
		/// <value>
		/// The type of the controllers handler.
		/// </value>
		public Type ControllersHandlerType
		{
			get { return _controllersHanderType ?? typeof(ControllersHandler); }
		}
		
		/// <summary>
		/// Gets the type of the page builder.
		/// </summary>
		/// <value>
		/// The type of the page builder.
		/// </value>
		public Type PageBuilderType
		{
			get { return _pageBuilderType ?? typeof(PageBuilder); }
		}
		
		/// <summary>
		/// Gets the type of the response writer.
		/// </summary>
		/// <value>
		/// The type of the response writer.
		/// </value>
		public Type ResponseWriterType
		{
			get { return _responseWriterType ?? typeof(ResponseWriter); }
		}

		/// <summary>
		/// Gets the type of the request handler.
		/// </summary>
		/// <value>
		/// The type of the request handler.
		/// </value>
		public Type RequestHandlerType
		{
			get { return _requestHandlerType ?? typeof(RequestHandler); }
		}

		/// <summary>
		/// Gets the type of the stopwatch provider.
		/// </summary>
		/// <value>
		/// The type of the stopwatch provider.
		/// </value>
		public Type StopwatchProviderType
		{
			get { return _stopwatchProviderType ?? typeof(StopwatchProvider); }
		}

		/// <summary>
		/// Gets the type of the context variables setter.
		/// </summary>
		/// <value>
		/// The type of the context variables setter.
		/// </value>
		public Type ContextVariablesSetterType
		{
			get { return _contextVariablesSetterType ?? typeof(ContextVariablesSetter); }
		}

		/// <summary>
		/// Gets the type of the AcspNet context provider.
		/// </summary>
		/// <value>
		/// The type of the AcspNet context provider.
		/// </value>
		public Type AcspNetContextProviderType
		{
			get { return _acspNetContextProviderType ?? typeof(AcspNetContextProvider); }
		}

		#endregion

		#region Bootstrapper types override

		/// <summary>
		/// Sets the type of the AcspNet settings.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		public void SetAcspNetSettingsType<T>()
			where T : IAcspNetSettings
		{
			_acspNetSettingsType = typeof(T);
		}

		/// <summary>
		/// Sets the type of the view factory.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		public void SetViewFactoryType<T>()
			where T : IViewFactory
		{
			_viewFactoryType = typeof(T);
		}

		/// <summary>
		/// Sets the type of the controller factory.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		public void SetControllerFactoryType<T>()
			where T : IControllerFactory
		{
			_controllerFactoryType = typeof(T);
		}

		/// <summary>
		/// Sets the type of the controller path parser.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		public void SetControllerPathParserType<T>()
		where T : IControllerPathParser
		{
			_controllerPathParserType = typeof(T);
		}

		/// <summary>
		/// Sets the type of the route matcher.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		public void SetRouteMatcherType<T>()
			where T : IRouteMatcher
		{
			_routeMatcherType = typeof(T);
		}

		/// <summary>
		/// Sets the type of the controllers agent.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		public void SetControllersAgentType<T>()
			where T : IControllersAgent
		{
			_controllersAgentType = typeof(T);
		}

		/// <summary>
		/// Sets the type of the controller response builder.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		public void SetControllerResponseBuilderType<T>()
			where T : IControllerResponseBuilder
		{
			_controllerResponseBuilderType = typeof(T);
		}

		/// <summary>
		/// Sets the type of the controller response handler.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		public void SetControllerResponseHandlerType<T>()
			where T : IControllerResponseHandler
		{
			_controllerResponseHandlerType = typeof(T);
		}

		/// <summary>
		/// Sets the type of the controllers handler.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		public void SetControllersHandlerType<T>()
			where T : IControllersHandler
		{
			_controllersHanderType = typeof(T);
		}
		
		/// <summary>
		/// Sets the page builder.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		public void SetPageBuilder<T>()
			where T : IPageBuilder
		{
			_pageBuilderType = typeof(T);
		}

		/// <summary>
		/// Sets the type of the response writer.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		public void SetResponseWriterType<T>()
			where T : IResponseWriter
		{
			_responseWriterType = typeof(T);
		}

		/// <summary>
		/// Sets the type of the request handler.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		public void SetRequestHandlerType<T>()
			where T : IRequestHandler
		{
			_requestHandlerType = typeof(T);
		}

		/// <summary>
		/// Sets the type of the stopwatch provider.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		public void SetStopwatchProviderType<T>()
			where T : IStopwatchProvider
		{
			_stopwatchProviderType = typeof(T);
		}

		/// <summary>
		/// Sets the type of the context variables setter.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		public void SetContextVariablesSetterType<T>()
			where T : IContextVariablesSetter
		{
			_contextVariablesSetterType = typeof(T);
		}

		/// <summary>
		/// Sets the AcspNet context provider.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		public void SetAcspNetContextProvider<T>()
			where T : IAcspNetContextProvider
		{
			_acspNetContextProviderType = typeof(T);
		}

		#endregion

		#region Bootstrapper types registration

		/// <summary>
		/// Registers the controllers meta store.
		/// </summary>
		public virtual void RegisterControllersMetaStore()
		{
			DIContainer.Current.Register(p => ControllersMetaStore.Current);
		}

		/// <summary>
		/// Registers the views meta store.
		/// </summary>
		public virtual void RegisterViewsMetaStore()
		{
			DIContainer.Current.Register(p => ViewsMetaStore.Current);
		}

		/// <summary>
		/// Registers the AcspNet settings.
		/// </summary>
		public virtual void RegisterAcspNetSettings()
		{
			DIContainer.Current.Register<IAcspNetSettings>(AcspNetSettingsType);
		}

		/// <summary>
		/// Registers the view factory.
		/// </summary>
		public virtual void RegisterViewFactory()
		{
			DIContainer.Current.Register<IViewFactory>(ViewFactoryType);
		}

		/// <summary>
		/// Registers the controller factory.
		/// </summary>
		public virtual void RegisterControllerFactory()
		{
			DIContainer.Current.Register<IControllerFactory>(ControllerFactoryType);
		}

		/// <summary>
		/// Registers the controller path parser.
		/// </summary>
		public virtual void RegisterControllerPathParser()
		{
			DIContainer.Current.Register<IControllerPathParser>(ControllerPathParser);
		}

		/// <summary>
		/// Registers the route matcher.
		/// </summary>
		public virtual void RegisterRouteMatcher()
		{
			DIContainer.Current.Register<IRouteMatcher>(RouteMatcherType);
		}

		/// <summary>
		/// Registers the controllers agent.
		/// </summary>
		public virtual void RegisterControllersAgent()
		{
			DIContainer.Current.Register<IControllersAgent>(ControllersAgentType);
		}

		/// <summary>
		/// Registers the controller response builder.
		/// </summary>
		public virtual void RegisterControllerResponseBuilder()
		{
			DIContainer.Current.Register<IControllerResponseBuilder>(ControllerResponseBuilderType);
		}

		/// <summary>
		/// Registers the controller response handler.
		/// </summary>
		public virtual void RegisterControllerResponseHandler()
		{
			DIContainer.Current.Register<IControllerResponseHandler>(ControllerResponseHandlerType);
		}

		/// <summary>
		/// Registers the controllers handler.
		/// </summary>
		public virtual void RegisterControllersHandler()
		{
			DIContainer.Current.Register<IControllersHandler>(ControllersHandlerType);
		}
		
		/// <summary>
		/// Registers the environment.
		/// </summary>
		public virtual void RegisterEnvironment()
		{
			DIContainer.Current.Register<IEnvironment>(
				p => new Environment(AppDomain.CurrentDomain.BaseDirectory, p.Resolve<IAcspNetSettings>()),
				LifetimeType.PerLifetimeScope);
		}

		/// <summary>
		/// Registers the language manager provider.
		/// </summary>
		public virtual void RegisterLanguageManagerProvider()
		{
			DIContainer.Current.Register<ILanguageManagerProvider>(p => new LanguageManagerProvider(p.Resolve<IAcspNetSettings>()), LifetimeType.PerLifetimeScope);
		}

		/// <summary>
		/// Registers the template factory.
		/// </summary>
		public virtual void RegisterTemplateFactory()
		{
			DIContainer.Current.Register<ITemplateFactory>(
				p =>
				{
					var settings = p.Resolve<IAcspNetSettings>();

					return new TemplateFactory(p.Resolve<IEnvironment>(), p.Resolve<ILanguageManagerProvider>().Get().Language, settings.DefaultLanguage, settings.TemplatesMemoryCache);
				}, LifetimeType.PerLifetimeScope);
		}
		
		/// <summary>
		/// Registers the file reader.
		/// </summary>
		public virtual void RegisterFileReader()
		{
			DIContainer.Current.Register<IFileReader>(
				p => new FileReader(p.Resolve<IEnvironment>().DataPhysicalPath, p.Resolve<IAcspNetSettings>().DefaultLanguage,
					p.Resolve<ILanguageManagerProvider>().Get().Language), LifetimeType.PerLifetimeScope);
		}

		/// <summary>
		/// Registers the string table.
		/// </summary>
		public virtual void RegisterStringTable()
		{
			DIContainer.Current.Register<IStringTable>(
				p =>
					new StringTable(p.Resolve<IAcspNetSettings>().DefaultLanguage, p.Resolve<ILanguageManagerProvider>().Get().Language,
						p.Resolve<IFileReader>()), LifetimeType.PerLifetimeScope);
		}

		/// <summary>
		/// Registers the data collector.
		/// </summary>
		public virtual void RegisterDataCollector()
		{
			DIContainer.Current.Register<IDataCollector>(p =>
			{
				var settings = p.Resolve<IAcspNetSettings>();

				return new DataCollector(settings.DefaultMainContentVariableName, settings.DefaultTitleVariableName, p.Resolve<IStringTable>());
			}, LifetimeType.PerLifetimeScope);
		}

		/// <summary>
		/// Registers the page builder.
		/// </summary>
		public virtual void RegisterPageBuilder()
		{
			DIContainer.Current.Register<IPageBuilder>(PageBuilderType, LifetimeType.PerLifetimeScope);
		}

		/// <summary>
		/// Registers the response writer.
		/// </summary>
		public virtual void RegisterResponseWriter()
		{
			DIContainer.Current.Register<IResponseWriter>(ResponseWriterType);
		}

		/// <summary>
		/// Registers the request handler.
		/// </summary>
		public virtual void RegisterRequestHandler()
		{
			DIContainer.Current.Register<IRequestHandler>(RequestHandlerType, LifetimeType.PerLifetimeScope);
		}

		/// <summary>
		/// Registers the stopwatch provider.
		/// </summary>
		public virtual void RegisterStopwatchProvider()
		{
			DIContainer.Current.Register<IStopwatchProvider>(StopwatchProviderType, LifetimeType.PerLifetimeScope);
		}

		/// <summary>
		/// Registers the context variables setter.
		/// </summary>
		public virtual void RegisterContextVariablesSetter()
		{
			DIContainer.Current.Register<IContextVariablesSetter>(ContextVariablesSetterType, LifetimeType.PerLifetimeScope);
		}

		/// <summary>
		/// Registers the AcspNet context provider.
		/// </summary>
		public virtual void RegisterAcspNetContextProvider()
		{
			DIContainer.Current.Register<IAcspNetContextProvider>(AcspNetContextProviderType, LifetimeType.PerLifetimeScope);
		}

		#endregion
	}
}