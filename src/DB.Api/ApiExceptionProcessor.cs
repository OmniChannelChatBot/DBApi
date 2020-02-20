using OCCBPackage.Exceptions;
using Sentry;
using Sentry.Extensibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DB.Api
{
    public class ApiExceptionProcessor : SentryEventExceptionProcessor<ApiException>
    {
        protected override void ProcessException(
            ApiException exception,
            SentryEvent sentryEvent)
        {
            sentryEvent.AddBreadcrumb("Processor running on api exception.");

            //sentryEvent.SetTag("IsSpecial", exception.IsSpecial.ToString());
        }
    }
}
