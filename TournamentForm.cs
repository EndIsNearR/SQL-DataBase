using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace SimpleTeamViewer
{
    public partial class TournamentForm : Form
    {
        private string connectionString = "Data Source=20RK-ASUS;Initial Catalog=Project;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        public TournamentForm()
        {
            InitializeComponent();
            LoadTournaments();
        }

        private void LoadTournaments()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                        SELECT T.Tournament_ID, T.Year, T.Name, Team.Team_Name AS Winning_Team
                        FROM Tournament T
                        LEFT JOIN Team ON T.Winning_Team_ID = Team.Team_ID";

                    SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dataGridViewTournaments.DataSource = dt;

                    // Customizing column headers
                    dataGridViewTournaments.Columns[0].HeaderText = "Tournament ID";
                    dataGridViewTournaments.Columns[1].HeaderText = "Year";
                    dataGridViewTournaments.Columns[2].HeaderText = "Tournament Name";
                    dataGridViewTournaments.Columns[3].HeaderText = "Winning Team";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void InitializeComponent()
        {
            this.dataGridViewTournaments = new System.Windows.Forms.DataGridView();
            this.labelTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTournaments)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewTournaments
            // 
            this.dataGridViewTournaments.AllowUserToAddRows = false;
            this.dataGridViewTournaments.AllowUserToDeleteRows = false;
            this.dataGridViewTournaments.AllowUserToResizeColumns = false;
            this.dataGridViewTournaments.AllowUserToResizeRows = false;
            this.dataGridViewTournaments.BackgroundColor = Color.AliceBlue;
            this.dataGridViewTournaments.BorderStyle = BorderStyle.Fixed3D;
            this.dataGridViewTournaments.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkSlateBlue;
            this.dataGridViewTournaments.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dataGridViewTournaments.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            this.dataGridViewTournaments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTournaments.GridColor = Color.LightSteelBlue;
            this.dataGridViewTournaments.Location = new System.Drawing.Point(50, 100);
            this.dataGridViewTournaments.Name = "dataGridViewTournaments";
            this.dataGridViewTournaments.RowHeadersVisible = false;
            this.dataGridViewTournaments.RowTemplate.Height = 30;
            this.dataGridViewTournaments.Size = new System.Drawing.Size(800, 400);
            this.dataGridViewTournaments.TabIndex = 0;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            this.labelTitle.ForeColor = Color.DarkSlateBlue;
            this.labelTitle.Location = new System.Drawing.Point(50, 30);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(241, 41);
            this.labelTitle.TabIndex = 1;
            this.labelTitle.Text = "Tournament List";
            // 
            // TournamentForm
            // 
            this.BackColor = Color.White;
            this.ClientSize = new System.Drawing.Size(900, 550);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.dataGridViewTournaments);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.Name = "TournamentForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Tournament Information";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTournaments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.DataGridView dataGridViewTournaments;
        private System.Windows.Forms.Label labelTitle;
    }
}
