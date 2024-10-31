using System.ComponentModel;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using SqlSugar;
using SqlSugar.Extensions;
using Wechat.Servers;

/// <summary>
/// 图库分类服务
/// </summary>
public class GalleryServiceController : WxApiControllerBase
{
    private readonly ISqlSugarClient _db;

    public GalleryServiceController(ISqlSugarClient db)
    {
        _db = db;
    }

    private int UserId => HttpContext?.User.FindFirst("UserId")?.Value.ObjToInt() ?? 0;
    private string OpenID => HttpContext?.User.FindFirst("OpenID")?.Value ?? "";


    /// <summary>
    /// 获取图库分类
    /// </summary>
    /// <returns></returns>
    [Description("获取图库分类信息")]
    [HttpGet]
    public async Task<dynamic> Categorize()
    {
        var listoutput = new List<CategorizeOutput>();
        var entity = new CategorizeOutput();
        entity.title = "分类";
        entity.backgroundColor = "backgroundColor";

        var listitem = new List<CategorizeOutputItem>();

        var type = _db.Queryable<BsGallery>().GroupBy(x => x.Type)
            .Select(x => new { x.Type }).ToList();
        foreach (var item in type)
            listitem.Add(new CategorizeOutputItem
            {
                icon = "gloves",
                title = item.Type,
                url = "/pages/randomgril/randomgril?type=" + item.Type
            });

        entity.list = listitem;
        listoutput.Add(entity);
        return listoutput;
    }


    /// <summary>
    /// 获取一张随机壁纸的照片
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<dynamic> RandomImg(string type, int count = 0, int imgid = 0)
    {
        var date = await _db.Queryable<BsGallery>()
            .WhereIF(type != null, x => x.Type == type)
            .WhereIF(imgid > 0, x => x.ImagesID == imgid)
            .Where(x => x.IsDelete == false)
            .Take(5)
            .OrderBy(x => SqlFunc.GetRandom())
            .FirstAsync();

        //默认情况下，无需任何配置，Mapster会根据两个实体字段名称相同进行匹配
        //第一次调用时，配置会被缓存，第二次将会从缓存中取，以此提升性能
        var output = date.Adapt<RandomGalleryOutput>();
        //用户是否喜欢 
        if (UserId > 0)
            output.customer_collect = await _db.Queryable<BsCustomerCollect>()
                .Where(x => x.UserID == UserId)
                .Where(x => x.ImagesID == output.ImagesID).FirstAsync();

        return output;
    }

    /// <summary>
    /// 喜欢图片
    /// </summary>
    /// <param name="imgid"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<bool> LikeImg(int imgid, bool islike)
    {
        var customerentity = await _db.Queryable<BsCustomer>()
            .Where(x => x.OpenID == OpenID).FirstAsync();
        if (customerentity == null) throw new Exception("获取用户信息失败，请重新登录");

        var list = await _db.Queryable<BsCustomerCollect>()
            .Where(x => x.ImagesID == imgid).ToListAsync();

        //更新次数 
        var likenum = list.Where(x => x.IsLike == true).Count();
        var dislikenum = list.Where(x => x.IsLike == false).Count();


        var userentity = list.Where(x => x.UserID == customerentity.UserID).FirstOrDefault();
        if (userentity != null)
        {
            if (islike) likenum--;
            else dislikenum--;
            _db.Deleteable<BsCustomerCollect>()
                .Where(x => x.UserID == customerentity.UserID)
                .Where(x => x.ImagesID == imgid).ExecuteCommand();
        }
        else
        {
            if (islike) likenum++;
            else dislikenum++;
            var entity = new BsCustomerCollect();
            entity.ImagesID = imgid;
            entity.UserID = customerentity.UserID;
            entity.IsLike = islike;
            _db.Insertable(entity).ExecuteCommand();
        }

        //不喜欢五次自动删除照片
        _db.Updateable<BsGallery>()
            .SetColumnsIF(dislikenum >= 5, x => x.IsDelete == true)
            .SetColumns(x => x.DisLike == dislikenum)
            .SetColumns(x => x.Praise == likenum)
            .Where(x => x.ImagesID == imgid)
            .ExecuteCommand();


        return true;
    }

    /// <summary>
    /// 获取用户喜欢的照片
    /// </summary>
    /// <param name="imgid"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<dynamic> LikeImgList([FromQuery] LikeImgPage input)
    {
        if (UserId == null) throw new Exception("获取用户信息失败，请重新登录");
        var like = await _db.Queryable<BsGallery>()
            .RightJoin<BsCustomerCollect>((g, c) => g.ImagesID == c.ImagesID)
            .Where((g, c) => c.IsLike == true && c.UserID == UserId)
            .ToPagedListAsync(input.PageNo, input.PageSize);

        return like.XnPagedResult();
    }
}