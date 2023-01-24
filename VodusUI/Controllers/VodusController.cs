using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using VodusDomainLayer.Model;


namespace VodusUILayer.Controllers
{
    public class VodusController : Controller
    {
        private readonly ILogger<VodusController> _logger;
        [Obsolete]
        private readonly IHostingEnvironment _env;
        private readonly IWebHostEnvironment _webHost;

        [Obsolete]
        public VodusController(ILogger<VodusController> logger,
            IHostingEnvironment env,
            IWebHostEnvironment webHost)
        {
            _env = env;
            _logger = logger;
            _webHost = webHost;

        }

        [HttpGet]
        public IActionResult Index()
        {
            List<PageContent> vodus = new List<PageContent>();
            return View(vodus);
        }

        [HttpPost]
        public IActionResult Index(IFormFile excelFileName, CancellationToken cancellationToken)
        {
            if (excelFileName == null || excelFileName.Length <= 0)
            {
                //return DemoResponse<List<PageContent>>.GetResult(-1, "formfile is empty");
            }

            if (!Path.GetExtension(excelFileName.FileName).Equals(".xlsx", StringComparison.OrdinalIgnoreCase))
            {
               // return DemoResponse<List<PageContent>>.GetResult(-1, "Not Support file extension");
            }

            var list = new List<PageContent>();
            
            using (var stream = excelFileName.OpenReadStream())
            {
                

                using (var package = new ExcelPackage(stream))
                {
                    if (package?.Workbook.Worksheets != null)
                    {
                        ExcelWorksheet worksheet = package.Workbook.Worksheets[1];
                        var rowCount = worksheet.Dimension.Rows;


                        for (int row =2; row <= rowCount; row++)
                        {
                            if (worksheet.Cells[row, 1].Value == null && worksheet.Cells[row, 2].Value == null && worksheet.Cells[row, 3].Value == null && worksheet.Cells[row, 4].Value == null && worksheet.Cells[row, 5].Value == null && worksheet.Cells[row, 6].Value == null && worksheet.Cells[row, 7].Value == null)
                            {
                                continue;
                            }
                            //if (worksheet.Cells["0"].Value == null)
                            //{
                            //    continue;
                            //}
                            //for(int i = 1; i <= rowCount; i++)
                            //{
                            //    if (worksheet.Cells.Value == null)
                            //    {
                            //        continue;
                            //    }
                            //}
                            var pageContext = new PageContent();
                            pageContext.Page = (worksheet.Cells[row, 1].Value ?? string.Empty).ToString().Trim();
                            pageContext.PromoTitle = (worksheet.Cells[row, 2].Value ?? string.Empty).ToString().Trim();
                            pageContext.PromoDescription = (worksheet.Cells[row, 3].Value ?? string.Empty).ToString().Trim();
                            pageContext.TermsCondition = (worksheet.Cells[row, 4].Value ?? string.Empty).ToString().Trim();
                            pageContext.StartDate = (worksheet.Cells[row, 5].Value ?? string.Empty).ToString().Trim();
                            pageContext.EndDate = (worksheet.Cells[row, 6].Value ?? string.Empty).ToString().Trim();
                            pageContext.ImageUrl = (worksheet.Cells[row, 7].Value ?? string.Empty).ToString().Trim();
                            list.Add(pageContext);
                        }
                    }

                }
            }
            //var result = DemoResponse<List<PageContent>>.GetResult(0, "OK", list);
            return View(list);

        }


    }
}
