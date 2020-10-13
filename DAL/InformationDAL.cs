using DAL.Models;
using System;
using System.Collections.Generic;
using System.IO;
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

        public ApiResponse AddInformationDissemination(InformationDissemination id)
        {
            try
            {
                id.AddedOn = DateTime.Now;
                _context.InformationDisseminations.Add(id);
                _context.SaveChanges();
                return new ApiResponse
                {
                    Added = true,
                    Message = "Information Dissemination added successfully."
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

        public IEnumerable<InformationDissemination> GetInformationDisseminations()
        {
            return _context.InformationDisseminations.OrderByDescending(i => i.AddedOn).ToList();
        }

        public MemoryStream DownloadVaccination()
        {

            var information = _context.Information.FirstOrDefault();

            if (information != null)
            {

                byte[] bytes = Encoding.UTF8.GetBytes(information.Vaccination);

                MemoryStream stream = new MemoryStream();

                stream.Write(bytes, 0, bytes.Length);


                return stream;
            }
            return null;
        }
        public MemoryStream DownloadFertilityManagement()
        {

            var information = _context.Information.FirstOrDefault();

            if (information != null)
            {

                byte[] bytes = Encoding.UTF8.GetBytes(information.FertilityManagement);

                MemoryStream stream = new MemoryStream();

                stream.Write(bytes, 0, bytes.Length);


                return stream;
            }
            return null;
        }
        public MemoryStream DownloadHygenicMilk()
        {

            var information = _context.Information.FirstOrDefault();

            if (information != null)
            {

                byte[] bytes = Encoding.UTF8.GetBytes(information.HygenicMilk);

                MemoryStream stream = new MemoryStream();

                stream.Write(bytes, 0, bytes.Length);


                return stream;
            }
            return null;
        }
    }
}
