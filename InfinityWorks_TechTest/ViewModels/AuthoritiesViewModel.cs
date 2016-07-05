using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InfinityWorks_TechTest.Models;

namespace InfinityWorks_TechTest.ViewModels
{
    public interface IAuthoritiesViewModel
    {
        Dictionary<int, string> authoritiesDict { get; set; }
        int id { get; set; }
        void presentAuthorities();
    }

    public class AuthoritiesViewModel : IAuthoritiesViewModel
    {
        public Dictionary<int, string> authoritiesDict { get; set; }
        public int id { get; set; }

        private IAuthorities authorities;

        public AuthoritiesViewModel(IAuthorities authorities)
        {
            this.authorities = authorities;
        }

        public void presentAuthorities()
        {
            authorities.getAll();
            authoritiesDict = new Dictionary<int, string>();

            foreach (Authority authority in authorities.authorities)
            {
                authoritiesDict.Add(authority.LocalAuthorityId, authority.Name);
            };
        }
    }
}