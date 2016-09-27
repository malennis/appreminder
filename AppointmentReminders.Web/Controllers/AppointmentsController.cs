using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AppointmentReminders.Web.Models;
using AppointmentReminders.Web.Models.Repository;
using System.Web.Security;
using System.Web;
using System.Collections.Generic;
using PagedList;


namespace AppointmentReminders.Web.Controllers
{
    [Authorize]
    public class AppointmentsController : Controller
    {
        private readonly IAppointmentRepository _repository;

       
        public AppointmentsController() : this(new AppointmentRepository()) 
        {
            var cookie = "0";
            if (this.ControllerContext!= null) { 
                if (this.ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("octest"))
                {
                    cookie = this.ControllerContext.HttpContext.Request.Cookies["octest"].Value;
                    Session["oc"] = cookie;
                }
            }
        }

        public AppointmentsController(IAppointmentRepository repository)
        {
            _repository = repository;
           
        }

        public SelectListItem[] Timezones
        {
            get
            {
                var systemTimeZones = TimeZoneInfo.GetSystemTimeZones();
                return systemTimeZones.Select(systemTimeZone => new SelectListItem
                {
                    Text = systemTimeZone.DisplayName,
                    Value = systemTimeZone.Id
                }).ToArray();
            }
        }

        public SelectListItem[] Physicians 
        {

            get 
            {
                var oc = Session["oc"] ?? 0;
                int _oc = Convert.ToInt32(oc);
                var physicianList = _repository.FindAllPhysicianByOC(_oc);
                return physicianList.Select(x => new SelectListItem
                    {
                        Text = x.PhysicianName,
                        Value = x.PhysicianId.ToString()
                    }).ToArray();
            
            }
        }

        public SelectListItem[] CountryCodes 
        {

            get
            {
                var contryList = _repository.GetAllCountriesCodes();
                return contryList.Select(x => new SelectListItem
                {
                    Text = x.Country,
                    Value = x.Code
                }).ToArray();

            }
        
        }

        // GET: Appointments
        public ActionResult Index(int? page)
        {
            int op = GetOperationCenter();

            var appointments = _repository.FindAllByOperationCenter(op );

            ViewBag.CurrentSort = "";
            ViewBag.CurrentFilter = "";
            int pageSize = 10;
            int pageNumber=(page??1);

            return View(appointments.ToPagedList(pageNumber,pageSize));
        }

        // GET: Appointments/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var appointment = _repository.FindById(id.Value);
            if (appointment == null)
            {
                return HttpNotFound();
            }

            return View(appointment);
        }

        // GET: Appointments/Create
         [Authorize]
        public ActionResult Create()
        {
            var cookie = "0";
            if (this.ControllerContext != null)
            {
                if (this.ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("octest"))
                {
                    cookie = this.ControllerContext.HttpContext.Request.Cookies["octest"].Value;
                    Session["oc"] = cookie;
                }
            }

             
             ViewBag.Timezones = Timezones;
            // Use an empty appointment to setup the default
            // values.
            ViewBag.Physicians = Physicians;
            ViewBag.CountryCodes = CountryCodes;
            
            var appointment = new Appointment
            {
                Timezone = "Pacific Standard Time",
                Time = DateTime.Now
                

            };

            return View(appointment);
        }

        [HttpPost]
         public ActionResult Create2(string PhoneNumber) //[Bind(Include = "PhoneNumber")]
        {
            if (ModelState.IsValid)
            {

                var cookie = "0";
                if (this.ControllerContext != null)
                {
                    if (this.ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("octest"))
                    {
                        cookie = this.ControllerContext.HttpContext.Request.Cookies["octest"].Value;
                        Session["oc"] = cookie;
                    }
                }

                ViewBag.Timezones = Timezones;
                // Use an empty appointment to setup the default
                // values.
                ViewBag.Physicians = Physicians;
                ViewBag.CountryCodes = CountryCodes;
                var customer = _repository.FindCustomerByPhoneNumber(PhoneNumber);
                if (customer == null)
                {
                    customer = new Custumer();
                }

                var appointment = new Appointment
                {
                    OperationCenterId = Convert.ToInt32(cookie),
                    Timezone = "Pacific Standard Time",
                    Time = DateTime.Now,
                    CountryCode = customer.CountryCode,
                    Name = customer.Name,
                    CustomerId = customer.CustumerId,
                    PhoneNumber = customer.PhoneNumber
                };




                if (Request.IsAjaxRequest())
                {
                    // ViewBag.CountryCodes = new SelectList(CountryCodes, "Code", "Country", "USA");
                    return PartialView("_Form", appointment);
                }


                return View("Create", appointment);

            }
            return View("Create");
        }


