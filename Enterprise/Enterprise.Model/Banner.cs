using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace Enterprise.Model
{
	/// <summary>
	/// 类Banner。
	/// </summary>
	[Serializable]
	public partial class Banner
	{
		public Banner()
		{}
		#region Model
		private int _bannerid;
		private string _imgurl="";
		private string _title="";
		private string _url="";
		private int _status=1;
		private int _sortindex=0;
		/// <summary>
		/// Banner编号
		/// </summary>
		public int BannerId
		{
			set{ _bannerid=value;}
			get{return _bannerid;}
		}
		/// <summary>
		/// 图片路径
		/// </summary>
		public string ImgUrl
		{
			set{ _imgurl=value;}
			get{return _imgurl;}
		}
		/// <summary>
		/// 标题
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
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
		#endregion Model


		
	}
}

