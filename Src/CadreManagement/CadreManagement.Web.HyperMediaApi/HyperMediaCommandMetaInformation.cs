using System;
using System.Diagnostics.Contracts;
using CadreManagement.Core.Extensions;
using TypeLite;

namespace CadreManagement.Web.HyperMediaApi
{
    [TsClass]
    public class HyperMediaCommandMetaInformation
    {
        [Obsolete("For serialization",error:true)]
        public HyperMediaCommandMetaInformation()
        {
        }

        public HyperMediaCommandMetaInformation(string commandClasses, bool isAvailable = true, string name = "", string description = "", string confirmExecutionQuestion = "", string reasonForBeingUnavailable = "", string webPageUrl = "")            
        {
            Contract.Requires(!commandClasses.IsNullOrEmpty());

            CommandClasses = commandClasses;
            IsAvailable = isAvailable;
            Name = name;
            Description = description;
            ConfirmExecutionQuestion = confirmExecutionQuestion;
            ReasonForBeingUnavailable = reasonForBeingUnavailable;
            WebPageUrl = webPageUrl;
        }

        public string CommandClasses { get; set; }
        public bool IsAvailable { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ConfirmExecutionQuestion { get; set; }
        public string ReasonForBeingUnavailable { get; set; }
        public string HoverMessage { get { return IsAvailable ? Description : ReasonForBeingUnavailable; } }
        public string WebPageUrl { get; set; }
    }
}