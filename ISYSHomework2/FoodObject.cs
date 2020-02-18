using System;
using System.Collections.Generic;
using System.Text;

namespace ISYSHomework2
{
    class FoodObject
    {
        private int classification = 0;
        private string name;
        private double price;
        private System.Drawing.Image photoLocation;

        public int Classification
        {
            get
            {
                return classification;
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
        }

        public double Price
        {
            get
            {
                return price;
            }
        }

        public System.Drawing.Image PhotoLocation
        {
            get
            {
                return photoLocation;
            }
        }

        public FoodObject(string name, System.Drawing.Image location, double price, int classification)
        {
            this.name = name;
            photoLocation = location;
            this.price = price;
            this.classification = classification;
        }





    }
}
