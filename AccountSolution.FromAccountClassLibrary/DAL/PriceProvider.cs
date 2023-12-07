using AccountSolution.FromAccountClassLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountSolution.FromAccountClassLibrary.DAL
{
    public abstract class PriceProvider : DataAccess
    {
        // methods that work with pricegroup
        public abstract List<PriceGroup> GetPriceGroup();
        public abstract List<PriceGroup> GetPriceGroupAll();
        //public abstract PriceGroup GetPriceGroupByID(int categoryID);
        //public abstract bool DeletePriceGroup(int categoryID);
        public abstract bool DeletePriceGroupAll();
        //public abstract bool UpdatePriceGroup(PriceGroup category);
        public abstract int InsertPriceGroup(PriceGroup category);

        // methods that work with price *******************************
        public abstract List<Price> GetPrice();
        public abstract int InsertPrice(Price Price);
        //public abstract SitePrice GetPriceByID(string productID);
        //public abstract Price GetPriceByID(int PriceID);
        //public abstract bool DeletePrice(int PriceID);
        public abstract bool DeletePriceAll();
        //public abstract bool UpdatePrice(PriceGroup Price);

        // methods that work with price *******************************
        public abstract List<ShortPrice> GetShortPrice();
        public abstract ShortPrice GetShortPriceById(int id);
        public abstract int InsertShortPrice(ShortPrice ShortPrice);
        //public abstract SitePrice GetPriceByID(string productID);
        //public abstract Price GetPriceByID(int PriceID);
        //public abstract bool DeletePrice(int PriceID);
        public abstract bool DeleteShortPriceAll();
        //public abstract bool UpdatePrice(PriceGroup Price);

        /// <summary>
        /// Returns a new CategoryDetails instance filled with the DataReader's current record data
        /// </summary>
        protected virtual PriceGroup GetPriceGroupFromReader(IDataReader reader)
        {
            return new PriceGroup(
                reader["GroupID"].ToString(),
                reader["GroupName"].ToString(),
                reader["ParentID"].ToString(),
                reader["ParentName"].ToString(),
                (bool)reader["Internet"],
                reader["Path"].ToString(),
                reader["Pict"].ToString()
                );
        }

        /// <summary>
        /// Returns a collection of CategoryDetails objects with the data read from the input DataReader
        /// </summary>
        protected virtual List<PriceGroup> GetPriceGroupCollectionFromReader(IDataReader reader)
        {
            List<PriceGroup> categories = new List<PriceGroup>();
            while (reader.Read())
                categories.Add(GetPriceGroupFromReader(reader));
            return categories;
        }

        /// <summary>
        /// Returns a new PriceDetails instance filled with the DataReader's current record data
        /// </summary>
        protected virtual Price GetPriceFromReader(IDataReader reader)
        {
            return new Price(
                reader["StockCounter"].ToString(),
                reader["NumbGroup"].ToString(),
                (int)reader["StockPriceGroupeID"],
                reader["Stock"].ToString(),
                reader["FullName"].ToString(),
                (float)reader["CountForPack"],
                reader["ValueForCount"].ToString(),
                //reader["Character"].ToString(),
                (float)reader["PriceForCount"]
                );
        }

        /// <summary>
        /// Returns a collection of CategoryDetails objects with the data read from the input DataReader
        /// </summary>
        protected virtual List<Price> GetPriceCollectionFromReader(IDataReader reader)
        {
            List<Price> price = new List<Price>();
            try
            {
                while (reader.Read())
                    price.Add(GetPriceFromReader(reader));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " From provider");
            }
            return price;
        }

        /// <summary>
        /// Returns a new PriceDetails instance filled with the DataReader's current record data
        /// </summary>
        protected virtual ShortPrice GetShortPriceFromReader(IDataReader reader)
        {
            return new ShortPrice(
                    (int)reader["StockPriceGroupeID"],
                    reader["StockGroupe"].ToString(),
                    reader["ValueForCount"].ToString(),
                    (double)reader["Base"],
                    (double)reader["BasePDV"],
                    (double)reader["Second"],
                    (double)reader["SecondPDV"],
                    (double)reader["Third"],
                    (double)reader["ThirdPDV"]
                );
        }

        /// <summary>
        /// Returns a collection of CategoryDetails objects with the data read from the input DataReader
        /// </summary>
        protected virtual List<ShortPrice> GetShortPriceCollectionFromReader(IDataReader reader)
        {
            List<ShortPrice> prices = new List<ShortPrice>();
            while (reader.Read())
                prices.Add(GetShortPriceFromReader(reader));
            return prices;
        }
    }
}
