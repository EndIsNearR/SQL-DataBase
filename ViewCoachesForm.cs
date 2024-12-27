using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace SimpleTeamViewer
{
    public partial class ViewCoachesForm : Form
    {
        private string connectionString = "Data Source=20RK-ASUS;Initial Catalog=Project;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        public ViewCoachesForm()
        {
            InitializeComponent();
            LoadCoachNames();
        }

        // Load only the coach names initially
        private void LoadCoachNames()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT Coach_ID, Name FROM Coach";
                    SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    // Display only the coach name in the DataGridView initially
                    dataGridViewCoaches.DataSource = dt;
                    dataGridViewCoaches.Columns["Coach_ID"].Visible = false; // Hide Coach_ID initially
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        // Event handler for selecting a coach name to display additional details
        private void dataGridViewCoaches_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Ensure a row is selected
            {
                string selectedCoachID = dataGridViewCoaches.Rows[e.RowIndex].Cells["Coach_ID"].Value.ToString();
                LoadCoachDetails(selectedCoachID);
            }
        }

        // Load additional details of the selected coach
        private void LoadCoachDetails(string coachID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                        SELECT c.Coach_ID, c.Name, c.Nationality, t.Team_Name
                        FROM Coach c
                        LEFT JOIN Team t ON c.Team_ID = t.Team_ID
                        WHERE c.Coach_ID = @CoachID";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@CoachID", coachID);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        lblCoachDetails.Text = $"Coach ID: {reader["Coach_ID"]}\n" +
                                               $"Name: {reader["Name"]}\n" +
                                               $"Nationality: {reader["Nationality"]}\n" +
                                               $"Team: {reader["Team_Name"]}";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void InitializeComponent()
        {
            this.dataGridViewCoaches = new System.Windows.Forms.DataGridView();
            this.groupBoxCoachDetails = new System.Windows.Forms.GroupBox();
            this.lblCoachDetails = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCoaches)).BeginInit();
            this.groupBoxCoachDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewCoaches
            // 
            this.dataGridViewCoaches.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCoaches.Location = new System.Drawing.Point(30, 30);
            this.dataGridViewCoaches.Name = "dataGridViewCoaches";
            this.dataGridViewCoaches.RowHeadersWidth = 51;
            this.dataGridViewCoaches.RowTemplate.Height = 29;
            this.dataGridViewCoaches.Size = new System.Drawing.Size(350, 400);
            this.dataGridViewCoaches.TabIndex = 0;
            this.dataGridViewCoaches.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCoaches_CellContentClick);
            this.dataGridViewCoaches.BackgroundColor = Color.WhiteSmoke;
            this.dataGridViewCoaches.DefaultCellStyle.BackColor = Color.White;
            this.dataGridViewCoaches.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            this.dataGridViewCoaches.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            this.dataGridViewCoaches.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            // 
            // groupBoxCoachDetails
            // 
            this.groupBoxCoachDetails.Controls.Add(this.lblCoachDetails);
            this.groupBoxCoachDetails.Font = new System.Drawing.Font("Segoe UI", 12F, FontStyle.Bold);
            this.groupBoxCoachDetails.Location = new System.Drawing.Point(420, 30);
            this.groupBoxCoachDetails.Name = "groupBoxCoachDetails";
            this.groupBoxCoachDetails.Size = new System.Drawing.Size(400, 250);
            this.groupBoxCoachDetails.TabIndex = 1;
            this.groupBoxCoachDetails.TabStop = false;
            this.groupBoxCoachDetails.Text = "Coach Details";
            this.groupBoxCoachDetails.BackColor = Color.WhiteSmoke;
            // 
            // lblCoachDetails
            // 
            this.lblCoachDetails.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCoachDetails.Location = new System.Drawing.Point(10, 30);
            this.lblCoachDetails.Name = "lblCoachDetails";
            this.lblCoachDetails.Size = new System.Drawing.Size(380, 200);
            this.lblCoachDetails.TabIndex = 0;
            this.lblCoachDetails.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            // 
            // ViewCoachesForm
            // 
            this.ClientSize = new System.Drawing.Size(850, 500);
            this.Controls.Add(this.groupBoxCoachDetails);
            this.Controls.Add(this.dataGridViewCoaches);
            this.Name = "ViewCoachesForm";
            this.Text = "Coaches Information";
            this.BackColor = Color.LightSteelBlue;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCoaches)).EndInit();
            this.groupBoxCoachDetails.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.DataGridView dataGridViewCoaches;
        private System.Windows.Forms.GroupBox groupBoxCoachDetails;
        private System.Windows.Forms.Label lblCoachDetails;

        private void ViewCoachesForm_Load(object sender, EventArgs e)
        {

        }
    }
}
