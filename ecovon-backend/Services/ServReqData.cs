using System.Collections.Generic;
using ecovon_backend.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ecovon_backend.Services
{
    public interface IServReqData
    {
        IEnumerable<ServiceRequest> GetAll();
        IEnumerable<ServiceRequest> GetSerReq(int id);
        IEnumerable<ServiceRequestDetail> GetSerReqDetails(int id);
        IEnumerable<User> GetUser(int id);
        ServiceRequest Get(int id);        
        ServiceRequestDetail GetRqD(int id);
        ServiceRequestDetail Add(ServiceRequestDetail reqStatusUpdate);
        //User GetUser(int id);
        void Commit();
        ServiceRequest Update(ServiceRequest reqServUpdate);
    }
    public class SqlIServReqData : IServReqData
    {
        private ecovondbcontext _context;

        public SqlIServReqData(ecovondbcontext context)
        {
            _context = context;
        }

        public ServiceRequestDetail Add(ServiceRequestDetail reqStatusUpdate)
        {
            _context.Add(reqStatusUpdate);
            return reqStatusUpdate;            
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public ServiceRequest Get(int id)
        {
            return _context.ServiceRequest.FirstOrDefault(r => r.ServiceRequestId == id);
        }

        public IEnumerable<ServiceRequest> GetAll()
        {
            //return _context.ServiceRequest.FromSql("EXECUTE dbo.mystuff").ToList();
            return _context.ServiceRequest;
        }

        public ServiceRequestDetail GetRqD(int id)
        {
            return (ServiceRequestDetail)_context.serviceRequestDetail.Where(r => r.ServiceRequestDetailId == id).Include(b => b.VendorId);
        }

        //public User GetUser(int id)
        //{
        //    return _context.User.FirstOrDefault(r => r.UserId == id);
        //}

      

        

        public IEnumerable<ServiceRequest> GetSerReq(int id)
        {
            //return _context.ServiceRequest.Where(r => r.ServiceRequestId == id).Include(b => b.custumerDetails).Include(b => b.ServiceTypeDetails)
            //               .ToList();
           // ServiceRequest serviceRequest = _context.ServiceRequest.Where(r => r.ServiceRequestId == id).FirstOrDefault();
           // serviceRequest.custumerDetails = _context.Customer.Where(r => r.CustomerId.Equals(serviceRequest.CustomerId)).FirstOrDefault();
           //// serviceRequest.ServiceTypeDetails = _context.ServiceType.Where(r => r.ServiceTypeId.Equals(serviceRequest.ServiceTypeId)).FirstOrDefault();
           // return new List<ServiceRequest>() { serviceRequest };
            return _context.ServiceRequest.Where(r => r.ServiceRequestId == id).Include(b=>b.custumerDetails).Include(b => b.ServiceTypeDetails);            
        }

        ServiceRequest IServReqData.Update(ServiceRequest reqServUpdate)
        {
            
            _context.Update(reqServUpdate);
            return reqServUpdate;
        }

        public IEnumerable<User> GetUser(int id)
        {
            return _context.User.Where(r => r.UserId == id);
        }

        public IEnumerable<ServiceRequestDetail> GetSerReqDetails(int id)
        {
            return _context.serviceRequestDetail.Where(r => r.ServiceRequestId == id).Include(b=>b.VendorDetails);
        }
    }    
}
