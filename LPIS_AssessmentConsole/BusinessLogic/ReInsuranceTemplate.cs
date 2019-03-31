using LPIS_Assessment.Helpers;
using LPIS_Assessment.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPIS_Assessment.BusinessLogic
{
    public abstract class ReInsuranceTemplate : IReInsuranceTemplate
    {
        public IEnumerable<int[]> GetEventsFromDB()
        {
            return ReInsuranceDB.Instance.Events;
        }

        public List<DealModel> GetDealsFromDB()
        {
            return ReInsuranceDB.Instance.DealDB;
        }

    }
}
