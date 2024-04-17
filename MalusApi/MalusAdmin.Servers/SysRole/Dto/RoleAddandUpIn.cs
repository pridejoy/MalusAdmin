using SqlSugar;

namespace MalusAdmin.Servers.SysRole
{
    public class RoleAddandUpIn
    {
        /// <summary>
        /// 主键
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
		///角色名称
		/// </summary> 
        public String Name { get; set; }
         

        /// <summary>
        ///描述
        /// </summary> 
        public String Desc { get; set; }

        /// <summary>
        ///是否启用
        ///默认值:1
        /// </summary> 
        public Boolean Status { get; set; }
    }
}