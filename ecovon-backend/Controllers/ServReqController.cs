using Microsoft.AspNetCore.Mvc;
using ecovon_backend.Services;
using ecovon_backend.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ReflectionIT.Mvc.Paging;
using Microsoft.AspNetCore.Routing;
using System.Linq;
using System;
using ecovon_backend.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Twilio;
using Twilio.Types;
using Twilio.Rest.Api.V2010.Account;

namespace ecovon_backend.Controllers
{
    public class ServReqController : Controller
    {
        private readonly ecovondbcontext _Context;
        private readonly IServReqData _servReqData;

        public ServReqController(IServReqData servReqData, ecovondbcontext context)
        {
            _Context = context;
            _servReqData = servReqData;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string filter, int page = 1, string sortExpression = "-ServiceRequestId")
        {

            //var products = _Context.ServiceRequest.FromSql("EXECUTE dbo.mystuff").ToList();           
            //var ServReqList = _Context.ServiceRequest.AsNoTracking().OrderBy(p => p.Status);
            var orderlist = _Context.ServiceRequest.OrderByDescending(p=>p.ServiceRequestId);
            var servReqList = orderlist.AsNoTracking().Include(p => p.ServiceTypeDetails).Include(p => p.custumerDetails);
            //    .Include(p => p.Notes)
            //    .Include(p => p.Status)
            //    .AsQueryable();

            //if (!string.IsNullOrWhiteSpace(filter))
            //{
            //    servReqList = servReqList.Where(p => p.Notes.Contains(filter));
            //}   
            
            var model = await PagingList.CreateAsync(servReqList, 20, page, sortExpression, "ServiceRequestId");
            model.OrderByDescending(p=>p.ServiceRequestId);
            //var insta = model.OrderByDescending(p => p.ServiceRequestId);
            model.RouteValue = new RouteValueDictionary {
        { "ServiceRequestId", filter}
    };
            //ViewData["pending"] = _Context.ServiceRequest.Select(r => r.Status == "Pending").Distinct().ToList();

            var servReqAllList = _Context.ServiceRequest.AsNoTracking();
            ViewBag.TotalReqs = servReqAllList.Count();
            var servReqPendList = _Context.ServiceRequest.AsNoTracking().Where(r => r.Status == "Pending");
            ViewBag.TotalPendingReqs = servReqPendList.Count();
            var servReqTermList = _Context.ServiceRequest.AsNoTracking().Where(r => r.Status == "Terminated");
            ViewBag.TotalTerminatedReqs = servReqTermList.Count();
            var servReqAssignedList = _Context.ServiceRequest.AsNoTracking().Where(r => r.Status == "Approved");
            ViewBag.TotalAssignedReqs = servReqAssignedList.Count();
            var servReqHoldList = _Context.ServiceRequest.AsNoTracking().Where(r => r.Status == "Hold");
            ViewBag.TotalHoldReqs = servReqHoldList.Count();
            var servReqSuccessList = _Context.ServiceRequest.AsNoTracking().Where(r => r.Status == "Success");
            ViewBag.TotalSuccessReqs = servReqSuccessList.Count();

            return View(model);

            //var model = new ServReqDetails();
            //model.ServiceRequests = _servReqData.GetAll();
            //return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Pending(string filter, int page = 1, string sortExpression = "-ServiceRequestId")
        {
            //var ServReqList = _Context.ServiceRequest.AsNoTracking().OrderBy(p => p.Status);
            var servReqList = _Context.ServiceRequest.AsNoTracking().Where(r => r.Status == "Pending").Include(p => p.ServiceTypeDetails).Include(p => p.custumerDetails);
            //    .Include(p => p.Notes)
            //    .Include(p => p.Status)
            //    .AsQueryable();

            //if (!string.IsNullOrWhiteSpace(filter))
            //{
            //    servReqList = servReqList.Where(p => p.Notes.Contains(filter));
            //}

            var model = await PagingList.CreateAsync(servReqList, 20, page, sortExpression, "ServiceRequestId");

            model.RouteValue = new RouteValueDictionary {
        { "filter", filter}
    };
            //ViewData["pending"] = _Context.ServiceRequest.Select(r => r.Status == "Pending").Distinct().ToList();

            var servReqAllList = _Context.ServiceRequest.AsNoTracking();
            ViewBag.TotalReqs = servReqAllList.Count();
            var servReqPendList = _Context.ServiceRequest.AsNoTracking().Where(r => r.Status == "Pending");
            ViewBag.TotalPendingReqs = servReqPendList.Count();
            var servReqTermList = _Context.ServiceRequest.AsNoTracking().Where(r => r.Status == "Terminated");
            ViewBag.TotalTerminatedReqs = servReqTermList.Count();
            var servReqAssignedList = _Context.ServiceRequest.AsNoTracking().Where(r => r.Status == "Approved");
            ViewBag.TotalAssignedReqs = servReqAssignedList.Count();
            var servReqHoldList = _Context.ServiceRequest.AsNoTracking().Where(r => r.Status == "Hold");
            ViewBag.TotalHoldReqs = servReqHoldList.Count();
            var servReqSuccessList = _Context.ServiceRequest.AsNoTracking().Where(r => r.Status == "Success");
            ViewBag.TotalSuccessReqs = servReqSuccessList.Count();
            return View(model);

            //var model = new ServReqDetails();
            //model.ServiceRequests = _servReqData.GetAll();
            //return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Assigned(string filter, int page = 1, string sortExpression = "-ServiceRequestId")
        {
            //var ServReqList = _Context.ServiceRequest.AsNoTracking().OrderBy(p => p.Status);
            var servReqList = _Context.ServiceRequest.AsNoTracking().Where(r => r.Status == "Approved").Include(p => p.ServiceTypeDetails).Include(p => p.custumerDetails);
            //    .Include(p => p.Notes)
            //    .Include(p => p.Status)
            //    .AsQueryable();

            //if (!string.IsNullOrWhiteSpace(filter))
            //{
            //    servReqList = servReqList.Where(p => p.Notes.Contains(filter));
            //}

            var model = await PagingList.CreateAsync(servReqList, 20, page, sortExpression, "ServiceRequestId");

            model.RouteValue = new RouteValueDictionary {
        { "filter", filter}
    };
            var servReqAllList = _Context.ServiceRequest.AsNoTracking();
            ViewBag.TotalReqs = servReqAllList.Count();
            var servReqPendList = _Context.ServiceRequest.AsNoTracking().Where(r => r.Status == "Pending");
            ViewBag.TotalPendingReqs = servReqPendList.Count();
            var servReqTermList = _Context.ServiceRequest.AsNoTracking().Where(r => r.Status == "Terminated");
            ViewBag.TotalTerminatedReqs = servReqTermList.Count();
            var servReqAssignedList = _Context.ServiceRequest.AsNoTracking().Where(r => r.Status == "Approved");
            ViewBag.TotalAssignedReqs = servReqAssignedList.Count();
            var servReqHoldList = _Context.ServiceRequest.AsNoTracking().Where(r => r.Status == "Hold");
            ViewBag.TotalHoldReqs = servReqHoldList.Count();
            var servReqSuccessList = _Context.ServiceRequest.AsNoTracking().Where(r => r.Status == "Success");
            ViewBag.TotalSuccessReqs = servReqSuccessList.Count();
            return View(model);

            //var model = new ServReqDetails();
            //model.ServiceRequests = _servReqData.GetAll();
            //return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Terminated(string filter, int page = 1, string sortExpression = "-ServiceRequestId")
        {
            //var ServReqList = _Context.ServiceRequest.AsNoTracking().OrderBy(p => p.Status);
            var servReqList = _Context.ServiceRequest.AsNoTracking().Where(r => r.Status == "Terminated").Include(p => p.ServiceTypeDetails).Include(p => p.custumerDetails);
            //    .Include(p => p.Notes)
            //    .Include(p => p.Status)
            //    .AsQueryable();

            //if (!string.IsNullOrWhiteSpace(filter))
            //{
            //    servReqList = servReqList.Where(p => p.Notes.Contains(filter));
            //}

            var model = await PagingList.CreateAsync(servReqList, 20, page, sortExpression, "ServiceRequestId");

            model.RouteValue = new RouteValueDictionary {
        { "filter", filter}
    };
            var servReqAllList = _Context.ServiceRequest.AsNoTracking();
            ViewBag.TotalReqs = servReqAllList.Count();
            var servReqPendList = _Context.ServiceRequest.AsNoTracking().Where(r => r.Status == "Pending");
            ViewBag.TotalPendingReqs = servReqPendList.Count();
            var servReqTermList = _Context.ServiceRequest.AsNoTracking().Where(r => r.Status == "Terminated");
            ViewBag.TotalTerminatedReqs = servReqTermList.Count();
            var servReqAssignedList = _Context.ServiceRequest.AsNoTracking().Where(r => r.Status == "Approved");
            ViewBag.TotalAssignedReqs = servReqAssignedList.Count();
            var servReqHoldList = _Context.ServiceRequest.AsNoTracking().Where(r => r.Status == "Hold");
            ViewBag.TotalHoldReqs = servReqHoldList.Count();
            var servReqSuccessList = _Context.ServiceRequest.AsNoTracking().Where(r => r.Status == "Success");
            ViewBag.TotalSuccessReqs = servReqSuccessList.Count();
            return View(model);

            //var model = new ServReqDetails();
            //model.ServiceRequests = _servReqData.GetAll();
            //return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Hold(string filter, int page = 1, string sortExpression = "-ServiceRequestId")
        {
            //var ServReqList = _Context.ServiceRequest.AsNoTracking().OrderBy(p => p.Status);
            var servReqList = _Context.ServiceRequest.AsNoTracking().Where(r => r.Status == "Hold").Include(p => p.ServiceTypeDetails).Include(p => p.custumerDetails);
            //    .Include(p => p.Notes)
            //    .Include(p => p.Status)
            //    .AsQueryable();

            //if (!string.IsNullOrWhiteSpace(filter))
            //{
            //    servReqList = servReqList.Where(p => p.Notes.Contains(filter));
            //}

            var model = await PagingList.CreateAsync(servReqList, 20, page, sortExpression, "ServiceRequestId");

            model.RouteValue = new RouteValueDictionary
            {
        { "filter", filter}
    };
            var servReqAllList = _Context.ServiceRequest.AsNoTracking();
            ViewBag.TotalReqs = servReqAllList.Count();
            var servReqPendList = _Context.ServiceRequest.AsNoTracking().Where(r => r.Status == "Pending");
            ViewBag.TotalPendingReqs = servReqPendList.Count();
            var servReqTermList = _Context.ServiceRequest.AsNoTracking().Where(r => r.Status == "Terminated");
            ViewBag.TotalTerminatedReqs = servReqTermList.Count();
            var servReqAssignedList = _Context.ServiceRequest.AsNoTracking().Where(r => r.Status == "Approved");
            ViewBag.TotalAssignedReqs = servReqAssignedList.Count();
            var servReqHoldList = _Context.ServiceRequest.AsNoTracking().Where(r => r.Status == "Hold");
            ViewBag.TotalHoldReqs = servReqHoldList.Count();
            var servReqSuccessList = _Context.ServiceRequest.AsNoTracking().Where(r => r.Status == "Success");
            ViewBag.TotalSuccessReqs = servReqSuccessList.Count();
            return View(model);

            //var model = new ServReqDetails();
            //model.ServiceRequests = _servReqData.GetAll();
            //return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Success(string filter, int page = 1, string sortExpression = "-ServiceRequestId")
        {
            //var ServReqList = _Context.ServiceRequest.AsNoTracking().OrderBy(p => p.Status);
            var servReqList = _Context.ServiceRequest.AsNoTracking().Where(r => r.Status == "Success").Include(p => p.ServiceTypeDetails).Include(p => p.custumerDetails);
            //    .Include(p => p.Notes)
            //    .Include(p => p.Status)
            //    .AsQueryable();

            //if (!string.IsNullOrWhiteSpace(filter))
            //{
            //    servReqList = servReqList.Where(p => p.Notes.Contains(filter));
            //}

            var model = await PagingList.CreateAsync(servReqList, 20, page, sortExpression, "ServiceRequestId");

            model.RouteValue = new RouteValueDictionary {
        { "filter", filter}
    };
            var servReqAllList = _Context.ServiceRequest.AsNoTracking();
            ViewBag.TotalReqs = servReqAllList.Count();
            var servReqPendList = _Context.ServiceRequest.AsNoTracking().Where(r => r.Status == "Pending");
            ViewBag.TotalPendingReqs = servReqPendList.Count();
            var servReqTermList = _Context.ServiceRequest.AsNoTracking().Where(r => r.Status == "Terminated");
            ViewBag.TotalTerminatedReqs = servReqTermList.Count();
            var servReqAssignedList = _Context.ServiceRequest.AsNoTracking().Where(r => r.Status == "Approved");
            ViewBag.TotalAssignedReqs = servReqAssignedList.Count();
            var servReqHoldList = _Context.ServiceRequest.AsNoTracking().Where(r => r.Status == "Hold");
            ViewBag.TotalHoldReqs = servReqHoldList.Count();
            var servReqSuccessList = _Context.ServiceRequest.AsNoTracking().Where(r => r.Status == "Success");
            ViewBag.TotalSuccessReqs = servReqSuccessList.Count();
            return View(model);

            //var model = new ServReqDetails();
            //model.ServiceRequests = _servReqData.GetAll();
            //return View(model);
        }

        public async Task<IActionResult> CustomerOrder(int Cid)
        {
            //var servReqByCustomer = _Context.ServiceRequest.FirstOrDefault(p => p.CustomerId==Cid);
            //return View(servReqByCustomer);

            ServiceReqAllUsrInfo model = new ServiceReqAllUsrInfo();
            //ServiceRequestDetailModel model = new ServiceRequestDetailModel();

            var reqDetails = _Context.ServiceRequest.FirstOrDefault(p => p.CustomerId == Cid);            
           
            if (reqDetails == null)
            {
                return RedirectToAction("Index");
            }
            var idname = reqDetails.ServiceTypeId;
            return View(reqDetails);
        }

        [HttpGet]
        public IActionResult Details(int id, ServiceRequestDetailModel models)
        {
            ServiceReqAllUsrInfo model = new ServiceReqAllUsrInfo();
            //ServiceRequestDetailModel model = new ServiceRequestDetailModel();
           
            var reqDetails = _servReqData.Get(id);
            model.serviceRequests = _servReqData.GetSerReq(id);
            var servdata = reqDetails.CreatedBy;
            model.users = _servReqData.GetUser(servdata);           
            if (model == null)
            {
                return RedirectToAction("Index");
            }
            var idname = reqDetails.ServiceTypeId;

            //Request Service Details update.
            //var statusUpdate = _servReqData.Get(id);
            //if (ModelState.IsValid == false)
            //{
            //    var reqStatusUpdate = new ServiceRequestDetail();
            //    {
            //        reqStatusUpdate.ServiceRequestId = id;
            //        reqStatusUpdate.PreviousStatus = statusUpdate.Status;
            //        reqStatusUpdate.CreatedDate = DateTime.Now;
            //        reqStatusUpdate.CreatedBy = DateTime.Now;
            //        reqStatusUpdate.CurrentStatus = models.CurrentStatus;
            //        reqStatusUpdate.AssignedTo = models.AssignedTo;
            //        reqStatusUpdate.Notes = models.Notes;
            //    }

            //    reqStatusUpdate = _servReqData.Add(reqStatusUpdate);
            //    _servReqData.Commit();
            //    statusUpdate.Status = models.CurrentStatus;
            //    _servReqData.Commit();                            
            //    return RedirectToAction("Index");
            //}
            return View(model);
        }

        [HttpGet]
        public IActionResult DetailsAll(int id)
        {
            ServiceReqAllUsrInfo model = new ServiceReqAllUsrInfo();
            //ServiceRequestDetailModel model = new ServiceRequestDetailModel();

            var reqDetails = _servReqData.Get(id);
            model.serviceRequests = _servReqData.GetSerReq(id);
            var servdata = reqDetails.CreatedBy;
            model.users = _servReqData.GetUser(servdata);
            model.serviceRequestDetails = _servReqData.GetSerReqDetails(id);
            if (model == null)
            {
                return RedirectToAction("Index");
            }
            var idname = reqDetails.ServiceTypeId;
            return View(model);
        }
        //[HttpGet]
        //public IActionResult Create(int id)
        //{
        //    var model = _servReqData.Get(id);
        //    if (model==null)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    return View(model);
        //}
        [HttpGet]
        public IActionResult Create()
        {            
            ViewBag.TechnicianDetails = new SelectList(_Context.Vendor.Select(u => u).ToList(), "VendorId", "FirstName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int id, ServReqDetailsForUserModel model)
        {
            var statusUpdate = _servReqData.Get(id);
            if (ModelState.IsValid == false)
            {
                var reqStatusUpdate = new ServiceRequestDetail();
                {
                    reqStatusUpdate.ServiceRequestId = id;
                    reqStatusUpdate.PreviousStatus = statusUpdate.Status;
                    reqStatusUpdate.CreatedDate = DateTime.Now;
                    reqStatusUpdate.CreatedBy = DateTime.Now;
                    reqStatusUpdate.CurrentStatus = model.CurrentStatus;
                    reqStatusUpdate.VendorId = model.AssignedTo;
                    reqStatusUpdate.Notes = model.Notes;
                }

                reqStatusUpdate = _servReqData.Add(reqStatusUpdate);
                _servReqData.Commit();

                statusUpdate.Status = model.CurrentStatus;
                _servReqData.Commit();
                
                //Send SMS.
                    //const string accountSid = "ACb3537f8f66fe675bcf63e6847c287f30";
                    //const string authToken = "50eb2745e719229c813323192f51d511";
                    //TwilioClient.Init(accountSid, authToken);

                    //var to = new PhoneNumber("+91 9440488221");
                    //var message = MessageResource.Create(
                    //    to,
                    //    from: new PhoneNumber("+15046080231"), //  From number, must be an SMS-enabled Twilio number ( This will send sms from ur "To" numbers ).
                    //    body: $"Hello Murthy !! We assigned a technician!!");                  
                
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}