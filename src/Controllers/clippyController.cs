using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Text;

namespace clippyAPI.Controllers
{
    public class clippyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        [Route("api/clippy")]
        public string ClippyIt()
        {
            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                string text = reader.ReadToEndAsync().Result.ToString();
                string top = "";
                string bottom= "";
                for (int i = 0; i < text.Length+2; i++)
                {
                    top +="_";
                    bottom+="-";
                }
                string output = $" {top}\n< {text} >\n {bottom}\n \\\n  \\\n    __\n   /  \\\n   |  |\n   @  @\n   |  |\n   || |/\n   || ||\n   |\\_/|\n   \\___/ ";

                output += $"\n From: {System.Runtime.InteropServices.RuntimeInformation.OSDescription}\n";

                return output;
            }
        }
    }
}