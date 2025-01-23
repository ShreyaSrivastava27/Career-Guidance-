using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using spicarrierguideness.Models;
using System.Data;

namespace spicarrierguideness.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/
        ConnectionManager cm = new ConnectionManager();
        EncryptionManager em = new EncryptionManager();
        public ActionResult Index()
        {
            if (Session["uid"] != null)
            {
                string email = Session["uid"].ToString();
                string command = "select * from tbl_reg where emailid='" +
                    email + "'";
                System.Data.DataTable dt = cm.GetBulkRecord(command);
                if (dt.Rows.Count > 0)
                {
                    string name = dt.Rows[0][0].ToString();
                    string picname = "../Content/Profiles/" + dt.Rows[0][7].ToString();
                    ViewBag.nm = name;
                    ViewBag.profile = picname;
                }

            }
            else
            {
                return RedirectToAction("login", "Home");
            }

            return View();
        }
        public ActionResult whatsnew()
        {
            if (Session["uid"] != null)
            {
                string email = Session["uid"].ToString();
                string command = "select * from tbl_reg where emailid='" +
                    email + "'";
                System.Data.DataTable dt = cm.GetBulkRecord(command);
                if (dt.Rows.Count > 0)
                {
                    string name = dt.Rows[0][0].ToString();
                    string picname = "../Content/Profiles/" + dt.Rows[0][7].ToString();
                    ViewBag.nm = name;
                    ViewBag.profile = picname;
                }

            }
            else
            {
                return RedirectToAction("login", "Home");
            }
            return View();
        }
        public ActionResult Feedback()
        {
            if (Session["uid"] != null)
            {
                string email = Session["uid"].ToString();
                string command = "select * from tbl_reg where emailid='" +
                    email + "'";
                System.Data.DataTable dt = cm.GetBulkRecord(command);
                if (dt.Rows.Count > 0)
                {
                    string name = dt.Rows[0][0].ToString();
                    string picname = "../Content/Profiles/" + dt.Rows[0][7].ToString();
                    ViewBag.nm = name;
                    ViewBag.profile = picname;
                }

            }
            else
            {
                return RedirectToAction("login", "Home");
            }
            return View();
        }
        [HttpPost]
        public ActionResult Feedback(string txttitle,string txtfed)
        {
            if (Session["uid"] != null)
            {
                string email = Session["uid"].ToString();
                string command = "select * from tbl_reg where emailid='" +
                    email + "'";
                System.Data.DataTable dt = cm.GetBulkRecord(command);
                if (dt.Rows.Count > 0)
                {
                    string name = dt.Rows[0][0].ToString();
                    string picname = "../Content/Profiles/" + dt.Rows[0][7].ToString();
                    ViewBag.nm = name;
                    ViewBag.profile = picname;
                }

            }
            else
            {
                return RedirectToAction("login", "Home");
            }
            string mycommand = "insert into tbl_feedback values('" + txttitle + "','" + txtfed + "','"+DateTime.Now.ToString()+"')";
            if (cm.ExecuteInsertUpdateOrDelete(mycommand) == true)
            {
                Response.Write("<script>alert('Record saved')</script>");
            }
            else
            {
                Response.Write("<script>alert('Record not saved')</script>");
            }
            return View();
        }
        public ActionResult Myprofile()
        {
            if (Session["uid"] != null)
            {
                string email = Session["uid"].ToString();
                string command = "select * from tbl_reg where emailid='" +
                    email + "'";
                System.Data.DataTable dt = cm.GetBulkRecord(command);
                if (dt.Rows.Count > 0)
                {
                    string name = dt.Rows[0][0].ToString();
                    string picname = "../Content/Profiles/" + dt.Rows[0][7].ToString();
                    ViewBag.nm = name;
                    ViewBag.profile = picname;

                    ViewBag.mob = dt.Rows[0][6].ToString();
                    ViewBag.email = dt.Rows[0][2].ToString();
                    ViewBag.add = dt.Rows[0][4].ToString();
                }

            }
            else
            {
                return RedirectToAction("login", "Home");
            }
            return View();
        }
        [HttpPost]
        public ActionResult Myprofile(string txtname, string txtemail, string txtmobile, string txtadd)
        {
            HttpPostedFileBase file = Request.Files["fufile"];
            string filename = file.FileName;
            string command = "update tbl_reg set name='" + txtname + "',emailid='" + txtemail + "',address='" + txtadd + "',mobno='" + txtmobile + "',profile='" + file.FileName + "' where emailid='" + Session["uid"].ToString() + "'";
            bool x = cm.ExecuteInsertUpdateOrDelete(command);
            if (x == true)
            {

                file.SaveAs(Server.MapPath("../Content/Profiles/" + file.FileName));

                Response.Write("<script>alert('Your profile updated successfully');window.location.href='/User/Logout'</script>");

            }
            else
            {
                Response.Write("<script>alert('Your profile is not updated');</script>");
            }
            return View();
        }
        public ActionResult changepassword()
        {
            if (Session["uid"] != null)
            {
                string email = Session["uid"].ToString();
                string command = "select * from tbl_reg where emailid='" +
                    email + "'";
                System.Data.DataTable dt = cm.GetBulkRecord(command);
                if (dt.Rows.Count > 0)
                {
                    string name = dt.Rows[0][0].ToString();
                    string picname = "../Content/Profiles/" + dt.Rows[0][7].ToString();
                    ViewBag.nm = name;
                    ViewBag.profile = picname;
                }

            }
            else
            {
                return RedirectToAction("login", "Home");
            }
            return View();
        }
        [HttpPost]
        public ActionResult changepassword(string txtold, string txtnew, string txtconfirm)
        {
            if (txtnew == txtconfirm)
            {
                string command = "update tbl_Login set Passwd='" + em.EncryptData(txtnew) + "'where UserId='" + Session["uid"].ToString() + "'and Passwd='" + em.EncryptData(txtold) + "'";
                bool x = cm.ExecuteInsertUpdateOrDelete(command);
                if (x == true)
                {
                    Response.Write("<script>alert('Password change successfully');window.location.href='/Home/Login'</script>");
                }
                else
                {
                    Response.Write("<script>alert('Your password not changed')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Plz Confirm password')</script>");
            }

            return View();
        }
        public ActionResult logout()
        {
            //destroy the value of session
            Session.Abandon();
            return View();
        }
        public ActionResult commerce()
        {
            if (Session["uid"] != null)
            {
                string email = Session["uid"].ToString();
                string command = "select * from tbl_reg where emailid='" +
                    email + "'";
                System.Data.DataTable dt = cm.GetBulkRecord(command);
                if (dt.Rows.Count > 0)
                {
                    string name = dt.Rows[0][0].ToString();
                    string picname = "../Content/Profiles/" + dt.Rows[0][7].ToString();
                    ViewBag.nm = name;
                    ViewBag.profile = picname;
                }

            }
            else
            {
                return RedirectToAction("login", "Home");
            }
            return View();
        }
        public ActionResult arthumanitie()
        {
            if (Session["uid"] != null)
            {
                string email = Session["uid"].ToString();
                string command = "select * from tbl_reg where emailid='" +
                    email + "'";
                System.Data.DataTable dt = cm.GetBulkRecord(command);
                if (dt.Rows.Count > 0)
                {
                    string name = dt.Rows[0][0].ToString();
                    string picname = "../Content/Profiles/" + dt.Rows[0][7].ToString();
                    ViewBag.nm = name;
                    ViewBag.profile = picname;
                }

            }
            else
            {
                return RedirectToAction("login", "Home");
            }

            return View();
        }
        public ActionResult discussion()
        {
            if (Session["uid"] != null)
            {
                string email = Session["uid"].ToString();
                string command = "select * from tbl_reg where emailid='" +
                    email + "'";
                System.Data.DataTable dt = cm.GetBulkRecord(command);
                if (dt.Rows.Count > 0)
                {
                    string name = dt.Rows[0][0].ToString();
                    string picname = "../Content/Profiles/" + dt.Rows[0][7].ToString();
                    ViewBag.nm = name;
                    ViewBag.profile = picname;
                }

            }
            else
            {
                return RedirectToAction("login", "Home");
            }
            return View();
        }
        [HttpPost]
        public ActionResult Discussion(string txtquestion)
        {
            string mycommand = "insert into tbl_question values('" + txtquestion + "','" + Session["uid"].ToString() + "','" + DateTime.Now.ToString() + "')";
            if (cm.ExecuteInsertUpdateOrDelete(mycommand) == true)
            {
                Response.Write("<script>alert('Question posted successfully')</script>");
            }
            else
            {
                Response.Write("<script>alert('Question not posted')</script>");
            }
            if (Session["uid"] != null)
            {
                string email = Session["uid"].ToString();
                string command = "select * from tbl_reg where emailid='" +
                    email + "'";
                System.Data.DataTable dt = cm.GetBulkRecord(command);
                if (dt.Rows.Count > 0)
                {
                    string name = dt.Rows[0][0].ToString();
                    string picname = "../Content/Profiles/" + dt.Rows[0][7].ToString();
                    ViewBag.nm = name;
                    ViewBag.profile = picname;
                }

            }
            else
            {
                return RedirectToAction("login", "Home");
            }
            return View();

        }
        
        public ActionResult answer()
        {


            int qid = int.Parse(Request.QueryString["aid"]);
            TempData["qd"] = qid;



            if (Session["uid"] != null)
            {
                string email = Session["uid"].ToString();
                string command = "select * from tbl_reg where emailid='" +
                    email + "'";
                System.Data.DataTable dt = cm.GetBulkRecord(command);
                if (dt.Rows.Count > 0)
                {
                    string name = dt.Rows[0][0].ToString();
                    string picname = "../Content/Profiles/" + dt.Rows[0][7].ToString();
                    ViewBag.nm = name;
                    ViewBag.profile = picname;
                }

            }
            else
            {
                return RedirectToAction("login", "Home");
            }
            

            return View();
        }
        public ActionResult Viewans()
        {
            if (Session["uid"] != null)
            {
                string email = Session["uid"].ToString();
                string command = "select * from tbl_reg where emailid='" +
                    email + "'";
                System.Data.DataTable dt = cm.GetBulkRecord(command);
                if (dt.Rows.Count > 0)
                {
                    string name = dt.Rows[0][0].ToString();
                    string picname = "../Content/Profiles/" + dt.Rows[0][7].ToString();
                    ViewBag.nm = name;
                    ViewBag.profile = picname;
                }

            }
            else
            {
                return RedirectToAction("login", "Home");
            }
            return View();
        }
        [HttpPost]
        public ActionResult answer(string txtanswer)
        {

            string qid = TempData["qd"].ToString();

            string command = "insert into tbl_answer values('" + qid + "','" + txtanswer + "','" + Session["uid"].ToString() + "','" + DateTime.Now + "')";
            if (cm.ExecuteInsertUpdateOrDelete(command))
            {
                Response.Write("<script>alert('Answer posted successfully');window.location.href='/User/Discussion'</script>");
            }
            else
            {
                Response.Write("<script>alert('Answer not posted');window.location.href='/User/answer'</script>");
            }

            return View();
        }

        public ActionResult pvtsevt()
        {
            if (Session["uid"] != null)
            {
                string email = Session["uid"].ToString();
                string command = "select * from tbl_reg where emailid='" +
                    email + "'";
                System.Data.DataTable dt = cm.GetBulkRecord(command);
                if (dt.Rows.Count > 0)
                {
                    string name = dt.Rows[0][0].ToString();
                    string picname = "../Content/Profiles/" + dt.Rows[0][7].ToString();
                    ViewBag.nm = name;
                    ViewBag.profile = picname;
                }

            }
            else
            {
                return RedirectToAction("login", "Home");
            }

            return View();
        }
        public ActionResult govtsect()
        {
            if (Session["uid"] != null)
            {
                string email = Session["uid"].ToString();
                string command = "select * from tbl_reg where emailid='" +
                    email + "'";
                System.Data.DataTable dt = cm.GetBulkRecord(command);
                if (dt.Rows.Count > 0)
                {
                    string name = dt.Rows[0][0].ToString();
                    string picname = "../Content/Profiles/" + dt.Rows[0][7].ToString();
                    ViewBag.nm = name;
                    ViewBag.profile = picname;
                }

            }
            else
            {
                return RedirectToAction("login", "Home");
            }
            return View();
        }
        public ActionResult pcm()
        {
            if (Session["uid"] != null)
            {
                string email = Session["uid"].ToString();
                string command = "select * from tbl_reg where emailid='" +
                    email + "'";
                System.Data.DataTable dt = cm.GetBulkRecord(command);
                if (dt.Rows.Count > 0)
                {
                    string name = dt.Rows[0][0].ToString();
                    string picname = "../Content/Profiles/" + dt.Rows[0][7].ToString();
                    ViewBag.nm = name;
                    ViewBag.profile = picname;
                }

            }
            else
            {
                return RedirectToAction("login", "Home");
            }
            return View();
        }
        public ActionResult pcb()
        {
            if (Session["uid"] != null)
            {
                string email = Session["uid"].ToString();
                string command = "select * from tbl_reg where emailid='" +
                    email + "'";
                System.Data.DataTable dt = cm.GetBulkRecord(command);
                if (dt.Rows.Count > 0)
                {
                    string name = dt.Rows[0][0].ToString();
                    string picname = "../Content/Profiles/" + dt.Rows[0][7].ToString();
                    ViewBag.nm = name;
                    ViewBag.profile = picname;
                }

            }
            else
            {
                return RedirectToAction("login", "Home");
            }

            return View();
        }
    }
}
