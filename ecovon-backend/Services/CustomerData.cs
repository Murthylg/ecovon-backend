using ecovon_backend.Entities;
using Microsoft.EntityFrameworkCore;
using ReflectionIT.Mvc.Paging;
using System.Collections.Generic;
using System.Linq;

namespace ecovon_backend.Services
{
    public interface ICustomerData
    {
        IEnumerable<Customer> GetAll(int page = 1);
        Customer Get(int id);
        Customer Add(Customer newCustomer);
        void Commit();
    }
    public class SqlICustomerData : ICustomerData
    {
        private ecovondbcontext _context;

        public SqlICustomerData(ecovondbcontext context)
        {
            _context = context;
        }

        public Customer Add(Customer newCustomer)
        {
            _context.Add(newCustomer);
            return newCustomer;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public Customer Get(int id)
        {
            return _context.Customer.FirstOrDefault(r => r.CustomerId == id);                 
        }

        public IEnumerable<Customer> GetAll(int page = 1)
        {
            //var qry = _context.Customer.AsNoTracking().OrderBy(p => p.Name);
            //var model = PagingList.CreateAsync(qry, 10, page);
            //return model;

            return _context.Customer;
        }
    }    
}
