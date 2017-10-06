﻿namespace sharp.Serene.BasicSamples.Endpoints
{
    using Serenity.Data;
    using Serenity.Reporting;
    using Serenity.Services;
    using Serenity.Web;
    using System;
    using System.Data;
    using System.Web.Mvc;
    using MyRepository = Repositories.CustomerGrossSalesRepository;
    using MyRow = Northwind.Entities.CustomerGrossSalesRow;

    [RoutePrefix("Services/BasicSamples/CustomerGrossSales"), Route("{action}")]
    [ConnectionKey(typeof(MyRow)), ServiceAuthorize(typeof(MyRow))]
    public class CustomerGrossSalesController : ServiceEndpoint
    {
        public ListResponse<MyRow> List(IDbConnection connection, CustomerGrossSalesListRequest request)
        {
            return new MyRepository().List(connection, request);
        }

        public FileContentResult ListExcel(IDbConnection connection, CustomerGrossSalesListRequest request)
        {
            var data = List(connection, request).Entities;
            var report = new DynamicDataReport(data, request.IncludeColumns, typeof(Columns.CustomerGrossSalesColumns));
            var bytes = new ReportRepository().Render(report);
            return ExcelContentResult.Create(bytes, "CustomerGrossSales_" +
                DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx");
        }
    }
}
