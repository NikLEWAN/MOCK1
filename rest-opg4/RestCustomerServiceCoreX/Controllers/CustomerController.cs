using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestCustomerServiceCoreY.Model;

namespace RestCustomerServiceCoreY.Controllers

//https://localhost:44387/api/customer using IISExpress
//https://localhost:5001/api/customer RestCustomerService local

{
    [Route("api/[controller]")]
    //[EnableCors("AllowAnyOrigin")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        public static long nextId = 1000000000000;

        private static List<Customer> cList = new List<Customer>()
        {    new Customer("en bog", "Kejser", 99),
             new Customer("2 bog", "Flod", 999),
        };



        // GET: api/Customer
        /// <summary>
        /// Base Uri Rest GET - List all
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Customer> Get()
        {
            return cList;// 
        }

        // GET: api/Customer/5
        //[HttpGet("{id}", Name = "Get")] changed uri to below
        /// <summary>
        /// Uri ID Parameter - List specific id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")] 
        public Customer GetCustomer(long id)
        {   // DOES  work

          Response.StatusCode = (int)HttpStatusCode.OK; //200  The message for the HttpResponse action

            Customer c = cList.FirstOrDefault(customer => customer.Isbn13 == id);
            //Set statuscode of response
            if (c == null) Response.StatusCode = (int)HttpStatusCode.NotFound;
            // Alternatively 
            // if (c == null) Response.StatusCode = 404;
            //Any number can be used for type casting, even customized numbers like 420

            return c;
        }

        // GET: api/Customer/5
        /// <summary>
        /// Special ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("special/{id}", Name = "Get1")]
        public ActionResult GetCustomer1(long id)
        {   
            Customer c = cList.FirstOrDefault(customer => customer.Isbn13 == id);
            if (c == null) return NotFound();
            return Ok(c);
        }

        // POST: api/Customer
        /// <summary>
        /// Post to Customers
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPost]
        //[EnableCors("AllowSpecifOrigin")]
        public Customer InsertCustomer([FromBody] Customer customer)
        {
            customer.Isbn13 = CustomerController.nextId++;
            cList.Add(customer);
            return customer;
        }


        // PUT: api/Customer/5
        /// <summary>
        /// Put into Customers
        /// </summary>
        /// <param name="id"></param>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public Customer UpdateCustomer(long id, [FromBody] Customer customer)
        {
            //Find customer in the list replace old data with new; i.e. original ID is not changed
            //The original position in the list is kept
            Customer c = GetCustomer(id); 
            if (c == null) return null;
            c.Titel = customer.Titel;
            c.Forfatter = customer.Forfatter;
            c.Sidetal = customer.Sidetal;
            return GetCustomer(id);

        }

        // DELETE: api/Customer/5
        //[HttpDelete("{id}")]
        /// <summary>
        /// Delete Customer by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        //[DisableCors]
        public Customer DeleteCustomer(long id)
        {
            Customer c = GetCustomer(id);
            if (c == null) return null;
            cList.Remove(c);
            return c;
        }

        // NEW URIS
    }
}
