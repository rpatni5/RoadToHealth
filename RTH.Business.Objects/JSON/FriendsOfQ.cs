﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTH.Business.Objects.JSON
{
    public partial class FriendsOfQ
    {
        public int status { get; set; }
        public string message { get; set; }
        public List<Product> data { get; set; }
    }


    public partial class Client
    {
        public string _id { get; set; }
        public string name { get; set; }
        public string image { get; set; }
    }

    public partial class ProductType
    {
        public string _id { get; set; }
        public string name { get; set; }
        public string color { get; set; }
        public string background { get; set; }
        public string image { get; set; }
    }

    public partial class Product
    {
        public string _id { get; set; }
        public Client client { get; set; }
        public ProductType product_type { get; set; }
        public string name { get; set; }
        public string summary { get; set; }
        public string url { get; set; }
        public string thumb_image { get; set; }
        public string main_image { get; set; }
        public bool featured { get; set; }
        public List<string> diseases { get; set; }       
        public string key_string { get; set; }
    }


}
