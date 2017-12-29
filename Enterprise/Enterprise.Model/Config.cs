using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
namespace Enterprise.Model
{
	/// <summary>
	/// 类Config。
	/// </summary>
	[Serializable]
	public partial class Config
	{
		public Config()
		{}
		#region Model
		private int _configid;
		private string _copyright="";
		private string _aboutimgurl="";
		private string _aboutintro="";
		private string _abouturl="";
		private string _newsurl="";
		private string _contactimgurl="";
		private string _contacturl="";
		private string _companyname="";
		private string _address="";
		private int _postcode=0;
		private string _telephone="";
		private string _website="";
		private string _email="";
		private string _producturl="";
		private string _logo;
		/// <summary>
		/// 网站配置编号
		/// </summary>
		public int ConfigId
		{
			set{ _configid=value;}
			get{return _configid;}
		}
		/// <summary>
		/// 版权信息
		/// </summary>
		public string Copyright
		{
			set{ _copyright=value;}
			get{return _copyright;}
		}
		/// <summary>
		/// 关于公司图片链接
		/// </summary>
		public string AboutImgUrl
		{
			set{ _aboutimgurl=value;}
			get{return _aboutimgurl;}
		}
		/// <summary>
		/// 关于公司简介
		/// </summary>
		public string AboutIntro
		{
			set{ _aboutintro=value;}
			get{return _aboutintro;}
		}
		/// <summary>
		/// 关于公司跳转链接
		/// </summary>
		public string AboutUrl
		{
			set{ _abouturl=value;}
			get{return _abouturl;}
		}
		/// <summary>
		/// 新闻动态跳转链接
		/// </summary>
		public string NewsUrl
		{
			set{ _newsurl=value;}
			get{return _newsurl;}
		}
		/// <summary>
		/// 联系方式图片链接
		/// </summary>
		public string ContactImgUrl
		{
			set{ _contactimgurl=value;}
			get{return _contactimgurl;}
		}
		/// <summary>
		/// 联系方式跳转链接
		/// </summary>
		public string ContactUrl
		{
			set{ _contacturl=value;}
			get{return _contacturl;}
		}
		/// <summary>
		/// 公司名称
		/// </summary>
		public string CompanyName
		{
			set{ _companyname=value;}
			get{return _companyname;}
		}
		/// <summary>
		/// 公司地址
		/// </summary>
		public string Address
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// 邮编
		/// </summary>
		public int Postcode
		{
			set{ _postcode=value;}
			get{return _postcode;}
		}
		/// <summary>
		/// 电话
		/// </summary>
		public string Telephone
		{
			set{ _telephone=value;}
			get{return _telephone;}
		}
		/// <summary>
		/// 网址
		/// </summary>
		public string Website
		{
			set{ _website=value;}
			get{return _website;}
		}
		/// <summary>
		/// 邮箱
		/// </summary>
		public string Email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// 公司产品跳转链接
		/// </summary>
		public string ProductUrl
		{
			set{ _producturl=value;}
			get{return _producturl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Logo
		{
			set{ _logo=value;}
			get{return _logo;}
		}
		#endregion Model


	}
}

