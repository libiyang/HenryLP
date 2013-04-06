using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Collections;

namespace Upload2英冠
{
    public class DbHelperOleDb
    {//数据库连接字符串  

        public static readonly string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=data.mdb";

        // 用于缓存参数的HASH表

        private static Hashtable parmCache = Hashtable.Synchronized(new Hashtable());

        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>影响的记录数</returns>
        public static int ExecuteSql(string SQLString)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                using (OleDbCommand cmd = new OleDbCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        int rows = cmd.ExecuteNonQuery();
                        return rows;
                    }
                    catch (System.Data.OleDb.OleDbException E)
                    {
                        connection.Close();
                        throw new Exception(E.Message);
                    }
                }
            }
        }
        public static int ExecuteSql(string SQLString, params OleDbParameter[] cmdParms)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                        int rows = cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        return rows;
                    }
                    catch (System.Data.OleDb.OleDbException E)
                    {
                        throw new Exception(E.Message);
                    }
                }
            }
        }

        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>DataSet</returns>
        public static DataSet Query(string SQLString)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    OleDbDataAdapter command = new OleDbDataAdapter(SQLString, connection);
                    command.Fill(ds, "ds");
                }
                catch (System.Data.OleDb.OleDbException ex)
                {
                    throw new Exception(ex.Message);
                }
                return ds;
            }
        }

        public static bool Exists(string strSql, params OleDbParameter[] cmdParms)
        {
            object obj = GetSingle(strSql, cmdParms);
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// </summary>
        /// <param name="SQLString">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public static object GetSingle(string SQLString, params OleDbParameter[] cmdParms)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                        object obj = cmd.ExecuteScalar();
                        cmd.Parameters.Clear();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (System.Data.OleDb.OleDbException e)
                    {
                        throw new Exception(e.Message);
                    }
                }
            }
        }

        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>DataSet</returns>
        public static DataSet Query(string SQLString, params OleDbParameter[] cmdParms)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                OleDbCommand cmd = new OleDbCommand();
                PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    try
                    {
                        da.Fill(ds, "ds");
                        cmd.Parameters.Clear();
                    }
                    catch (System.Data.OleDb.OleDbException ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    return ds;
                }
            }
        }

        /// <summary>  
        ///  给定连接的数据库用假设参数执行一个sql命令（不返回数据集）  
        /// </summary>  
        /// <param name="connectionString">一个有效的连接字符串</param>  
        /// <param name="commandText">存储过程名称或者sql命令语句</param>  
        /// <param name="commandParameters">执行命令所用参数的集合</param>  
        /// <returns>执行命令所影响的行数</returns>  
        public static int ExecuteNonQuery(string cmdText, params OleDbParameter[] commandParameters)
        {
            OleDbCommand cmd = new OleDbCommand();
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                PrepareCommand(cmd, conn, null, cmdText, commandParameters);
                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return val;
            }
        }

        public static int ExecuteNonQuery(string cmdText)
        {
            OleDbCommand cmd = new OleDbCommand(cmdText);
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                int val = cmd.ExecuteNonQuery();
                return val;
            }
        }

        /// <summary>  
        /// 用现有的数据库连接执行一个sql命令（不返回数据集）  
        /// </summary>  
        /// <remarks>  
        ///举例:    
        ///  int result = ExecuteNonQuery(connString, "PublishOrders", new OleDbParameter("@prodid", 24));  
        /// </remarks>  
        /// <param name="conn">一个现有的数据库连接</param>  
        /// <param name="commandText">存储过程名称或者sql命令语句</param>  
        /// <param name="commandParameters">执行命令所用参数的集合</param>  
        /// <returns>执行命令所影响的行数</returns>  
        public static int ExecuteNonQuery(OleDbConnection connection, string cmdText, params OleDbParameter[] commandParameters)
        {
            OleDbCommand cmd = new OleDbCommand();
            PrepareCommand(cmd, connection, null, cmdText, commandParameters);
            int val = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return val;
        }

        /// <summary>  
        /// 用执行的数据库连接执行一个返回数据集的sql命令  
        /// </summary>  
        /// <remarks>  
        /// 举例:    
        ///  OleDbDataReader r = ExecuteReader(connString, "PublishOrders", new OleDbParameter("@prodid", 24));  
        /// </remarks>  
        /// <param name="connectionString">一个有效的连接字符串</param>  
        /// <param name="commandText">存储过程名称或者sql命令语句</param>  
        /// <param name="commandParameters">执行命令所用参数的集合</param>  
        /// <returns>包含结果的读取器</returns>  
        public static OleDbDataReader ExecuteReader(string cmdText, params OleDbParameter[] commandParameters)
        {
            //创建一个SqlCommand对象  
            OleDbCommand cmd = new OleDbCommand();
            //创建一个SqlConnection对象  
            OleDbConnection conn = new OleDbConnection(connectionString);
            //在这里我们用一个try/catch结构执行sql文本命令/存储过程，因为如果这个方法产生一个异常我们要关闭连接，因为没有读取器存在，  
            //因此commandBehaviour.CloseConnection 就不会执行  
            try
            {
                //调用 PrepareCommand 方法，对 SqlCommand 对象设置参数  
                PrepareCommand(cmd, conn, null, cmdText, commandParameters);
                //调用 SqlCommand  的 ExecuteReader 方法  
                OleDbDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                //清除参数  
                cmd.Parameters.Clear();
                return reader;
            }
            catch
            {
                //关闭连接，抛出异常  
                conn.Close();
                throw;
            }
        }

        /// <summary>  
        /// 返回一个DataSet数据集  
        /// </summary>  
        /// <param name="connectionString">一个有效的连接字符串</param>  
        /// <param name="cmdText">存储过程名称或者sql命令语句</param>  
        /// <param name="commandParameters">执行命令所用参数的集合</param>  
        /// <returns>包含结果的数据集</returns>  
        public static DataSet ExecuteDataSet(string cmdText, params OleDbParameter[] commandParameters)
        {
            //创建一个SqlCommand对象，并对其进行初始化  
            OleDbCommand cmd = new OleDbCommand();
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                PrepareCommand(cmd, conn, null, cmdText, commandParameters);
                //创建SqlDataAdapter对象以及DataSet  
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataSet ds = new DataSet();
                try
                {
                    //填充ds  
                    da.Fill(ds);
                    // 清除cmd的参数集合   
                    cmd.Parameters.Clear();
                    //返回ds  
                    return ds;
                }
                catch
                {
                    //关闭连接，抛出异常  
                    conn.Close();
                    throw;
                }
            }
        }

        /// <summary>  
        /// 用指定的数据库连接字符串执行一个命令并返回一个数据集的第一列  
        /// </summary>  
        /// <remarks>  
        ///例如:    
        ///  Object obj = ExecuteScalar(connString, "PublishOrders", new OleDbParameter("@prodid", 24));  
        /// </remarks>  
        ///<param name="connectionString">一个有效的连接字符串</param>  
        /// <param name="commandText">存储过程名称或者sql命令语句</param>  
        /// <param name="commandParameters">执行命令所用参数的集合</param>  
        /// <returns>用 Convert.To{Type}把类型转换为想要的 </returns>  
        public static object ExecuteScalar(string cmdText, params OleDbParameter[] commandParameters)
        {
            OleDbCommand cmd = new OleDbCommand();
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                PrepareCommand(cmd, connection, null, cmdText, commandParameters);
                object val = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                return val;
            }
        }

        /// <summary>  
        /// 用指定的数据库连接执行一个命令并返回一个数据集的第一列  
        /// </summary>  
        /// <remarks>  
        /// 例如:    
        ///  Object obj = ExecuteScalar(connString, "PublishOrders", new OleDbParameter("@prodid", 24));  
        /// </remarks>  
        /// <param name="conn">一个存在的数据库连接</param>  
        /// <param name="commandText">存储过程名称或者sql命令语句</param>  
        /// <param name="commandParameters">执行命令所用参数的集合</param>  
        /// <returns>用 Convert.To{Type}把类型转换为想要的 </returns>  
        public static object ExecuteScalar(OleDbConnection connection, string cmdText, params OleDbParameter[] commandParameters)
        {
            OleDbCommand cmd = new OleDbCommand();
            PrepareCommand(cmd, connection, null, cmdText, commandParameters);
            object val = cmd.ExecuteScalar();
            cmd.Parameters.Clear();
            return val;
        }

        /// <summary>  
        /// 将参数集合添加到缓存  
        /// </summary>  
        /// <param name="cacheKey">添加到缓存的变量</param>  
        /// <param name="cmdParms">一个将要添加到缓存的sql参数集合</param>  
        public static void CacheParameters(string cacheKey, params OleDbParameter[] commandParameters)
        {
            parmCache[cacheKey] = commandParameters;
        }

        /// <summary>  
        /// 找回缓存参数集合  
        /// </summary>  
        /// <param name="cacheKey">用于找回参数的关键字</param>  
        /// <returns>缓存的参数集合</returns>  
        public static OleDbParameter[] GetCachedParameters(string cacheKey)
        {
            OleDbParameter[] cachedParms = (OleDbParameter[])parmCache[cacheKey];
            if (cachedParms == null)
                return null;
            OleDbParameter[] clonedParms = new OleDbParameter[cachedParms.Length];
            for (int i = 0, j = cachedParms.Length; i < j; i++)
                clonedParms = (OleDbParameter[])((ICloneable)cachedParms).Clone();
            return clonedParms;
        }

        /// <summary>  
        /// 准备执行一个命令  
        /// </summary>  
        /// <param name="cmd">sql命令</param>  
        /// <param name="conn">Sql连接</param>  
        /// <param name="trans">Sql事务</param>  
        /// <param name="cmdText">命令文本,例如：Select * from Products</param>  
        /// <param name="cmdParms">执行命令的参数</param>  
        private static void PrepareCommand(OleDbCommand cmd, OleDbConnection conn, OleDbTransaction trans, string cmdText, OleDbParameter[] cmdParms)
        {
            //判断连接的状态。如果是关闭状态，则打开  
            if (conn.State != ConnectionState.Open)

                conn.Open();

            //cmd属性赋值  
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            //是否需要用到事务处理  
            if (trans != null)
                cmd.Transaction = trans;
            cmd.CommandType = CommandType.Text;
            //添加cmd需要的存储过程参数  
            if (cmdParms != null)
            {
                foreach (OleDbParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
        }

    }
}
