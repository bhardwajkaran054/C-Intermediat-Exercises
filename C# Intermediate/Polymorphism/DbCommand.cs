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
            string connection;
            string command;

            Console.WriteLine("Enter the connection string: ");
            connection = Console.ReadLine();

            Console.WriteLine("Enter the Command");
            command = Console.ReadLine();

            var dbCommand = new DbCommand(connection, command);

            Console.WriteLine("DbConnection\n1.SQLServer\n2.Oracle");
            var input = Convert.ToInt32(Console.ReadLine());

            if (input == 1)
                dbCommand.Execute(new SqlConnection(connection));
            else if(input == 2)
                dbCommand.Execute(new OracleConnection(connection));
            else
                Console.WriteLine("EnterValidOption");

        }
    }

    public class DbConnection
    {
        protected string connectionString;
        protected DateTime timeout;

        public DbConnection(string ConnectionString)
        {
            if (string.IsNullOrEmpty(ConnectionString))
                throw new ArgumentException("The connection string cant be null or empty");
            this.connectionString = ConnectionString;
            timeout = DateTime.Now.AddSeconds(5);


        }

        public virtual void OpeningConnection()
        {
        }

        public virtual void ClosingConnection()
        {
        }

    }
    public class SqlConnection : DbConnection
    {
        public SqlConnection(string ConnectionString)
            :base(ConnectionString)
        {

        }
        
        public override void OpeningConnection()
        {
            if (timeout < DateTime.Now)
            {
                Console.WriteLine("Connection Timeout...");

            }
            else
                Console.WriteLine("SQL CONNECTION OPEN: Connection String : {0}", connectionString);

        }
        public override void ClosingConnection()
        {
            Console.WriteLine("SQL CONNECTION CLOSED");
        }
    }
    public class OracleConnection : DbConnection
    {
        public OracleConnection(string ConnectionString)
            :base(ConnectionString)
        {

        }
        public override void OpeningConnection()
        {
            if (timeout < DateTime.Now)
            {
                Console.WriteLine("Connection Timeout...");
            }
            else
                Console.WriteLine("ORACLE CONNECTION OPEN: Connection String : {0}", connectionString);

        }
        public override void ClosingConnection()
        {
            Console.WriteLine("ORACLE CONNECTION CLOSED");
        }
    }
    public class DbCommand : DbConnection
    {
        private string _command;

        public DbCommand(string connectionString, string command)
            :base(connectionString)
        {
            if (string.IsNullOrEmpty(command))
                throw new ArgumentException("Command can not be Null or Empty");
            _command = command;
        }

        public void Execute(DbConnection dbConnection)
        {
            dbConnection.OpeningConnection();
            Console.WriteLine("INSTRUCTION EXECUTING...: {0}", _command);
            dbConnection.ClosingConnection();
        }
    }
}
