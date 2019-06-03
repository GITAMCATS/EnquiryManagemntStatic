using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDemo1.Models;

namespace MVCDemo1.Controllers
{
    public class EnquiryController : Controller
    {
        // Public to the controller 
        static List<Enquiry> lstEnquries = new List<Enquiry>();

        // GET: Enquiry
        public ActionResult Index()
        {

            return View("Index",lstEnquries);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection frm)
        {
            try
            {
                string email = Request["emailid"].ToString();
                string name = Request["name"].ToString();
                string companyname = Request["companyname"].ToString();

                lstEnquries.Add(new Enquiry { Id =  lstEnquries.Count()+1 , EmailId = email, Name = name, CompanyName = companyname });
                return RedirectToAction("Index");

            }
            catch (Exception ex) { }

            return View();
            
        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            return View(GetEnquiryById(Id));
        }
        [HttpPost]
        public ActionResult Edit(FormCollection frm)
        {
            Enquiry finenqItem = GetEnquiryById(Int32.Parse(frm["Id"]));

            finenqItem.EmailId = Request["emailid"].ToString();
            finenqItem.Name = Request["name"].ToString();
            finenqItem.CompanyName = Request["companyname"].ToString();

            return RedirectToAction("Index");
        }

        // Delete finctionality
        [HttpGet]
        public ActionResult Delete(int Id)
        {
            return View(GetEnquiryById(Id));
        }

        [HttpPost]
        public ActionResult Delete(Enquiry obj)
        {
            int index = lstEnquries.FindIndex(a => a.Id == obj.Id);
            lstEnquries.RemoveAt(index);
            return RedirectToAction("Index");
        }




        private Enquiry GetEnquiryById(int Id)
        {
            Enquiry finenqItem = null;
            foreach (var item in lstEnquries)
            {
                if (item.Id == Id)
                {
                    finenqItem = item;
                }
            }
            return finenqItem;

        }

    }
}