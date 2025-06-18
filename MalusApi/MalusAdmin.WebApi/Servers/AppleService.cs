

using Simple.DynamicWebApi;

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


        [HttpPost("{id}")]
        public int post(int id)
        {
            return id;
        }
    }
}
