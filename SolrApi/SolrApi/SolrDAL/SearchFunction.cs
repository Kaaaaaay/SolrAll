using CommonServiceLocator;
using SolrApi.SolrClass;
using SolrNet;
using SolrNet.Commands.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolrApi.SolrDAL
{
    public class SearchFunction
    {
        ISolrOperations<SearchItem> solr;
        public SearchFunction() {
            solr = ServiceLocator.Current.GetInstance<ISolrOperations<SearchItem>>();
        }
        public void AddAndEdit(SearchItem item) {
            solr.Add(item);
            solr.Commit();
        }
        public void updateHopes(string id) {
            SolrQueryResults<SearchItem> searchItems = solr.Query(new SolrQuery("id:"+id));
            var item = searchItems.FirstOrDefault();
            item.Hopes = item.Hopes + 1;
            this.AddAndEdit(item);
        }
        public SolrQueryResults<SearchItem> SearchList(string name) {
            var extraParams = new List<KeyValuePair<string, string>>();
            extraParams.Add(new KeyValuePair<string, string>("bf", "Hopes^10"));
            extraParams.Add(new KeyValuePair<string, string>("defType", "edismax"));
            extraParams.Add(new KeyValuePair<string, string>("qf", "Name^5"));

            QueryOptions options = new QueryOptions();
            options.Rows = 10;
            options.ExtraParams = extraParams;
            SolrQueryResults<SearchItem> searchItems = solr.Query(new SolrQuery(name),options);

            return searchItems;
        }
    }
}
