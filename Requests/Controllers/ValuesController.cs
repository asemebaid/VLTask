using HealthAttache.Data.Infrastructure;
using HealthAttache.Data.UnitOfWork;
using Requests.Contract.v1;
using Requests.Data;
using Requests.Data.Dtos;
using Requests.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Requests.Controllers
{
 
    public class ValuesController : ApiController
    {
        private IUnitOfWorkRequest _UnitOfWork;

        ValuesController()
        {
            _UnitOfWork = new UnitOfWork();

        }

        // GET api/values
        [AllowAnonymous]
        [HttpPost]
        [Route("Post")]
        public RequestReturnMeassgeDto Post([FromBody] RequestDataDto requestData)
        {
            try
            {
                var context = new RequestDBEntities();  
                Request request = new Request
                {   
                    MobileNumber = requestData.MobileNumber,
                    Action = requestData.Action,
                    RequestDate = DateTime.Now,
                };
                 _UnitOfWork.RequestRepository.Add(request); 
                _UnitOfWork.Commit();

                return new RequestReturnMeassgeDto()
                {
                    Message = "Success",
                    Status = 1
                };
            }
            catch (Exception ex)
            {

                return new RequestReturnMeassgeDto()
                {
                    Message = "Faield",
                    Status = 2
                };
             }

        }

        // GET api/values
        [AllowAnonymous]
        [HttpPost]
         public RequestReturnMeassgeDto updateStatus([FromBody] UpdateModel updateModel)
        {
            try
            { 
               int MobileNumber =  Convert.ToInt32(updateModel.MobileNumber);
                var myresult = _UnitOfWork.RequestRepository.Get(c=>c.MobileNumber== MobileNumber);
                myresult.Handled = true; 
                myresult.HandlingDate = DateTime.Now; 
                _UnitOfWork.RequestRepository.Update(myresult);
                _UnitOfWork.Commit();
         
                return new RequestReturnMeassgeDto()
                {
                    Message = "Success",
                    Status = 1
                };
            }
            catch (Exception ex)
            {

                return new RequestReturnMeassgeDto()
                {
                    Message = "Faield",
                    Status = 2
                };
            }

        }

  
        public class UpdateModel
        {
            public string MobileNumber { get; set; }
        }

    }
}
