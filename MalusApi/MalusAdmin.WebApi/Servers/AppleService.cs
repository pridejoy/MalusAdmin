using Simple.DynamicWebApi.Abstractions;

namespace MalusAdmin.WebApi.Servers
{
    [ApiExplorerSettings(GroupName =nameof(ApiVersionGropInfo.Default))]
    public class AppleService: IDynamicWebApi
    {

        [HttpGet("{id}")]
        public int Get(int id)
        {
            return id;
        }
    }
}
