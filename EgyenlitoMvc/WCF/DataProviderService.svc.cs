using EgyenlitoMvc.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EgyenlitoMvc.WCF
{
    public class DataProviderService : IDataProviderService
    {
        public NewspaperModelContainer Entities { get; set; }

        public DataProviderService()
        {
            Entities = new NewspaperModelContainer();
        }


        public string GetNewspapers()
        {
            var newspapers = Entities.Newspapers.OrderByDescending((x) => x.UploadDate).ToList();

            var str = JsonConvert.SerializeObject(newspapers);
            return str;
        }

        public string GetAllArticles()
        {
            var articles = Entities.Articles.OrderBy((x) => x.Title).ToList();

            var str = JsonConvert.SerializeObject(articles);
            return str;
        }

        public string GetArticles(int newspaperId)
        {
            var articles = from article in Entities.Articles
                           where article.NewspaperId == newspaperId
                           orderby article.Title
                           select article;

            var str = JsonConvert.SerializeObject(articles);
            return str;
        }
    }
}
