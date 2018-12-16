using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.ADODataAccessLayer
{
    public class BaseClass
    {
        protected string _connString;
        public BaseClass():this (ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString)
        {
        }

        public BaseClass(string connectionString)
        {
            _connString = connectionString;
        }
    }
}
