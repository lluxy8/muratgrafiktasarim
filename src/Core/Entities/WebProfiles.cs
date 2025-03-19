using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class WebProfile
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required Theme Theme { get; set; }

        public IEnumerable<Carousel> Carousels { get; set; } = [];
        public IEnumerable<ProjectForIndex> ProjectsForIndex { get; set; } = [];
        public IEnumerable<FooterLink> FooterLinks { get; set; } = [];
        public IEnumerable<NavbarLink> NavbarLinks { get; set; } = [];

        public DateTime Date { get; set; } = DateTime.Now;
    }

    public class Carousel
    {
        public string? Title { get; set; }
        public string? Text { get; set; }
        public string? Image { get; set; }
    }

    public class ProjectForIndex
    {
        public string? Name { get; set; }
        public string? Image { get; set; }
        public string? Url { get; set; }

    }

    public class FooterLink
    {
        public string? Text { get; set; }
        public string? Url { get; set; }
    }

    public class NavbarLink
    {
        public string? Text { get; set; }
        public string? Url { get; set; }
    }

    public class Theme
    {
        public string? PrimaryColor { get; set; }
        public string? SecondaryColor { get; set; }
        public string? TertiaryColor { get; set; }
    }


}
