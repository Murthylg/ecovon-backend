using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ecovon_backend.Entities;
using ecovon_backend.Entities.Vendors;
using Microsoft.EntityFrameworkCore;

namespace ecovon_backend.Services
{
    public interface IVendorData
    {
        Vendor Add(Vendor model);
        IEnumerable<Vendor> GetAll();
        void Commit();
        Vendor Get(int id);
    }
    public class SqlIVendorData : IVendorData
    {
        private ecovondbcontext _Context;

        public SqlIVendorData(ecovondbcontext context)
        {
            _Context = context;
        }

        public Vendor Add(Vendor model)
        {
            _Context.Add(model);
            return model;
        }

        public void Commit()
        {
            _Context.SaveChanges();
        }

        public Vendor Get(int id)
        {
            return _Context.Vendor.FirstOrDefault(r => r.VendorId == id);
        }

        public IEnumerable<Vendor> GetAll()
        {
            return _Context.Vendor.AsNoTracking().Include(c => c.VendorTypeOfWorkDetails);
        }
    }

    
}
