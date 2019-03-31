using System;
using System.Linq;
using System.Text;
using LPIS_Assessment.Helpers;

namespace LPIS_Assessment.BusinessLogic
{
    public class ReInsuranceCreator
    {
        /// <summary>
        /// Get Company Loss for all events
        /// </summary>
        /// <returns></returns>
        public string CalculateCompanyLoss()
        {
            StringBuilder messageBuilder = new StringBuilder();
            IReInsuranceBuilder reInsuranceBuilder = new ReInsuranceBuilder();

            try
            {
                //Get all events from DB
                var eventsDB = reInsuranceBuilder.GetAllEvents();

                foreach (int[] arrEvent in eventsDB)
                {
                    int eventId = arrEvent[(int)EventArrayPosition.Id];
                    int eventLoss = arrEvent[(int)EventArrayPosition.Loss];

                    var eventDetails = reInsuranceBuilder.GetEventDetails(arrEvent);
                    if (eventDetails != null)
                    {
                        var dealDetails = reInsuranceBuilder.GetDealDetail(eventDetails.Item1, eventDetails.Item2);
                        int? dealCount = dealDetails?.Count();

                        if (dealDetails != null)
                        {
                            var buildMsg = reInsuranceBuilder.GettDealInfo(dealDetails, eventId, eventLoss, dealCount);
                            messageBuilder.Append(buildMsg);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return messageBuilder.ToString();
        }
    }
}
