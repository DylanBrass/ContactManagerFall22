using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagerFall22.DB.Entities
{
    internal class TypeOf
    {
        public TypeOf()
        {

        }
        public TypeOf(char code, string desc)
        {
            Code = code;
            Desc = desc;
        }

        public char Code { get; set; }

        public string Desc { get; }
    }
}
