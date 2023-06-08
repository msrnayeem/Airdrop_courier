using BLL.DTO;
using DA.Models;
using DA.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CustomerService
    {
        public static int AddCustomer(CustomerDTO customer)
        {
            return CustomerRepo.AddCustomer(Convert(customer));
            
        }

        public static bool DeleteCustomer(int id)
        {
            return CustomerRepo.DeleteCustomer(id);
        }
        public static CustomerDTO GetCustomer(int id)
        {
            var data = CustomerRepo.GetCustomer(id);
            return Convert(data);
        }
        public static List<CustomerDTO> GetCustomers()
        {
            var data = CustomerRepo.GetCustomers();
            return Convert(data);
        }

        public static bool UpdateCustomer(CustomerDTO customer)
        {
            return CustomerRepo.UpdateCustomer(Convert(customer));
        }

        //convert
        public static CustomerDTO Convert(Customer customer)
        {
            return new CustomerDTO()
            {
                Id = customer.Id,
                Name = customer.Name,
                Address = customer.Address,
                Phone = customer.Phone
            };
        }

        public static Customer Convert(CustomerDTO customer)
        {
            return new Customer()
            {
                Id = customer.Id,
                Name = customer.Name,
                Address = customer.Address,
                Phone = customer.Phone
            };
        }
        //list convert to dto
        public static List<CustomerDTO> Convert(List<Customer> customers)
        {
            return customers.Select(c => Convert(c)).ToList();
        }
    }
}
