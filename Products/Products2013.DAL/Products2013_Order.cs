using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Products2013.DAL
{
    public class Products2013_Order
    {
        public Products2013_Order()
        { }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Products2013_Order");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
            parameters[0].Value = Id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        public DataSet Query(string strSql)
        {
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Products2013.Model.Products2013_Order model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Products2013_Order(");
            strSql.Append("ProductId,ProductName,LeiBei,HuoHao,OrderDate,OrderAmount,PriceSell,AmountFee,AgentId,AgentName,pic,remark)");
            strSql.Append(" values (");
            strSql.Append("@ProductId,@ProductName,@LeiBei,@HuoHao,@OrderDate,@OrderAmount,@PriceSell,@AmountFee,@AgentId,@AgentName,@pic,@remark)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@ProductId", SqlDbType.Int,4),
					new SqlParameter("@ProductName", SqlDbType.NVarChar,30),
					new SqlParameter("@LeiBei", SqlDbType.NVarChar,30),
					new SqlParameter("@HuoHao", SqlDbType.NVarChar,50),
					new SqlParameter("@OrderDate", SqlDbType.DateTime),
					new SqlParameter("@OrderAmount", SqlDbType.Int,4),
					new SqlParameter("@PriceSell", SqlDbType.Decimal,9),
					new SqlParameter("@AmountFee", SqlDbType.Decimal,9),
					new SqlParameter("@AgentId", SqlDbType.Int,4),
					new SqlParameter("@AgentName", SqlDbType.NVarChar,50),
					new SqlParameter("@pic", SqlDbType.NVarChar,1000),
					new SqlParameter("@remark", SqlDbType.NVarChar,250)};
            parameters[0].Value = model.ProductId;
            parameters[1].Value = model.ProductName;
            parameters[2].Value = model.LeiBei;
            parameters[3].Value = model.HuoHao;
            parameters[4].Value = model.OrderDate;
            parameters[5].Value = model.OrderAmount;
            parameters[6].Value = model.PriceSell;
            parameters[7].Value = model.AmountFee;
            parameters[8].Value = model.AgentId;
            parameters[9].Value = model.AgentName;
            parameters[10].Value = model.pic;
            parameters[11].Value = model.remark;

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
        public bool Update(Products2013.Model.Products2013_Order model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Products2013_Order set ");
            strSql.Append("ProductId=@ProductId,");
            strSql.Append("ProductName=@ProductName,");
            strSql.Append("LeiBei=@LeiBei,");
            strSql.Append("HuoHao=@HuoHao,");
            strSql.Append("OrderDate=@OrderDate,");
            strSql.Append("OrderAmount=@OrderAmount,");
            strSql.Append("PriceSell=@PriceSell,");
            strSql.Append("AmountFee=@AmountFee,");
            strSql.Append("AgentId=@AgentId,");
            strSql.Append("AgentName=@AgentName,");
            strSql.Append("pic=@pic,");
            strSql.Append("remark=@remark");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@ProductId", SqlDbType.Int,4),
					new SqlParameter("@ProductName", SqlDbType.NVarChar,30),
					new SqlParameter("@LeiBei", SqlDbType.NVarChar,30),
					new SqlParameter("@HuoHao", SqlDbType.NVarChar,50),
					new SqlParameter("@OrderDate", SqlDbType.DateTime),
					new SqlParameter("@OrderAmount", SqlDbType.Int,4),
					new SqlParameter("@PriceSell", SqlDbType.Decimal,9),
					new SqlParameter("@AmountFee", SqlDbType.Decimal,9),
					new SqlParameter("@AgentId", SqlDbType.Int,4),
					new SqlParameter("@AgentName", SqlDbType.NVarChar,50),
					new SqlParameter("@pic", SqlDbType.NVarChar,1000),
					new SqlParameter("@remark", SqlDbType.NVarChar,250),
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = model.ProductId;
            parameters[1].Value = model.ProductName;
            parameters[2].Value = model.LeiBei;
            parameters[3].Value = model.HuoHao;
            parameters[4].Value = model.OrderDate;
            parameters[5].Value = model.OrderAmount;
            parameters[6].Value = model.PriceSell;
            parameters[7].Value = model.AmountFee;
            parameters[8].Value = model.AgentId;
            parameters[9].Value = model.AgentName;
            parameters[10].Value = model.pic;
            parameters[11].Value = model.remark;
            parameters[12].Value = model.Id;

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
            strSql.Append("delete from Products2013_Order ");
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
            strSql.Append("delete from Products2013_Order ");
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
        public Products2013.Model.Products2013_Order GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,ProductId,ProductName,LeiBei,HuoHao,OrderDate,OrderAmount,PriceSell,AmountFee,AgentId,AgentName,pic,remark from Products2013_Order ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
            parameters[0].Value = Id;

            Products2013.Model.Products2013_Order model = new Products2013.Model.Products2013_Order();
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
        public Products2013.Model.Products2013_Order DataRowToModel(DataRow row)
        {
            Products2013.Model.Products2013_Order model = new Products2013.Model.Products2013_Order();
            if (row != null)
            {
                if (row["Id"] != null && row["Id"].ToString() != "")
                {
                    model.Id = int.Parse(row["Id"].ToString());
                }
                if (row["ProductId"] != null && row["ProductId"].ToString() != "")
                {
                    model.ProductId = int.Parse(row["ProductId"].ToString());
                }
                if (row["ProductName"] != null)
                {
                    model.ProductName = row["ProductName"].ToString();
                }
                if (row["LeiBei"] != null)
                {
                    model.LeiBei = row["LeiBei"].ToString();
                }
                if (row["HuoHao"] != null)
                {
                    model.HuoHao = row["HuoHao"].ToString();
                }
                if (row["OrderDate"] != null && row["OrderDate"].ToString() != "")
                {
                    model.OrderDate = DateTime.Parse(row["OrderDate"].ToString());
                }
                if (row["OrderAmount"] != null && row["OrderAmount"].ToString() != "")
                {
                    model.OrderAmount = int.Parse(row["OrderAmount"].ToString());
                }
                if (row["PriceSell"] != null && row["PriceSell"].ToString() != "")
                {
                    model.PriceSell = decimal.Parse(row["PriceSell"].ToString());
                }
                if (row["AmountFee"] != null && row["AmountFee"].ToString() != "")
                {
                    model.AmountFee = decimal.Parse(row["AmountFee"].ToString());
                }
                if (row["AgentId"] != null && row["AgentId"].ToString() != "")
                {
                    model.AgentId = int.Parse(row["AgentId"].ToString());
                }
                if (row["AgentName"] != null)
                {
                    model.AgentName = row["AgentName"].ToString();
                }
                if (row["pic"] != null)
                {
                    model.pic = row["pic"].ToString();
                }
                if (row["remark"] != null)
                {
                    model.remark = row["remark"].ToString();
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
            strSql.Append("select Id,ProductId,ProductName,LeiBei,HuoHao,OrderDate,OrderAmount,PriceSell,AmountFee,AgentId,AgentName,pic,remark ");
            strSql.Append(" FROM Products2013_Order ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by OrderDate desc ");
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
            strSql.Append(" Id,ProductId,ProductName,LeiBei,HuoHao,OrderDate,OrderAmount,PriceSell,AmountFee,AgentId,AgentName,pic,remark ");
            strSql.Append(" FROM Products2013_Order ");
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
            strSql.Append("select count(1) FROM Products2013_Order ");
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
            strSql.Append(")AS Row, T.*  from Products2013_Order T ");
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
