using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HenryLP.Model
{
    public class ReportOut
    {
        public ReportOut()
        { }
        #region Model
        private int _id;
        private int _productid = 0;
        private string _huohao = "";
        private string _productname = "";
        private DateTime _reportdate = DateTime.Now;
        private int _amountout = 0;
        private decimal _amountfee = 0M;
        private decimal _pricesell;
        private int _agentid = 0;
        private string _agentname = "";
        private string _leibei = "";
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
        public string HuoHao
        {
            set { _huohao = value; }
            get { return _huohao; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProductName
        {
            set { _productname = value; }
            get { return _productname; }
        }
        public string LeiBei
        {
            set { _leibei = value; }
            get { return _leibei; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime ReportDate
        {
            set { _reportdate = value; }
            get { return _reportdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int AmountOut
        {
            set { _amountout = value; }
            get { return _amountout; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal AmountFee
        {
            set { _amountfee = value; }
            get { return _amountfee; }
        }
        public decimal PriceSell
        {
            set { _pricesell = value; }
            get { return _pricesell; }
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
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        #endregion Model
    }
}
