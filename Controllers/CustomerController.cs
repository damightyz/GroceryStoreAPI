using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using GroceryStoreAPI.Models;
using Newtonsoft.Json;


namespace GroceryStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        // Notes - Written By Jason Zemgulis on 6/30/2021
        // **********************************************************
        // Requires "Newtonsoft.Json" NuGet package
        // Using Swagger to test API
        // **********************************************************



        // GET: /api/Customer
        // Get all customer records
        [HttpGet]
        public IEnumerable<CustomerModel> Get()
        {
            // Read & deserialize json
            string jsonString = System.IO.File.ReadAllText(@"database.json");
            List<CustomerModel> customers = JsonConvert.DeserializeObject<List<CustomerModel>>(jsonString);

            // Return customer list
            return customers;
        }



        // GET: /api/Customer/{id}
        // Get specific customer record based on Id
        [HttpGet("{id}")]
        public IEnumerable<CustomerModel> Get(int id)
        {
            // Read & deserialize json
            string jsonString = System.IO.File.ReadAllText(@"database.json");
            List<CustomerModel> customers = JsonConvert.DeserializeObject<List<CustomerModel>>(jsonString);

            // Return filtered customer list
            return customers.Where(x => x.Id == id);
        }



        // POST: /api/Customer
        // Insert new customer record
        [HttpPost]
        public void Post(string name)
        {
            // Read & deserialize json
            string jsonString = System.IO.File.ReadAllText(@"database.json");
            List<CustomerModel> customers = JsonConvert.DeserializeObject<List<CustomerModel>>(jsonString);

            // Insert new customer
            customers.Add(new CustomerModel { Id = customers.Max(x => x.Id) + 1, Name = name });

            // Save json
            jsonString = JsonConvert.SerializeObject(customers, Formatting.Indented);
            System.IO.File.WriteAllText(@"database.json", jsonString);
        }



        // PUT: /api/Customer
        // Update existing customer record   int id, string name
        [HttpPut]
        public void Put([FromBody] CustomerModel customer)
        {
            // Read & deserialize json
            string jsonString = System.IO.File.ReadAllText(@"database.json");
            List<CustomerModel> customers = JsonConvert.DeserializeObject<List<CustomerModel>>(jsonString);

            // Update existing customer
            customers.Where(x => x.Id == customer.Id).FirstOrDefault<CustomerModel>().Name = customer.Name;

            // Save json
            jsonString = JsonConvert.SerializeObject(customers, Formatting.Indented);
            System.IO.File.WriteAllText(@"database.json", jsonString);
        }


    }
}
