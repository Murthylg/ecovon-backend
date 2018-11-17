using Microsoft.AspNetCore.Mvc;
using ecovon_backend.Services;
using ecovon_backend.Models;
using ecovon_backend.Entities;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ReflectionIT.Mvc.Paging;
using Microsoft.AspNetCore.Routing;

namespace ecovon_backend.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ecovondbcontext _context;
        private readonly ICustomerData _customerdata;

        public CustomerController(ICustomerData customerData, ecovondbcontext context)
        {
            _context = context;
            _customerdata = customerData;
        }
        public async Task<IActionResult> Index(string filter, int page = 1, string sortExpression = "Name")
        {

            var qry = _context.Customer.AsNoTracking();
            //.Include(p=>p.Name).Include(p=>p.Email).AsQueryable();
            if (!string.IsNullOrWhiteSpace(filter))
            {
                qry = qry.Where(p => p.Name.Contains(filter));
            }

#pragma warning disable CS0618 // Type or member is obsolete
            var model = await PagingList<Customer>.CreateAsync(qry, 15, page, sortExpression, "Name");
#pragma warning restore CS0618 // Type or member is obsolete
            model.RouteValue = new RouteValueDictionary
            {
                {"filter", filter }
            };
            return View(model);

            //var qry = _context.Customer.AsNoTracking().OrderBy(p => p.Name);
            //var model = new CustomerDetailsModel();
            //model.Customers = _customerdata.GetAll();
            //var rsr = await PagingList.CreateAsync(10, page);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CustomerModel customerModel)
        {
            if (ModelState.IsValid)
            {
                var newCustomer = new Customer();
                newCustomer.Name = customerModel.Name;
                newCustomer.Email = customerModel.Email;
                newCustomer.PrimaryPhone = customerModel.PrimaryPhone;
                newCustomer.AlternatePhone = customerModel.AlternatePhone;
                newCustomer.Address1 = customerModel.Address1;
                newCustomer.Address2 = customerModel.Address2;
                newCustomer.Address3 = customerModel.Address3;
                newCustomer.City = customerModel.City;
                newCustomer.State = customerModel.State;
                newCustomer.Country = customerModel.Country;
                newCustomer.Zip = customerModel.Zip;
                newCustomer = _customerdata.Add(newCustomer);

                _customerdata.Commit();

                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _customerdata.Get(id);
            if (model == null)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CustomerModel model)
        {
            var updatecustomer = _customerdata.Get(id);
            if (ModelState.IsValid)
            {
                updatecustomer.Name = model.Name;
                updatecustomer.Email = model.Email;
                updatecustomer.PrimaryPhone = model.PrimaryPhone;
                updatecustomer.AlternatePhone = model.AlternatePhone;
                updatecustomer.Address1 = model.Address1;
                updatecustomer.Address2 = model.Address2;
                updatecustomer.Address3 = model.Address3;
                updatecustomer.City = model.City;
                updatecustomer.State = model.State;
                updatecustomer.Country = model.Country;
                updatecustomer.Zip = model.Zip;

                _customerdata.Commit();
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            var model = _customerdata.Get(id);
            if (model != null)
            {
                _context.Customer.Remove(_context.Customer.FirstOrDefault(r => r.CustomerId == id));
                _customerdata.Commit();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}