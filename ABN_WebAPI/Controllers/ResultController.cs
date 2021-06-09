using ABN_WebAPI.Model;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ABN_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultController : ControllerBase
    {
        AreaController area = new AreaController();
        [HttpGet("{radius}")]
        public ResultModel GetStatus(int radius)
        {
            ResultModel resultModel = new ResultModel();

            try
            {
                if (radius != 0)
                {
                    resultModel = area.StartCalculation(Convert.ToInt32(radius));
                    if (resultModel != null)
                    {
                        resultModel.Status = Convert.ToString(Status.Completed);
                        resultModel.Progress = Convert.ToInt32(Progress.Complete);
                    }
                    return resultModel;
                }
                else
                {
                    resultModel.Status = Convert.ToString(Status.Failed);
                    return resultModel;
                }
            }
            catch (Exception)
            {
                resultModel.Status = Convert.ToString(Status.Failed);
                return new ResultModel();
            }
        }
    }
}
