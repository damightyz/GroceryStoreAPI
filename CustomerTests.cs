using GroceryStoreAPI.Controllers;
using GroceryStoreAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace GroceryStoreAPI.Tests
{
    public class CustomerTests
    {

        [Fact]
        public void Compare_Count_Of_All_Customers()
        {
            // Arrange
            string jsonString = System.IO.File.ReadAllText(@"database.json");
            List<CustomerModel> expectedCustomers = JsonConvert.DeserializeObject<List<CustomerModel>>(jsonString);

            // Act
            CustomerController customerController = new CustomerController();
            List<CustomerModel> actualCustomers = (List<CustomerModel>)customerController.Get();

            // Assert
            Assert.Equal(expectedCustomers.Count, actualCustomers.Count);
        }


        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void Compare_Name_Of_Specific_Customer(int id)
        {
            // Arrange
            string jsonString = System.IO.File.ReadAllText(@"database.json");
            List<CustomerModel> expectedCustomers = JsonConvert.DeserializeObject<List<CustomerModel>>(jsonString);
            CustomerModel customer = expectedCustomers.Where(x => x.Id == id).FirstOrDefault();
            string expectedName = customer.Name;

            // Act
            CustomerController customerController = new CustomerController();
            CustomerModel actualCustomer = (CustomerModel)customerController.Get(id).FirstOrDefault();
            string actualName = actualCustomer.Name;

            // Assert
            Assert.Equal(expectedName, actualName);
        }

    }

}
