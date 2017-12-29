using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
namespace Enterprise.Model
{
	/// <summary>
	/// 类UserInfo。
	/// </summary>
	[Serializable]
	public partial class UserInfo
	{
		public UserInfo()
		{}
		#region Model
		private int _userid;
		private string _username="";
		private string _password="";
		private string _realname="";
		private string _phone="";
		private int _usertype=2;
		private int _status=1;
		private DateTime _createdate= DateTime.Now;
		/// <summary>
		/// 用户编号
		/// </summary>
		public int UserId
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 用户名
		/// </summary>
		public string Username
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 密码
		/// </summary>
		public string Password
		{
			set{ _password=value;}
			get{return _password;}
		}
		/// <summary>
		/// 真实姓名
		/// </summary>
		public string RealName
		{
			set{ _realname=value;}
			get{return _realname;}
		}
		/// <summary>
		/// 手机号
		/// </summary>
		public string Phone
		{
			set{ _phone=value;}
			get{return _phone;}
		}
		/// <summary>
		/// 用户类型 1超级管理员 2网站管理员
		/// </summary>
		public int UserType
		{
			set{ _usertype=value;}
			get{return _usertype;}
		}
		/// <summary>
		/// 状态 0禁用 1启用
		/// </summary>
		public int Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 创建日期
		/// </summary>
		public DateTime CreateDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
        #endregion Model

        #region Extension Properties
        public string StatusName { get; set; }
        #endregion
    }
}

