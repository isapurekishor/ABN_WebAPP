using ABN_WebAPI.Model;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ABN_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreaController : ControllerBase
    {
        public ResultModel StartCalculation(int radius)
        {
            ResultModel resultModel = new ResultModel();
            if (radius != 0)
            {
                resultModel.Diameter = Convert.ToDecimal(Constants.Di_Constant * radius);
                resultModel.Progress = Convert.ToInt32(Progress.First);

                resultModel.Circumference = Convert.ToDecimal(Constants.Ci_Constant * Constants.Pi * radius);
                resultModel.Progress = Convert.ToInt32(Progress.Second);

                resultModel.Area = Convert.ToDecimal(Constants.Pi * (radius * radius));
                resultModel.Progress = Convert.ToInt32(Progress.Third);

            }
            return resultModel;
        }
    }
}
