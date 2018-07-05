using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class HttpRequest
    {
        //http://192.168.9.135:7301/OrdersService.svc/GetPatientOrderViewInfo

        /// <summary>
        /// 
        /// </summary>
        /// <param name="BasUrl">url</param>
        /// <param name="methodName">方法</param>
        /// <param name="param">参数</param>
        /// <returns></returns>
        public static ResutEntity<T> GetWebService<T>(string BasUrl, string methodName, object param = null) where T : new()
        {
            try
            {
                //拼接全路径
                methodName = BasUrl + "/" + methodName;
                string json = param == null ? "" : param.ToJson();
                //请求数据
                var mresult = Request(methodName, json);
                var df = mresult.ToObject<ResutEntity<T>>();
                return !string.IsNullOrEmpty(mresult) ? mresult.ToObject<ResutEntity<T>>() : default(ResutEntity<T>);
            }
            catch (Exception ex)
            {
                return default(ResutEntity<T>);
            }
        }
        /// <summary>
        /// 请求数据
        /// </summary>
        /// <param name="url"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        private static string Request(string url, string param)
        {
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            Stream stream = null;
            Stream stream1 = null;
            CookieContainer cc = new CookieContainer();
            try
            {
                byte[] postBytes = Encoding.GetEncoding("UTF-8").GetBytes(param);

                request = (HttpWebRequest)WebRequest.Create(url);
                request.Timeout = 40000;//40秒40000
                request.Method = "POST";
                request.ContentType = "application/json";
                request.MaximumResponseHeadersLength = 200000;
                // request.KeepAlive = false;//System.Net.WebException: 基础连接已经关闭: 服务器关闭了本应保持活动状态的连接。
                //request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; rv:19.0) Gecko/20100101 Firefox/19.0";
                request.ContentLength = postBytes.Length;
                request.ProtocolVersion = HttpVersion.Version10;

                stream = request.GetRequestStream();
                stream.Write(postBytes, 0, postBytes.Length); //设置请求主体的内容
                stream.Close();
                //接收响应
                response = (HttpWebResponse)request.GetResponse();

                stream1 = response.GetResponseStream();
                if (stream1 != null)
                {
                    using (var sr = new StreamReader(stream1))
                    {
                        return sr.ReadToEnd();
                    }
                }
                return "";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                response?.Close();
                stream?.Close();
                stream1?.Close();
            }
        }
    }
}
