//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EgyenlitoMvc.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    
    public partial class Newspaper
    {
        public Newspaper()
        {
            this.Articles = new HashSet<Article>();
        }
    
        public int NewspaperId { get; set; }
        public string Title { get; set; }
        public int Pages { get; set; }
        public string ReleaseDate { get; set; }
        public string UploadDate { get; set; }
        public string CoverUri { get; set; }
    
        [JsonIgnore]
        public virtual ICollection<Article> Articles { get; set; }
    }
}
