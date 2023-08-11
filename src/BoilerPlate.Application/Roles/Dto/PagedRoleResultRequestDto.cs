using Abp.Application.Services.Dto;

namespace BoilerPlate.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

