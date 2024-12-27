using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SimpleTeamViewer
{
    public partial class UpdateNameForm : Form
    {
        private string connectionString;
        private string playerID;

        public UpdateNameForm(string connectionString, string playerID)
        {
            InitializeComponent();
            this.connectionString = connectionString;
            this.playerID = playerID;
            LoadPlayerName();
        }

        private void LoadPlayerName()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT Name FROM Player WHERE Player_ID = @PlayerID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@PlayerID", playerID);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        txtPlayerName.Text = reader["Name"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnUpdateName_Click(object sender, EventArgs e)
        {
            string newName = txtPlayerName.Text;
            if (!string.IsNullOrEmpty(newName))
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        string query = "UPDATE Player SET Name = @NewName WHERE Player_ID = @PlayerID";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@NewName", newName);
                        cmd.Parameters.AddWithValue("@PlayerID", playerID);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Player name updated successfully.");
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please enter a new name.");
            }
        }

        private void InitializeComponent()
        {
            this.txtPlayerName = new System.Windows.Forms.TextBox();
            this.btnUpdateName = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtPlayerName
            // 
            this.txtPlayerName.Location = new System.Drawing.Point(30, 30);
            this.txtPlayerName.Name = "txtPlayerName";
            this.txtPlayerName.Size = new System.Drawing.Size(250, 22);
            this.txtPlayerName.TabIndex = 0;
            // 
            // btnUpdateName
            // 
            this.btnUpdateName.BackColor = System.Drawing.Color.LightGreen;
            this.btnUpdateName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnUpdateName.Location = new System.Drawing.Point(30, 70);
            this.btnUpdateName.Name = "btnUpdateName";
            this.btnUpdateName.Size = new System.Drawing.Size(150, 40);
            this.btnUpdateName.TabIndex = 1;
            this.btnUpdateName.Text = "Update Name";
            this.btnUpdateName.UseVisualStyleBackColor = false;
            this.btnUpdateName.Click += new System.EventHandler(this.btnUpdateName_Click);
            // 
            // UpdateNameForm
            // 
            this.ClientSize = new System.Drawing.Size(300, 150);
            this.Controls.Add(this.btnUpdateName);
            this.Controls.Add(this.txtPlayerName);
            this.Name = "UpdateNameForm";
            this.Text = "Update Player Name";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox txtPlayerName;
        private System.Windows.Forms.Button btnUpdateName;
    }
}
