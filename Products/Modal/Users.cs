using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HenryLP.Model
{
    public class Users
    {
        public Users()
        { }
        #region Model
        private int _id;
        private string _username = "";
        private string _loginname = "";
        private string _password = "";
        private int _usertype = 0;
        private DateTime _lastlogindate = DateTime.Now;
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
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LoginName
        {
            set { _loginname = value; }
            get { return _loginname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Password
        {
            set { _password = value; }
            get { return _password; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int UserType
        {
            set { _usertype = value; }
            get { return _usertype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime LastLoginDate
        {
            set { _lastlogindate = value; }
            get { return _lastlogindate; }
        }
        #endregion Model
    }
}
