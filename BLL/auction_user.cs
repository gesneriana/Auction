﻿using System;
using System.Data;
using System.Collections.Generic;
using Auction.Common;
using Auction.Model;
namespace Auction.BLL
{
	/// <summary>
	/// auction_user
	/// </summary>
	public partial class auction_user
	{
		private readonly Auction.DAL.auction_user dal=new Auction.DAL.auction_user();
		public auction_user()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int user_id)
		{
			return dal.Exists(user_id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Auction.Model.auction_user model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Auction.Model.auction_user model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int user_id)
		{
			
			return dal.Delete(user_id);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string user_idlist )
		{
			return dal.DeleteList(user_idlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Auction.Model.auction_user GetModel(int user_id)
		{
			
			return dal.GetModel(user_id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Auction.Model.auction_user GetModelByCache(int user_id)
		{
			
			string CacheKey = "auction_userModel-" + user_id;
			object objModel = Auction.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(user_id);
					if (objModel != null)
					{
						int ModelCache = Auction.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Auction.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Auction.Model.auction_user)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Auction.Model.auction_user> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Auction.Model.auction_user> DataTableToList(DataTable dt)
		{
			List<Auction.Model.auction_user> modelList = new List<Auction.Model.auction_user>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Auction.Model.auction_user model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

