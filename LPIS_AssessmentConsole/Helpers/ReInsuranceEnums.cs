using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPIS_Assessment.Helpers
{
    enum Region
    {
        California = 1,
        Louisania = 2,
        Florida = 3
    }

    enum Peril
    {
        Hurricane =1,
        Earthquake = 2,
        Flood = 3
    }

    enum EventArrayPosition
    {
        Id = 0,
        Peril = 1,
        Region = 2,
        Loss = 3
    }
}
