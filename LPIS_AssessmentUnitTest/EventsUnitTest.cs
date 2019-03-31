using System;
using LPIS_Assessment.BusinessLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace LPIS_AssessmentUnitTest
{
    [TestClass]
    public class EventsUnitTest
    {
        [TestMethod]
        public void GetEventDetails_Test()
        {
            ReInsuranceTemplate reInsuranceTemplate = new ReInsuranceBuilder();
            var eventsDB = reInsuranceTemplate.GetEventsFromDB();
            
            Assert.IsTrue(eventsDB.Count() > 1);
        }

        [TestMethod]
        public void GetDealDetails_Test()
        {
            ReInsuranceTemplate reInsuranceTemplate = new ReInsuranceBuilder();
            var dealsDB = reInsuranceTemplate.GetDealsFromDB();

            Assert.IsTrue(dealsDB.Count() > 1);
        }

        [TestMethod]
        public void ExecuteLoss_Test_Limit()
        {
            ReInsuranceBuilder reInsuranceTemplate = new ReInsuranceBuilder();
            int eventLoss = 1000;
            int retention = 500;
            int limit = 100;

            var loss = reInsuranceTemplate.ExecuteLoss(eventLoss,retention,limit);

            Assert.AreEqual(loss, limit);
        }


        [TestMethod]
        public void ExecuteLoss_Test_Retention()
        {
            ReInsuranceBuilder reInsuranceTemplate = new ReInsuranceBuilder();
            int eventLoss = 2000;
            int retention = 1000;
            int limit = 3000;

            var loss = reInsuranceTemplate.ExecuteLoss(eventLoss, retention, limit);

            Assert.AreEqual(loss, retention);
        }

        [TestMethod]
        public void GetDealDetail_Test_Positive()
        {
            ReInsuranceBuilder reInsuranceTemplate = new ReInsuranceBuilder();
            int peril = 1;
            int region = 3;

            var deal = reInsuranceTemplate.GetDealDetail(peril, region);

            Assert.IsTrue(deal.Count() == 2);
        }

        [TestMethod]
        public void GetDealDetail_Test_Negative()
        {
            ReInsuranceBuilder reInsuranceTemplate = new ReInsuranceBuilder();
            int peril = 4;
            int region = 4;

            var deal = reInsuranceTemplate.GetDealDetail(peril, region);

            Assert.IsNull(deal.GetEnumerator().Current);
        }

        [TestMethod]
        public void ConstructMessage_Test()
        {
            ReInsuranceBuilder reInsuranceTemplate = new ReInsuranceBuilder();
            int eventId = 1;
            int dealId = 2;
            int loss = 1000;
            int? dealCount = 1;
            bool isFirst = true;
            string message = "Event 1 only  affects deal 2 and the reinsurance company's loss is 1000";

            var returnMessage = reInsuranceTemplate.ConstructMessage(eventId, dealId,loss,dealCount, isFirst);

            Assert.AreEqual(String.Compare(returnMessage, message), 0);
        }
    }
}
