using Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLibrary.DtO_Models
{
    public class ProductPhoto : IModel
    {
        public int PhotoID { get; set; }
        public int ProductID { get; set; }
        public string PhotoPath { get; set; }
    }
}
