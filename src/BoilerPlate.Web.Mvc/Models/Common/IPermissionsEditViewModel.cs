using BoilerPlate.Roles.Dto;
using System.Collections.Generic;

namespace BoilerPlate.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}