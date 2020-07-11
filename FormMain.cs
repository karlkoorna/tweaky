using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

partial class FormMain : Form {

	private readonly SortableBindingList<Tweak> tweaks = new SortableBindingList<Tweak>();

	public FormMain() {
		InitializeComponent();
	}

	void FormMain_Load(object sender, EventArgs e) {
		DataGridViewTweaks.AutoGenerateColumns = false;
		DataGridViewTweaks.DataSource = tweaks;
		
		// Populate list from data folder.
		foreach (string path in Directory.EnumerateFiles("Tweaky", "*.ini", SearchOption.AllDirectories)) if (path.Split('\\').Length > 2) {
			Tweak tweak = new Tweak(path);
			tweaks.Add(tweak);

			if (!ComboBoxSearch.Items.Contains(tweak.Category)) ComboBoxSearch.Items.Add(tweak.Category);
		}

		ComboBoxSearch.Select();
	}

	// Toggle tweak.
	void DataGridViewTweaks_CellMouseDoubleClick(object s, DataGridViewCellMouseEventArgs e) {
		if (e.RowIndex != -1) tweaks[e.RowIndex].Toggle();
	}

	// Search tweaks.
	void ComboBoxSearch_TextChanged(object sender, EventArgs e) {
		string query = ComboBoxSearch.Text.Trim().ToLower();
		DataGridViewTweaks.DataSource = query == "" ? tweaks : new BindingList<Tweak>(tweaks.Where((tweak) => tweak.Category.ToLower().Contains(query) || tweak.Name.ToLower().Contains(query) || tweak.Description.ToLower().Contains(query)).ToList());
	}

	// Add keyboard shortcuts to search.
	private void ComboBoxSearch_KeyDown(object sender, KeyEventArgs e) {
		if (e.KeyCode == Keys.Tab) { // Move focus to tweaks.
			DataGridViewTweaks.Focus();
			e.SuppressKeyPress = true;
		} else if (e.Control && e.KeyCode == Keys.Space) { // Show category dropdown.
			ComboBoxSearch.DroppedDown = true;
			e.SuppressKeyPress = true;
		}
	}

	// Add keyboard shortcuts to tweaks.
	private void DataGridViewTweaks_KeyDown(object sender, KeyEventArgs e) {
		if (e.KeyCode == Keys.Tab) { // Move focus to search.
			ComboBoxSearch.Select();
			e.Handled = true;
		} else if (e.KeyCode == Keys.Space || e.KeyCode == Keys.Enter) { // Toggle tweak.
			((Tweak) DataGridViewTweaks.CurrentRow.DataBoundItem).Toggle();
			DataGridViewTweaks.Refresh();
			e.Handled = true;
		}
	}

	// Color row depending on tweak status.
	private void DataGridViewTweaks_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e) {
		foreach (DataGridViewRow row in DataGridViewTweaks.Rows) if (((Tweak) row.DataBoundItem).Status == Tweak.TweakStatus.ENABLED) {
			row.DefaultCellStyle.BackColor = Color.SeaGreen;
			row.DefaultCellStyle.ForeColor = Color.White;
		} else {
			row.DefaultCellStyle.BackColor = Color.WhiteSmoke;
			row.DefaultCellStyle.ForeColor = Color.Black;
		}
	}

	// Hide cell focus outline.
	private void DataGridViewTweaks_CellPainting(object sender, DataGridViewCellPaintingEventArgs e) {
		e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.Focus);
		e.Handled = true;
	}

}
