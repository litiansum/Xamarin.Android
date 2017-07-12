using Express.Tools.Responses;
using System;
using System.Collections.Generic;
using System.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Tools
{
    public class KDNiaoHelper
    {
        //电商ID,请到快递鸟官网申请http://www.kdniao.com/ServiceApply.aspx
        private const string EBusinessID = "1295332";
        //电商加密私钥，快递鸟提供，注意保管，不要泄漏
        private const string AppKey = "65f3f78f-00e4-42ad-8ed5-3e06978fe762";

        /// <summary>
        /// Json方式  单号识别
        /// </summary>
        /// <returns></returns>
        public async Task<OrderDisResponse> OrderTracesSubByJson(string expressId = "710386923334")
        {
            try
            {
                //string reqUrl = "http://testapi.kdniao.cc:8081/Ebusiness/EbusinessOrderHandle.aspx";
                //正式
                string reqUrl = "http://api.kdniao.cc/Ebusiness/EbusinessOrderHandle.aspx";
                string requestData = "{'LogisticCode': '" + expressId + "'}";
                Dictionary<string, string> param = new Dictionary<string, string>();
                param.Add("RequestData", requestData);
                param.Add("EBusinessID", EBusinessID);
                param.Add("RequestType", "2002");
                string dataSign = SignHelper.Encrypt(requestData, AppKey, "UTF-8");
                param.Add("DataSign", dataSign);
                param.Add("DataType", "2");
                var response = await RestService.SendPost(reqUrl, param);
                var jsonObject = (JsonObject)JsonObject.Load(response);
                OrderDisResponse orderReponse = new OrderDisResponse();
                orderReponse.EBusinessID = jsonObject["EBusinessID"];
                orderReponse.Success = jsonObject["Success"];
                orderReponse.LogisticCode = jsonObject["LogisticCode"];
                var array = (JsonArray)jsonObject["Shippers"];
                orderReponse.Shippers = new List<Shipper>();
                foreach (var item in array)
                {
                    Shipper sp = new Shipper();
                    sp.ShipperCode = item["ShipperCode"];
                    sp.ShipperName = item["ShipperName"];
                    orderReponse.Shippers.Add(sp);
                }
                return orderReponse;
            }
            catch (Exception ex)
            {
                
            }
            return null;
        }
        /// <summary>
        /// 查询快递单物流轨迹
        /// </summary>
        /// <param name="exType"></param>
        /// <param name="exCode"></param>
        /// <returns></returns>
        public async Task<object> GetOrderTracesByJson(string exType,string exCode)
        {
            string reqUrl = "http://api.kdniao.cc/Ebusiness/EbusinessOrderHandle.aspx";
            string requestData = "{'OrderCode':'','ShipperCode':'"+ exType + "','LogisticCode':'"+ exCode + "'}";

            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("RequestData", requestData);
            param.Add("EBusinessID", EBusinessID);
            param.Add("RequestType", "1002");
            string dataSign = SignHelper.Encrypt(requestData, AppKey, "UTF-8");
            param.Add("DataSign", dataSign);
            param.Add("DataType", "2");

            var result = await RestService.SendPost(reqUrl, param);

            //根据公司业务处理返回的信息......

            return result;
        }
    }
}
