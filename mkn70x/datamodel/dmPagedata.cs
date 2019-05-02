using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mkn70x.datamodel
{
	public class dmWattData
	{
		private List<dmKeyValuePair> _values = null;

		public dmWattData()
		{
			_values = new List<dmKeyValuePair>();
		}

		public decimal unit_price { get; set; }
		public decimal buy_watts { get; set; }

		public List<dmKeyValuePair> values
		{
			get
			{
				return _values;
			}
			set
			{
				_values = value;
			}
		}
	}
}
