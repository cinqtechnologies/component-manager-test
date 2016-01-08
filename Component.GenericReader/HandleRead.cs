using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Component.GenericReader
{
    public class HandleRead
    {
        public static string Process(string request)
        {
            if (request.ToUpper() != "READDATA")
                return "Unrecognized";
            //First 4 characters indicates length of message in hex
            //Next 4 characters indicates component status
            //Next 8 characters for date
            //Next characters are the DATA as follow: 
            //FirstName/LastName/Country/Age (can happen multiple times)
            // | is the separator for multiple data
            return "0047021520160101JOHN/WILLIAMS/USA/21|JOHN/DOE/USA/46|MARY/SMITH/CAN/38|TAYLOR/JOHNSON/CAN/13";
        }
    }
}
