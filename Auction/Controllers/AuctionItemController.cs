using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Auction.Common;

namespace Auction.Controllers
{
    public class AuctionItemController : Controller
    {
        // GET: AuctionItem
        public ActionResult Failure()
        {
            System.Data.DataSet ds = Maticsoft.DBUtility.DbHelperMySQL.Query("select * from item where state_id=3;");

            if (ds == null || ds.Tables.Count == 0)
            {
                return Content("null");
            }

            BLL.item item = new BLL.item();
            List<Model.item> itemList = item.DataTableToList(ds.Tables[0]);
            if (itemList.Count == 0)
            {
                return Content("null");
            }

            return Json(itemList, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 查看当前用户的竞标成功的物品
        /// state_id=2
        /// </summary>
        /// <returns></returns>
        public ActionResult Success(int userid=0)
        {
            if (userid <= 0)
            {
                return Content("-1");
            }
            BLL.item bi = new BLL.item();
            List<Model.item> miList = bi.GetModelList("state_id=2 and winer_id=" + userid);
            if (miList != null && miList.Count > 0)
            {
                return Json(miList, JsonRequestBehavior.AllowGet);
            }
            return Content("-2");
        }

        /// <summary>
        /// 查看当前用户处于拍卖中的所有物品
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public ActionResult ViewOwnerItem(int userid = 0)
        {
            if (userid == 0)
            {
                return Content("-1");
            }
            try
            {
                System.Data.DataSet ds = Maticsoft.DBUtility.DbHelperMySQL.Query("select * from item where state_id=1 and owner_id=@userid", new MySql.Data.MySqlClient.MySqlParameter("@userid", userid));
                if (ds != null && ds.Tables.Count > 0)
                {
                    List<Model.item> miList = new BLL.item().DataTableToList(ds.Tables[0]);
                    if (miList != null && miList.Count > 0)
                    {
                        return Json(miList, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Content("-3");
                    }
                }
                else
                {
                    return Content("-2");
                }
            }
            catch (Exception e)
            {
                return Content("-4");
            }
        }


        /// <summary>
        /// 添加拍卖品
        /// </summary>
        /// <param name="item_name"></param>
        /// <param name="item_desc"></param>
        /// <param name="item_remark"></param>
        /// <param name="init_price"></param>
        /// <param name="kind_id"></param>
        /// <param name="availTime"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        public ActionResult AddItem(string item_name = "", string item_desc = "", string item_remark = "",
            double init_price = 0, int kind_id = 0, int availTime = 0, int userid = 0)
        {
            if (item_name.Trim().Equals("") || item_desc.Trim().Equals("") || item_remark.Trim().Equals("")
                || init_price == 0 || kind_id == 0 || availTime == 0 || userid == 0)
            {
                return Content("参数错误");   // 参数错误
            }
            Model.item mi = new Model.item();
            mi.addtime = DateTime.Now;
            mi.EndTime = mi.addtime.AddDays(availTime);
            mi.init_price = init_price;
            mi.item_desc = item_desc;
            mi.item_name = item_name;
            mi.item_remark = item_remark;
            mi.kind_id = kind_id;
            mi.max_price = mi.init_price;
            mi.owner_id = userid;
            mi.state_id = 1;

            BLL.item bi = new BLL.item();
            bool b = bi.Add(mi);
            if (b)
            {
                return Content("添加成功:");
            }
            else { return Content("添加失败"); }
        }


        /// <summary>
        /// 根据拍卖品种类id返回 JSON数组
        /// </summary>
        /// <param name="kid"></param>
        /// <returns></returns>
        [ActionName(name: "ItemByKid")]
        public ActionResult ViewAuctionItemByKindId(int kid = 0)
        {
            if (kid <= 0) { return Content("-1"); }

            BLL.item bi = new BLL.item();
            List<Model.item> miList = bi.GetModelList("state_id=1 and kind_id=" + kid);    // state_id=1
            if (miList != null && miList.Count > 0)
            {
                return Json(miList, JsonRequestBehavior.AllowGet);
            }
            return Content("-2");
        }

        /// <summary>
        /// 根据指定的拍卖品编号 (主键) 获取拍卖品信息
        /// </summary>
        /// <param name="item_id"></param>
        /// <returns></returns>
        [ActionName(name: "getItemById")]
        public ActionResult ViewAuctionItemById(int itemid = 0)
        {
            if (itemid <= 0)
            {
                return Content("-1");
            }
            BLL.item bi = new BLL.item();
            Model.item mi = bi.GetModel(itemid);
            if (mi != null)
            {
                DataCache.SetCache("item_id_" + mi.item_id, mi);
                return Json(mi, JsonRequestBehavior.AllowGet);
            }
            return Content("-2");
        }

        /// <summary>
        /// 竞价
        /// 这里没有判断拍卖品的 state_id 
        /// 以及 是否 到期 还有竞价值是否大于当前价格
        /// 还有寄卖的主人编号
        /// </summary>
        /// <param name="item_id"></param>
        /// <param name="userid"></param>
        /// <param name="bidPrice"></param>
        /// <returns></returns>
        public ActionResult AddBid(int item_id = 0, int userid = 0, double bidPrice = 0)
        {
            if (item_id <= 0 || userid <= 0 || bidPrice <= 0)
            {
                return Content("参数错误");
            }
            // 先从缓存中查找 拍卖品
            Model.item mi = DataCache.GetCache("item_id_" + item_id) == null ? null : (Model.item)DataCache.GetCache("item_id_" + item_id);

            BLL.item bi = new BLL.item();
            // 缓存中没找到
            if (mi == null)
            {
                // 从数据库找
                mi = bi.GetModel(item_id);
                // 数据库找到了拍卖品
                if (mi != null)
                {
                    DataCache.SetCache("item_id_" + mi.item_id, mi);
                    if (mi.max_price >= bidPrice)
                    {
                        return Content("竞价应该高于当前最高价");
                    }

                    // 更新竞价
                    mi.max_price = bidPrice;
                    mi.owner_id = userid;
                    mi.addtime = DateTime.Now;
                    bool b = bi.Update(mi);
                    if (b)
                    {
                        return Content("竞价成功");
                    }
                    else
                    {
                        return Content("竞价失败");
                    }
                }
                else
                {
                    return Content("错误的拍卖品编号");
                }
            }
            else
            {
                // 从缓存中找到拍卖品,多数是从缓存中找到的
                if (mi.max_price >= bidPrice)
                {
                    return Content("竞价应该高于当前最高价");
                }

                // 更新竞价
                mi.max_price = bidPrice;
                mi.winer_id = userid;
                mi.addtime = DateTime.Now;
                bool b = bi.Update(mi);
                if (b)
                {
                    return Content("竞价成功!");
                }
                else
                {
                    return Content("竞价失败!");
                }
            }
        }

        /// <summary>
        /// 查看当前用户竞标的拍卖品列表
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public ActionResult ViewBid(int userid=0)
        {
            if (userid <= 0)
            {
                return Content("-1");
            }
            BLL.item bi = new BLL.item();
            List<Model.item> miList = bi.GetModelList("state_id=1 and winer_id=" + userid);
            if (miList != null && miList.Count >= 0)
            {
                return Json(miList, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Content("-2");
            }
        }
    }
}