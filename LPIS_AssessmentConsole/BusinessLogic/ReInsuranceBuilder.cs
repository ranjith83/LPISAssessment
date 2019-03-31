using LPIS_Assessment.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPIS_Assessment.BusinessLogic
{
    public class ReInsuranceBuilder : ReInsuranceTemplate, IReInsuranceBuilder
    {
        public const string REINSURANCE_OUTPUT = "Event {0}{1} affects deal {2} and the reinsurance company's loss is {3}";

        /// <summary>
        /// GetAllEvents - All events from DB
        /// </summary>
        /// <returns></returns>
        public IEnumerable<int[]> GetAllEvents()
        {
            return  base.GetEventsFromDB();
        }

        /// <summary>
        /// GetEventDetails return Peril and Region from the events
        /// </summary>
        /// <param name="eventList"></param>
        /// <returns></returns>
        public Tuple<int, int> GetEventDetails(int[] eventList)
        {
            return new Tuple<int, int>(eventList[(int)EventArrayPosition.Peril], eventList[(int)EventArrayPosition.Region]);
        }

        /// <summary>
        /// GetDealDetails Read DealDB and matched the record which exists with peril and region
        /// </summary>
        /// <param name="peril"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        public IEnumerable<Tuple<int, int, int>> GetDealDetail(int peril, int region)
        {
            var dealDetails = base.GetDealsFromDB();

            var dealDb = dealDetails.FindAll(x => x.peril == peril && x.region == region);

            foreach (var deal in dealDb)
            {
                yield return new Tuple<int, int, int>(deal.dealId, deal.limit, deal.retention);
            }

        }

        /// <summary>
        /// ExecuteLoss - formula to find the loss
        /// </summary>
        /// <param name="eventLoss"></param>
        /// <param name="retention"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public int ExecuteLoss(int eventLoss, int retention, int limit)
        {
            int reinnsuranceLoss = (eventLoss <= limit) ? retention : limit;
            return reinnsuranceLoss;
        }

        /// <summary>
        /// ConstructMessage - forms the message as per requirement
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="dealId"></param>
        /// <param name="loss"></param>
        /// <param name="dealCount"></param>
        /// <param name="isFirst"></param>
        /// <returns></returns>
        public string ConstructMessage(int eventId, int dealId, int loss, int? dealCount, bool isFirst)
        {
            var onlyOrAlso = (dealCount == 1) ? " only " : (!isFirst) ? " also " : String.Empty;

            return String.Format(REINSURANCE_OUTPUT, eventId, onlyOrAlso, dealId, loss);
        }

        /// <summary>
        /// GettDealInfo - Parse the Deal data and get execute loss and format the message
        /// </summary>
        /// <param name="dealDetails"></param>
        /// <param name="eventId"></param>
        /// <param name="eventLoss"></param>
        /// <param name="dealCount"></param>
        /// <returns></returns>
        public StringBuilder GettDealInfo(IEnumerable<Tuple<int, int, int>> dealDetails, int eventId, int eventLoss, int? dealCount)
        {
            StringBuilder messageBuilder = new StringBuilder();

            foreach (var deal in dealDetails)
            {
                int dealId = deal.Item1;
                int retention = deal.Item3;
                int limit = deal.Item2;
                bool isFirst = dealDetails.First().Equals(deal);

                var loss = ExecuteLoss(eventLoss, retention, limit);

                messageBuilder.AppendLine(ConstructMessage(eventId, dealId, loss, dealCount, isFirst));
            }

            return messageBuilder;
        }
    }
}
