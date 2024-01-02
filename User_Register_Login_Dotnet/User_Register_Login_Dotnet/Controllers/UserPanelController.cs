 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using User_Register_Login_Dotnet.Models;



namespace User_Register_Login_Dotnet.Controllers
{
    public class UserPanelController : Controller
    {
        Dbcontext db = new Dbcontext();
        // GET: UserPanel
        public ActionResult Index()
        {
            return View();
        }
    
        [HttpGet]
        public ActionResult Login(string email)
        {
            var row = db.GetUser().FirstOrDefault(model => model.Emailid == email);
            return View(row);

        }


        [HttpPost]
        public ActionResult Login(UserModel um)
        {
            var data = db.GetUser().Where(model => model.Emailid == um.Emailid && model.Password == um.Password).FirstOrDefault();
            if(data != null)
            {
                Session["uid"] = um.Emailid;
                return RedirectToAction("welcome");
            }
            else
            { 
                ViewBag.Showmsg = "Invalid EmailId or Password!!";
                ModelState.Clear();

            }
            return View();

        }


        public ActionResult Welcome()
        {

            var row = db.GetbyId(Session["uid"].ToString());
            
            return View(row);
        }
        

        public ActionResult Create ()
        {
            return View();

        }


        [HttpPost]
        public ActionResult Create(UserModel um)
        {
            db.Add(um);
            return RedirectToAction("Login");

        }
  


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = db.GetUser().Where(x => x.ID == id).FirstOrDefault();
            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(UserModel um)
        {

            db.Update(um);

            return RedirectToAction("Welcome");
        }

        public ActionResult Logout()
        {

            Session.Clear();

            return RedirectToAction("Login");
        }

    }

}