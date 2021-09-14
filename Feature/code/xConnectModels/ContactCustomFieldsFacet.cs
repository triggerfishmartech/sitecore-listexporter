using Sitecore.XConnect;
using System.Collections.Generic;

namespace Feature.Listmanager.xConnectModels
{
    public class ContactCustomFieldsFacet : Facet
    {
        public const string DefaultFacetKey = "ContactCustomFields";
        public Dictionary<string, string> Fields { get; set; } = new Dictionary<string, string>();
    }
}