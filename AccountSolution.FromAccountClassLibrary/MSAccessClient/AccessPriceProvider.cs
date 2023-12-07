using AccountSolution.FromAccountClassLibrary.DAL;
using AccountSolution.FromAccountClassLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountSolution.FromAccountClassLibrary.MSAccessClient
{
    public class AccessPriceProvider : PriceProvider
    {
        public AccessPriceProvider()
        {
            this.ConnectionString = "Provider =";
            this.ConnectionString += ConfigurationManager.ConnectionStrings["AccountContextAccess"].ProviderName + ";";
            this.ConnectionString += ConfigurationManager.ConnectionStrings["AccountContextAccess"].ConnectionString;
        }


        /// <summary>
        /// Returns a collection with all the categories
        /// </summary>
        public override List<PriceGroup> GetPriceGroup()
        {
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {
                //OleDbCommand cmd = new OleDbCommand("select * from PriceGroup WHERE ((PriceGroup.Internet)=True)", cn);
                OleDbCommand cmd = new OleDbCommand("select * from PriceGroup where Internet=true", cn)
                {
                    CommandType = CommandType.Text
                };
                cn.Open();
                return GetPriceGroupCollectionFromReader(ExecuteReader(cmd));
            }
        }

        public override List<PriceGroup> GetPriceGroupAll()
        {
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {
                //OleDbCommand cmd = new OleDbCommand("select * from PriceGroup WHERE ((PriceGroup.Internet)=True)", cn);
                OleDbCommand cmd = new OleDbCommand("select * from PriceGroup", cn)
                {
                    CommandType = CommandType.Text
                };
                cn.Open();
                return GetPriceGroupCollectionFromReader(ExecuteReader(cmd));
            }
        }

        public override int InsertPriceGroup(PriceGroup category)
        {
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {
                string sqlCmd = "INSERT INTO PriceGroup ";
                sqlCmd += "(GroupID, GroupName, ParentID, ParentName, Internet, Path, Pict) VALUES ";
                sqlCmd += "(@GroupID, @GroupName, @ParentID, @ParentName, @Internet, @Path, @Pict);";
                OleDbCommand cmd = new OleDbCommand(sqlCmd, cn)
                {
                    CommandType = CommandType.Text
                };
                cmd.Parameters.Add("@GroupID", OleDbType.VarChar).Value = category.GroupID;
                cmd.Parameters.Add("@GroupName", OleDbType.VarChar).Value = category.GroupName;
                cmd.Parameters.Add("@ParentID", OleDbType.VarChar).Value = category.ParentID;
                cmd.Parameters.Add("@ParentName", OleDbType.VarChar).Value = category.ParentName;
                cmd.Parameters.Add("@Internet", OleDbType.Boolean).Value = category.Internet;
                cmd.Parameters.Add("@Path", OleDbType.VarChar).Value = category.Path;
                cmd.Parameters.Add("@Pict", OleDbType.VarChar).Value = category.Pict;
                //cmd.Parameters.Add("@CategoryID", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return ret;
            }
        }

        public override List<Price> GetPrice()
        {
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {
                //OleDbCommand cmd = new OleDbCommand("select NumbGroup, StockPriceGroupeID, StockCounter, Stock, FullName, CountForPack, ValueForCount, Character, PriceForCount from Price", cn)
                OleDbCommand cmd = new OleDbCommand("PriceAll", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cn.Open();
                return GetPriceCollectionFromReader(ExecuteReader(cmd));
            }
        }

        public override int InsertPrice(Price Price)
        {
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {
                string sqlCmd = "INSERT INTO Price ";
                //sqlCmd += "(NumbGroup, StockPriceGroupeID, StockCounter, Stock, FullName, CountForPack, ValueForCount, Character, PriceForCount) VALUES ";
                //sqlCmd += "(@NumbGroup, @StockPriceGroupeID, @StockCounter, @Stock, @FullName, @CountForPack, @ValueForCount, @Character, @PriceForCount);";
                sqlCmd += "(NumbGroup, StockPriceGroupeID, StockCounter, Stock, FullName, CountForPack, ValueForCount, PriceForCount) VALUES ";
                sqlCmd += "(@NumbGroup, @StockPriceGroupeID, @StockCounter, @Stock, @FullName, @CountForPack, @ValueForCount, @PriceForCount);";
                OleDbCommand cmd = new OleDbCommand(sqlCmd, cn)
                {
                    CommandType = CommandType.Text
                };
                cmd.Parameters.Add("@NumbGroup", OleDbType.VarChar).Value = Price.NumbGroup;
                cmd.Parameters.Add("@StockPriceGroupeID", OleDbType.Integer).Value = Price.StockPriceGroupeID;
                cmd.Parameters.Add("@StockCounter", OleDbType.VarChar).Value = Price.StockCounter;
                cmd.Parameters.Add("@Stock", OleDbType.VarChar).Value = Price.Stock;
                cmd.Parameters.Add("@FullName", OleDbType.VarChar).Value = Price.FullName;
                cmd.Parameters.Add("@CountForPack", OleDbType.Double).Value = Price.CountForPack;
                cmd.Parameters.Add("@ValueForCount", OleDbType.VarChar).Value = Price.ValueForCount;
                //cmd.Parameters.Add("@Character", OleDbType.VarChar).Value = "Add";
                //if (Price.Character.Length == 0)
                //{
                //    cmd.Parameters.Add("@Character", OleDbType.VarChar).Value = "-";
                //}
                //else
                //{
                //    cmd.Parameters.Add("@Character", OleDbType.VarChar).Value = Price.Character;
                //}
                cmd.Parameters.Add("@PriceForCount", OleDbType.Double).Value = Price.PriceForCount;
                //cmd.Parameters.Add("@CategoryID", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return ret;

            }
        }

        public override List<ShortPrice> GetShortPrice()
        {
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {
                OleDbCommand cmd = new OleDbCommand("select * from ShortPrice", cn)
                {
                    CommandType = CommandType.Text
                };
                cn.Open();
                return GetShortPriceCollectionFromReader(ExecuteReader(cmd));
            }
        }

        public override int InsertShortPrice(ShortPrice ShortPrice)
        {
            throw new NotImplementedException();
        }

        public override bool DeletePriceGroupAll()
        {
            throw new NotImplementedException();
        }

        public override bool DeletePriceAll()
        {
            throw new NotImplementedException();
        }

        public override bool DeleteShortPriceAll()
        {
            throw new NotImplementedException();
        }

        public override ShortPrice GetShortPriceById(int id)
        {
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {
                OleDbCommand cmd = new OleDbCommand(String.Format("select * from ShortPrice where {0}",id.ToString()), cn)
                {
                    CommandType = CommandType.Text
                };
                cn.Open();
                return GetShortPriceFromReader(ExecuteReader(cmd));
            }
        }
    }
}
