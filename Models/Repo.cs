using Microsoft.ApplicationBlocks.Data;
using rwa_projekt_katlija_2407.Models.dto;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace rwa_projekt_katlija_2407.Models
{
    public class Repo
    {
        private static string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        static private string CheckIfNull(DataRow dataRow, string columName)
        {
            if (dataRow.IsNull(columName))
                return "-";
            else
                return dataRow[columName].ToString();

        }
        private static int CheckIfNullInt(DataRow row, string v)
        {
            var value = row[v];
            if (value == DBNull.Value)
                return 0;
            else
                return (int)row[v];
        }

        public static int GetMaxCustomers()
        {
            return (int)SqlHelper.ExecuteScalar(cs, "ShowMax");
        }
        public static IEnumerable<Customer> GetCustomers(int a)
        {
            var tblCustomers = SqlHelper.ExecuteDataset(cs, "ShowCustomers", a).Tables[0];

            foreach (DataRow row in tblCustomers.Rows)
            {
                yield return new Customer
                {
                    IDKupac = int.Parse(CheckIfNull(row, "IDKupac")),
                    Ime = CheckIfNull(row, "Ime"),
                    Prezime = CheckIfNull(row, "Prezime"),
                    Email = CheckIfNull(row, "Email"),
                    Telefon = CheckIfNull(row, "Telefon"),
                    Drzava = CheckIfNull(row, "Drzava"),
                    Grad = CheckIfNull(row, "Grad"),
                    DrzavaID = CheckIfNullInt(row, "IDDrzava"),
                    GradID = CheckIfNullInt(row, "IDGrad")

                };
            }
        }
        public static IEnumerable<State> FillDDLStates()
        {
            var tblState = SqlHelper.ExecuteDataset(cs, "ShowStates").Tables[0];

            foreach (DataRow row in tblState.Rows)
            {
                yield return new State
                {
                    IDDrzava = (int)row["IDDrzava"],
                    Naziv = CheckIfNull(row, "Naziv"),
                };
            }

        }
        public static IEnumerable<City> FillDDLCities(int a)
        {
            var tblCity = SqlHelper.ExecuteDataset(cs, "ShowCities", a).Tables[0];

            foreach (DataRow row in tblCity.Rows)
            {
                yield return new City
                {
                    IDGrad = (int)row["IDGrad"],
                    Naziv = CheckIfNull(row, "Naziv"),
                    DrzavaID = CheckIfNullInt(row, "DrzavaID")
                };
            }
        }
        public static IEnumerable<Customer> ShowCustomerFromState(int a, int b)
        {
            var tblCustomer = SqlHelper.ExecuteDataset(cs, "ShowCustomerFromState", a, b).Tables[0];
            foreach (DataRow row in tblCustomer.Rows)
            {
                yield return new Customer
                {
                    IDKupac = int.Parse(CheckIfNull(row, "IDKupac")),
                    Ime = CheckIfNull(row, "Ime"),
                    Prezime = CheckIfNull(row, "Prezime"),
                    Email = CheckIfNull(row, "Email"),
                    Telefon = CheckIfNull(row, "Telefon"),
                    Drzava = CheckIfNull(row, "Drzava"),
                    Grad = CheckIfNull(row, "Grad"),
                    DrzavaID = CheckIfNullInt(row, "IDDrzava"),
                    GradID = CheckIfNullInt(row, "IDGrad")

                };
            }
        }
        public static IEnumerable<Customer> ShowCustomerFromStateAndCity(int a, int b, int c)
        {
            var tblCustomer = SqlHelper.ExecuteDataset(cs, "ShowCustomerFromStateAndCity", a, b, c).Tables[0];
            foreach (DataRow row in tblCustomer.Rows)
            {
                yield return new Customer
                {
                    IDKupac = int.Parse(CheckIfNull(row, "IDKupac")),
                    Ime = CheckIfNull(row, "Ime"),
                    Prezime = CheckIfNull(row, "Prezime"),
                    Email = CheckIfNull(row, "Email"),
                    Telefon = CheckIfNull(row, "Telefon"),
                    Drzava = CheckIfNull(row, "Drzava"),
                    Grad = CheckIfNull(row, "Grad"),
                    DrzavaID = CheckIfNullInt(row, "IDDrzava"),
                    GradID = CheckIfNullInt(row, "IDGrad")

                };
            }
        }
        public static int InsertState(State s)
        {
            return SqlHelper.ExecuteNonQuery(cs, "InsertState", s.Naziv);
        }
        public static int InsertCity(City c)
        {
            return SqlHelper.ExecuteNonQuery(cs, "InsertCity", c.Naziv, c.DrzavaID);
        }
        public static int CheckState(State s)
        {
            return (int)SqlHelper.ExecuteScalar(cs, "CheckState", s.Naziv);
        }
        public static int CheckCity(City c)
        {
            return (int)SqlHelper.ExecuteScalar(cs, "CheckCity", c.DrzavaID, c.Naziv);
        }
        public static int UpdateCustomer(Customer c)
        {
            return SqlHelper.ExecuteNonQuery(cs, "UpdateCustomer", c.IDKupac, c.Ime, c.Prezime, c.Email, c.Telefon, c.GradID);
        }
        public static Customer ShowMoreInfo(int a)
        {
            var tblCustomer = SqlHelper.ExecuteDataset(cs, "MoreInfoCustomer", a).Tables[0];
            if (tblCustomer.Rows.Count == 0) return null;
            DataRow row = tblCustomer.Rows[0];
            return new Customer
            {
                IDKupac = int.Parse(CheckIfNull(row, "IDKupac")),
                Ime = CheckIfNull(row, "Ime"),
                Prezime = CheckIfNull(row, "Prezime"),
                Email = CheckIfNull(row, "Email"),
                Telefon = CheckIfNull(row, "Telefon"),
                Drzava = CheckIfNull(row, "Drzava"),
                Grad = CheckIfNull(row, "Grad"),
                DrzavaID = CheckIfNullInt(row, "IDDrzava"),
                GradID = CheckIfNullInt(row, "IDGrad")
            };

        }
        public static IEnumerable<Receipt> GetReceipts(int a)
        {
            var tblReceipts = SqlHelper.ExecuteDataset(cs, "ShowReceipt", a).Tables[0];

            foreach (DataRow row in tblReceipts.Rows)
            {
                yield return new Receipt
                {
                    IDRacun = int.Parse(CheckIfNull(row, "IDRacun")),
                    BrojRacuna = CheckIfNull(row, "BrojRacuna"),
                    DatumIzdavanja = DateTime.Parse(CheckIfNull(row, "DatumIzdavanja")).ToShortDateString()
                };
            }
        }
        public static IEnumerable<Item> GetItems(int a)
        {
            var tblItems = SqlHelper.ExecuteDataset(cs, "ShowReceiptDetails", a).Tables[0];

            foreach (DataRow row in tblItems.Rows)
            {
                yield return new Item
                {
                    Naziv = CheckIfNull(row, "Ime"),
                    Kategorija = CheckIfNull(row, "Kategorija"),
                    Potkategorija = CheckIfNull(row, "Potkategorija"),
                    Kolicina = int.Parse(CheckIfNull(row, "Kolicina")),
                    CijenaPoKomadu = decimal.Round(decimal.Parse(CheckIfNull(row, "CijenaPoKomadu")), 2),
                    UkupnaCijena = decimal.Round(decimal.Parse(CheckIfNull(row, "UkupnaCijena")),2)
                };
            }
        }
        public static Komercijalist GetKomercijalist(int a)
        {
            var tblKomercijalist = SqlHelper.ExecuteDataset(cs, "GetKomercijalist", a).Tables[0];


            if (tblKomercijalist.Rows.Count == 0)
            {
                return new Komercijalist
                {
                    Ime = "-",
                    Prezime = "-"
                };
            }
            else
            {
                DataRow row = tblKomercijalist.Rows[0];
                return new Komercijalist
                {

                    Ime = CheckIfNull(row, "Ime"),
                    Prezime = CheckIfNull(row, "Prezime"),

                };
            }
        }
        public static KreditnaKartica GetCreditCard(int a)
        {
            var tblCard = SqlHelper.ExecuteDataset(cs, "GetKreditnaKartica", a).Tables[0];

          
            if (tblCard.Rows.Count == 0)
            {
                return new KreditnaKartica
                {
                    Tip = "-",
                    Broj = "-"
                };
            }
            else {
                DataRow row = tblCard.Rows[0];
                return new KreditnaKartica
            {

                Tip = CheckIfNull(row, "Tip"),
                Broj = CheckIfNull(row, "Broj"),
            };
            }
        }
        public static IEnumerable<Product> GetProducts()
        {
            var tblProducts = SqlHelper.ExecuteDataset(cs, "GetAllProducts").Tables[0];

            foreach (DataRow row in tblProducts.Rows)
            {
                yield return new Product
                {
                    IDProizvod = (int)row["IDProizvod"],
                    Naziv = row["Naziv"].ToString(),                                       
                    BrojProizvoda = row["BrojProizvoda"].ToString(),
                    Kolicina=int.Parse(CheckIfNull(row,"Kolicina")),
                    Boja=CheckIfNull(row, "Boja"),
                    PotkategorijaID=CheckIfNullInt(row, "PotkategorijaID"),
                    Potkategorija=CheckIfNull(row, "Potkategorija"),
                    CijenaBezPDV =decimal.Round(decimal.Parse(CheckIfNull(row,"CijenaBezPDV")),2)
                };
            }
        }
        public static IEnumerable<Category> GetCategories()
        {
            var tblCategories = SqlHelper.ExecuteDataset(cs, "GetAllCategories").Tables[0];

            foreach (DataRow row in tblCategories.Rows)
            {
                yield return new Category
                {
                    IDKategorija = (int)row["IDKategorija"],
                    Naziv = row["Naziv"].ToString(),
                   
                };
            }
        }
        public static IEnumerable<Subcategory> GetSubcategories()
        {
            var tblCategories = SqlHelper.ExecuteDataset(cs, "GetAllSubcategories").Tables[0];

            foreach (DataRow row in tblCategories.Rows)
            {
                yield return new Subcategory
                {
                    IDPotkategorija = (int)row["IDPotkategorija"],
                    Naziv = row["Naziv"].ToString(),
                    KategorijaID=(int)row["KategorijaID"],
                    Kategorija= row["Kategorija"].ToString()
                };
            }
        }

        public static Product GetProduct(int a)
        {
            var tblProduct = SqlHelper.ExecuteDataset(cs, "GetProduct", a).Tables[0];

                DataRow row = tblProduct.Rows[0];
                return new Product
                {

                    IDProizvod = (int)row["IDProizvod"],
                    Naziv = row["Naziv"].ToString(),
                    BrojProizvoda = row["BrojProizvoda"].ToString(),
                    Kolicina = int.Parse(CheckIfNull(row, "Kolicina")),
                    Boja = CheckIfNull(row, "Boja"),
                    PotkategorijaID = CheckIfNullInt(row, "PotkategorijaID"),
                    Potkategorija = CheckIfNull(row, "Potkategorija"),
                    CijenaBezPDV = decimal.Round(decimal.Parse(CheckIfNull(row, "CijenaBezPDV")))

                };
         }
        public static int UpdateProduct(Product p)
        {
            return SqlHelper.ExecuteNonQuery(cs, "UpdateProduct",p.IDProizvod, p.Naziv, p.BrojProizvoda, p.Boja, p.Kolicina, p.CijenaBezPDV, p.PotkategorijaID);
        }
        public static int CreateProduct(Product p)
        {
            return SqlHelper.ExecuteNonQuery(cs, "CreateProduct", p.Naziv, p.BrojProizvoda, p.Boja, p.Kolicina, p.CijenaBezPDV, p.PotkategorijaID);
        }

        public static Category GetCategory(int a)
        {
            var tblCategory = SqlHelper.ExecuteDataset(cs, "GetCategory", a).Tables[0];

            DataRow row = tblCategory.Rows[0];
            return new Category
            {
                IDKategorija = (int)row["IDKategorija"],
                Naziv = row["Naziv"].ToString(),
              
            };
        }
        public static int UpdateCategory(Category c)
        {
            return SqlHelper.ExecuteNonQuery(cs, "UpdateCategory", c.IDKategorija, c.Naziv);
        }
        public static Subcategory GetSubcategory(int a)
        {
            var tblCategory = SqlHelper.ExecuteDataset(cs, "GetSubcategory", a).Tables[0];

            DataRow row = tblCategory.Rows[0];
            return new Subcategory
            {
                IDPotkategorija = (int)row["IDPotkategorija"],
                Naziv = row["Naziv"].ToString(),
                KategorijaID = (int)row["KategorijaID"],
            
            };
        }
        public static int UpdateSubcategory(Subcategory s)
        {
            return SqlHelper.ExecuteNonQuery(cs, "UpdateSubcategory", s.IDPotkategorija, s.Naziv, s.KategorijaID);
        }
        public static Receipt GetReceipt(int a)
        {
            var tblreceipt = SqlHelper.ExecuteDataset(cs, "GetReceipt", a).Tables[0];

            DataRow row = tblreceipt.Rows[0];
            return new Receipt
            {
                IDRacun = (int)row["IDRacun"],
                BrojRacuna=row["BrojRacuna"].ToString()
               

            };
        }
        public static int DeleteProduct(int a)
        {
            return SqlHelper.ExecuteNonQuery(cs, "DeleteProduct",a);
        }
        public static int CreateCategory(Category c)
        {
            return SqlHelper.ExecuteNonQuery(cs, "CreateCategory", c.Naziv);
        }
        public static int DeleteCategory(int a)
        {
            return SqlHelper.ExecuteNonQuery(cs, "DeleteCategory", a);
        }
        public static int DeleteSubcategory(int a)
        {
            return SqlHelper.ExecuteNonQuery(cs, "DeleteSubcategory", a);
        }
        public static int CreateSubcategory(Subcategory c)
        {
            return SqlHelper.ExecuteNonQuery(cs, "CreateSubcategory", c.Naziv, c.KategorijaID);
        }
        public static IEnumerable<Customer> GetAllCustomers()
        {
            var tblCustomers = SqlHelper.ExecuteDataset(cs, "GetAllCustomers").Tables[0];

            foreach (DataRow row in tblCustomers.Rows)
            {
                yield return new Customer
                {
                    IDKupac = int.Parse(CheckIfNull(row, "IDKupac")),
                    Ime = CheckIfNull(row, "Ime"),
                    Prezime = CheckIfNull(row, "Prezime"),
                    Email = CheckIfNull(row, "Email"),
                    Telefon = CheckIfNull(row, "Telefon"),
                    Drzava = CheckIfNull(row, "Drzava"),
                    Grad = CheckIfNull(row, "Grad"),
                    GradID = CheckIfNullInt(row, "IDGrad")

                };
            }
        }
        public static int CreateCustomer(Customer c)
        {
            return SqlHelper.ExecuteNonQuery(cs, "CreateCustomer", c.Ime, c.Prezime, c.Email, c.Telefon, c.GradID);
        }
        public static int DeleteCustomer(int a)
        {
            return SqlHelper.ExecuteNonQuery(cs, "DeleteCustomer", a);
        }
    }

}



