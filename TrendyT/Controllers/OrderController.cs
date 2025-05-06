using Microsoft.AspNetCore.Mvc;
using TrendyT.DTO;
using TrendyT.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TrendyT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {


        private readonly IOrderServices _OrderServices;

        public OrderController(IOrderServices OrderService)
        {

            _OrderServices = OrderService;

        }
        // GET: api/<OrderController>

        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<OrderController>/5
        [HttpGet]
        public async Task<ApiResponse> Get()
        {
            return await _OrderServices.GetAllOrder();
           
        }

        // POST api/<OrderController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
