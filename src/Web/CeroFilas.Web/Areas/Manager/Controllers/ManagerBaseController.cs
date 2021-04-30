namespace CeroFilas.Web.Areas.Manager.Controllers
{
    using CeroFilas.Common;
    using CeroFilas.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.PartnerManagerRoleName)]
    [Area("Manager")]
    public class ManagerBaseController : BaseController
    {
    }
}
