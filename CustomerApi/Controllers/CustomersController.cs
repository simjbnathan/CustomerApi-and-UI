using CustomerApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomerApi.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomersController : ControllerBase
    {
        private static List<Customer> customers = new List<Customer>
        {
            new Customer { CustomerId = 1, Name = "Regular Customer 1", Email = "regular1@example.com" },
            // Add more regular customers as needed
        };

        private static List<PremiumCustomer> premiumCustomers = new List<PremiumCustomer>
        {
            new PremiumCustomer { CustomerId = 2, Name = "Premium Customer 1", Email = "premium1@example.com", IsGoldMember = true },
            // Add more premium customers as needed
        };



        [HttpGet]
        public ActionResult<IEnumerable<Customer>> Get()
        {
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public ActionResult<Customer> Get(int id)
        {
            var customer = customers.FirstOrDefault(c => c.CustomerId == id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpPost]
        public ActionResult<Customer> Post([FromBody] Customer customer)
        {
            customer.CustomerId = customers.Count + 1;
            customers.Add(customer);
            return CreatedAtAction(nameof(Get), new { id = customer.CustomerId }, customer);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Customer updatedCustomer)
        {
            var existingCustomer = customers.FirstOrDefault(c => c.CustomerId == id);
            if (existingCustomer == null)
            {
                return NotFound();
            }

            existingCustomer.Name = updatedCustomer.Name;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var customer = customers.FirstOrDefault(c => c.CustomerId == id);
            if (customer == null)
            {
                return NotFound();
            }

            customers.Remove(customer);
            return NoContent();
        }

        [HttpGet("premium/{id}")]
        public IActionResult GetPremiumCustomer(int id)
        {
            PremiumCustomer premiumCustomer = FindPremiumCustomerById(id);
            if (premiumCustomer == null)
            {
                return NotFound();
            }

            return Ok(premiumCustomer);
        }

                // Helper method to find a premium customer by ID in the premium customers list
        private PremiumCustomer FindPremiumCustomerById(int id)
        {
            return premiumCustomers.Find(c => c.CustomerId == id);
        }
    }


}
