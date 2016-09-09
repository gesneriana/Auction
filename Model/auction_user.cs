using System;
namespace Auction.Model
{
	/// <summary>
	/// auction_user:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class auction_user
	{
		public auction_user()
		{}
		#region Model
		private int _user_id;
		private string _username;
		private string _userpass;
		private string _email;
		/// <summary>
		/// auto_increment
		/// </summary>
		public int user_id
		{
			set{ _user_id=value;}
			get{return _user_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string username
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string userpass
		{
			set{ _userpass=value;}
			get{return _userpass;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string email
		{
			set{ _email=value;}
			get{return _email;}
		}
		#endregion Model

	}
}

