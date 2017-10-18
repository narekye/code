using NLog;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Web.Http.Tracing;
using ITraceWriter = System.Web.Http.Tracing.ITraceWriter;
using TraceLevel = System.Web.Http.Tracing.TraceLevel;

namespace sharp.aspnet.webapi.Helpers.Logger
{
    public class NLogger : ITraceWriter
    {
        private static readonly NLog.Logger cLogger = LogManager.GetCurrentClassLogger();

        private static readonly Lazy<Dictionary<TraceLevel, Action<string>>> loggingMap =
            new Lazy<Dictionary<TraceLevel, Action<string>>>(() => new Dictionary<TraceLevel, Action<string>>
            {
                { TraceLevel.Info, cLogger.Info },
                { TraceLevel.Debug, cLogger.Debug },
                { TraceLevel.Error, cLogger.Error },
                { TraceLevel.Fatal, cLogger.Fatal },
                { TraceLevel.Warn, cLogger.Warn }
            });

        private Dictionary<TraceLevel, Action<string>> Logger => loggingMap.Value;



        public void Trace(HttpRequestMessage request, string category, TraceLevel level, Action<TraceRecord> traceAction)
        {
            if (level != TraceLevel.Off)
            {
                var record = new TraceRecord(request, category, level);
                traceAction(record);
                Log(record);
            }
        }

        private void Log(TraceRecord record)
        {
            // you can edit this sample.
            var message = new StringBuilder();

            if (record.Request != null)
            {
                if (record.Request.Method != null)
                    message.Append(record.Request.Method);

                if (record.Request.RequestUri != null)
                    message.Append(" ").Append(record.Request.RequestUri);
            }

            if (!string.IsNullOrWhiteSpace(record.Category))
                message.Append(" ").Append(record.Category);

            if (!string.IsNullOrWhiteSpace(record.Operator))
                message.Append(" ").Append(record.Operator).Append(" ").Append(record.Operation);

            if (!string.IsNullOrWhiteSpace(record.Message))
                message.Append(" ").Append(record.Message);

            if (record.Exception != null && !string.IsNullOrWhiteSpace(record.Exception.GetBaseException().Message))
                message.Append(" ").Append(record.Exception.GetBaseException().Message);

            Logger[record.Level](message.ToString());
        }
    }
}