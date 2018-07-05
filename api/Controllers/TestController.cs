using Common;
using System.Web.Http;

namespace api.Controllers
{
    [RoutePrefix("api/test")]
    public class TestController : ApiController
    {
        //private ITestService service;
        //public TestController(ITestService iservice)
        //{
        //    service = iservice;
        //}
        /// <summary>
        /// 测试用例
        /// </summary>
        /// <param name="str"></param>
        [Route("void/test/{str}")]
        public bool Test(string str)
        {
            //object param = null;
            //string json = param == null ? "" : param.ToJson();
            string uil = "http://192.168.9.135:7301/OrdersService.svc";
            string methodName = "GetPatientOrderViewInfo";
            var ss = HttpRequest.GetWebService<object>(uil, methodName, "20154161");
            return true;
        }
    }
}