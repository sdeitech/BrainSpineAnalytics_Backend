using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainSpineAnalytics.Application.DTOs.ResponseDTOs.Menu
{
    public class MenuListDTO
    {
        public int RoleId { get; set; }
        public string HeaderName { get; set; } = string.Empty;
        public string SubHeaderName { get; set; } = string.Empty;
        public string? RouteUrl { get; set; }
        public string? Icon { get; set; }
        public int DisplayOrder { get; set; }
        public bool CanView { get; set; }
        public bool CanEdit { get; set; }
    }
}
