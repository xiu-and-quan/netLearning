using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MyWebApplicationLinq2Db.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public string Login(string Name,string Password) {

            if (Name == "admin" && Password == "123")
            {
                return "success";
            }
            else 
            {
                return "failed";
            }
        }
    }
}
