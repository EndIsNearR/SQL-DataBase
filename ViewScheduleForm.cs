using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace SimpleTeamViewer
{
    public partial class ViewScheduleForm : Form
    {
        private string connectionString = "Data Source=20RK-ASUS;Initial Catalog=Project;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        public ViewScheduleForm()
        {
            InitializeComponent();
            LoadMatchSchedule();
        }

        private void LoadMatchSchedule()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT m.Match_ID, m.Date, m.Stadium, m.Score, 
                                     t1.Team_Name AS Team1, t2.Team_Name AS Team2 
                                     FROM Match m
                                     JOIN Team t1 ON m.Team1_ID = t1.Team_ID
                                     JOIN Team t2 ON m.Team2_ID = t2.Team_ID";

                    SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    // Display data in DataGridView
                    dataGridViewSchedule.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void InitializeComponent()
        {
            this.dataGridViewSchedule = new System.Windows.Forms.DataGridView();
            this.SuspendLayout();

            // Styling the DataGridView according to the theme
            this.dataGridViewSchedule.BackgroundColor = Color.LightCyan;
            this.dataGridViewSchedule.BorderStyle = BorderStyle.Fixed3D;
            this.dataGridViewSchedule.Font = new Font("Segoe UI", 12F, FontStyle.Regular);
            this.dataGridViewSchedule.ForeColor = Color.DarkSlateBlue;

            // 
            // dataGridViewSchedule
            // 
            this.dataGridViewSchedule.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSchedule.Location = new Point(30, 30);
            this.dataGridViewSchedule.Name = "dataGridViewSchedule";
            this.dataGridViewSchedule.Size = new Size(700, 400);
            this.dataGridViewSchedule.TabIndex = 0;

            // Add alternating row colors to match the theme
            this.dataGridViewSchedule.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(230, 255, 255);
            this.dataGridViewSchedule.AlternatingRowsDefaultCellStyle.ForeColor = Color.DarkSlateBlue;

            // Form styling
            this.BackColor = Color.LightCyan;
            this.ClientSize = new Size(800, 500);
            this.Controls.Add(this.dataGridViewSchedule);
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.Name = "ViewScheduleForm";
            this.Text = "Match Schedule";
            this.ResumeLayout(false);
        }

        private DataGridView dataGridViewSchedule;
    }
}
