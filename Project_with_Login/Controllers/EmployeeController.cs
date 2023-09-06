using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspNetCore.Reporting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_with_Login.Data;

namespace Project_with_Login.Controllers
{
    [Route ("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
       // EmployeeService EmployeeService = new EmployeeService();

        public EmployeeController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnvironment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
               
        }

        [HttpGet]
        [Route("EmployeeReport")]
        public IActionResult EmployeeReport()
        {
            var dt = new DataTable();
            //dt = EmployeeService.GetEmployeeInfo();

            string mimetype = "";
            int extension = 1;
            var path = $"{this._webHostEnvironment.WebRootPath}\\Reports\\EmployeeReport.rdlc";

            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("param", "Blazor RDLC Report");
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("dsEmployeeInfo", dt);
            var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimetype);
            return File(result.MainStream, "application/pdf");
        }
    }
}
