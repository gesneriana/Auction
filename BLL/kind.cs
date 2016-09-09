using System;
using System.Data;
using System.Collections.Generic;
using Auction.Common;
using Auction.Model;
namespace Auction.BLL
{
	/// <summary>
	/// kind
	/// </summary>
	public partial class kind
	{
		private readonly Auction.DAL.kind dal=new Auction.DAL.kind();
		public kind()
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
		public bool Exists(int kind_id)
		{
			return dal.Exists(kind_id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Auction.Model.kind model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Auction.Model.kind model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int kind_id)
		{
			
			return dal.Delete(kind_id);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string kind_idlist )
		{
			return dal.DeleteList(kind_idlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Auction.Model.kind GetModel(int kind_id)
		{
			
			return dal.GetModel(kind_id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Auction.Model.kind GetModelByCache(int kind_id)
		{
			
			string CacheKey = "kindModel-" + kind_id;
			object objModel = Auction.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(kind_id);
					if (objModel != null)
					{
						int ModelCache = Auction.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Auction.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Auction.Model.kind)objModel;
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
		public List<Auction.Model.kind> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Auction.Model.kind> DataTableToList(DataTable dt)
		{
			List<Auction.Model.kind> modelList = new List<Auction.Model.kind>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Auction.Model.kind model;
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

