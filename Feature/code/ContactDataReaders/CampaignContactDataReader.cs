using System.Linq;
using Sitecore.Configuration;
using Sitecore.Data;
using Sitecore.Diagnostics;
using Sitecore.EmailCampaign.Model.XConnect.Events;
using Sitecore.ListManagement.XConnect.Web.Export;
using Sitecore.XConnect;
using Sitecore.XConnect.Client;
using Sitecore.XConnect.Client.Configuration;

namespace Feature.Listmanager.ContactDataReaders
{
    public class CampaignContactDataReader : IContactDataReader
    {
        public string FacetName => "Personal";

        /// <summary></summary>
        public string Map(Contact contact)
        {
            using (var client = SitecoreXConnectClientConfiguration.GetClient())
            {
                var result = "";
                Interaction interaction = null;

                try
                {
                    // retrieves all Email Sent Events for contact - desc order
                    var queryable = client.Interactions.Where(x => x.Contact.Id == contact.Id
                                                                   && x.Events.OfType<EmailSentEvent>()
                                                                       .Any())
                        .OrderByDescending(x => x.StartDateTime);

                    var enumerable = queryable.GetBatchEnumeratorSync(20);

                    // iterate until finds latest interaction on contact
                    while (enumerable.MoveNext())
                    {
                        var interactionBatch = enumerable.Current; // Batch of <= 20 interactions

                        interaction = interactionBatch.First(x => x.Events?.FirstOrDefault() != null);

                        if (interaction?.CampaignId == null)
                        {
                            continue;
                        }

                        // retrieves campaign display name
                        result = Factory.GetDatabase("master")
                                     .GetItem(new ID(interaction.CampaignId.Value))
                                     .DisplayName;

                        break;
                    }
                }
                catch (XdbExecutionException ex)
                {
                    Log.Error(ex.Message,
                        ex,
                        this);
                }

                return result;
            }
        }
    }
}