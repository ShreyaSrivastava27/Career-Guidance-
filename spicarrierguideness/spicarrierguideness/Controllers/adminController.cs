using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using spicarrierguideness.Models;
namespace spicarrierguideness.Controllers
{
    public class adminController : Controller
    {
        //
        // GET: /admin/
        ConnectionManager cm = new ConnectionManager();
        EncryptionManager em = new EncryptionManager();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult newstudent()
        {
            return View();
        }
        public ActionResult delete()
        {
            if (Request.QueryString["dt"] != null)
            {
                string email = Request.QueryString["dt"].ToString();
                string command = "delete from tbl_reg where emailid='" + email + "'";
                if (cm.ExecuteInsertUpdateOrDelete(command))
                {
                    Response.Write("<script>alert('User removed by admin');window.location.href='/admin/newstudent'</script>");
                }
                else
                {
                    Response.Write("<script>alert('User not removed by admin');window.location.href='/admin/newstudent'</script>");
                }
            }

            return View();
        }
        public ActionResult responsemgmt()
        {
            return View();
        }
        public ActionResult Notification()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Notification(string txtmsg)
        {
            string command = "insert into tbl_notification values('" + txtmsg + "','" + DateTime.Now + "')";
            if (cm.ExecuteInsertUpdateOrDelete(command))
            {
                Response.Write("<script>alert('Notification Added')</script>");
            }
            else
            {
                Response.Write("<script>alert('Notification not Added')</script>");
            }
            return View();
        }
        public ActionResult contactmgmt()
        {
            return View();
        }
        public ActionResult deletec()
        {
            if (Request.QueryString["dt"] != null)
            {
                string mob = Request.QueryString["dt"].ToString();
                string command = "delete from tbl_contact where mobno='" + mob + "'";
                if (cm.ExecuteInsertUpdateOrDelete(command))
                {
                    Response.Write("<script>alert('User removed by admin');window.location.href='/admin/contactmgmt'</script>");
                }
                else
                {
                    Response.Write("<script>alert('User not removed by admin');window.location.href='/admin/contactmgmt'</script>");
                }
            }
            return View();
        }
        public ActionResult feedbackmgmt()
        {
            
            return View();
        }
        public ActionResult deletefe()
        {
            if (Request.QueryString["dt"] != null)
            {
                string me = Request.QueryString["dt"].ToString();
                string command = "delete from tbl_feedback where title='" + me + "'";
                if (cm.ExecuteInsertUpdateOrDelete(command))
                {
                    Response.Write("<script>alert('User removed by admin');window.location.href='/admin/feedbackmgmt'</script>");
                }
                else
                {
                    Response.Write("<script>alert('User not removed by admin');window.location.href='/admin/feedbackmgmt'</script>");
                }
            }
            return View();
        }
        public ActionResult changepass()
        {
            return View();
        }
        [HttpPost]
        public ActionResult changepass(string txtold, string txtnew, string txtconfirm)
        {
            if (txtnew == txtconfirm)
            {
                string command = "update tbl_Login set Passwd='" + em.EncryptData(txtnew) + "'where UserId='" + Session["aid"].ToString() + "'and Passwd='" + em.EncryptData(txtold) + "'";
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
        public ActionResult discussionmgmt()
        {
            return View();
        }
        public ActionResult logininfo()
        {
            return View();
        }
        public ActionResult deletel()
        {
            if (Request.QueryString["dt"] != null)
            {
                string id = Request.QueryString["dt"].ToString();
                string command = "delete from tbl_login where UserId='" + id + "'";
                if (cm.ExecuteInsertUpdateOrDelete(command))
                {
                    Response.Write("<script>alert('User removed by admin');window.location.href='/admin/logininfo'</script>");
                }
                else
                {
                    Response.Write("<script>alert('User not removed by admin');window.location.href='/admin/logininfo'</script>");
                }
            }
            return View();
        }
        public ActionResult Logout()
        {
            //destroy the value of session
            Session.Abandon();
            return View();
        }
        public ActionResult notificationmgmt()
        {
            return View();
        }
        public ActionResult deleten()
        {
            if (Request.QueryString["dt"] != null)
            {
                string im = Request.QueryString["dt"].ToString();
                string command = "delete from tbl_notification where nid='" + im + "'";
                if (cm.ExecuteInsertUpdateOrDelete(command))
                {
                    Response.Write("<script>alert('User removed by admin');window.location.href='/admin/notificationmgmt'</script>");
                }
                else
                {
                    Response.Write("<script>alert('User not removed by admin');window.location.href='/admin/notificationmgmt'</script>");
                }
            }
            return View();
        }
    }
}
