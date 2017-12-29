using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
namespace Enterprise.Model
{
	/// <summary>
	/// 类Feedback。
	/// </summary>
	[Serializable]
	public partial class Feedback
	{
		public Feedback()
		{}
		#region Model
		private int _msgid;
		private string _name="";
		private string _email="";
		private long _qq=0;
		private string _msg="";
		private DateTime _createdate= DateTime.Now;
		private int _status=1;
		private string _replymsg="";
		private int _replyuserid=0;
		private DateTime _replydate= DateTime.Now;
		/// <summary>
		/// 留言编号
		/// </summary>
		public int MsgId
		{
			set{ _msgid=value;}
			get{return _msgid;}
		}
		/// <summary>
		/// 留言人姓名
		/// </summary>
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 留言人Email
		/// </summary>
		public string Email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// 留言人QQ
		/// </summary>
		public long QQ
		{
			set{ _qq=value;}
			get{return _qq;}
		}
		/// <summary>
		/// 留言内容
		/// </summary>
		public string Msg
		{
			set{ _msg=value;}
			get{return _msg;}
		}
		/// <summary>
		/// 留言日期
		/// </summary>
		public DateTime CreateDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		/// <summary>
		/// 状态 0不显示 1显示
		/// </summary>
		public int Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 回复内容
		/// </summary>
		public string ReplyMsg
		{
			set{ _replymsg=value;}
			get{return _replymsg;}
		}
		/// <summary>
		/// 回复用户编号
		/// </summary>
		public int ReplyUserId
		{
			set{ _replyuserid=value;}
			get{return _replyuserid;}
		}
		/// <summary>
		/// 回复日期
		/// </summary>
		public DateTime ReplyDate
		{
			set{ _replydate=value;}
			get{return _replydate;}
		}
		#endregion Model

	}
}

