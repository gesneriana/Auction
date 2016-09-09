﻿using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Auction.DAL
{
	/// <summary>
	/// 数据访问类:state
	/// </summary>
	public partial class state
	{
		public state()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("state_id", "state"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int state_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from state");
			strSql.Append(" where state_id=@state_id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@state_id", MySqlDbType.Int32)
			};
			parameters[0].Value = state_id;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Auction.Model.state model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into state(");
			strSql.Append("state_name)");
			strSql.Append(" values (");
			strSql.Append("@state_name)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@state_name", MySqlDbType.VarChar,10)};
			parameters[0].Value = model.state_name;

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
		public bool Update(Auction.Model.state model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update state set ");
			strSql.Append("state_name=@state_name");
			strSql.Append(" where state_id=@state_id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@state_name", MySqlDbType.VarChar,10),
					new MySqlParameter("@state_id", MySqlDbType.Int32,11)};
			parameters[0].Value = model.state_name;
			parameters[1].Value = model.state_id;

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
		public bool Delete(int state_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from state ");
			strSql.Append(" where state_id=@state_id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@state_id", MySqlDbType.Int32)
			};
			parameters[0].Value = state_id;

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
		public bool DeleteList(string state_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from state ");
			strSql.Append(" where state_id in ("+state_idlist + ")  ");
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
		public Auction.Model.state GetModel(int state_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select state_id,state_name from state ");
			strSql.Append(" where state_id=@state_id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@state_id", MySqlDbType.Int32)
			};
			parameters[0].Value = state_id;

			Auction.Model.state model=new Auction.Model.state();
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
		public Auction.Model.state DataRowToModel(DataRow row)
		{
			Auction.Model.state model=new Auction.Model.state();
			if (row != null)
			{
				if(row["state_id"]!=null && row["state_id"].ToString()!="")
				{
					model.state_id=int.Parse(row["state_id"].ToString());
				}
				if(row["state_name"]!=null)
				{
					model.state_name=row["state_name"].ToString();
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
			strSql.Append("select state_id,state_name ");
			strSql.Append(" FROM state ");
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
			strSql.Append("select count(1) FROM state ");
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
				strSql.Append("order by T.state_id desc");
			}
			strSql.Append(")AS Row, T.*  from state T ");
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
			parameters[0].Value = "state";
			parameters[1].Value = "state_id";
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

