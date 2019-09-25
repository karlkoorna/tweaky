using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

partial class FormMain : Form {

	BindingList<Tweak> tweaks = new BindingList<Tweak>();

	public FormMain() {
		InitializeComponent();
	}

	void FormMain_Load(object sender, EventArgs e) {
		// Bind tweak list to view.
		DataGridViewTweaks.AutoGenerateColumns = false;
		DataGridViewTweaks.DataSource = tweaks;
		
		// Ensure data folder exists.
		Directory.CreateDirectory("Tweaky");

		// Populate tweak list from data folder.
		foreach (string path in Directory.EnumerateFiles("Tweaky", "*.ini", SearchOption.AllDirectories)) {
			Tweak tweak = new Tweak(path);
			tweaks.Add(tweak);

			if (!ComboBoxFilter.Items.Contains(tweak.Category)) ComboBoxFilter.Items.Add(tweak.Category);
		}
	}

	// Toggle tweak.
	void DataGridViewTweaks_CellMouseDoubleClick(object s, DataGridViewCellMouseEventArgs e) {
		if (e.RowIndex != -1) tweaks[e.RowIndex].Toggle();
	}

	// Filter tweaks.
	void ComboBoxFilter_TextChanged(object sender, EventArgs e) {
		string query = ComboBoxFilter.Text.Trim().ToLower();
		DataGridViewTweaks.DataSource = query == "" ? tweaks : new BindingList<Tweak>(tweaks.Where((tweak) => tweak.Category.ToLower().Contains(query) || tweak.Name.ToLower().Contains(query) || tweak.Description.ToLower().Contains(query)).ToList());
	}

	// Show category dropdown with keyboard shortcut.
	private void ComboBoxFilter_KeyDown(object sender, KeyEventArgs e) {
		if (e.Control && e.KeyCode == Keys.Space) ComboBoxFilter.DroppedDown = true;
	}

	// Recolor row if dirty.
	private void DataGridViewTweaks_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e) {
		foreach (DataGridViewRow row in DataGridViewTweaks.Rows) if (((Tweak) row.DataBoundItem).State == "Enabled") {
			row.DefaultCellStyle.BackColor = Color.SeaGreen;
			row.DefaultCellStyle.ForeColor = Color.White;
		} else {
			row.DefaultCellStyle.BackColor = Color.WhiteSmoke;
			row.DefaultCellStyle.ForeColor = Color.Black;
		}
	}

}
