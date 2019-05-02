using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using mkn70x;

namespace testapp
{
	public partial class Form1 : Form
	{
		private WattData client = null;




		public Form1()
		{
			InitializeComponent();
			timer1.Tick += Timer1_Tick;

			dgv.ReadOnly = true;
			
			if (System.Environment.GetCommandLineArgs().Length == 3)
			{
				client = new WattData(Environment.GetCommandLineArgs()[1], Environment.GetCommandLineArgs()[2]);
			}
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			if (client != null)
			{
				getValue();
				timer1.Enabled = true;
			}
		}

		private void Timer1_Tick(object sender, EventArgs e)
		{
			if (client != null)
			{
				getValue();
			}
		}

		private void getValue()
		{
			var x = client.Get();

			dgv.Rows.Clear();

			setText(string.Format("{0} Total:{1}W Cost: {2} JPY/h",
				  DateTime.Now.ToString() , x.buy_watts.ToString("N0") , (x.unit_price * (x.buy_watts / 1000)).ToString("N0")));

			foreach (var data in x.values)
			{
				if (string.IsNullOrEmpty(data.unit)) { continue; }

				using (var row = dgv.AddRow())
				{
					row.Cells[(int)ColNum.PAGENO].Value = data.pageno;
					row.Cells[(int)ColNum.NAME].Value = data.name;
					row.Cells[(int)ColNum.VALUE].Value = decimal.ToInt32(data.value).ToString("N0");
					row.Cells[(int)ColNum.UNIT].Value = data.unit;
					row.Cells[(int)ColNum.COST].Value = (data.value / 1000) * x.unit_price;

					if (data.pageno == "-1")
					{
						row.Cells[(int)ColNum.NAME].Value = "３Ｆサーバ系統";
					}

					using (var p = (CustomControls.CustomDataGridView.DataGridViewProgressBarCell)row.Cells[(int)ColNum.PERCENTAGE])
					{
						p.Minimum = 0;
						p.Maximum = decimal.ToInt32(x.buy_watts);
						p.Value = decimal.ToInt32(data.value);
					}
				}

				dgv.Sort(dgv.Columns[(int)ColNum.NAME],ListSortDirection.Ascending);
				dgv.SetAutoCellStyle();
			}
		}

		private void setText(string text)
		{
			if (base.InvokeRequired)
			{
				base.Invoke(new Action(() => setText(text)));

			}else
			{
				this.Text = text;
			}
		}

		private enum ColNum
		{
			PAGENO,
			NAME,
			VALUE,
			UNIT,
			PERCENTAGE,
			COST,
		}
	}
}
