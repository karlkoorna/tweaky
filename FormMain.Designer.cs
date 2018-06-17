﻿using System.ComponentModel;
using System.Windows.Forms;

partial class FormMain {
	
	private IContainer components = null;

	protected override void Dispose(bool disposing) {
		if (disposing && components != null) components.Dispose();
		base.Dispose(disposing);
	}

	#region Windows Form Designer generated code

	private void InitializeComponent() {
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
			this.DataGridViewTweaks = new System.Windows.Forms.DataGridView();
			this.ColumnEnabled = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.ColumnCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColumnDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ComboBoxFilter = new System.Windows.Forms.ComboBox();
			((System.ComponentModel.ISupportInitialize)(this.DataGridViewTweaks)).BeginInit();
			this.SuspendLayout();
			// 
			// DataGridViewTweaks
			// 
			this.DataGridViewTweaks.AllowUserToAddRows = false;
			this.DataGridViewTweaks.AllowUserToDeleteRows = false;
			this.DataGridViewTweaks.AllowUserToResizeColumns = false;
			this.DataGridViewTweaks.AllowUserToResizeRows = false;
			this.DataGridViewTweaks.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.DataGridViewTweaks.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.DataGridViewTweaks.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
			this.DataGridViewTweaks.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(4);
			this.DataGridViewTweaks.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.DataGridViewTweaks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.DataGridViewTweaks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnEnabled,
            this.ColumnCategory,
            this.ColumnName,
            this.ColumnDescription});
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.DataGridViewTweaks.DefaultCellStyle = dataGridViewCellStyle2;
			this.DataGridViewTweaks.Dock = System.Windows.Forms.DockStyle.Fill;
			this.DataGridViewTweaks.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
			this.DataGridViewTweaks.GridColor = System.Drawing.Color.LightGray;
			this.DataGridViewTweaks.Location = new System.Drawing.Point(0, 29);
			this.DataGridViewTweaks.Margin = new System.Windows.Forms.Padding(0);
			this.DataGridViewTweaks.MultiSelect = false;
			this.DataGridViewTweaks.Name = "DataGridViewTweaks";
			this.DataGridViewTweaks.ReadOnly = true;
			this.DataGridViewTweaks.RowHeadersVisible = false;
			this.DataGridViewTweaks.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
			this.DataGridViewTweaks.RowTemplate.Height = 32;
			this.DataGridViewTweaks.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.DataGridViewTweaks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.DataGridViewTweaks.Size = new System.Drawing.Size(784, 332);
			this.DataGridViewTweaks.TabIndex = 3;
			this.DataGridViewTweaks.TabStop = false;
			this.DataGridViewTweaks.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridViewTweaks_CellMouseDoubleClick);
			this.DataGridViewTweaks.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.DataGridViewTweaks_RowPrePaint);
			// 
			// ColumnEnabled
			// 
			this.ColumnEnabled.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.ColumnEnabled.DataPropertyName = "Enabled";
			this.ColumnEnabled.HeaderText = "";
			this.ColumnEnabled.Name = "ColumnEnabled";
			this.ColumnEnabled.ReadOnly = true;
			this.ColumnEnabled.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.ColumnEnabled.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.ColumnEnabled.Width = 27;
			// 
			// ColumnCategory
			// 
			this.ColumnCategory.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.ColumnCategory.DataPropertyName = "Category";
			this.ColumnCategory.HeaderText = "Category";
			this.ColumnCategory.Name = "ColumnCategory";
			this.ColumnCategory.ReadOnly = true;
			this.ColumnCategory.Width = 97;
			// 
			// ColumnName
			// 
			this.ColumnName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.ColumnName.DataPropertyName = "Name";
			this.ColumnName.HeaderText = "Name";
			this.ColumnName.Name = "ColumnName";
			this.ColumnName.ReadOnly = true;
			this.ColumnName.Width = 77;
			// 
			// ColumnDescription
			// 
			this.ColumnDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.ColumnDescription.DataPropertyName = "Description";
			this.ColumnDescription.HeaderText = "Description";
			this.ColumnDescription.Name = "ColumnDescription";
			this.ColumnDescription.ReadOnly = true;
			// 
			// ComboBoxFilter
			// 
			this.ComboBoxFilter.Dock = System.Windows.Forms.DockStyle.Top;
			this.ComboBoxFilter.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ComboBoxFilter.ItemHeight = 21;
			this.ComboBoxFilter.Location = new System.Drawing.Point(0, 0);
			this.ComboBoxFilter.Name = "ComboBoxFilter";
			this.ComboBoxFilter.Size = new System.Drawing.Size(784, 29);
			this.ComboBoxFilter.TabIndex = 2;
			this.ComboBoxFilter.TabStop = false;
			this.ComboBoxFilter.TextChanged += new System.EventHandler(this.ComboBoxFilter_TextChanged);
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.WhiteSmoke;
			this.ClientSize = new System.Drawing.Size(784, 361);
			this.Controls.Add(this.DataGridViewTweaks);
			this.Controls.Add(this.ComboBoxFilter);
			this.Name = "FormMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Tweaky";
			this.Load += new System.EventHandler(this.FormMain_Load);
			((System.ComponentModel.ISupportInitialize)(this.DataGridViewTweaks)).EndInit();
			this.ResumeLayout(false);

	}

	#endregion

	private DataGridView DataGridViewTweaks;
	private ComboBox ComboBoxFilter;
	private DataGridViewCheckBoxColumn ColumnEnabled;
	private DataGridViewTextBoxColumn ColumnCategory;
	private DataGridViewTextBoxColumn ColumnName;
	private DataGridViewTextBoxColumn ColumnDescription;

}