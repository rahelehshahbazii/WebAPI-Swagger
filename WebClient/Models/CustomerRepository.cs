using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Text;

namespace WebClient.Models
{
    public class CustomerRepository
    {
        private string apiURL = "http://localhost:53085/api/customers";
        //send request to API
        private HttpClient _client;
        private IHttpClientFactory _httpClientFactory { get; set; }


        public CustomerRepository()
        {
            _client = new HttpClient();
           
        }

        public List<Customer> GetAllCustomer(string token)
        {
            //  API response
            //locate token in header 
            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            
            
            try
            {
                var result = _client.GetStringAsync(apiURL).Result;
                List<Customer> list = JsonConvert.DeserializeObject<List<Customer>>(result);
                return list;
            }
            catch (AggregateException ex)
            {
                throw ex;
            }
       }
        public Customer GetCustomerById(int customerId)
        {
            var result = _client.GetStringAsync(apiURL + "/" + customerId).Result;
            Customer customer = JsonConvert.DeserializeObject<Customer>(result);
            return customer;
        }

        public void AddCustomer(Customer customer)
        {
            //change customer to Json
            string JsonCustomer = JsonConvert.SerializeObject(customer);
            StringContent content = new StringContent(JsonCustomer, Encoding.UTF8, "application/json");
            var res = _client.PostAsync(apiURL, content).Result;
        }
        public void UpdateCustomer(Customer customer)
        {
            string JsonCustomer = JsonConvert.SerializeObject(customer);
            StringContent content = new StringContent(JsonCustomer, Encoding.UTF8, "application/json");
            var res = _client.PutAsync(apiURL+"/"+customer.CustomerId, content).Result;
        }

        public void DeleteCustomer(int customerId)
        {
            var res = _client.DeleteAsync(apiURL + "/" + customerId).Result;

        }
        public class Customer
        {
            public int CustomerId { get; set; }
            [Required(ErrorMessage = "Enter FirstName")]
            [StringLength(50)]
            public string FirstName { get; set; }
            [Required]
            [StringLength(50)]
            public string LastName { get; set; }
            [EmailAddress]
            public string Email { get; set; }
            [Phone]
            public string Phone { get; set; }
            public string Address { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string ZipCode { get; set; }
        }
    }
}
