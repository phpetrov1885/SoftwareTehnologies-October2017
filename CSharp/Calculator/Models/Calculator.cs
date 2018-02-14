using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace Calculator_CSharp.Models
{
    public class Calculator
    {
        public Calculator()
        {
            this.Result = 0m;
        }
        public decimal RightOperand { get; set; }

        public string Operator { get; set; }
        public decimal LeftOperand { get; set; }
        public decimal Result { get; set; }
    }
}