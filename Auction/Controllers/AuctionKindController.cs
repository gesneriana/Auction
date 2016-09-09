using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Auction.BLL;
using Maticsoft.DBUtility;
using System.ComponentModel;

namespace Auction.Controllers
{
    /// <summary>
    /// 拍卖品种类
    /// </summary>
    public class AuctionKindController : Controller
    {
        /// <summary>
        /// 查看拍卖品种类
        /// </summary>
        /// <returns></returns>
        [ActionName(name:"kind")]
        public ActionResult ViewAuctionItemKind()
        {
            BLL.kind bk = new kind();
            List<Model.kind> mk = bk.GetModelList("");
            if (mk != null && mk.Count > 0)
            {
                return Json(mk, JsonRequestBehavior.AllowGet);
            }
            return Content("null");
        }

        /// <summary>
        /// 添加拍卖品种类
        /// </summary>
        /// <param name="kind_name"></param>
        /// <param name="kind_desc"></param>
        /// <returns></returns>
        [ActionName(name: "addKind")]
        public ActionResult AddAuctionKind(string kind_name = "", string kind_desc = "")
        {
            if (!kind_name.Trim().Equals("") && !kind_desc.Trim().Equals(""))
            {
                Model.kind k = new Model.kind();
                k.kind_name = kind_name;
                k.kind_desc = kind_desc;
                BLL.kind bk = new kind();
                bool b= bk.Add(k);
                if (b)
                {
                    return Content("添加成功");
                }
                else
                {
                    return Content("添加失败");
                }
            }
            else
            {
                return Content("参数错误,添加失败");
            }
        }

    }
}