using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly2.Dtos;
using Vidly2.Models; 
using System.Data.Entity;

namespace Vidly2.Controllers.Api
{
    public class CustomersController : ApiController
    {

       private ApplicationDbContext _context;

       public CustomersController()
       {
            _context = new ApplicationDbContext();
       }

       // Get/api/customers
      // public IHttpActionResult GetCustomers()
      /* public IHttpActionResult GetCustomers()
       {
            var customers = _context.Customers
                           .Include(c => c.MembershipType)
                           .ToList()
                           .Select(Mapper.Map<Customer, CustomerDto>);

            return Ok(customers);
       } */

        public IHttpActionResult GetCustomers(string query = null)
        {
            var customersQuery = _context.Customers
                .Include(c => c.MembershipType);

            if (!String.IsNullOrWhiteSpace(query))
                customersQuery = customersQuery.Where(c => c.Name.Contains(query));

            var customerDtos = customersQuery
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDto>);
            
            return Ok(customerDtos);    
        }

        // Get/api/customers/1
        // public CustomerDto GetCustomer(int Id) 
        public IHttpActionResult GetCustomer(int Id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == Id);
            if(customer == null)
            {
                return NotFound();
                //throw new HttpResponseException(HttpStatusCode.NotFound); 
            }

            return Ok(Mapper.Map<Customer, CustomerDto>(customer));        
        }

        // POST
        // /api/customers
        [HttpPost]
         public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
               // throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer); 
            _context.SaveChanges(); 

            customerDto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);

        }

        // POST
        // /api/customers/1
        [HttpPut]
        public void UpdateCustomer(int Id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == Id);

            if(customerInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }


            Mapper.Map(customerDto, customerInDb);
            /*
            customerInDb.Name = customerDto.Name;
            customerInDb.Birthday = customerDto.Birthday;
            customerInDb.IsSubscribedToNewsLetter = customerDto.IsSubscribedToNewsLetter;
            customerInDb.MembershipTypeId = customerDto.MembershipTypeId;
            */
            _context.SaveChanges();
        }

        // Delete
        ///api/customers/1
        [HttpDelete ]
        public void DeleteCustomer(int Id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == Id);
            if(customerInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
        }
 

    }
}
