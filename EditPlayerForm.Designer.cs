using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SimpleTeamViewer
{
    public partial class EditPlayerForm : Form
    {
        private string connectionString;
        private string playerId;

        public EditPlayerForm(string connectionString, string playerId = null)
        {
            InitializeComponent();
            this.connectionString = connectionString;
            this.playerId = playerId;

            if (!string.IsNullOrEmpty(playerId))
            {
                LoadPlayerDetails(playerId);
            }
        }

        private void LoadPlayerDetails(string playerId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT Player_ID, Name FROM Player WHERE Player_ID = @PlayerID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@PlayerID", playerId);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        txtPlayerID.Text = reader["Player_ID"].ToString();
                        txtPlayerName.Text = reader["Name"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query;

                    if (string.IsNullOrEmpty(playerId)) // New player
                    {
                        query = "INSERT INTO Player (Player_ID, Name) VALUES (@PlayerID, @Name)";
                    }
                    else // Update existing player
                    {
                        query = "UPDATE Player SET Player_ID = @PlayerID, Name = @Name WHERE Player_ID = @OriginalPlayerID";
                    }

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@PlayerID", txtPlayerID.Text);
                    cmd.Parameters.AddWithValue("@Name", txtPlayerName.Text);

                    if (!string.IsNullOrEmpty(playerId))
                    {
                        cmd.Parameters.AddWithValue("@OriginalPlayerID", playerId);
                    }

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Player saved successfully.");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }



        private void InitializeComponent()
        {
            this.txtPlayerID = new System.Windows.Forms.TextBox();
            this.txtPlayerName = new System.Windows.Forms.TextBox();
            this.lblPlayerID = new System.Windows.Forms.Label();
            this.lblPlayerName = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtPlayerID
            // 
            this.txtPlayerID.Location = new System.Drawing.Point(150, 30);
            this.txtPlayerID.Name = "txtPlayerID";
            this.txtPlayerID.Size = new System.Drawing.Size(200, 22);
            this.txtPlayerID.TabIndex = 0;
            // 
            // txtPlayerName
            // 
            this.txtPlayerName.Location = new System.Drawing.Point(150, 70);
            this.txtPlayerName.Name = "txtPlayerName";
            this.txtPlayerName.Size = new System.Drawing.Size(200, 22);
            this.txtPlayerName.TabIndex = 1;
            // 
            // lblPlayerID
            // 
            this.lblPlayerID.AutoSize = true;
            this.lblPlayerID.Location = new System.Drawing.Point(30, 30);
            this.lblPlayerID.Name = "lblPlayerID";
            this.lblPlayerID.Size = new System.Drawing.Size(68, 17);
            this.lblPlayerID.TabIndex = 2;
            this.lblPlayerID.Text = "Player ID:";
            // 
            // lblPlayerName
            // 
            this.lblPlayerName.AutoSize = true;
            this.lblPlayerName.Location = new System.Drawing.Point(30, 70);
            this.lblPlayerName.Name = "lblPlayerName";
            this.lblPlayerName.Size = new System.Drawing.Size(90, 17);
            this.lblPlayerName.TabIndex = 3;
            this.lblPlayerName.Text = "Player Name:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(150, 110);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 30);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // EditPlayerForm
            // 
            this.ClientSize = new System.Drawing.Size(400, 180);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblPlayerName);
            this.Controls.Add(this.lblPlayerID);
            this.Controls.Add(this.txtPlayerName);
            this.Controls.Add(this.txtPlayerID);
            this.Name = "EditPlayerForm";
            this.Text = "Edit Player";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox txtPlayerID;
        private System.Windows.Forms.TextBox txtPlayerName;
        private System.Windows.Forms.Label lblPlayerID;
        private System.Windows.Forms.Label lblPlayerName;
        private System.Windows.Forms.Button btnSave;
    }
}
