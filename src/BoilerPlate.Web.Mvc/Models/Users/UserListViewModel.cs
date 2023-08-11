using BoilerPlate.Roles.Dto;
using System.Collections.Generic;

namespace BoilerPlate.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
