using System;
using CadreManagement.WebApi.Models;
using TypeLite;
using TypeLite.Net4;

namespace CadreManagement.Web.Scripts
{
    public static class TypeScriptGenerationConfig
    {
        public static TypeScriptFluent SetupGeneration()
        {
            return TypeScript.Definitions()
                .ForLoadedAssemblies()
                .WithMemberFormatter((identifier) =>
                        Char.ToLower(identifier.Name[0]) + identifier.Name.Substring(1))
                .For(typeof(ViewModel<>).Assembly)
                .For(typeof(CadreManagement.Web.HyperMediaApi.HyperMediaCommand<>).Assembly);
        }
    }
}