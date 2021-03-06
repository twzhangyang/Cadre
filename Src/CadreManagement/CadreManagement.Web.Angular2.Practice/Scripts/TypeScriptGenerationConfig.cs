﻿using System;
using CadreManagement.Web.HyperMediaApi;
using CadreManagement.WebApi;
using TypeLite;
using TypeLite.Net4;

namespace CadreManagement.Web.Angular2.Practice.Scripts
{
    public static class TypeScriptGenerationConfig
    {
        public static TypeScriptFluent SetupGeneration()
        {
            return TypeScript.Definitions()
                .ForLoadedAssemblies()
                .WithMemberFormatter((identifier) =>
                        Char.ToLower(identifier.Name[0]) + identifier.Name.Substring(1))
                .For(typeof(CadreApiNavigator).Assembly)
                .For(typeof(HyperMediaCommand<>).Assembly);
        }
    }
}