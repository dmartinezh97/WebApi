using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Helpers {
    public class MyStaticHelperClass {
        private static IHttpContextAccessor httpContextAccessor;
        public static void SetHttpContextAccessor(IHttpContextAccessor accessor) {
            httpContextAccessor = accessor;
        }

        public static string GetRequestScheme() {
            return httpContextAccessor.HttpContext.Request.Scheme;
        }

        public static HostString GetRequestHost() {
            return httpContextAccessor.HttpContext.Request.Host;
        }

        //public static void addReplaceCookie(string cookieName, string cookieValue) {
        //    var HttpContext = httpContextAccessor.HttpContext;
        //    if (HttpContext.Request.Cookies(cookieName) == null) {
        //        // add cookie
        //        HttpCookie s = new HttpCookie(cookieName);
        //        s.Value = cookieValue;
        //        s.Expires = DateTime.Now.AddDays(7);
        //        HttpContext.Response.Cookies.Add(s);
        //    } else {
        //        // ensure cookie value is correct 
        //        HttpCookie existingSchoolCookie = HttpContext.Request.Cookies(cookieName);
        //        existingSchoolCookie.Expires = DateTime.Now.AddDays(7);
        //        existingSchoolCookie.Value = cookieValue;
        //        HttpContext.Response.Cookies.Set(existingSchoolCookie);
        //    }
        //}
    }
}
