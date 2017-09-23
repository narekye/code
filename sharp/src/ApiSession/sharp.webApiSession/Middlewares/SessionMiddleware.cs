﻿using Microsoft.Owin;
using sharp.webApiSession.BLL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sharp.webApiSession.Middlewares
{
    public class SessionMiddleware : OwinMiddleware
    {
        public static readonly List<SessionModel> Session = new List<SessionModel>();
        public SessionMiddleware(OwinMiddleware next) : base(next)
        {
        }

        public override async Task Invoke(IOwinContext context)
        {
            var token = context.Request.Headers[""];
            var model = new SessionModel
            {
                Token = token
            };
            Session.Add(model);
            await Next.Invoke(context);
        }
    }
}