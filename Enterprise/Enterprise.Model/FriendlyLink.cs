using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
namespace Enterprise.Model
{
	/// <summary>
	/// 类FriendlyLink。
	/// </summary>
	[Serializable]
	public partial class FriendlyLink
	{
		public FriendlyLink()
		{}
		#region Model
		private int _linkid;
		private string _name="";
		private string _url="";
		private int _status=1;
		private int _sortindex=0;
		private string _imgurl;
		/// <summary>
		/// 友情链接编号
		/// </summary>
		public int LinkId
		{
			set{ _linkid=value;}
			get{return _linkid;}
		}
		/// <summary>
		/// 链接显示名称
		/// </summary>
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 跳转链接
		/// </summary>
		public string Url
		{
			set{ _url=value;}
			get{return _url;}
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
		/// 排序
		/// </summary>
		public int SortIndex
		{
			set{ _sortindex=value;}
			get{return _sortindex;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ImgUrl
		{
			set{ _imgurl=value;}
			get{return _imgurl;}
		}
		#endregion Model


	}
}

