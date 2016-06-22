using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BanHang.Utils
{
	public class CookieUtil
	{
		public static void SetCookie(string cookieName, string cookieValue)
		{
			var cookie = new HttpCookie(cookieName, cookieValue);
			HttpContext.Current.Response.Cookies.Add(cookie);
		}

		public static string GetCookie(string cookieName)
		{
			var cookies = HttpContext.Current.Request.Cookies;
			if (cookies.AllKeys.Contains(cookieName))
			{
				return cookies[cookieName].Value;
			}
			return null;
		}

		public static void ClearCookie()
		{
			HttpContext.Current.Request.Cookies.Clear();
		}
	}
}