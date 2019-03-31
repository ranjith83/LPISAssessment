using LPIS_Assessment.Helpers;
using LPIS_Assessment.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPIS_Assessment
{
    public class ReInsuranceDB
    {
        //Singleton Pattern Implementation
        private static ReInsuranceDB instance = new ReInsuranceDB();
        private static readonly object padlock = new object();

        ReInsuranceDB()
        {
        }

        public static ReInsuranceDB Instance
        {
            get
            {
                lock (padlock)
                {
                    return new ReInsuranceDB();
                }
            }
        }
        /// <summary>
        /// Event DB copied from the requirement
        /// </summary>
        public int[][] Events
        {
            get
            {

                return new[]{
                    new []{ 1, (int)Peril.Earthquake,(int)Region.California,1000},
                    new []{ 2, (int)Peril.Flood, (int)Region.Louisania, 500},
                    new []{ 3, (int)Peril.Flood, (int)Region.Florida, 750},
                    new []{ 4, (int)Peril.Hurricane, (int)Region.Florida, 2000},
                };
            }
        }

        /// <summary>
        /// Deal DB created based on the requirement
        /// - Deal 1 covers California earthquake, and is 500x100
        /// - Deal 2 covers Florida hurricane, and is 3000x1000
        /// - Deal 3 covers Florida and Louisiana for both hurricane and flood and is 250x250
        /// </summary>
        public List<DealModel> DealDB
        {
            get
            {
                return new List<DealModel>(){
                    new DealModel(){ dealId= 1, retention =100,limit = 500,peril = (int)Peril.Earthquake,region=(int)Region.California},
                    new DealModel(){ dealId= 2,retention = 1000,limit= 3000,peril =(int)Peril.Hurricane,region=(int)Region.Florida},
                    new DealModel(){dealId =3, retention = 250, limit=250,peril = (int)Peril.Hurricane, region=(int)Region.Florida },
                    new DealModel(){dealId =3,retention= 250,limit= 250,peril= (int)Peril.Flood, region=(int)Region.Louisania},
                    new DealModel(){dealId =3,retention= 250,limit= 250,peril= (int)Peril.Flood, region=(int)Region.Florida},
                    new DealModel(){dealId =3,retention= 250,limit= 250,peril= (int)Peril.Earthquake, region=(int)Region.Louisania},
                };
            }
        }

    }
}
