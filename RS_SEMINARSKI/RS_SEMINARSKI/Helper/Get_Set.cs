using Data.EFModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS_SEMINARSKI.Helper
{
    public static class Get_Set
    {

        public static void SetLogiraniKorisnik(this HttpContext httpContext, Korisnik k)
        {
            httpContext.Session.Set<Korisnik>("nekiKljucVarijabla", k);
        }

        public static Korisnik GetLogiraniKorisnik(this HttpContext httpContext)
        {
            var k = httpContext.Session.Get<Korisnik>(key: "nekiKljucVarijabla");
            return k;
        }


    }
}
