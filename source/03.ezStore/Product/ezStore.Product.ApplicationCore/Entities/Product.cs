﻿using Ws4vn.Microservicess.ApplicationCore.Entities;

namespace ezStore.Product.ApplicationCore.Entities
{
    public class Product : ModelGuidIdEntity
    {
        public string Name { get; set; }

        public string ShortDescription { get; set; }

        public string FullDescription { get; set; }

        public string SKU { get; set; }

        public bool Published { get; set; }
    }
}
