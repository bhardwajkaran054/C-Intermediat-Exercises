using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbConnection
{
    class Program
    {
        static void Main(string[] args)
        {
           
            do
            {
                Console.WriteLine("DbConnection:\n1.Sql Server\n2.Oracle Sql\n3.Exit");
                int dbConnectionOption = Convert.ToInt32(Console.ReadLine());
                switch (dbConnectionOption)
                {
                    case 1:
                        var sqlconnection = new SqlConnection("c:\\");
                        while (true)
                        {
                            Console.WriteLine("SQL Server:\n1.Open Connection\n2.Close Connection\n3.Exit");
                            int sqlServerOption = Convert.ToInt32(Console.ReadLine());
                            if (sqlServerOption == 1)
                                sqlconnection.OpeningConnection();
                            else if (sqlServerOption == 2)
                                sqlconnection.ClosingConnection();
                            else
                                break;
                        }
                        break;
                    case 2:
                        var oracleconnection = new OracleConnection("c:\\");
                        while (true)
                        {
                            Console.WriteLine("Oracle SQL:\n1.Open Connection\n2.Close Connection\n3.Exit");
                            int oracleSqlOption = Convert.ToInt32(Console.ReadLine());
                            if (oracleSqlOption == 1)
                                oracleconnection.OpeningConnection();
                            else if (oracleSqlOption == 2)
                                oracleconnection.ClosingConnection();
                            else
                                break;
                        }
                        break;
                    default:
                        break;
                }
                if (dbConnectionOption == 3)
                    break;
            } while (true);
        }
    }

    public abstract class DbConnection
    {
        protected string connectionString;
        protected DateTime timeout;

        public DbConnection(string ConnectionString)
        {
            if(string.IsNullOrEmpty(ConnectionString))
                throw new ArgumentException("The connection string cant be null or empty");
            this.connectionString = ConnectionString;
            timeout = DateTime.Now.AddSeconds(5);
            
            
        }

        public abstract void OpeningConnection();

        public abstract void ClosingConnection();
        
    }
    public class SqlConnection : DbConnection
    {
        public SqlConnection(string connectionString)
            :base(connectionString)
        {

        }
        public override void OpeningConnection()
        {
            if (timeout < DateTime.Now)
            {
                Console.WriteLine("Connection Timeout...");
                
            }
            else
                Console.WriteLine("Connection Open, Connection String : {0}", connectionString);
            
        }
        public override void ClosingConnection()
        {
            Console.WriteLine("Connection Closed.");
        }
    }
    public class OracleConnection : DbConnection
    {
        public OracleConnection(string connectionString)
            :base(connectionString)
        {

        }
        public override void OpeningConnection()
        {
            if (timeout < DateTime.Now)
            {
                Console.WriteLine("Connection Timeout...");
            }
            else
                Console.WriteLine("Connection Open, Connection String : {0}", connectionString);
           
        }
        public override void ClosingConnection()
        {
            Console.WriteLine("Connection Closed.");
        }
    }
}
