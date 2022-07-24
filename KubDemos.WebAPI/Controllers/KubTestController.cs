using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KubDemos.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KubTestController : ControllerBase
    {
        private readonly IConfiguration configuration;

        
        public KubTestController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpGet]
        public List<SettingResult> Get()
        {
            return configuration.AsEnumerable().Select(c => 
            new SettingResult { Key = c.Key, Value = c.Value })
                .ToList();
        }
    }

    public class SettingResult
    {
        public string Key { get; set; }

        public string Value { get; set; }
    }
}
