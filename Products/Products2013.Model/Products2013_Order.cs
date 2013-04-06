using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Products2013.Model
{
    public class Products2013_Order
    {
        public Products2013_Order()
        { }
        #region Model
        private int _id;
        private int _productid = 0;
        private string _productname = "";
        private string _leibei = "";
        private string _huohao = "";
        private DateTime _orderdate = DateTime.Now;
        private int _orderamount = 0;
        private decimal _pricesell = 0M;
        private decimal _amountfee = 0M;
        private int _agentid = 0;
        private string _agentname = "";
        private string _pic = "";
        private string _remark = "";
        /// <summary>
        /// 
        /// </summary>
        public int Id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ProductId
        {
            set { _productid = value; }
            get { return _productid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProductName
        {
            set { _productname = value; }
            get { return _productname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LeiBei
        {
            set { _leibei = value; }
            get { return _leibei; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string HuoHao
        {
            set { _huohao = value; }
            get { return _huohao; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime OrderDate
        {
            set { _orderdate = value; }
            get { return _orderdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int OrderAmount
        {
            set { _orderamount = value; }
            get { return _orderamount; }
        }
        /// <summary>
        /// 实际销售单价
        /// </summary>
        public decimal PriceSell
        {
            set { _pricesell = value; }
            get { return _pricesell; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal AmountFee
        {
            set { _amountfee = value; }
            get { return _amountfee; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int AgentId
        {
            set { _agentid = value; }
            get { return _agentid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string AgentName
        {
            set { _agentname = value; }
            get { return _agentname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string pic
        {
            set { _pic = value; }
            get { return _pic; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        #endregion Model
    }
}
