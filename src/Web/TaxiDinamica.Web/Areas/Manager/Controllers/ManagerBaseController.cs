namespace TaxiDinamica.Web.Areas.Manager.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using TaxiDinamica.Common;
    using TaxiDinamica.Web.Controllers;

    [Authorize(Roles = GlobalConstants.PartnerManagerRoleName)]
    [Area("Manager")]
    public class ManagerBaseController : BaseController
    {
    }
}
