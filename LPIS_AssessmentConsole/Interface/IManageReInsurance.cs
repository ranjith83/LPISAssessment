using LPIS_Assessment.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPIS_Assessment
{
    interface IReInsuranceTemplate
    {

        IEnumerable<int[]> GetEventsFromDB();

        List<DealModel> GetDealsFromDB();
    }

    interface IReInsuranceBuilder
    {
        IEnumerable<int[]> GetAllEvents();
        Tuple<int, int> GetEventDetails(int[] eventList);
        IEnumerable<Tuple<int, int, int>> GetDealDetail(int peril, int region);

        int ExecuteLoss(int eventLoss, int retention, int limit);

        string ConstructMessage(int eventId, int dealId, int loss, int? dealCount, bool isFirst);

        StringBuilder GettDealInfo(IEnumerable<Tuple<int, int, int>> dealDetails, int eventId, int eventLoss, int? dealCount);
        
    }
}
