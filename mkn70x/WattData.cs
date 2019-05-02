using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mkn70x.datamodel;

namespace mkn70x
{
	public class WattData
	{
		string _server = string.Empty;
		string _password = string.Empty;

		public WattData(string server, string password)
		{
			_server = server;
			_password = password;
		}

		public dmWattData Get()
		{
			dmWattData res = new dmWattData();

			List<dmKeyValuePair> lst = new List<dmKeyValuePair>();

			//dtl
			res.values.AddRange(GetDetail(0));
			res.values.AddRange(GetDetail(1));

			//header
			var val = GetHeader();
			decimal[] i = { 0, 0 };
			
			decimal.TryParse(val["buyElecT"], out i[0]);
			decimal.TryParse(val["buyUnitT"], out i[1]);

			res.buy_watts = i[0] * 1000;
			res.unit_price = i[1];

			var circuitPower = res.values.Sum(x => x.value);

			if (res.buy_watts != circuitPower)
			{
				var xx = new dmKeyValuePair()
				{
					 access_status = "0"
					,pageno = "-1"
					,name = "unknown"
					,value = (res.buy_watts - circuitPower)
					,unit = "W"
				};

				res.values.Add(xx);
			}

			return res;
		}

		public Dictionary<string, string> GetHeader()
		{
			var url = string.Format("http://{0}/get/top_ajax.cgi", _server);

			string res = new common.http("", _password).Get(url);

			Dictionary<string, string> ret = new Dictionary<string, string>();

			res.Split(';')
				.ToList()
				.ForEach(x =>
				{
					string tmp = x.Replace("\n", "").Replace("\"", "").Trim();

					if (tmp.StartsWith("var"))
					{
						var xx = tmp.Replace("var ", "").Replace("\"", "").Split('=');

						if (xx.Length == 2)
						{
							ret.Add(xx[0].Trim(), xx[1].Trim());
						}
					}
				});

			return ret;
		}


		public List<dmKeyValuePair> GetDetail(int pageNo)
		{
			var url = string.Format("http://{0}/get/instantvalajaxdata.cgi?pageno={1}", _server, pageNo.ToString());
			
			string res = new common.http("", _password).Get(url);

			Dictionary<string, string> dic = new Dictionary<string, string>();

			res.Split(';')
				.ToList()
				.ForEach(x =>
				{
					var tmp = x.Replace("\n", "").Replace("\"", "").Split('=');

					if (tmp.Length == 2)
					{
						dic.Add(tmp[0].Replace("javascript:parent.", "").Trim(), tmp[1].Trim());
					}
				});

			var ret = new List<dmKeyValuePair>();

			foreach (var row in dic)
			{
				if (row.Key.StartsWith("name"))
				{
					var key = row.Key.Replace("name", "");

					var xx = new dmKeyValuePair()
					{
						 name = row.Value
						,access_status = dic["access_status"]
						,pageno = dic["pageno"]
						,value = 0
						,unit = string.Empty
					};

					var v = dic["value" + key];

					if (!string.IsNullOrEmpty(v))
					{
						decimal i = 0;

						xx.unit = v.Substring(v.Length - 1, 1);
						decimal.TryParse(v.Substring(0, v.Length - 1), out i);
						xx.value = i;
					}

					ret.Add(xx);
				}
			}

			return ret;
		}
	}
}
