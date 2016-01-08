using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Component.PolarReader
{
    public class HandleRead
    {
        public static string Process(string request)
        {
            if (request.ToUpper() != "CM-READ")
                return "Unrecognized";
            //The DATA as follow (can happen multiple times): 
            //LastName,FirstName(20 bytes)
            //Country (3 bytes)
            //Age (3 bytes)
            // & is the separator for multiple data
            return "WILLIAMS,JOHN       USA021&DOE,JOHN            USA046&SMITH,MARY          CAN038&JOHNSON,TAYLOR      CAN015";
        }
    }
}
