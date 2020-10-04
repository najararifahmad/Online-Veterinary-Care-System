using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class InformationDAL
    {
        VCDbContext _context = new VCDbContext();
        public Information GetInformation()
        {
            return _context.Information.FirstOrDefault();
        }
        public ApiResponse AddUpdateInformation(Information information)
        {
            try
            {
                var _information = _context.Information.FirstOrDefault();
                if(_information != null)
                {
                    _information.Vaccination = information.Vaccination;
                    _information.FertilityManagement = information.FertilityManagement;
                    _information.HygenicMilk = information.HygenicMilk;
                    _information.InformationDissemination = information.InformationDissemination;
                    _context.SaveChanges();
                    return new ApiResponse
                    {
                        Added = true,
                        Message = "Saved successfully."
                    };
                }

                _context.Information.Add(information);
                _context.SaveChanges();
                return new ApiResponse
                {
                    Added = true,
                    Message = "Saved successfully."
                };
            }
            catch (Exception)
            {
                return new ApiResponse
                {
                    Added = false,
                    Message = "Error occured. Please try again..."
                };
            }
        }
    }
}
