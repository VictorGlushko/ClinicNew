﻿
[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Clinic.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Clinic.App_Start.NinjectWebCommon), "Stop")]



namespace Clinic.App_Start
{
    using Clinic.Core;
    using Clinic.Persistence;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;
    using System;
    using System.Web;


    public static class NinjectWebCommon
    {
    private static readonly Bootstrapper bootstrapper = new Bootstrapper();

    public static void Start()
    {
        DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
        DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
        bootstrapper.Initialize(CreateKernel);
    }

    public static void Stop()
    {
        bootstrapper.ShutDown();
    }

    private static IKernel CreateKernel()
    {
        var kernel = new StandardKernel();
        kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
        kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

        RegisterServices(kernel);

        return kernel;
    }
    private static void RegisterServices(IKernel kernel)
    {
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>();
    }
}
}