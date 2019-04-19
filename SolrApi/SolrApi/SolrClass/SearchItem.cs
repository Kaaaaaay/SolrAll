using SolrNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolrApi.SolrClass
{
    public class SearchItem
    {
        [SolrUniqueKey("id")]
        public string id { get; set; }
        [SolrUniqueKey("Category")]
        public string Category { get; set; }
        [SolrUniqueKey("SKU")]
        public string SKU { get; set; }
        [SolrUniqueKey("Name")]
        public string Name { get; set; }
        [SolrUniqueKey("Image ")]
        public string Image { get; set; }
        [SolrUniqueKey("Hopes")]
        public int Hopes { get; set; }
    }
}
