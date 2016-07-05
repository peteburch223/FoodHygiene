using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using InfinityWorks_TechTest.Helpers;

namespace InfinityWorks_TechTest.Helpers
{
    public interface IEstablishments
    {
        void getAllByAuthorityID(Int32 localAuthorityId);
        Int32 count { get; set; }
        List<Establishment> establishments { get; set; }
        Meta meta { get; set; }
        List<Link> links { get; set; }
    }

    public class Establishments : IEstablishments
    {
        public List<Establishment> establishments { get; set; }
        public Meta meta { get; set; }
        public List<Link> links { get; set; }
        public Int32 count { get; set; }

        private static readonly String endPoint = "Establishments?localAuthorityId";
        private IFoodHygieneRESTService service;

        public Establishments(IFoodHygieneRESTService service)
        {
            this.service = service;
        }

        public void getAllByAuthorityID(Int32 localAuthorityId)
        {
            this.establishments = JsonConvert.DeserializeObject<Establishments>(service.getAPIData($"{endPoint}={localAuthorityId}")).establishments;
            count = this.establishments.Count;
        }
    }

    public class Establishment
    {
        public int FHRSID { get; set; }
        public string LocalAuthorityBusinessID { get; set; }
        public string BusinessName { get; set; }
        public string BusinessType { get; set; }
        public int BusinessTypeID { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string AddressLine4 { get; set; }
        public string PostCode { get; set; }
        public string Phone { get; set; }
        public string RatingValue { get; set; }
        public string RatingKey { get; set; }
        public string RatingDate { get; set; }
        public string LocalAuthorityCode { get; set; }
        public string LocalAuthorityName { get; set; }
        public string LocalAuthorityWebSite { get; set; }
        public string LocalAuthorityEmailAddress { get; set; }
        public Scores scores { get; set; }
        public string SchemeType { get; set; }
        public Geocode geocode { get; set; }
        public string RightToReply { get; set; }
        public object Distance { get; set; }
        public bool NewRatingPending { get; set; }
        public List<Link> links { get; set; }
    }

    public class Scores
    {
        public object Hygiene { get; set; }
        public object Structural { get; set; }
        public object ConfidenceInManagement { get; set; }
    }

    public class Geocode
    {
        public string longitude { get; set; }
        public string latitude { get; set; }
    }
}