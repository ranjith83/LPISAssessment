using LPIS_Assessment.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPIS_AssessmentConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            ReInsuranceCreator reInsuranceTemplate = new ReInsuranceCreator();

            var message = reInsuranceTemplate.CalculateCompanyLoss();

            Console.WriteLine(message);
            Console.ReadLine();
        }
    }
}
