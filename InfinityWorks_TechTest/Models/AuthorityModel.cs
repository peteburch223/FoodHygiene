using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using InfinityWorks_TechTest.Helpers;

namespace InfinityWorks_TechTest.Models
{
    public interface IAuthorities
    {
        void getAll();
        List<Authority> authorities { get; set; }
    }

    public class Authorities : IAuthorities
    {
        public List<Authority> authorities { get; set; }
        public Meta meta { get; set; }
        public List<Link> links { get; set; }

        private readonly String endPoint = "Authorities";
        private IFoodHygieneRESTService _service;

        public Authorities(IFoodHygieneRESTService service)
        {
            _service = service;
            authorities = new List<Authority>();
        }

        public void getAll()
        {
            authorities = JsonConvert.DeserializeObject<Authorities>(_service.getAPIData(endPoint)).authorities;
        }
    }

    public interface IAuthority
    {
         int LocalAuthorityId { get; set; }
         string Name { get; set; }
    }

    public class Authority : IAuthority
    {
        public int LocalAuthorityId { get; set; }
        public string LocalAuthorityIdCode { get; set; }
        public string Name { get; set; }
        public string FriendlyName { get; set; }
        public string Url { get; set; }
        public string SchemeUrl { get; set; }
        public string Email { get; set; }
        public string RegionName { get; set; }
        public string FileName { get; set; }
        public string FileNameWelsh { get; set; }
        public int EstablishmentCount { get; set; }
        public string CreationDate { get; set; }
        public string LastPublishedDate { get; set; }
        public int SchemeType { get; set; }
        public List<Link> links { get; set; }
    }

    public class Meta
    {
        public string dataSource { get; set; }
        public string extractDate { get; set; }
        public int itemCount { get; set; }
        public string returncode { get; set; }
        public int totalCount { get; set; }
        public int totalPages { get; set; }
        public int pageSize { get; set; }
        public int pageNumber { get; set; }
    }

    public class Link
    {
        public string rel { get; set; }
        public string href { get; set; }
    }
}