using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace CustomControls
{
	/// <summary>
	/// カスタムグリッドコントロール
	/// </summary>
	public class CustomDataGridView : DataGridView
	{
		#region"【内部変数】"
		/// <summary>
		/// 組み込みセルスタイル
		/// </summary>
		private Dictionary<string, DataGridViewCellStyle> _cellStyles = new Dictionary<string, DataGridViewCellStyle>();

		/// <summary>
		/// 標準フォント
		/// </summary>
		private Font _defaultFont = new Font("MS UI Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(128)));
		#endregion

		#region"【コンストラクタ】"
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public CustomDataGridView() 
		{
			SetDefuaultStyles();

			base.AllowUserToAddRows = false;
			base.AllowUserToDeleteRows = false;
			base.AutoGenerateColumns = false;
			base.RowHeadersVisible = false;
			base.RowTemplate.Height = 24;
			base.ColumnHeadersDefaultCellStyle = Styles(CellStyleName.HeaderMiddleCenter);
			base.EnableHeadersVisualStyles = false;
			base.DoubleBuffered = true;
			//base.Columns
		
		}
		#endregion

		#region "【行制御】"
		/// <summary>
		/// 行オブジェクトの返却
		/// </summary>
		/// <param name="iRow"></param>
		/// <returns></returns>
		public DataGridViewRow Row(int iRow) 
		{
			if (iRow < 0) { return null; }
			return base.Rows[iRow];
		}

		/// <summary>
		/// 行を追加して対象の行を返却する
		/// </summary>
		/// <returns></returns>
		public DataGridViewRow AddRow()
		{
			//todo データバインド時のテスト
			base.Rows.Add();
			return LastRow();
		}

		/// <summary>
		/// 行を追加して対象の行を返却する
		/// </summary>
		/// <param name="index">追加先の行番号</param>
		/// <returns></returns>
		public DataGridViewRow AddRow(int index)
		{
			//if (base.DataBindings == null)
			//{
				//データバインドなし
				base.Rows.Insert(index);
			//}
			//else
			//{
				//todo データバインドあり
				//base.Rows.Insert(index, base.);
			//}

			return Row(index);
		}

		/// <summary>
		/// 最終行オブジェクトの返却
		/// </summary>
		/// <returns></returns>
		public DataGridViewRow LastRow()
		{
			return Row(base.Rows.Count - 1);
		}

		/// <summary>
		/// 対象列に検索条件の含まれる最小の行番号の取得
		/// </summary>
		/// <param name="ColumnIndex">列番号</param>
		/// <param name="Value">比較値</param>
		/// <returns>一致する行が存在しない場合は-1を返却</returns>
		public int IndexOf(int ColumnIndex, Object Value)
		{
			for (int i = 0; i < base.Rows.Count; i++)
			{
				if (base.Rows[i].Cells[ColumnIndex].Value.Equals(Value))
				{
					return i;

				}
			}
			return -1;
		}
		#endregion

		#region "【セル制御】"
		/// <summary>
		/// Cellを取得または設定します
		/// </summary>
		/// <param name="Row"></param>
		/// <param name="Col"></param>
		/// <returns></returns>
		public DataGridViewCell Cell(int Row, int Col) 
		{
			 if (Row < 0 || Col < 0)
			 {
				 return null;
			 }

			return base[Col, Row];
		}
		#endregion

		#region "【スタイル制御】"
		/// <summary>
		/// 標準フォントの取得および設定
		/// </summary>
		public new Font DefaultFont
		{
			get { return _defaultFont; }
			set { _defaultFont = value; }
		}

		/// <summary>
		/// 組み込みセルスタイル名
		/// </summary>
		public struct CellStyleName
		{
			/// <summary>
			/// ヘッダ（左寄せ）
			/// </summary>
			public const string HeaderMiddleLeft = "HeaderMiddleLeft";

			/// <summary>
			/// ヘッダ（中寄せ）
			/// </summary>
			public const string HeaderMiddleCenter = "HeaderMiddleCenter";

			/// <summary>
			/// 数値（背景：白）
			/// </summary>
			public const string NumberWhite = "NumberWhite";

			/// <summary>
			/// 数値（背景：黄）
			/// </summary>
			public const string NumberYellow = "NumberYellow";

			/// <summary>
			/// 数値(背景：赤)
			/// </summary>
			public const string NumberRed = "NumberRed";

			/// <summary>
			/// 文字列（背景：白）
			/// </summary>
			public const string StirngWhite = "StirngWhite";

			/// <summary>
			/// 文字列（中寄せ　背景：白）
			/// </summary>
			public const string StirngCenterWhite = "StirngCenterWhite";

			/// <summary>
			/// 日付（背景：白）
			/// </summary>
			public const string DateWhite = "DateWhite";

			/// <summary>
			/// 時刻（背景：白）
			/// </summary>
			public const string TimeWhite = "TimeWhite";
		}

		/// <summary>
		/// 組み込み書式の初期化
		/// </summary>
		public void SetDefuaultStyles()
		{
			_cellStyles.Clear();

			_cellStyles.Add(CellStyleName.HeaderMiddleLeft,
				new DataGridViewCellStyle()
				{
					 Alignment = DataGridViewContentAlignment.MiddleLeft
					,BackColor = Color.LightSkyBlue
					,Font = _defaultFont
				});

			_cellStyles.Add(CellStyleName.HeaderMiddleCenter,
				new DataGridViewCellStyle()
				{
					 Alignment = DataGridViewContentAlignment.MiddleCenter
					,BackColor = Color.LightSkyBlue
					,Font = _defaultFont
				});

			_cellStyles.Add(CellStyleName.NumberWhite,
				new DataGridViewCellStyle()
				{
					 Alignment = DataGridViewContentAlignment.MiddleRight
					,Font = _defaultFont
					,BackColor = Color.White
				});

			_cellStyles.Add(CellStyleName.NumberYellow,
				new DataGridViewCellStyle()
				{
					 Alignment = DataGridViewContentAlignment.MiddleRight
					,Font = _defaultFont
					,BackColor = Color.Yellow
				});

			_cellStyles.Add(CellStyleName.NumberRed,
				new DataGridViewCellStyle()
				{
					 Alignment = DataGridViewContentAlignment.MiddleRight
					,Font = _defaultFont
					,BackColor = Color.Red
				});

			_cellStyles.Add(CellStyleName.StirngWhite,
				new DataGridViewCellStyle()
				{
					 Alignment = DataGridViewContentAlignment.MiddleLeft
					,Font = _defaultFont
					,BackColor = Color.White
				});

			_cellStyles.Add(CellStyleName.StirngCenterWhite,
				new DataGridViewCellStyle()
				{
					Alignment = DataGridViewContentAlignment.MiddleCenter
					,
					Font = _defaultFont
					,
					BackColor = Color.White
				});


			_cellStyles.Add(CellStyleName.DateWhite,
				new DataGridViewCellStyle()
				{
					Alignment = DataGridViewContentAlignment.MiddleRight
					,Font = _defaultFont
					,BackColor = Color.White
				});

			_cellStyles.Add(CellStyleName.TimeWhite,
				new DataGridViewCellStyle()
				{
					Alignment = DataGridViewContentAlignment.MiddleRight
					,Font = _defaultFont
					,BackColor = Color.White
				});
		}

		/// <summary>
		/// ユーザ定義セルスタイルの追加
		/// </summary>
		/// <param name="StyleName">スタイル名</param>
		/// <param name="CellStyle">スタイル定義</param>
		/// <returns><para>true:正常に追加された</para>
		/// <para>false:既に存在するスタイル名が指定された</para></returns>
		public bool AddCellStyle(string StyleName, DataGridViewCellStyle CellStyle) 
		{
			if (_cellStyles.ContainsKey(StyleName))
			{
				return false;
			}
			else
			{
				_cellStyles.Add(StyleName, CellStyle);
				return true;
			}
		}

		/// <summary>
		/// 組み込みセルスタイルの返却
		/// </summary>
		/// <param name="styleName">スタイル名</param>
		/// <returns></returns>
		public DataGridViewCellStyle Styles(string styleName)
		{
			if (_cellStyles.ContainsKey(styleName))
			{
				return _cellStyles[styleName].Clone();
			}
			else
			{
				return base.DefaultCellStyle.Clone();
			}
		}

		/// <summary>
		/// 全てのセルへ書式を自動設定する
		/// </summary>
		public void SetAutoCellStyle()
		{
			for (int iRow = 0; iRow < base.Rows.Count; iRow++) 
			{
				for (int iCol = 0; iCol < base.Columns.Count; iCol++)
				{
					SetAutoCellStyle(iRow, iCol);
				}
			}
		}

		/// <summary>
		/// セルを指定して書式を自動設定する
		/// </summary>
		/// <param name="Row">行番号</param>
		/// <param name="Col">列番号</param>
		public void SetAutoCellStyle(int Row, int Col)
		{
			DataGridViewCell _cell = Cell(Row, Col);

			if (_cell.Value == null) { return; }

			Type T = _cell.Value.GetType();

			//数値型
			if (Information.IsNumeric(_cell.Value))
			{
				_cell.Style = Styles(CellStyleName.NumberWhite);
				return;
			}

			//日付型
			if (Information.IsDate(_cell.Value))
			{
				_cell.Style = Styles(CellStyleName.DateWhite);
				return;
			}

			//文字
			if (T == typeof(string))
			{
				_cell.Style = Styles(CellStyleName.StirngWhite);
				return;
			}
		}

		/// <summary>
		/// 行を指定して書式を自動設定する
		/// </summary>
		/// <param name="Row"></param>
		public void SetAutoRowStyle(int Row)
		{
			for (int i = 0; i < base.ColumnCount; i++) 
			{
				SetAutoCellStyle(Row, i);
			}
		}
		#endregion

		#region"【データバインド】"

		/// <summary>
		/// データバインドの設定
		/// </summary>
		/// <param name="ColumnNamePair"></param>
		public void SetColumnBindingName(Dictionary<int, string> ColumnNamePair)
		{
			try
			{
				foreach (var v in ColumnNamePair)
				{
					base.Columns[v.Key].DataPropertyName = v.Value;
				}
			}
			finally 
			{
			}
		}
		#endregion

		#region"【DataGridViewProgressBarCell】"
		/// <summary>
		/// DataGridViewProgressBarCell
		/// </summary>
		public class DataGridViewProgressBarColumn : DataGridViewTextBoxColumn
		{
			//コンストラクタ
			public DataGridViewProgressBarColumn()
			{
				this.CellTemplate = new DataGridViewProgressBarCell();
			}

			//CellTemplateの取得と設定
			public override DataGridViewCell CellTemplate
			{
				get
				{
					return base.CellTemplate;
				}
				set
				{
					//DataGridViewProgressBarCell以外はホストしない
					if (!(value is DataGridViewProgressBarCell))
					{
						throw new InvalidCastException(
							"DataGridViewProgressBarCellオブジェクトを指定してください。");
					}
					base.CellTemplate = value;
				}
			}

			/// <summary>
			/// ProgressBarの最大値
			/// </summary>
			public int Maximum
			{
				get
				{
					return ((DataGridViewProgressBarCell)this.CellTemplate).Maximum;
				}
				set
				{
					if (this.Maximum == value) { return; }

					//セルテンプレートの値を変更する
					((DataGridViewProgressBarCell)this.CellTemplate).Maximum = value;

					//DataGridViewにすでに追加されているセルの値を変更する
					if (this.DataGridView == null) { return; } 

					for (int i = 0; i < this.DataGridView.RowCount; i++)
					{
						((DataGridViewProgressBarCell)this.DataGridView.Rows.SharedRow(i).Cells[this.Index])
							.Maximum = value;
					}
				}
			}

			/// <summary>
			/// ProgressBarの最小値
			/// </summary>
			public int Minimum
			{
				get
				{
					return ((DataGridViewProgressBarCell)this.CellTemplate).Minimum;
				}
				set
				{
					if (this.Minimum == value) { return; }
						
					//セルテンプレートの値を変更する
					((DataGridViewProgressBarCell)this.CellTemplate).Minimum = value;

					//DataGridViewにすでに追加されているセルの値を変更する
					if (this.DataGridView == null) { return; }
						
					for (int i = 0; i < this.DataGridView.RowCount; i++)
					{
						((DataGridViewProgressBarCell)this.DataGridView.Rows.SharedRow(i).Cells[this.Index])
							.Minimum = value;
					}
				}
			}
		}
		#endregion

		#region"【DataGridViewProgressBarCell】"
		/// <summary>
		/// ProgressBarをDataGridViewに表示する
		/// </summary>
		public class DataGridViewProgressBarCell : DataGridViewTextBoxCell
		{
			private int m_Maximum;
			private int m_Minimum;

			/// <summary>
			/// コンストラクタ 
			/// </summary>
			public DataGridViewProgressBarCell()
			{
				this.m_Maximum = 100;
				this.m_Minimum = 0;
			}

			/// <summary>
			/// 最大値
			/// </summary>
			public int Maximum
			{
				get
				{
					return this.m_Maximum;
				}
				set
				{
					this.m_Maximum = value;
				}
			}

			/// <summary>
			/// 最小値
			/// </summary>
			public int Minimum
			{
				get
				{
					return this.m_Minimum;
				}
				set
				{
					this.m_Minimum = value;
				}
			}

			/// <summary>
			/// セルの値のデータ型
			/// </summary>
			public override Type ValueType
			{
				get
				{
					return typeof(int);
				}
			}

			/// <summary>
			/// 新しいレコード行のセルの既定値を指定する 
			/// </summary>
			public override object DefaultNewRowValue
			{
				get
				{
					return 0;
				}
			}

			/// <summary>
			/// Clone
			/// </summary>
			/// <returns></returns>
			public override object Clone()
			{
				DataGridViewProgressBarCell cell = (DataGridViewProgressBarCell)base.Clone();
				cell.Maximum = this.Maximum;
				cell.Minimum = this.Minimum;
				return cell;
			}

			/// <summary>
			/// 
			/// </summary>
			/// <param name="graphics"></param>
			/// <param name="clipBounds"></param>
			/// <param name="cellBounds"></param>
			/// <param name="rowIndex"></param>
			/// <param name="cellState"></param>
			/// <param name="value"></param>
			/// <param name="formattedValue"></param>
			/// <param name="errorText"></param>
			/// <param name="cellStyle"></param>
			/// <param name="advancedBorderStyle"></param>
			/// <param name="paintParts"></param>
			protected override void Paint(Graphics graphics,
				Rectangle clipBounds, Rectangle cellBounds,
				int rowIndex, DataGridViewElementStates cellState,
				object value, object formattedValue, string errorText,
				DataGridViewCellStyle cellStyle,
				DataGridViewAdvancedBorderStyle advancedBorderStyle,
				DataGridViewPaintParts paintParts)
			{
				//値を決定する
				int currentValue = 0;

				if (value is int)
				{
					currentValue = (int)value;
				}

				if (currentValue < this.m_Minimum)
				{
					currentValue = this.m_Minimum;
				}

				if (currentValue > this.m_Maximum)
				{
					currentValue = this.m_Maximum;
				}

				//セルの境界線（枠）を描画する
				if ((paintParts & DataGridViewPaintParts.Border) == DataGridViewPaintParts.Border)
				{
					this.PaintBorder(graphics, clipBounds, cellBounds, cellStyle, advancedBorderStyle);
				}

				//境界線の内側に範囲を取得する
				Rectangle borderRect = this.BorderWidths(advancedBorderStyle);
				Rectangle paintRect = new Rectangle(
					cellBounds.Left + borderRect.Left,
					cellBounds.Top + borderRect.Top,
					cellBounds.Width - borderRect.Right,
					cellBounds.Height - borderRect.Bottom);

				//背景色を決定する
				//選択されている時とされていない時で色を変える
				Color backColor;
				if ((cellState & DataGridViewElementStates.Selected) == DataGridViewElementStates.Selected
					&& (paintParts & DataGridViewPaintParts.SelectionBackground) == DataGridViewPaintParts.SelectionBackground)
				{
					backColor = cellStyle.SelectionBackColor;
				}
				else
				{
					backColor = cellStyle.BackColor;
				}

				//背景を描画する
				if ((paintParts & DataGridViewPaintParts.Background) == DataGridViewPaintParts.Background)
				{
					using (SolidBrush backBrush = new SolidBrush(backColor))
					{
						graphics.FillRectangle(backBrush, paintRect);
					}
				}

				//Paddingを差し引く
				paintRect.Offset(cellStyle.Padding.Right, cellStyle.Padding.Top);
				paintRect.Width -= cellStyle.Padding.Horizontal;
				paintRect.Height -= cellStyle.Padding.Vertical;

				//割合を計算する
				double rate = (double)(currentValue - this.m_Minimum) / (this.m_Maximum - this.m_Minimum);

				//ProgressBarを描画する
				if ((paintParts & DataGridViewPaintParts.ContentForeground) == DataGridViewPaintParts.ContentForeground)
				{

					if (ProgressBarRenderer.IsSupported)
					{
						//visualスタイルで描画する

						//ProgressBarの枠を描画する
						ProgressBarRenderer.DrawHorizontalBar(graphics, paintRect);

						//ProgressBarのバーを描画する
						Rectangle barBounds = new Rectangle(
							paintRect.Left + 3, paintRect.Top + 3,
							paintRect.Width - 6, paintRect.Height - 6);
						barBounds.Width = (int)Math.Round(barBounds.Width * rate);

						ProgressBarRenderer.DrawHorizontalChunks(graphics, barBounds);
					}
					else
					{
						//visualスタイルで描画できない時
						graphics.FillRectangle(Brushes.White, paintRect);
						graphics.DrawRectangle(Pens.Black, paintRect);

						Rectangle barBounds = new Rectangle(
							paintRect.Left + 1, paintRect.Top + 1,
							paintRect.Width - 1, paintRect.Height - 1);
						barBounds.Width = (int)Math.Round(barBounds.Width * rate);

						graphics.FillRectangle(Brushes.Blue, barBounds);
					}
				}

				//フォーカスの枠を表示する
				if (this.DataGridView.CurrentCellAddress.X == this.ColumnIndex
					&& this.DataGridView.CurrentCellAddress.Y == this.RowIndex
					&& (paintParts & DataGridViewPaintParts.Focus) == DataGridViewPaintParts.Focus 
					&& this.DataGridView.Focused)
				{
					//フォーカス枠の大きさを適当に決める
					Rectangle focusRect = paintRect;
					focusRect.Inflate(-3, -3);
					ControlPaint.DrawFocusRectangle(graphics, focusRect);
					//背景色を指定してフォーカス枠を描画する時
					//ControlPaint.DrawFocusRectangle(
					//    graphics, focusRect, Color.Empty, bkColor);
				}

				//テキストを表示する
				if ((paintParts & DataGridViewPaintParts.ContentForeground) == DataGridViewPaintParts.ContentForeground)
				{
					TextFormatFlags flags = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter;

					//テキストを描画する
					paintRect.Inflate(-2, -2);
					TextRenderer.DrawText(graphics, string.Format("{0}%", Math.Round(rate * 100))
						, cellStyle.Font, paintRect, cellStyle.ForeColor, flags);
				}

				//エラーアイコンの表示
				if ((paintParts & DataGridViewPaintParts.ErrorIcon) == DataGridViewPaintParts.ErrorIcon 
					&& this.DataGridView.ShowCellErrors 
					&& !string.IsNullOrEmpty(errorText))
				{
					//エラーアイコンを表示させる領域を取得
					Rectangle iconBounds 
						= this.GetErrorIconBounds(graphics, cellStyle, rowIndex);
					iconBounds.Offset(cellBounds.X, cellBounds.Y);

					//エラーアイコンを描画
					this.PaintErrorIcon(graphics, iconBounds, cellBounds, errorText);
				}
			}
		}
		#endregion
	}
}
