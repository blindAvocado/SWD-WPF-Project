using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Entities;
using SWD_WPF_Project.Models;


namespace SWD_WPF_Project.Services
{
    public class DistrictService
    {
        DeliveryDBContext db;

        public DistrictService()
        {
            db = new DeliveryDBContext();
        }

        public List<DistrictModel> GetAllDistricts()
        {
            return db.Districts.AsEnumerable().Select(d => new DistrictModel(d)).ToList();
        }

        public string GetDistrictNameByID(int id)
        {
            return db.Districts.Where(i => i.id_district == id).Select(i => i.name_district).SingleOrDefault();
        }
    }
}
