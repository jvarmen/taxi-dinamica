namespace TaxiDinamica.Web.Areas.Administration.Controllers
{
    using TaxiDinamica.Common;
    using TaxiDinamica.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}
