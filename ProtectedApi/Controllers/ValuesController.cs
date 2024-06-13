using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ProtectedApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var userInfo = new
            {
                Name = "Warren Albino",
                Section = "32E1",
                Course = "BSCS",
                FunFacts = new List<string>
                {
                "Introverted.",
                "I like programming",
                "I spend most of my time playing video games",
                "I can't sleep forcibly",
                "I'm a Night Person",
                "When I get my first paycheck, the first thing I will buy outside of basic necessities is an AC",
                "One of my biggest issue is procrastination",
                "The current anime that I follow is JJK",
                "I have kidney problems (due to overconsumption of soda and genetics)",
                "Managing people is very hard for me. But I like to get out of my comfort zone for some change."
                }
            };

            return Ok(userInfo);
        }
    }
}
