using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Auction.DAL
{
	/// <summary>
	/// 数据访问类:bid
	/// </summary>
	public partial class bid
	{
		public bid()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("bid_id", "bid"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int bid_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from bid");
			strSql.Append(" where bid_id=@bid_id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@bid_id", MySqlDbType.Int32)
			};
			parameters[0].Value = bid_id;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Auction.Model.bid model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into bid(");
			strSql.Append("user_id,item_id,bid_price,bid_date)");
			strSql.Append(" values (");
			strSql.Append("@user_id,@item_id,@bid_price,@bid_date)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@user_id", MySqlDbType.Int32,11),
					new MySqlParameter("@item_id", MySqlDbType.Int32,11),
					new MySqlParameter("@bid_price", MySqlDbType.Double),
					new MySqlParameter("@bid_date", MySqlDbType.Date)};
			parameters[0].Value = model.user_id;
			parameters[1].Value = model.item_id;
			parameters[2].Value = model.bid_price;
			parameters[3].Value = model.bid_date;

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Auction.Model.bid model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update bid set ");
			strSql.Append("user_id=@user_id,");
			strSql.Append("item_id=@item_id,");
			strSql.Append("bid_price=@bid_price,");
			strSql.Append("bid_date=@bid_date");
			strSql.Append(" where bid_id=@bid_id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@user_id", MySqlDbType.Int32,11),
					new MySqlParameter("@item_id", MySqlDbType.Int32,11),
					new MySqlParameter("@bid_price", MySqlDbType.Double),
					new MySqlParameter("@bid_date", MySqlDbType.Date),
					new MySqlParameter("@bid_id", MySqlDbType.Int32,11)};
			parameters[0].Value = model.user_id;
			parameters[1].Value = model.item_id;
			parameters[2].Value = model.bid_price;
			parameters[3].Value = model.bid_date;
			parameters[4].Value = model.bid_id;

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int bid_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from bid ");
			strSql.Append(" where bid_id=@bid_id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@bid_id", MySqlDbType.Int32)
			};
			parameters[0].Value = bid_id;

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string bid_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from bid ");
			strSql.Append(" where bid_id in ("+bid_idlist + ")  ");
			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Auction.Model.bid GetModel(int bid_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select bid_id,user_id,item_id,bid_price,bid_date from bid ");
			strSql.Append(" where bid_id=@bid_id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@bid_id", MySqlDbType.Int32)
			};
			parameters[0].Value = bid_id;

			Auction.Model.bid model=new Auction.Model.bid();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Auction.Model.bid DataRowToModel(DataRow row)
		{
			Auction.Model.bid model=new Auction.Model.bid();
			if (row != null)
			{
				if(row["bid_id"]!=null && row["bid_id"].ToString()!="")
				{
					model.bid_id=int.Parse(row["bid_id"].ToString());
				}
				if(row["user_id"]!=null && row["user_id"].ToString()!="")
				{
					model.user_id=int.Parse(row["user_id"].ToString());
				}
				if(row["item_id"]!=null && row["item_id"].ToString()!="")
				{
					model.item_id=int.Parse(row["item_id"].ToString());
				}
					//model.bid_price=row["bid_price"].ToString();
				if(row["bid_date"]!=null && row["bid_date"].ToString()!="")
				{
					model.bid_date=DateTime.Parse(row["bid_date"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select bid_id,user_id,item_id,bid_price,bid_date ");
			strSql.Append(" FROM bid ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperMySQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM bid ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.bid_id desc");
			}
			strSql.Append(")AS Row, T.*  from bid T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperMySQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			MySqlParameter[] parameters = {
					new MySqlParameter("@tblName", MySqlDbType.VarChar, 255),
					new MySqlParameter("@fldName", MySqlDbType.VarChar, 255),
					new MySqlParameter("@PageSize", MySqlDbType.Int32),
					new MySqlParameter("@PageIndex", MySqlDbType.Int32),
					new MySqlParameter("@IsReCount", MySqlDbType.Bit),
					new MySqlParameter("@OrderType", MySqlDbType.Bit),
					new MySqlParameter("@strWhere", MySqlDbType.VarChar,1000),
					};
			parameters[0].Value = "bid";
			parameters[1].Value = "bid_id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

