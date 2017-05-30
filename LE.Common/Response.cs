using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LE.Common
{
    /// <summary>
    /// Response类是一个常用的方法返回数据类型，包含返回代码、返回消息和返回数据3个属性。
    /// </summary>
    public class Response
    {
        /// <summary>
        /// 返回代码. 0-失败，1-成功，其他-具体见方法返回值说明
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// 返回消息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 返回数据,动态数据类型，类似于匿名类，只是匿名类的字段可读不可写。动态类型可以
        /// </summary>
        public dynamic Data { get; set; }

        public Response()
        {
            Code = 0;
        }
    }
}
