using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalusAdmin.Common
{
    public interface IApiResultProvider
    {
        IActionResult ProcessActionResult(IActionResult actionResult);

        IActionResult ProcessApiResultException(ApiResultException resultException);
    }
}
