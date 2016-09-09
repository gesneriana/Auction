using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Auction.DAL
{
	/// <summary>
	/// 数据访问类:kind
	/// </summary>
	public partial class kind
	{
		public kind()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("kind_id", "kind"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int kind_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from kind");
			strSql.Append(" where kind_id=@kind_id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@kind_id", MySqlDbType.Int32)
			};
			parameters[0].Value = kind_id;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Auction.Model.kind model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into kind(");
			strSql.Append("kind_name,kind_desc)");
			strSql.Append(" values (");
			strSql.Append("@kind_name,@kind_desc)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@kind_name", MySqlDbType.VarChar,50),
					new MySqlParameter("@kind_desc", MySqlDbType.VarChar,255)};
			parameters[0].Value = model.kind_name;
			parameters[1].Value = model.kind_desc;

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
		public bool Update(Auction.Model.kind model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update kind set ");
			strSql.Append("kind_name=@kind_name,");
			strSql.Append("kind_desc=@kind_desc");
			strSql.Append(" where kind_id=@kind_id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@kind_name", MySqlDbType.VarChar,50),
					new MySqlParameter("@kind_desc", MySqlDbType.VarChar,255),
					new MySqlParameter("@kind_id", MySqlDbType.Int32,11)};
			parameters[0].Value = model.kind_name;
			parameters[1].Value = model.kind_desc;
			parameters[2].Value = model.kind_id;

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
		public bool Delete(int kind_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from kind ");
			strSql.Append(" where kind_id=@kind_id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@kind_id", MySqlDbType.Int32)
			};
			parameters[0].Value = kind_id;

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
		public bool DeleteList(string kind_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from kind ");
			strSql.Append(" where kind_id in ("+kind_idlist + ")  ");
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
		public Auction.Model.kind GetModel(int kind_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select kind_id,kind_name,kind_desc from kind ");
			strSql.Append(" where kind_id=@kind_id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@kind_id", MySqlDbType.Int32)
			};
			parameters[0].Value = kind_id;

			Auction.Model.kind model=new Auction.Model.kind();
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
		public Auction.Model.kind DataRowToModel(DataRow row)
		{
			Auction.Model.kind model=new Auction.Model.kind();
			if (row != null)
			{
				if(row["kind_id"]!=null && row["kind_id"].ToString()!="")
				{
					model.kind_id=int.Parse(row["kind_id"].ToString());
				}
				if(row["kind_name"]!=null)
				{
					model.kind_name=row["kind_name"].ToString();
				}
				if(row["kind_desc"]!=null)
				{
					model.kind_desc=row["kind_desc"].ToString();
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
			strSql.Append("select kind_id,kind_name,kind_desc ");
			strSql.Append(" FROM kind ");
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
			strSql.Append("select count(1) FROM kind ");
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
				strSql.Append("order by T.kind_id desc");
			}
			strSql.Append(")AS Row, T.*  from kind T ");
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
			parameters[0].Value = "kind";
			parameters[1].Value = "kind_id";
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

