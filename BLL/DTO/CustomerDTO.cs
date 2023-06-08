using DA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class CustomerDTO
    {
       
        public int Id { get; set; }

    
        public string Name { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }
    }
}
