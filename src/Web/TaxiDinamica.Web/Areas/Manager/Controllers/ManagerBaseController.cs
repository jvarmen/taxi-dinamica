namespace TaxiDinamica.Web.Areas.Manager.Controllers
{
    using TaxiDinamica.Common;
    using TaxiDinamica.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.PartnerManagerRoleName)]
    [Area("Manager")]
    public class ManagerBaseController : BaseController
    {
    }
}
