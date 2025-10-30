using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainSpineAnalytics.Application.DTOs.RequestDTOs.UserDTO
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string? FullName { get; set; }
       
        public string Email { get; set; } = string.Empty;
        public int? ClinicId { get; set; }
    }
}
