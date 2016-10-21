using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Domain.Enums;


namespace Domain.Entity
{
    public class Product
    {
        [Key]
        public int ID { get; set; }
        public string SERVICE_NUMBER { get; set; }
        public string NAME { get; set; }
        public TypeProd TYPE { get; set; }

        public Product(string ServiceNumber, string Name, TypeProd Type)
        {
            this.SERVICE_NUMBER = ServiceNumber;
            this.NAME = Name;
            this.TYPE = Type;
        }
        public Product()
        {
        }

        public override string ToString()
        {
            return ( SERVICE_NUMBER + ", " + NAME + " , " + TYPE);
        }
    }

}
