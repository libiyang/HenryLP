using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace UploadSalesFooter
{
    public class DalProducts
    {
        public DalProducts()
        { }
        
        public bool Exists(string HuoHao)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Products2013_Products(nolock)");
            strSql.Append(" where HuoHao=@HuoHao ");
            SqlParameter[] parameters = {
					new SqlParameter("@HuoHao", SqlDbType.NVarChar,30)};
            parameters[0].Value = HuoHao;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ModelProducts model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Products2013_Products(");
            strSql.Append("HuoHao,LeiBei,ProductName,PriceFactory,PriceSell,Size,pic,Weight,UpdateOn)");
            strSql.Append(" values (");
            strSql.Append("@HuoHao,@LeiBei,@ProductName,@PriceFactory,@PriceSell,@Size,@pic,@Weight,@UpdateOn)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@HuoHao", SqlDbType.NVarChar,30),
					new SqlParameter("@LeiBei", SqlDbType.NVarChar,30),
					new SqlParameter("@ProductName", SqlDbType.NVarChar,30),
					new SqlParameter("@PriceFactory", SqlDbType.Decimal,9),
					new SqlParameter("@PriceSell", SqlDbType.Decimal,9),
					new SqlParameter("@Size", SqlDbType.NVarChar,100),
					new SqlParameter("@pic", SqlDbType.NVarChar,1000),
					new SqlParameter("@Weight", SqlDbType.Decimal,9),
					new SqlParameter("@UpdateOn", SqlDbType.DateTime)};
            parameters[0].Value = model.HuoHao;
            parameters[1].Value = model.LeiBei;
            parameters[2].Value = model.ProductName;
            parameters[3].Value = model.PriceFactory;
            parameters[4].Value = model.PriceSell;
            parameters[5].Value = model.Size;
            parameters[6].Value = model.pic;
            parameters[7].Value = model.Weight;
            parameters[8].Value = model.UpdateOn;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
    }
}
