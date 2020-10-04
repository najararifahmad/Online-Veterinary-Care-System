using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class InformationBAL
    {
        InformationDAL _dal = new InformationDAL();
        public Information GetInformation()
        {
            return _dal.GetInformation();
        }
        public ApiResponse AddUpdateInformation(Information information)
        {
            return _dal.AddUpdateInformation(information);
        }
    }
}
