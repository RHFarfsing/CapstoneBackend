﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CapstoneBackend.Models {
    public class Vendor {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        [JsonIgnore]
        public virtual List<Product> Products { get; set; }
        public Vendor() {

        }
    }
}
