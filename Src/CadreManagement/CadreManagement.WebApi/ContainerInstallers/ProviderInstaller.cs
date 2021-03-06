﻿using CadreManagement.WebApi.Models;
using CadreManagement.WebApi.Models.Product;
using CadreManagement.WebApi.Providers;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace CadreManagement.WebApi.ContainerInstallers
{
    public class ProviderInstaller:IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<ProductProvider>().ImplementedBy<ProductProvider>().LifestylePerWebRequest());
        }
    }
}