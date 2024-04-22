using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalusAdmin.Common
{
    public static class ObjectHelper
    {
        /// <summary>
        /// 检查 Object 是否为 NULL
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsEmpty(this object value)
        {
            return value == null || string.IsNullOrEmpty(value.ToString());
        }
    }
}
