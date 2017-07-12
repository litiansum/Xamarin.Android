using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Express.Tools.Responses
{
    /// <summary>
    /// 单号识别响应实体
    /// </summary>
    public class OrderDisResponse : BaseResponse
    {
        public List<Shipper> Shippers { get; set; }
    }

    public class Shipper
    {
        /// <summary>
        /// 快递公司代码
        /// </summary>
        public string ShipperCode { get; set; }
        /// <summary>
        /// 快递公司名称
        /// </summary>
        public string ShipperName { get; set; }
    }
}