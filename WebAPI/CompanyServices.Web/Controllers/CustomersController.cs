using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CompanyServices.Data;
using CompanyServices.Domain;




namespace CompanyServices.Web.Controllers
{
    public class CustomersController : ApiController
    {
        CompanyServicesDataContext db = new CompanyServicesDataContext();

        public IEnumerable<Customer> GetCustomers()
        {
            return db.Customers.ToArray();
        }

        public Customer GetCustomer (int id)
        {
            return db.Customers.FirstOrDefault(c => c.Id == id);
        }

        public void PostCustomers(Customer customer)
        {
            db.Customers.InsertOnSubmit(customer);
            db.SubmitChanges();
        }

        public void PutCustomers(string id, Customer customer)
        {
            var matchingCustomer = db.Customers.FirstOrDefault(c => c.Id == Convert.ToInt32(id));
            if (matchingCustomer != null)
            {
                SetChangedProperties(matchingCustomer, customer);
                db.SubmitChanges();
            }
        }

        public void DeleteCustomers(int id)
        {
            var matchingCustomer = db.Customers.FirstOrDefault(c => c.Id == id);
            if (matchingCustomer != null)
            {
                db.Customers.DeleteOnSubmit(matchingCustomer);
                db.SubmitChanges();
            }
        }

        static void SetChangedProperties(object target, object source)
        {
            if (target.GetType() != source.GetType())
                throw new ArgumentException("Unmatching types");
            var props = target.GetType().GetProperties();
            foreach (var prop in props)
            {
                object valTarget = prop.GetValue(target, null);
                object valSource = prop.GetValue(source, null);
                if (valTarget != null && !valTarget.Equals(valSource)) 
                    prop.SetValue(target, valSource, null);
                else 
                    prop.SetValue(target, valSource, null);
            }
        }
    }


}
