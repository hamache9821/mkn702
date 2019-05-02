using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace mkn70x.common
{
	public class http
	{
		private string _user = string.Empty;
		private string _password = string.Empty;

		public http()
		{

		}

		public http(string user, string password)
		{
			_user = user;
			_password = password;			
		}

		public string Get(string url)
		{
			using (WebClient webClient = new WebClient())
			{
				//webClient.Headers.Add(HttpRequestHeader.Accept, " application/json");
				//webClient.Headers.Add(HttpRequestHeader.ContentType, " application/json");
				webClient.Encoding = Encoding.UTF8;
				//webClient.Credentials = new NetworkCredential("", _password);

				var namePassword = string.Format("{0}:{1}", "", _password);
				var chars = System.Text.Encoding.ASCII.GetBytes(namePassword);
				//var base64 = Convert.ToBase64String(chars);
				//webClient.Headers[HttpRequestHeader.Authorization] = "Basic " + base64;
				webClient.Headers.Add(HttpRequestHeader.Authorization, string.Format("Basic {0}", Convert.ToBase64String(chars)));

				string json = "";

				try
				{
					json = webClient.DownloadString(url);
				}
				catch (WebException ex)
				{
					if (ex.Status == WebExceptionStatus.ProtocolError)
					{
						HttpWebResponse HttpWebResponse = (HttpWebResponse)ex.Response;

						if (HttpWebResponse.StatusCode == HttpStatusCode.Unauthorized)
						{


						}
					}
					//break;
				}
				catch (Exception)
				{
					//break;
				}

				return json;
			}
		}
	}
}
