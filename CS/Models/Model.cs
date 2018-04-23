using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace E4425.Models {
    public static class DataProvider {

        static HttpSessionState Session { get { return HttpContext.Current.Session; } }

        static DemoDataObject DemoData {
            get {
                const string key = "FB1EB35F-86F5-4FFE-BB23-CBAAF1514C49";
                if (Session[key] == null) {
                    var obj = new DemoDataObject();
                    obj.FillObj();
                    Session[key] = obj;
                }
                return (DemoDataObject)Session[key];
            }
        }

        public static IEnumerable<Customer> GetCustomers() {
            return DemoData.Customers;
        }
        public static IEnumerable<Country> GetCountries() {
            return DemoData.Countries;
        }

        public static void UpdateCustomer(Customer customerInfo) {
            var c = DemoData.Customers.First(i => i.CustomerID == customerInfo.CustomerID);
            c.CustomerName = customerInfo.CustomerName;
            c.CountryID = customerInfo.CountryID;
        }
    }

    public class DemoDataObject {
        public List<Customer> Customers { get; set; }
        public List<Country> Countries { get; set; }
        public void FillObj() {
            Customers = new List<Customer>();
            Countries = new List<Country>();
            for (int i = 0; i < 1000; i++)
                Countries.Add(CreateCountry("CountryName" + i));
            for (int i = 0; i < 1000; i++)
                CreateCustomer("CustomerName" + i, Countries[i]);
        }

        Customer CreateCustomer(string name, Country country) {
            var c = new Customer() {
                CustomerName = name,
                CountryID = country.CountryID,
                CustomerID = Customers.Count
            };
            Customers.Add(c);
            return c;
        }

        Country CreateCountry(string name) {
            var c = new Country() { CountryName = name };
            c.CountryID = Countries.Count;
            return c;
        }
    }

    public class Customer {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public int CountryID { get; set; }
    }

    public class Country {
        public int CountryID { get; set; }
        public string CountryName { get; set; }
    }

}