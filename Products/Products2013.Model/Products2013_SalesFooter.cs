using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Products2013.Model
{
    public class Products2013_SalesFooter
    {
        public Products2013_SalesFooter()
        { }
        #region Model
        private int _id;
        private string _scid = "";
        private string _productid = "";
        private string _deschn = "";
        private string _size = "";
        private string _unit = "";
        private string _ccurrency = "";
        private decimal _sellprice = 0M;
        private string _photopath = "";
        /// <summary>
        /// 
        /// </summary>
        public int Id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 外销合同号
        /// </summary>
        public string SCID
        {
            set { _scid = value; }
            get { return _scid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Productid
        {
            set { _productid = value; }
            get { return _productid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DesChn
        {
            set { _deschn = value; }
            get { return _deschn; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Size
        {
            set { _size = value; }
            get { return _size; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Unit
        {
            set { _unit = value; }
            get { return _unit; }
        }
        /// <summary>
        /// 币别
        /// </summary>
        public string Ccurrency
        {
            set { _ccurrency = value; }
            get { return _ccurrency; }
        }
        /// <summary>
        /// 美金售价
        /// </summary>
        public decimal SellPrice
        {
            set { _sellprice = value; }
            get { return _sellprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PhotoPath
        {
            set { _photopath = value; }
            get { return _photopath; }
        }
        #endregion Model
    }
}
