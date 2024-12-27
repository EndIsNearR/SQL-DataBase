using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace SimpleTeamViewer
{
    public partial class ViewRefereeForm : Form
    {
        private string connectionString = "Data Source=20RK-ASUS;Initial Catalog=Project;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        public ViewRefereeForm()
        {
            InitializeComponent();
            LoadRefereeData();
        }

        private void LoadRefereeData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT Referee_ID, Name, Nationality, Matches_Officiated FROM Referee";
                    SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    // Display data in DataGridView
                    dataGridViewReferees.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void InitializeComponent()
        {
            this.dataGridViewReferees = new System.Windows.Forms.DataGridView();
            this.SuspendLayout();

            // Styling the DataGridView according to the theme
            this.dataGridViewReferees.BackgroundColor = Color.LightCyan;
            this.dataGridViewReferees.BorderStyle = BorderStyle.Fixed3D;
            this.dataGridViewReferees.Font = new Font("Segoe UI", 12F, FontStyle.Regular);
            this.dataGridViewReferees.ForeColor = Color.DarkSlateBlue;

            // 
            // dataGridViewReferees
            // 
            this.dataGridViewReferees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewReferees.Location = new Point(30, 30);
            this.dataGridViewReferees.Name = "dataGridViewReferees";
            this.dataGridViewReferees.Size = new Size(700, 400);
            this.dataGridViewReferees.TabIndex = 0;

            // Add alternating row colors to match the theme
            this.dataGridViewReferees.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(230, 255, 255);
            this.dataGridViewReferees.AlternatingRowsDefaultCellStyle.ForeColor = Color.DarkSlateBlue;

            // Form styling
            this.BackColor = Color.LightCyan;
            this.ClientSize = new Size(800, 500);
            this.Controls.Add(this.dataGridViewReferees);
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.Name = "ViewRefereeForm";
            this.Text = "Referee Information";
            this.ResumeLayout(false);
        }

        private DataGridView dataGridViewReferees;
    }
}
