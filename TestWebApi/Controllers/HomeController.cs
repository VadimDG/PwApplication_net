using Microsoft.AspNetCore.Mvc;

namespace TestWebApi.Controllers
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string[] Books { get; set; }
    }

    public class HomeController : Controller
    {
        [HttpGet]
        public async Task Index()
        {
            string form = @"<form method='post'>
                <p><input name='name' /></p>
                <p><input name='age' /></p>
                <div>
                    <p><input name='books' /></p>
                    <p><input name='books' /></p>
                    <p><input name='books' /></p>
                </div>
                <input type='submit' value='Send' />
            </form>";
            Response.ContentType = "text/html;charset=utf-8";
            await Response.WriteAsync(form);
        }

        [HttpPost]
        public string Index(Person person)
        {
            

            return "abc";
        }
    }
}
