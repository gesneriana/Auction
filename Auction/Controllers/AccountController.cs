using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Auction.BLL;
using Auction.Model;
using Maticsoft.DBUtility;
using MySql.Data.MySqlClient;

namespace Auction.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(string user = null, string pass = null)
        {
            if (user == null || pass == null)
            {
                return Json(new { userId = -1 }, JsonRequestBehavior.AllowGet);
            }

            MySqlParameter[] param = { new MySqlParameter("@user", user), new MySqlParameter("@pwd", pass) };
            System.Data.DataSet ds = DbHelperMySQL.Query("select user_id,username,userpass,email FROM auction_user where username=@user and userpass=@pwd", param);

            if (ds == null || ds.Tables.Count == 0)
            {
                return Json(new { userId = -2 }, JsonRequestBehavior.AllowGet);
            }

            BLL.auction_user au = new BLL.auction_user();
            List<Auction.Model.auction_user> auList = au.DataTableToList(ds.Tables[0]);
            if (auList.Count != 1)
            {
                return Json(new { userId = -3 }, JsonRequestBehavior.AllowGet);
            }
            
            return Json(new { userId = auList[0].user_id }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 应在登陆之前请求此action,获取唯一的Session标识
        /// </summary>
        /// <returns></returns>
        public ActionResult getSessionID()
        {
            return Content(Session.SessionID);
        }
    }
}