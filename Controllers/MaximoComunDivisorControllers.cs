using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PrimeraWebApi.Controllers
{
    [ApiController]

    [Route("api/[controller]")]
    public class MaximoComunDivisorController : ControllerBase
    {
        [HttpGet("mcd/{a:int}/{b:int}")]
        public int mcd(int a, int b)
        {
            if (b == 0)
            {
                return a;
            }
            return mcd(b, a % b);
        }
            
    }
}
