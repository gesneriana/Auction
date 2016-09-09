using System;
namespace Auction.Model
{
	/// <summary>
	/// state:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class state
	{
		public state()
		{}
		#region Model
		private int _state_id;
		private string _state_name;
		/// <summary>
		/// auto_increment
		/// </summary>
		public int state_id
		{
			set{ _state_id=value;}
			get{return _state_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string state_name
		{
			set{ _state_name=value;}
			get{return _state_name;}
		}
		#endregion Model

	}
}