        [HttpPost]
        public ActionResult Create([Bind(Include = "ID,Name,PhoneNumber,Time,Timezone,CountryCode,PhysicianId,OperationCenterId")]Appointment appointment)
        {
            appointment.CreatedAt = DateTime.Now;
            var cookie = "0";
            if (ModelState.IsValid)
            {

               
                if (this.ControllerContext != null)
                {
                    if (this.ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("octest"))
                    {
                        cookie = this.ControllerContext.HttpContext.Request.Cookies["octest"].Value;
                       // Session["oc"] = cookie;
                    }
                }

                var customer = _repository.FindCustomerByPhoneNumber(appointment.PhoneNumber);
                if(customer!=null)
                    appointment.CustomerId = customer.CustumerId;

                appointment.OperationCenterId = Convert.ToInt32(cookie);
                _repository.Create(appointment);

                return RedirectToAction("Details", new {id = appointment.Id});
            }
            else
            {
                ViewBag.Timezones = Timezones;
                // Use an empty appointment to setup the default
                // values.
                ViewBag.Physicians = Physicians;
                ViewBag.CountryCodes = CountryCodes;
                var customer = _repository.FindCustomerByPhoneNumber(appointment.PhoneNumber);
                if (customer == null)
                {
                    customer = new Custumer();
                }

                 appointment.OperationCenterId = Convert.ToInt32(cookie);
                 appointment.Timezone = "Pacific Standard Time";
                    appointment.Time = DateTime.Now;
                    appointment.CountryCode = customer.CountryCode;
                    appointment.Name = customer.Name;
                    appointment.CustomerId = customer.CustumerId;
                    appointment.PhoneNumber = customer.PhoneNumber;
            }

           return View("Create", appointment);
           // return RedirectToAction("Create");
        }

        // GET: Appointments/Edit/5
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var appointment = _repository.FindById(id.Value);
            if (appointment == null)
            {
                return HttpNotFound();
            }

            ViewBag.Timezones = Timezones;
            ViewBag.Physicians = Physicians;
            ViewBag.CountryCodes = CountryCodes;
          
            return View(appointment);
        }

        // POST: /Appointments/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "ID,Name,PhoneNumber,Time,Timezone,CountryCode,PhysicianId,OperationCenterId,CustomerId,Status")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                _repository.Update(appointment);
                return RedirectToAction("Details", new { id = appointment.Id });
            }

            var errors = ModelState.Values.SelectMany(v => v.Errors);
            return View(appointment);
        }

        // DELETE: Appointments/Delete/5
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            _repository.Delete(id);
            return RedirectToAction("Index");
        }
        
        [AllowAnonymous]
        public ActionResult Login() 
        {


            var login = new Login();
           

            return View(login);
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(Login login) 
        {
            
            if (ModelState.IsValid)
            {
                Assistant a = _repository.FindAssistantByUserPassword(login.user, login.password);
                FormsAuthentication.SetAuthCookie(login.user, false);
                if (a != null)
                {
                    HttpCookie cookie = new HttpCookie("octest");
                    cookie.Value = a.OperationCenterId.ToString();
                    this.ControllerContext.HttpContext.Response.Cookies.Add(cookie);

                    return RedirectToAction("Create");
                }
                else
                {
                    ModelState.AddModelError("","Incorrect user name or password");
                }
                
            }

            return View();
        }

        public ActionResult Logout() 
        {




            // Delete the authentication ticket and sign out.
            FormsAuthentication.SignOut();

            // Clear authentication cookie.
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, "");
            cookie.Expires = DateTime.Now.AddYears(-1);
            this.ControllerContext.HttpContext.Request.RequestContext.HttpContext.Response.Cookies.Add(cookie);
        

            if (this.ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("octest"))
            {
                HttpCookie cookieOC = this.ControllerContext.HttpContext.Request.Cookies["octest"];
                cookieOC.Expires = DateTime.Now.AddDays(-1);
                this.ControllerContext.HttpContext.Response.Cookies.Add(cookieOC);
            }

            return RedirectToAction("Index", "Home");

            return View();
        
        }
        //public bool IsAuthenticated
        //{
        //    get
        //    {
        //        return this._context.User != null &&
        //               this._context.User.Identity != null &&
        //               this._context.User.Identity.IsAuthenticated;
        //    }
        //}

        [NonAction]
        private int GetOperationCenter() 
        {
            var cookie = "0";
            if (this.ControllerContext != null)
            {
                if (this.ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("octest"))
                {
                    cookie = this.ControllerContext.HttpContext.Request.Cookies["octest"].Value;
                    Session["oc"] = cookie;
                }
            }

            return Convert.ToInt32(cookie);
        }

    }
}