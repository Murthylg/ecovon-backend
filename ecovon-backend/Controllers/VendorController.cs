using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ecovon_backend.Models.Vendors;
using ecovon_backend.Entities.Vendors;
using ecovon_backend.Services;
using ecovon_backend.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ecovon_backend.Controllers
{
    public class VendorController : Controller
    {
        private IVendorData _vendorData;
        private ecovondbcontext _context;

        public VendorController(IVendorData vendorData, ecovondbcontext context)
        {
            _vendorData = vendorData;
            _context = context;
        }
        public IActionResult Index()
        {
            var model = new VendorDetails();
            model.Vendors = _vendorData.GetAll();
            //var model = _context.Vendor.AsNoTracking();
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.TypeOfWorkName = new SelectList(_context.VendorTypeOfWork.Select(u => u).ToList(), "TypeofWorkId", "Name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VendorModel model)
        {
            if (ModelState.IsValid)
            {
                var newVendor = new Vendor();
                newVendor.FirstName = model.FirstName;
                newVendor.MiddleName = model.MiddleName;
                newVendor.LastName = model.LastName;
                newVendor.TypeofWorkId = model.TypeofWorkId;
                newVendor.CompanyName = model.CompanyName;
                newVendor.MobileNumber = model.MobileNumber;
                newVendor.WorkNumber = model.WorkNumber;
                newVendor.IsEnabled = model.IsEnabled;
                newVendor.Experience = model.Experience;
                newVendor.TeamSize = model.TeamSize;
                newVendor.Address1 = model.Address1;
                newVendor.Address2 = model.Address2;
                newVendor.Address3 = model.Address3;
                newVendor.IdentityType = model.IdentityType;
                newVendor.IdentityNumber = model.IdentityNumber;
                newVendor = _vendorData.Add(newVendor);
                _vendorData.Commit();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.TypeOfWorkName = new SelectList(_context.VendorTypeOfWork.Select(u => u).ToList(), "TypeofWorkId", "Name");
            var model = _vendorData.Get(id);
            if (model == null)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, VendorModel model)
        {
            var updateVendor = _vendorData.Get(id);
            if (ModelState.IsValid)
            {
                updateVendor.FirstName = model.FirstName;
                updateVendor.MiddleName = model.MiddleName;
                updateVendor.LastName = model.LastName;
                updateVendor.TypeofWorkId = model.TypeofWorkId;
                updateVendor.CompanyName = model.CompanyName;
                updateVendor.MobileNumber = model.MobileNumber;
                updateVendor.WorkNumber = model.WorkNumber;
                updateVendor.IsEnabled = model.IsEnabled;
                updateVendor.Experience = model.Experience;
                updateVendor.TeamSize = model.TeamSize;
                updateVendor.Address1 = model.Address1;
                updateVendor.Address2 = model.Address2;
                updateVendor.Address3 = model.Address3;
                updateVendor.IdentityType = model.IdentityType;
                updateVendor.IdentityNumber = model.IdentityNumber;
                _vendorData.Commit();
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var model = _vendorData.Get(id);
            if (model == null)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}