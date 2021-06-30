using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace GroceryStoreAPI.Models
{
    public class CustomerModel
    {
        [Key]
        public Int64 Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
