using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;  //Data Provider
using spicarrierguideness.Models;

namespace spicarrierguideness.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
         ConnectionManager cm = new ConnectionManager();
         EncryptionManager em = new EncryptionManager();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult homem()
        {
            return View();
        }
        [HttpGet]
        public ActionResult registration()
        {
            CaptchaGenerator cg = new CaptchaGenerator();
            string CaptchaCode = cg.GetCaptchCode();
            ViewBag.code = CaptchaCode;
            return View();
        }
        [HttpPost]
        public ActionResult registration(FormCollection frm)
        {
            FileManager fm = new FileManager();
            string name = frm["txtname"].ToString();
            string qualification=frm["txtqualification"].ToString();
            string address = frm["txtaddress"].ToString();
            string email = frm["txtemail"].ToString();
            string pass = frm["txtpass"].ToString();
            string mobile = frm["txtmob"].ToString();
            string Gender=frm["gender"].ToString();
            string ocode = frm["txtccode"].ToString().Trim();
            string txtcode = frm["txtcaptcha"].ToString().Trim();
            HttpPostedFileBase file=Request.Files["profile"];
              if (ocode == txtcode)
            {
                string mycommand = "insert into tbl_reg values('"+name+"','"
                    +qualification+"','"+email+"','"+em.EncryptData(pass)+"','"+address+"','"+Gender+"','"
                    +mobile+"','"+file.FileName+"','"+DateTime.Now.ToString()+"')";
                bool x = cm.ExecuteInsertUpdateOrDelete(mycommand);
                if (x == true)
                {
                    file.SaveAs(Server.MapPath("../Content/Profiles/" + file.FileName));
                    string command = "insert into tbl_login values('" + email + "','"
                        + em.EncryptData(pass) + "','user')";
                    if (cm.ExecuteInsertUpdateOrDelete(command) == true)
                    {
                        Response.Write("<script>alert('Registration completed successfully ')</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Registration not completed due to some technical problems  ')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Invalid captcha code')</script>");
            }

            return View();
        }
        public ActionResult enquiryc()
        {
            return View();
        }
        [HttpPost]
        public ActionResult enquiryc(string txtname,string txtadd,string txtmob,string txtmsg)
        {
            string command="insert into tbl_contact Values('"+txtname+"','"+txtadd+"','"+txtmob+"','"+txtmsg+"','"+DateTime.Now.ToString()+"')";
            if (cm.ExecuteInsertUpdateOrDelete(command) == true)
            {
                Response.Write("<script>alert('Record Saved')</script>");
            }
            else
            {
                Response.Write("<script>alert('Record not saved')</script>");
            }
            return View();
        }
        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult login(string txtuserid, string txtpass)
        {
            string cmd = "select * from tbl_login where UserId='"
                + txtuserid + "' and Passwd='" + em.EncryptData(txtpass) + "'";
            System.Data.DataTable dt = cm.GetBulkRecord(cmd);
            if (dt.Rows.Count > 0)
            {
                string UserId = dt.Rows[0][0].ToString();
                string Password = dt.Rows[0][1].ToString();
                string utype = dt.Rows[0][2].ToString();
                if ((UserId == txtuserid) && (Password == em.EncryptData(txtpass))&&(utype=="user"))
                {
                    //set email into the session variable
                    Session["uid"] = txtuserid;
                   return RedirectToAction("Index", "User");
                  //  Response.Write("<script>alert('WElcme in next Zone')</script>");
                }
                else if ((UserId == txtuserid) && (Password == em.EncryptData(txtpass)) && (utype == "admin"))
                {
                    //set email for admin into session
                    Session["aid"] = txtuserid;
                    return RedirectToAction("Index", "admin");
                }
                else
                {
                    Response.Write("<script>alert('Invalid UserId or Password')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Invalid UserId or Password')</script>");
            }

            return View();
        }
        public ActionResult imggal()
        {
            return View();
        }
    }
}
