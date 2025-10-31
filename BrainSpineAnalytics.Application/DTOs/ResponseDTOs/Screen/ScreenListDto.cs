using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainSpineAnalytics.Application.DTOs.ResponseDTOs.Screen
{
    public class ScreenListDto
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; } = string.Empty;
        public int ScreenId { get; set; }
        public string? ScreenName { get; set; }  
    }
}
