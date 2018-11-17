using System.Collections.Generic;
using ecovon_backend.Models.Charts;
using Microsoft.AspNetCore.Mvc;
using ecovon_backend.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ecovon_backend.Controllers
{
    public class ChartsController : Controller
    {
        private readonly ecovondbcontext _context;        
        public ChartsController(ecovondbcontext context)
        {
            _context = context;
        }        

        public IActionResult Bar()
        {            
            var servReqAllList = _context.ServiceRequest.AsNoTracking();
            ViewBag.TotalReqs = servReqAllList.Count();            
            var servReqPendList = _context.ServiceRequest.AsNoTracking().Where(r => r.Status == "Pending");
            ViewBag.TotalPendingReqs = servReqPendList.Count();            
            var servReqTermList = _context.ServiceRequest.AsNoTracking().Where(r => r.Status == "Terminated");
            ViewBag.TotalTerminatedReqs = servReqTermList.Count();
            var servReqAssignedList = _context.ServiceRequest.AsNoTracking().Where(r => r.Status == "Approved");
            ViewBag.TotalAssignedReqs = servReqAssignedList.Count();
            var servReqHoldList = _context.ServiceRequest.AsNoTracking().Where(r => r.Status == "Hold");
            ViewBag.TotalHoldReqs = servReqHoldList.Count();
            var servReqSuccessList = _context.ServiceRequest.AsNoTracking().Where(r => r.Status == "Success");
            ViewBag.TotalSuccessReqs = servReqSuccessList.Count();

            var lstModel = new List<SimpleReportViewModel>();
            lstModel.Add(new SimpleReportViewModel
            {
                DimensionOne = "Pending",
                Quantity = ViewBag.TotalPendingReqs
            });

            lstModel.Add(new SimpleReportViewModel
            {
                DimensionOne = "Terminated",
                Quantity = ViewBag.TotalTerminatedReqs
            });
            lstModel.Add(new SimpleReportViewModel
            {
                DimensionOne = "Assigned",
                Quantity = ViewBag.TotalAssignedReqs
            });
            lstModel.Add(new SimpleReportViewModel
            {
                DimensionOne = "Hold",
                Quantity = ViewBag.TotalHoldReqs
            });
            lstModel.Add(new SimpleReportViewModel
            {
                DimensionOne = "Success",
                Quantity = ViewBag.TotalSuccessReqs
            });

            return View(lstModel);
        }

        public IActionResult Line()
        {
            //list of countries
            var servReqAllList = _context.ServiceRequest.AsNoTracking();
            ViewBag.TotalReqs = servReqAllList.Count();
            var servReqPendList = _context.ServiceRequest.AsNoTracking().Where(r => r.Status == "Pending");
            ViewBag.TotalPendingReqs = servReqPendList.Count();
            var servReqTermList = _context.ServiceRequest.AsNoTracking().Where(r => r.Status == "Terminated");
            ViewBag.TotalTerminatedReqs = servReqTermList.Count();
            var servReqAssignedList = _context.ServiceRequest.AsNoTracking().Where(r => r.Status == "Approved");
            ViewBag.TotalAssignedReqs = servReqAssignedList.Count();
            var servReqHoldList = _context.ServiceRequest.AsNoTracking().Where(r => r.Status == "Hold");
            ViewBag.TotalHoldReqs = servReqHoldList.Count();
            var servReqSuccessList = _context.ServiceRequest.AsNoTracking().Where(r => r.Status == "Success");
            ViewBag.TotalSuccessReqs = servReqSuccessList.Count();

            var lstModel = new List<SimpleReportViewModel>();
            lstModel.Add(new SimpleReportViewModel
            {
                DimensionOne = "Pending",
                Quantity = ViewBag.TotalPendingReqs
            });

            lstModel.Add(new SimpleReportViewModel
            {
                DimensionOne = "Terminated",
                Quantity = ViewBag.TotalTerminatedReqs
            });
            lstModel.Add(new SimpleReportViewModel
            {
                DimensionOne = "Assigned",
                Quantity = ViewBag.TotalAssignedReqs
            });
            lstModel.Add(new SimpleReportViewModel
            {
                DimensionOne = "Hold",
                Quantity = ViewBag.TotalHoldReqs
            });
            lstModel.Add(new SimpleReportViewModel
            {
                DimensionOne = "Success",
                Quantity = ViewBag.TotalSuccessReqs
            });
            return View(lstModel);
        }

        public IActionResult Pie()
        {
            //list of drinks
            var servReqAllList = _context.ServiceRequest.AsNoTracking();
            ViewBag.TotalReqs = servReqAllList.Count();
            var servReqPendList = _context.ServiceRequest.AsNoTracking().Where(r => r.Status == "Pending");
            ViewBag.TotalPendingReqs = servReqPendList.Count();
            var servReqTermList = _context.ServiceRequest.AsNoTracking().Where(r => r.Status == "Terminated");
            ViewBag.TotalTerminatedReqs = servReqTermList.Count();
            var servReqAssignedList = _context.ServiceRequest.AsNoTracking().Where(r => r.Status == "Approved");
            ViewBag.TotalAssignedReqs = servReqAssignedList.Count();
            var servReqHoldList = _context.ServiceRequest.AsNoTracking().Where(r => r.Status == "Hold");
            ViewBag.TotalHoldReqs = servReqHoldList.Count();
            var servReqSuccessList = _context.ServiceRequest.AsNoTracking().Where(r => r.Status == "Success");
            ViewBag.TotalSuccessReqs = servReqSuccessList.Count();

            var lstModel = new List<SimpleReportViewModel>();
            lstModel.Add(new SimpleReportViewModel
            {
                DimensionOne = "Pending",
                Quantity = ViewBag.TotalPendingReqs
            });

            lstModel.Add(new SimpleReportViewModel
            {
                DimensionOne = "Terminated",
                Quantity = ViewBag.TotalTerminatedReqs
            });
            lstModel.Add(new SimpleReportViewModel
            {
                DimensionOne = "Assigned",
                Quantity = ViewBag.TotalAssignedReqs
            });
            lstModel.Add(new SimpleReportViewModel
            {
                DimensionOne = "Hold",
                Quantity = ViewBag.TotalHoldReqs
            });
            lstModel.Add(new SimpleReportViewModel
            {
                DimensionOne = "Success",
                Quantity = ViewBag.TotalSuccessReqs
            });
            return View(lstModel);
        }        
    }
}