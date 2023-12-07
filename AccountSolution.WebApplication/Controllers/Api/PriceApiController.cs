using AccountSolution.FromAccountClassLibrary.Entities;
using AccountSolution.SqliteClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace AccountSolution.WebApplication.Controllers.Api
{
    public class PriceApiController : ApiController
    {
        SqlitePriceProvider db = new SqlitePriceProvider("web");

        // GET: api/PriceApi
        //public IEnumerable<string> Get()
        public IEnumerable<Price> Get()
        {
            string path = AppDomain.CurrentDomain.GetData("DataDirectory").ToString();
            //db.ConnectionString = "D:\\VS\\VS2017\\AccountSolution\\AccountSolution.WebApplication\\App_Data\\FromAccount.db";
            db.ConnectionString = AppDomain.CurrentDomain.GetData("DataDirectory").ToString() + "\\FromAccount.db";
            //db.ConnectionString = HttpContext.Current.Server.MapPath("~/App_Data/FromAccount.db");
            return db.GetPrice().Where(p => p.StockPriceGroupeID != 0).OrderBy(p => p.Stock).Take(15);
        }

        // GET: api/PriceApi/5
        public Price Get(string id)
        {
            db.ConnectionString = HttpContext.Current.Server.MapPath("~/App_Data/FromAccount.db");
            return db.GetPrice().Where(p => p.StockCounter == id).FirstOrDefault();
        }

        // POST: api/PriceApi
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/PriceApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/PriceApi/5
        public void Delete(int id)
        {
        }
    }
}
