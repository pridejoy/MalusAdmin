namespace MalusAdmin.Common;

public interface IApiResultProvider
{
    IActionResult ProcessActionResult(IActionResult actionResult);

    IActionResult ProcessApiResultException(ApiResultException resultException);
}