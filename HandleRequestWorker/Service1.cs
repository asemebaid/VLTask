using Dapper;
using HealthAttache.Data.UnitOfWork;
using Newtonsoft.Json;
using Requests.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HandleRequestWorker
{
    public class UpdateModel
    {
        public string MobileNumber { get; set; }
    }
    public partial class Service1 : ServiceBase
    {
         Thread worker;
        AutoResetEvent StopRequest = new AutoResetEvent(false);

        public Service1()
        {
            try
            {
 
                InitializeComponent();
            }
            catch (Exception e)
            {

                throw;
            }

        }

        protected override void OnStart(string[] args)
        {
            worker = new Thread(DoSomething);
            worker.Start();

        }
        private void DoSomething(object args)
        {
            Thread.Sleep(10000);
            for (; ; )
            {
                List<Request> requests = new List<Request>();
                using (var connection = new SqlConnection(@"Server=.\SQLEXPRESS;Database=RequestDB;Integrated Security=SSPI"))
                {
                    requests = connection.Query<Request>("Select * From Request where Handled='false'").ToList();
                }
                 
                foreach (var item in requests)
                {
                    var input = new UpdateModel();
                    input.MobileNumber = item.MobileNumber.ToString();
                    var inputString = JsonConvert.SerializeObject(input);
                    using (HttpClient client = new HttpClient())
                    {
                        client.DefaultRequestHeaders
                            .Accept
                            .Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        var content = new StringContent(inputString, UnicodeEncoding.UTF8, "application/json");
                        var response = client.PostAsync("http://localhost:59713/api/values/updateStatus", content).Result;
                        var jsonString = response.Content.ReadAsStringAsync().Result;

                        var r = JsonConvert.DeserializeObject<RequestReturnMeassgeDto>(jsonString);
                    }


                }
                //
                if (StopRequest.WaitOne(50000)) return;
            }
        }

        protected override void OnStop()
        {
            StopRequest.Set();
            worker.Join();
        }
    }
    public class RequestReturnMeassgeDto
    {
        public int Status { get; set; }
        public string Message { get; set; }

    }

}
