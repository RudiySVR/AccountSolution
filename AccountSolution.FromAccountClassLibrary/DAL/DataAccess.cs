using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountSolution.FromAccountClassLibrary.DAL
{
    public abstract class DataAccess
    {
        public string ConnectionString { get; set; } = "";

        //private bool _enableCaching = true;
        //protected bool EnableCaching
        //{
        //    get { return _enableCaching; }
        //    set { _enableCaching = value; }
        //}

        //private int _cacheDuration = 0;
        //protected int CacheDuration
        //{
        //    get { return _cacheDuration; }
        //    set { _cacheDuration = value; }
        //}

        //protected Cache Cache
        //{
        //    get { return HttpContext.Current.Cache; }
        //}

        protected int ExecuteNonQuery(DbCommand cmd)
        {
            //Console.WriteLine(cmd.CommandText);
            return cmd.ExecuteNonQuery();
        }

        protected IDataReader ExecuteReader(DbCommand cmd)
        {
            return ExecuteReader(cmd, CommandBehavior.Default);
        }

        protected IDataReader ExecuteReader(DbCommand cmd, CommandBehavior behavior)
        {
            return cmd.ExecuteReader(behavior);
        }

        protected object ExecuteScalar(DbCommand cmd)
        {
            return cmd.ExecuteScalar();
        }
    }
}
