using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Web.Http;

namespace RetailManagmentSystem.DataManager.Controllers
{
    [Authorize]
    public class ValuesController : ApiController
    {
        //? Metody IEnumerable<string> Get() a IHttpActionResult GetResult()
        //? dělají v podstatě to samé. Rozdíl v použití je popsán v komentáři
        //? v těle dané metody.

        // GET api/values
        public IEnumerable<string> Get()
        {
            // Pokud potřebuješ znát hlavně hodnoty a jejich datové typy,
            // použij tento způsob.
            var userId = RequestContext.Principal.Identity.GetUserId();
            return new string[] { "value1", "value2", userId };
        }

        public IHttpActionResult GetResult()
        {
            // Pokud chceš mít větší kontrolu nad výsledky, použij tento způsob.
            // Do výsledku můžeš vrazit hodnoty jako parametr.
            // Výsledek může být Ok, NotFound, Exception..
            var userId = RequestContext.Principal.Identity.GetUserId();
            return Ok(new string[] { "value1", "value2", userId });
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
