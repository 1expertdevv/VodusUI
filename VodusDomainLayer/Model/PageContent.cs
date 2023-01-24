using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VodusDomainLayer.Model
{
    public class PageContent
    {
        //  Page Promo Title Promo Description Terms and Conditions    Start Date  End Date    Image URL

        public string? Page { get; set; } 
        public string? PromoTitle  { get; set; }
        public string? PromoDescription { get; set; }
        public string? TermsCondition { get; set; }
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
        public string? ImageUrl { get; set; }
    }

}
