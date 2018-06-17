using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Windows.Forms;

partial class FormMain : Form {

	BindingList<Tweak> tweaks = new BindingList<Tweak>();

	public FormMain() {
		InitializeComponent();
	}

	void FormMain_Load(object s, EventArgs e) {

		// Check for administrative privilages.
		if (!(new WindowsPrincipal(WindowsIdentity.GetCurrent())).IsInRole(WindowsBuiltInRole.Administrator)) {
			MessageBox.Show("Administrative privilages required.", "Tweaky", MessageBoxButtons.OK, MessageBoxIcon.Information);
			Application.Exit();
		}

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
		string query = ComboBoxFilter.Text.Trim();
		DataGridViewTweaks.DataSource = query == "" ? tweaks : new BindingList<Tweak>(tweaks.Where((tweak) => tweak.Category.Contains(query) || tweak.Name.Contains(query) || tweak.Description.Contains(query)).ToList());
	}

	// Recolor rows if dirty.
	private void DataGridViewTweaks_RowPrePaint(object s, DataGridViewRowPrePaintEventArgs e) {

		foreach (DataGridViewRow row in DataGridViewTweaks.Rows) if (((Tweak)row.DataBoundItem).Enabled) {
			row.DefaultCellStyle.BackColor = Color.MediumSeaGreen;
			row.DefaultCellStyle.SelectionBackColor = Color.SeaGreen;
		} else {
			row.DefaultCellStyle.BackColor = Color.WhiteSmoke;
			row.DefaultCellStyle.SelectionBackColor = Color.DodgerBlue;
		}

	}

}
