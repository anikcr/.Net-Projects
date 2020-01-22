using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectV.Models
{
    public class admission
    {
         
        public int Id { get; set; }
        public string Name { get; set; }
        public string Birthday { get; set; }
        public string Gander { get; set; }
        public string Email { get; set; }
        public int Weight { get; set; }
        public string Parmanent_address { get; set; }
        public string Present_address { get; set; }
        public string Previous_school { get; set; }
        public string Mother_name { get; set; }
        public int Mother_phone { get; set; }
        public string Mother_occupation { get; set; }
        public string Father_name { get; set; }
        public int Father_phone { get; set; }
        public string Father_profession { get; set; }
        public string Father_email { get; set; }
    }
}

