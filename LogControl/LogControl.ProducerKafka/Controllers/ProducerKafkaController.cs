using LogControl.Model.Interface.Application;
using LogControl.Model.Model;
using Microsoft.AspNetCore.Mvc;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LogControl.ProducerKafka.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProducerKafkaController : ControllerBase
    {

        private readonly IKafkaApplication _kafkaApplication;
        public ProducerKafkaController(IKafkaApplication kafkaApplication)
        {
            _kafkaApplication = kafkaApplication;
        }

    
        // POST api/<ProducerKafkaController>
        [HttpPost]
     
            public IActionResult Post([FromBody] Log log)
            {
                try
                {
                    if (_kafkaApplication.ProducerMsg(log))
                    {
                        return Ok("");
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
                catch (Exception ex)
                {

                    return StatusCode(500, ex.Message);
                }

            }

        

    }
}
