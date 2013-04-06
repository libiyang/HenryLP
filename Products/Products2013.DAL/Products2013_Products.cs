using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Products2013.DAL
{
    public class Products2013_Products
    {
        public Products2013_Products()
        { }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Products2013_Products");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
            parameters[0].Value = Id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

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
        public int Add(Products2013.Model.Products2013_Products model)
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
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Products2013.Model.Products2013_Products model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Products2013_Products set ");
            strSql.Append("HuoHao=@HuoHao,");
            strSql.Append("LeiBei=@LeiBei,");
            strSql.Append("ProductName=@ProductName,");
            strSql.Append("PriceFactory=@PriceFactory,");
            strSql.Append("PriceSell=@PriceSell,");
            strSql.Append("Size=@Size,");
            strSql.Append("pic=@pic,");
            strSql.Append("Weight=@Weight,");
            strSql.Append("UpdateOn=@UpdateOn");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@HuoHao", SqlDbType.NVarChar,30),
					new SqlParameter("@LeiBei", SqlDbType.NVarChar,30),
					new SqlParameter("@ProductName", SqlDbType.NVarChar,30),
					new SqlParameter("@PriceFactory", SqlDbType.Decimal,9),
					new SqlParameter("@PriceSell", SqlDbType.Decimal,9),
					new SqlParameter("@Size", SqlDbType.NVarChar,100),
					new SqlParameter("@pic", SqlDbType.NVarChar,1000),
					new SqlParameter("@Weight", SqlDbType.Decimal,9),
					new SqlParameter("@UpdateOn", SqlDbType.DateTime),
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = model.HuoHao;
            parameters[1].Value = model.LeiBei;
            parameters[2].Value = model.ProductName;
            parameters[3].Value = model.PriceFactory;
            parameters[4].Value = model.PriceSell;
            parameters[5].Value = model.Size;
            parameters[6].Value = model.pic;
            parameters[7].Value = model.Weight;
            parameters[8].Value = model.UpdateOn;
            parameters[9].Value = model.Id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Products2013_Products ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
            parameters[0].Value = Id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string Idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Products2013_Products ");
            strSql.Append(" where Id in (" + Idlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Products2013.Model.Products2013_Products GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,HuoHao,LeiBei,ProductName,PriceFactory,PriceSell,Size,pic,Weight,UpdateOn from Products2013_Products(nolock) ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
            parameters[0].Value = Id;

            Products2013.Model.Products2013_Products model = new Products2013.Model.Products2013_Products();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Products2013.Model.Products2013_Products DataRowToModel(DataRow row)
        {
            Products2013.Model.Products2013_Products model = new Products2013.Model.Products2013_Products();
            if (row != null)
            {
                if (row["Id"] != null && row["Id"].ToString() != "")
                {
                    model.Id = int.Parse(row["Id"].ToString());
                }
                if (row["HuoHao"] != null)
                {
                    model.HuoHao = row["HuoHao"].ToString();
                }
                if (row["LeiBei"] != null)
                {
                    model.LeiBei = row["LeiBei"].ToString();
                }
                if (row["ProductName"] != null)
                {
                    model.ProductName = row["ProductName"].ToString();
                }
                if (row["PriceFactory"] != null && row["PriceFactory"].ToString() != "")
                {
                    model.PriceFactory = decimal.Parse(row["PriceFactory"].ToString());
                }
                if (row["PriceSell"] != null && row["PriceSell"].ToString() != "")
                {
                    model.PriceSell = decimal.Parse(row["PriceSell"].ToString());
                }
                if (row["Size"] != null)
                {
                    model.Size = row["Size"].ToString();
                }
                if (row["pic"] != null)
                {
                    model.pic = row["pic"].ToString();
                }
                if (row["Weight"] != null && row["Weight"].ToString() != "")
                {
                    model.Weight = decimal.Parse(row["Weight"].ToString());
                }
                if (row["UpdateOn"] != null && row["UpdateOn"].ToString() != "")
                {
                    model.UpdateOn = DateTime.Parse(row["UpdateOn"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,HuoHao,LeiBei,ProductName,PriceFactory,PriceSell,Size,pic,Weight,UpdateOn ");
            strSql.Append(" FROM Products2013_Products(nolock) ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by UpdateOn desc");
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" Id,HuoHao,LeiBei,ProductName,PriceFactory,PriceSell,Size,pic,Weight,UpdateOn ");
            strSql.Append(" FROM Products2013_Products(nolock) ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM Products2013_Products ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.Id desc");
            }
            strSql.Append(")AS Row, T.*  from Products2013_Products T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}
