using LogControl.Model.Interface.Application;
using LogControl.Model.Model;
using Microsoft.AspNetCore.Mvc;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LogControl.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private readonly ILogApplication _logApplication;

        public LogController(ILogApplication logApplication)
        {
            _logApplication = logApplication;
        }

    
        // GET: api/<LogController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var logs = _logApplication.GetAll();
                return Ok(logs);

            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message); 
            }
           
        }

        // GET api/<LogController>/{id}
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            try
            {
                var log = _logApplication.Get(id);
                return Ok(log);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
          
        }

        // POST api/<LogController>
        [HttpPost]
        public IActionResult Post([FromBody] Log log)
        {
            try
            {
                if (_logApplication.Insert(log))
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

        // PUT api/<LogController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Log log)
        {
            try
            {
                _logApplication.Update(log.Id, log);
                    return Ok(log);
                
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        // DELETE api/<LogController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                 return Ok("");
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
    }
}
