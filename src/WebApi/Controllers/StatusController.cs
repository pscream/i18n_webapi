using System;
using System.Linq;

using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Mvc;

using WebApi.Models;
using System.Globalization;

namespace WebApi.Controllers
{

    [Route("[controller]")]
    public class StatusController : Controller
    {

        private const string CURRENT_TIME = "CURRENT_TIME";

        private readonly IStringLocalizer<StatusController> _localizer;

        public StatusController(IStringLocalizer<StatusController> localizer)
        {
            _localizer = localizer;
        }

        [HttpGet]
        [Route("{culture}")]
        public CurrentTime Get(string culture)
        {
            CultureInfo.CurrentUICulture = new CultureInfo(culture);
            //CultureInfo.CurrentCulture = new CultureInfo("en");
            //var strings = _localizer.GetAllStrings().ToList();
            
            return new CurrentTime() { Text = _localizer[CURRENT_TIME], Now = DateTime.Now };
        }

    }

}
