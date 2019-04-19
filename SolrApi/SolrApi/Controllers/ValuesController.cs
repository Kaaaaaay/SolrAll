using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SolrApi.SolrClass;
using SolrApi.SolrDAL;

namespace SolrApi.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowAllOrigin")]
    public class ValuesController : Controller
    {
        SearchFunction searchFunction;
        public ValuesController() {
            searchFunction = new SearchFunction();
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{name}")]
        public List<SearchItem> Get(string name)
        {
            var result=searchFunction.SearchList("Name:*"+name+"*");
            List<SearchItem> list = new List<SearchItem>();
            foreach (var item in result) {
                list.Add(item);
            }
            return list;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]SearchItem value)
        {
            searchFunction.AddAndEdit(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(string id)
        {
            searchFunction.updateHopes(id);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
