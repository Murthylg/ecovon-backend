using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ecovon_backend.Models;
using ecovon_backend.Entities;
using ecovon_backend.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using ecovon_backend.Services.EmailService;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using MimeKit;

namespace ecovon_backend.Controllers
{
    public class RegisterUserController : Controller
    {

        private ecovondbcontext _context;
        private IRegisterData _registerData;
        
        private readonly IEmailSender emailSender;
        private readonly IHostingEnvironment env;

        public RegisterUserController(ecovondbcontext context, IRegisterData registerData, IEmailSender emailSender, IHostingEnvironment env)
        {
            _context = context;
            _registerData = registerData;
            this.emailSender = emailSender;
            this.env = env;
        }
        public IActionResult Index()
        {
            ViewBag.Message = "Welcome to my demo!";
            RegUsrDetails mymodel = new RegUsrDetails();
            mymodel.users = _registerData.GetAllUser();
            mymodel.logins = _registerData.GetAllLogin();
            return View(mymodel);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Name = new SelectList(_context.UserRole.Select(u => u).ToList(), "UserRoleId", "Name");
            ViewBag.CustomName = new SelectList(_context.Customer.Select(u => u).ToList(), "CustomerId", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var RegUsr = new User();
                {
                    RegUsr.CustomerId = model.CustomerId;
                    RegUsr.UserRoleId = model.UserRoleId;
                    RegUsr.FirstName = model.FirstName;
                    RegUsr.LastName = model.LastName;
                    RegUsr.MiddleName = model.MiddleName;
                    RegUsr.Email = model.Email;
                    RegUsr.WorkPhone = model.WorkPhone;
                    RegUsr.MobilePhone = model.MobilePhone;
                    RegUsr.HomePhone = model.HomePhone;
                    RegUsr.Address1 = model.Address1;
                    RegUsr.Address2 = model.Address2;
                    RegUsr.Address3 = model.Address3;
                    RegUsr.City = model.City;
                    RegUsr.State = model.State;
                    RegUsr.Country = model.Country;
                    RegUsr.Zip = model.Zip;
                };
                var loginUsr = new Login();
                {
                    //loginUsr.UserId = RegUsr.UserId;
                    loginUsr.LoginName = model.LoginName;
                    loginUsr.Password = model.Password;
                    loginUsr.CreatedDate = DateTime.Now;
                    //login user id
                    loginUsr.CreatedBy = 1;
                    loginUsr.ModifiedDate = "17/5/2018";
                    loginUsr.ModifiedBy = 1;
                    loginUsr.LastSuccessfulLoginDate = DateTime.Now;
                };
                _context.User.Add(RegUsr);
                _context.SaveChanges();
                loginUsr.UserId = RegUsr.UserId;
                _context.Login.Add(loginUsr);
                _context.SaveChanges();
                
                //Email Send operation without any template.
                //TempData["MessageValue"] = "1";
                //await emailSender.SendEmailAsync(RegUsr.Email, "Welcome" + loginUsr.LoginName, "User Name: " + loginUsr.LoginName + ";" + "Password: " + loginUsr.Password);
                                
                //Email from Email Template
                string Message = "Please confirm your account by clicking <a href=";
                // string body;

                var webRoot = env.WebRootPath; //get wwwroot Folder

                //Get TemplateFile located at wwwroot/Templates/EmailTemplate/Register_EmailTemplate.html
                var pathToFile = env.WebRootPath
                        + Path.DirectorySeparatorChar.ToString()
                        + "EmailTemplates"                       
                        + Path.DirectorySeparatorChar.ToString()
                        + "usrRegPage.html";

                var subject = "Confirm Account Registration";

                var builder = new BodyBuilder();
                using (StreamReader SourceReader = System.IO.File.OpenText(pathToFile))
                {
                    builder.HtmlBody = SourceReader.ReadToEnd();
                }
                //{0} : Subject
                //{1} : DateTime
                //{2} : Email
                //{3} : Username
                //{4} : Password
                //{5} : Message
                //{6} : callbackURL

                string messageBody = string.Format(builder.HtmlBody,
                    subject,
                    String.Format("{0:dddd, d MMMM yyyy}", DateTime.Now),
                    model.Email,
                    model.LoginName,
                    model.Password,
                    model.FirstName,
                    model.LastName,
                    Message                    
                    );


                await emailSender.SendEmailAsync(model.Email, subject, messageBody);

                //ViewData["Message"] = $"Please confirm your account by clicking this link: <a href='ecovon.in' class='btn btn-primary'>Confirmation Link</a>";
                //ViewData["MessageValue"] = "1";          






                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Name = new SelectList(_context.UserRole.Select(u => u).ToList(), "UserRoleId", "Name");
            ViewBag.CustomName = new SelectList(_context.Customer.Select(u => u).ToList(), "CustomerId", "Name");
            // var model = _registerData.Get(id);
            UpdateSingleUsrDetails model = new UpdateSingleUsrDetails();
            model.login = _registerData.Gets(id);
            model.user = _registerData.Get(id);

            //model = _registerData.Gets(id);
            if (model == null)
            {
                return RedirectToAction("Edit");
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id,UpdateSingleUsrDetails model)
        {
            if (ModelState.IsValid)
            {
                model.user.UserId = id;
                model.user.CustomerId = 1;
                model.user.UserRoleId = 1;
                model.login.CreatedDate = DateTime.Now;
                //login user id
                model.login.UserId = id;
               // model.login.LoginId=
                model.login.CreatedBy = 1;
                model.login.ModifiedDate = "17/5/2018";
                model.login.ModifiedBy = 1;
                 model.login.LastSuccessfulLoginDate = DateTime.Now;

              //  _registerData.Update(model.login);
                _registerData.Update(model.user);
                 _registerData.Commit();
               // _context.SaveChanges();
               
            }

           // var usrext = _registerData.Get(id);
            //if (ModelState.IsValid)
            //{
            //    usrext.FirstName = model.FirstName;
            //    usrext.LastName = model.LastName;
            //    usrext.MiddleName = model.MiddleName;                
            //    usrext.Email = model.Email;
            //    usrext.WorkPhone = model.WorkPhone;
            //    usrext.MobilePhone = model.MobilePhone;
            //    usrext.HomePhone = model.HomePhone;
            //    usrext.Address1 = model.Address1;
            //    usrext.Address2 = model.Address2;
            //    usrext.Address3 = model.Address3;
            //    usrext.City = model.City;
            //    usrext.State = model.State;
            //    usrext.Country = model.Country;
            //    usrext.Zip = model.Zip;
            //    _registerData.Commit();
            //}
            //var lognext = _registerData.Gets(id);
            //if (ModelState.IsValid)
            //{
            //    lognext.LoginName = model.LoginName;
            //    lognext.Password = model.Password;
            //    lognext.ModifiedDate = "17/05/2018";                
            //}
            //_registerData.Commit();

            // RegUsrDetails mymodel = new RegUsrDetails();
            // mymodel.users = _registerData.GetAllUser();
            // mymodel.logins = _registerData.GetAllLogin();
            //   _registerData.Commit();

            // return View("Index");
            // return Index();

            return RedirectToAction("Index");
        }
    }
}