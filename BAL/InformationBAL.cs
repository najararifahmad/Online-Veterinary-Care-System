using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
        public ApiResponse AddInformationDissemination(InformationDissemination id)
        {
            return _dal.AddInformationDissemination(id);
        }

        public IEnumerable<InformationDissemination> GetInformationDisseminations()
        {
            return _dal.GetInformationDisseminations();
        }
        public MemoryStream DownloadVaccination()
        {
            return _dal.DownloadVaccination();
        }
        public MemoryStream DownloadFertilityManagement()
        {
            return _dal.DownloadFertilityManagement();
        }
        public MemoryStream DownloadHygenicMilk()
        {
            return _dal.DownloadHygenicMilk();
        }
    }
}
