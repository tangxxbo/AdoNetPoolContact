using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNetPoolContact
{
    class Program
    {
        static void Main(string[] args)
        {
            //SqlConnectionStringBuilder cnstr = new SqlConnectionStringBuilder();
            //cnstr.DataSource = ".";
            //cnstr.InitialCatalog = "Frame";
            //cnstr.UserID = "txx1557";
            //cnstr.Password = "123";
            //cnstr.MaxPoolSize = 5;

            //for (int i = 0; i < 10; i++)
            //{
            //    SqlConnection conn = new SqlConnection(cnstr.ToString());
            //    conn.Open();
            //    Console.WriteLine($"第{i+1}次连接");
            //}

            //禁用连接池证明
            //SqlConnectionStringBuilder cnstr = new SqlConnectionStringBuilder();
            //cnstr.DataSource = ".";
            //cnstr.InitialCatalog = "Frame";
            //cnstr.UserID = "txx1557";
            //cnstr.Password = "123";
            //cnstr.MaxPoolSize = 5;
            //cnstr.Pooling = false;
            //for (int i = 0; i < 10; i++)
            //{
            //    SqlConnection conn = new SqlConnection(cnstr.ToString());
            //    conn.Open();
            //    Console.WriteLine($"第{i + 1}次连接");
            //}

            //不启用连接池耗时证明
            //string cnsql0 = "server=.;database=Frame;uid=txx1557;pwd=123;Pooling=false";
            //Stopwatch sw = new Stopwatch();
            //sw.Start();
            ////SqlConnectionStringBuilder cnstr = new SqlConnectionStringBuilder();
            ////cnstr.DataSource = ".";
            ////cnstr.InitialCatalog = "Frame";
            ////cnstr.UserID = "txx1557";
            ////cnstr.Password = "123";
            ////cnstr.Pooling = false;
            //for (int i = 0; i < 100; i++)
            //{
            //    SqlConnection conn = new SqlConnection(cnsql0);
            //    conn.Open();
            //    //Console.WriteLine($"第{i + 1}次连接");
            //    conn.Close();
            //}
            //sw.Stop();
            //Console.WriteLine($"不启用连接池耗时{sw.ElapsedMilliseconds}ms");

            ////启用连接池耗时证明
            //Stopwatch sw1 = new Stopwatch();
            //sw1.Start();
            //string cnsql1 = "server=.;database=Frame;uid=txx1557;pwd=123";
            ////SqlConnectionStringBuilder cnstr1 = new SqlConnectionStringBuilder();
            ////cnstr1.DataSource = ".";
            ////cnstr1.InitialCatalog = "Frame";
            ////cnstr1.UserID = "txx1557";
            ////cnstr1.Password = "123";
            //for (int j = 0; j < 100; j++)
            //{
            //    SqlConnection conn = new SqlConnection(cnsql1);
            //    conn.Open();
            //    //Console.WriteLine($"第{i + 1}次连接");
            //    conn.Close();
            //}
            //sw1.Stop();
            //Console.WriteLine($"启用连接池耗时{sw1.ElapsedMilliseconds}ms");

            ////字符串内容相同的连接池会公用1个连接池，当超过5次，就会终止
            ////下面3个字符串，因为1和3的内容相同所以共用1个连接池，导致在第3次循环的时候，会报错
            //string connsql1 = "server=.;database=Frame;uid=txx1557;pwd=123;Max Pool Size=5;";
            //string connsql2 = "server=.;database=Frame; uid=txx1557;pwd=123;Max Pool Size=5;";
            //string connsql3 = "server=.;database=Frame;uid=txx1557;pwd=123;Max Pool Size=5;";
            //for (int i = 0; i < 5; i++)
            //{
            //    SqlConnection conn1 = new SqlConnection(connsql1);
            //    conn1.Open();
            //    Console.WriteLine($"conn1 第{i + 1}次连接");
            //    SqlConnection conn2 = new SqlConnection(connsql2);
            //    conn2.Open();
            //    Console.WriteLine($"conn2第{i + 1}次连接");
            //    SqlConnection conn3 = new SqlConnection(connsql3);
            //    conn3.Open();
            //    Console.WriteLine($"conn3第{i + 1}次连接");
            //}

            //Console.ReadKey();
            string connSql = ConfigurationManager.ConnectionStrings["connSql"].ConnectionString;
            try
            {
                int dataCount;
                using (SqlConnection conn =new SqlConnection(connSql)) {
                
                    //创建对SQL语句执行的命令SqlCommand对象
                    {
                        ////1.
                        //SqlCommand sc = new SqlCommand();
                        //sc.Connection = conn;
                        //sc.CommandText = "select * from student";
                        ////sc.CommandType=sc.CommandText;  这是sql查询语句没必要这样设置
                        //sc.CommandType = CommandType.StoredProcedure;//这是存储过程必须得这样设置




                        ////2.
                        //string sql1 = "select * from student";
                        //SqlCommand sc1 = new SqlCommand(sql1);
                        //sc1.Connection = conn;

                        //string uCode = "1000000";
                        //string uName = "陈年";
                        //int uSex = 1;
                        //string uaddress = "湖南长沙宁乡大道";
                        //int uAge = 13;
                        //string uInte = "Internet Game";
                        //string uTeach = "胡志明";
                        ////拼接的SQL语句
                        //string iSql = "insert into dbo.student(code,name,sex,address,age,interesting,classteacher)" +
                        //    "values('"+ uCode + "','"+uName+ "','"+ uSex + "','"+ uaddress + "','"+ uAge + "','"+ uInte + "','"+ uTeach + "')";
                        ////适用增删改的SQL语句 DML语句
                        //conn.Open();
                        //int dataCount =  sc1.ExecuteNonQuery();


                        //sc1.ExecuteScalar();
                        //sc1.ExecuteReader();

                        ////3
                        //string sql2 = "select * from student";
                        //SqlCommand sc2 = new SqlCommand(sql2,conn);

                        ////4
                        //string sql3 = "select * from student";
                        //SqlCommand sc3 = conn.CreateCommand();
                        //sc3.CommandText = sql3;
                        ////5
                        //string sql4 = "select * from student";
                        //SqlCommand sc4 = new SqlCommand(sql2, conn,null);
                    }

                    //string sql1 = "select * from student";
                    //SqlCommand sc1 = new SqlCommand(sql1);
                    //sc1.Connection = conn;
                    
                    string uCode = "1000000";
                    string uName = "陈年";
                    int uSex = 1;
                    string uaddress = "湖南长沙宁乡大道";
                    int uAge = 13;
                    string uInte = "Internet Game";
                    string uTeach = "胡志明";
                    //拼接的SQL语句
                    string iSql = "insert into student(code,name,sex,address,age,interesting,classteacher)" +
                        "values('" + uCode + "','" + uName + "','" + uSex + "','" + uaddress + "','" + uAge + "','" + uInte + "','" + uTeach + "')";
                    //适用增删改的SQL语句 DML语句
                    SqlCommand sc2 = new SqlCommand(iSql,conn);
                    conn.Open();
                    dataCount = sc2.ExecuteNonQuery();
                    conn.Close();
                }
                if (dataCount>0)
                {
                    Console.WriteLine("数据插入成功");
                }
                Console.ReadKey();
            }
            catch (SqlException ex)
            {

                throw ex;
            }


        }
    }
}
