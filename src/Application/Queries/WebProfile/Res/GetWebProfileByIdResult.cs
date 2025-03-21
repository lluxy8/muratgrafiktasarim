using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.WebProfile.Res
{
    public class GetWebProfileByIdResult
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string LogoUrl { get; set; }
        public required string FaviconUrl { get; set; }
        public string? MetaKeywords { get; set; }
        public string? MetaDescription { get; set; }
        public required Theme Theme { get; set; }

        public IEnumerable<Carousel> Carousels { get; set; } = [];
        public IEnumerable<ProjectForIndex> ProjectsForIndex { get; set; } = [];
        public IEnumerable<FooterLink> FooterLinks { get; set; } = [];
        public IEnumerable<NavbarLink> NavbarLinks { get; set; } = [];

        public DateTime Date { get; set; }
    }
}
