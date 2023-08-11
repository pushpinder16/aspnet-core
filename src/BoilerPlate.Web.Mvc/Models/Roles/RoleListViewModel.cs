using BoilerPlate.Roles.Dto;
using System.Collections.Generic;

namespace BoilerPlate.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}
