namespace testapp
{
	partial class Form1
	{
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows フォーム デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			this.dgv = new CustomControls.CustomDataGridView();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.pageno = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.value = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.percentage = new CustomControls.CustomDataGridView.DataGridViewProgressBarColumn();
			this.cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
			this.SuspendLayout();
			// 
			// dgv
			// 
			this.dgv.AllowUserToAddRows = false;
			this.dgv.AllowUserToDeleteRows = false;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSkyBlue;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pageno,
            this.name,
            this.value,
            this.unit,
            this.percentage,
            this.cost});
			this.dgv.DefaultFont = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.dgv.EnableHeadersVisualStyles = false;
			this.dgv.Location = new System.Drawing.Point(0, 0);
			this.dgv.Name = "dgv";
			this.dgv.RowHeadersVisible = false;
			this.dgv.RowTemplate.Height = 24;
			this.dgv.Size = new System.Drawing.Size(444, 503);
			this.dgv.TabIndex = 0;
			// 
			// timer1
			// 
			this.timer1.Interval = 2500;
			// 
			// pageno
			// 
			this.pageno.HeaderText = "pageno";
			this.pageno.Name = "pageno";
			this.pageno.Visible = false;
			// 
			// name
			// 
			this.name.HeaderText = "name";
			this.name.Name = "name";
			this.name.Width = 150;
			// 
			// value
			// 
			this.value.HeaderText = "value";
			this.value.Name = "value";
			this.value.Width = 80;
			// 
			// unit
			// 
			this.unit.HeaderText = "";
			this.unit.Name = "unit";
			this.unit.Width = 30;
			// 
			// percentage
			// 
			this.percentage.HeaderText = "％";
			this.percentage.Maximum = 100;
			this.percentage.Minimum = 0;
			this.percentage.Name = "percentage";
			this.percentage.Width = 80;
			// 
			// cost
			// 
			this.cost.HeaderText = "cost(JPY/h)";
			this.cost.Name = "cost";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(447, 504);
			this.Controls.Add(this.dgv);
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.ShowIcon = false;
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private CustomControls.CustomDataGridView dgv;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.DataGridViewTextBoxColumn pageno;
		private System.Windows.Forms.DataGridViewTextBoxColumn name;
		private System.Windows.Forms.DataGridViewTextBoxColumn value;
		private System.Windows.Forms.DataGridViewTextBoxColumn unit;
		private CustomControls.CustomDataGridView.DataGridViewProgressBarColumn percentage;
		private System.Windows.Forms.DataGridViewTextBoxColumn cost;
	}
}

