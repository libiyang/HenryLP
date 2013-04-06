using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Upload2英冠
{
    public class DalProducts
    {
        public DalProducts()
        { }
        
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ModelProducts model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Products(");
            strSql.Append("HuoHao,LeiBei,ProductName,Agent,AgentIds,PriceFactory,PriceSell,AmountKc,AmountOut,Size,Remark,pic,UpdateOn,Weight,AmountXM,AmountHZ)");
            strSql.Append(" values (");
            strSql.Append("@HuoHao,@LeiBei,@ProductName,@Agent,@AgentIds,@PriceFactory,@PriceSell,@AmountKc,@AmountOut,@Size,@Remark,@pic,@UpdateOn,@Weight,@AmountXM,@AmountHZ)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@HuoHao", SqlDbType.NVarChar,30),
					new SqlParameter("@LeiBei", SqlDbType.NVarChar,30),
					new SqlParameter("@ProductName", SqlDbType.NVarChar,30),
					new SqlParameter("@Agent", SqlDbType.NVarChar,400),
					new SqlParameter("@AgentIds", SqlDbType.NVarChar,100),
					new SqlParameter("@PriceFactory", SqlDbType.Decimal,9),
					new SqlParameter("@PriceSell", SqlDbType.Decimal,9),
					new SqlParameter("@AmountKc", SqlDbType.Int,4),
					new SqlParameter("@AmountOut", SqlDbType.Int,4),
					new SqlParameter("@Size", SqlDbType.NVarChar,100),
					new SqlParameter("@Remark", SqlDbType.NVarChar,250),
					new SqlParameter("@pic", SqlDbType.NVarChar,1000),
					new SqlParameter("@UpdateOn", SqlDbType.DateTime),
					new SqlParameter("@Weight", SqlDbType.Decimal,9),
					new SqlParameter("@AmountXM", SqlDbType.Int,4),
					new SqlParameter("@AmountHZ", SqlDbType.Int,4)};
            parameters[0].Value = model.HuoHao;
            parameters[1].Value = model.LeiBei;
            parameters[2].Value = model.ProductName;
            parameters[3].Value = model.Agent;
            parameters[4].Value = model.AgentIds;
            parameters[5].Value = model.PriceFactory;
            parameters[6].Value = model.PriceSell;
            parameters[7].Value = model.AmountKc;
            parameters[8].Value = model.AmountOut;
            parameters[9].Value = model.Size;
            parameters[10].Value = model.Remark;
            parameters[11].Value = model.pic;
            parameters[12].Value = model.UpdateOn;
            parameters[13].Value = model.Weight;
            parameters[14].Value = model.AmountXM;
            parameters[15].Value = model.AmountHZ;

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

        public ModelProducts GetModel(string HuoHao)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from Products(nolock) ");
            strSql.Append(" where HuoHao=@HuoHao");
            SqlParameter[] parameters = {
					new SqlParameter("@HuoHao", SqlDbType.NVarChar,30)};
            parameters[0].Value = HuoHao;

            ModelProducts model = new ModelProducts();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                model.HuoHao = ds.Tables[0].Rows[0]["HuoHao"].ToString();
                model.LeiBei = ds.Tables[0].Rows[0]["LeiBei"].ToString();
                model.ProductName = ds.Tables[0].Rows[0]["ProductName"].ToString();
                model.Agent = ds.Tables[0].Rows[0]["Agent"].ToString();
                model.AgentIds = ds.Tables[0].Rows[0]["AgentIds"].ToString();
                if (ds.Tables[0].Rows[0]["PriceFactory"].ToString() != "")
                {
                    model.PriceFactory = decimal.Parse(ds.Tables[0].Rows[0]["PriceFactory"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PriceSell"].ToString() != "")
                {
                    model.PriceSell = decimal.Parse(ds.Tables[0].Rows[0]["PriceSell"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AmountKc"].ToString() != "")
                {
                    model.AmountKc = int.Parse(ds.Tables[0].Rows[0]["AmountKc"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AmountOut"].ToString() != "")
                {
                    model.AmountOut = int.Parse(ds.Tables[0].Rows[0]["AmountOut"].ToString());
                }
                model.Size = ds.Tables[0].Rows[0]["Size"].ToString();
                model.Remark = ds.Tables[0].Rows[0]["Remark"].ToString();
                model.pic = ds.Tables[0].Rows[0]["pic"].ToString();
                if (ds.Tables[0].Rows[0]["UpdateOn"].ToString() != "")
                {
                    model.UpdateOn = DateTime.Parse(ds.Tables[0].Rows[0]["UpdateOn"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Weight"].ToString() != "")
                {
                    model.Weight = decimal.Parse(ds.Tables[0].Rows[0]["Weight"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AmountXM"].ToString() != "")
                {
                    model.AmountXM = int.Parse(ds.Tables[0].Rows[0]["AmountXM"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AmountHZ"].ToString() != "")
                {
                    model.AmountHZ = int.Parse(ds.Tables[0].Rows[0]["AmountHZ"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        public bool UpdateAmountXM(ModelProducts model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Products set ");
            strSql.Append("AmountXM=@AmountXM");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@AmountXM", SqlDbType.Int,4),
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = model.AmountXM;
            parameters[1].Value = model.Id;

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
    }
}
