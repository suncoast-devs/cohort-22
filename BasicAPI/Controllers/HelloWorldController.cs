using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BasicAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class HelloWorldController : ControllerBase
  {
    // The name of the method is to be clear to
    // *me* the programmer. Doesn't tell ASP
    // anything.
    [HttpGet]
    public string SayHello(string who = "World")
    {
      return $"Hello, {who}. {DateTime.Now}";
    }
  }
}