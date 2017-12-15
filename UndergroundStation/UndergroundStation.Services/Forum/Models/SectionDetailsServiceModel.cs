using System;
using System.Collections.Generic;
using System.Text;
using UndergroundStation.Common.Mapping;
using UndergroundStation.Data.Models;

namespace UndergroundStation.Services.Forum.Models
{
    public class SectionDetailsServiceModel : IMapFrom<ForumSection>
    {
        public int Id { get; set; }

        public string Tittle { get; set; }

        public List<ForumTheme> Themes { get; set; } = new List<ForumTheme>();
    }
}
