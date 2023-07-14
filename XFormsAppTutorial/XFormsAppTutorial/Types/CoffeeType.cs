using System;
using System.Collections.Generic;
using System.Text;

namespace XFormsAppTutorial.Types
{
    public class CoffeeType
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        private const string DefaultImage = "https://images.immediate.co.uk/production/volatile/sites/30/2020/08/flat-white-3402c4f.jpg";

        public CoffeeType(string name, string description = "", string imageUrl = DefaultImage)
        {
            this.Name = name;
            this.Description = description;
            this.ImageUrl = imageUrl;
        }
    }
}
