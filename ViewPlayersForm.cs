using Project2;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace SimpleTeamViewer
{
    public partial class ViewPlayersForm : Form
    {
        private string connectionString = "Data Source=20RK-ASUS;Initial Catalog=Project;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        public ViewPlayersForm()
        {
            InitializeComponent();
            LoadPlayers();
        }

        private void LoadPlayers()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT Player_ID, Name FROM Player";
                    SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    listViewPlayers.Items.Clear();
                    foreach (DataRow row in dt.Rows)
                    {
                        ListViewItem item = new ListViewItem(row["Player_ID"].ToString());
                        item.SubItems.Add(row["Name"].ToString());
                        listViewPlayers.Items.Add(item);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void listViewPlayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewPlayers.SelectedItems.Count > 0)
            {
                string selectedPlayerID = listViewPlayers.SelectedItems[0].Text;
                LoadPlayerDetails(selectedPlayerID);
            }
        }

        private void LoadPlayerDetails(string playerID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                        SELECT p.Player_ID, p.Name, p.Age, p.Position, p.Nationality, 
                               t.Team_Name
                        FROM Player p
                        LEFT JOIN Team t ON p.Team_ID = t.Team_ID
                        WHERE p.Player_ID = @PlayerID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@PlayerID", playerID);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        lblPlayerDetails.Text = $"Player ID: {reader["Player_ID"]}\n" +
                                                $"Name: {reader["Name"]}\n" +
                                                $"Age: {reader["Age"]}\n" +
                                                $"Position: {reader["Position"]}\n" +
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
            this.listViewPlayers = new System.Windows.Forms.ListView();
            this.columnPlayerID = new System.Windows.Forms.ColumnHeader();
            this.columnPlayerName = new System.Windows.Forms.ColumnHeader();
            this.groupBoxPlayerDetails = new System.Windows.Forms.GroupBox();
            this.lblPlayerDetails = new System.Windows.Forms.Label();
            this.btnEditPlayer = new System.Windows.Forms.Button();
            this.btnDeletePlayer = new System.Windows.Forms.Button(); // Change from object to Button
            this.SuspendLayout();
            // 
            // listViewPlayers
            // 
            this.listViewPlayers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnPlayerID,
            this.columnPlayerName});
            this.listViewPlayers.FullRowSelect = true;
            this.listViewPlayers.GridLines = true;
            this.listViewPlayers.HideSelection = false;
            this.listViewPlayers.Location = new System.Drawing.Point(30, 30);
            this.listViewPlayers.Name = "listViewPlayers";
            this.listViewPlayers.Size = new System.Drawing.Size(300, 400);
            this.listViewPlayers.TabIndex = 0;
            this.listViewPlayers.UseCompatibleStateImageBehavior = false;
            this.listViewPlayers.View = System.Windows.Forms.View.Details;
            this.listViewPlayers.SelectedIndexChanged += new System.EventHandler(this.listViewPlayers_SelectedIndexChanged);
            this.listViewPlayers.BackColor = Color.WhiteSmoke;
            this.listViewPlayers.Font = new Font("Segoe UI", 10);
            this.columnPlayerID.Text = "Player ID";
            this.columnPlayerName.Text = "Name";
            this.columnPlayerID.Width = 100;
            this.columnPlayerName.Width = 150;
            // 
            // groupBoxPlayerDetails
            // 
            this.groupBoxPlayerDetails.Controls.Add(this.lblPlayerDetails);
            this.groupBoxPlayerDetails.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.groupBoxPlayerDetails.Location = new System.Drawing.Point(350, 30);
            this.groupBoxPlayerDetails.Name = "groupBoxPlayerDetails";
            this.groupBoxPlayerDetails.Size = new System.Drawing.Size(400, 250);
            this.groupBoxPlayerDetails.TabIndex = 1;
            this.groupBoxPlayerDetails.TabStop = false;
            this.groupBoxPlayerDetails.Text = "Player Details";
            this.groupBoxPlayerDetails.BackColor = Color.WhiteSmoke;
            // 
            // lblPlayerDetails
            // 
            this.lblPlayerDetails.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPlayerDetails.Location = new System.Drawing.Point(10, 30);
            this.lblPlayerDetails.Name = "lblPlayerDetails";
            this.lblPlayerDetails.Size = new System.Drawing.Size(380, 200);
            this.lblPlayerDetails.TabIndex = 0;
            this.lblPlayerDetails.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lblPlayerDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            // 
            // btnEditPlayer
            // 
            this.btnEditPlayer.BackColor = System.Drawing.Color.LightBlue;
            this.btnEditPlayer.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnEditPlayer.Location = new System.Drawing.Point(350, 300);
            this.btnEditPlayer.Name = "btnEditPlayer";
            this.btnEditPlayer.Size = new System.Drawing.Size(150, 40);
            this.btnEditPlayer.TabIndex = 2;
            this.btnEditPlayer.Text = "Edit Player";
            this.btnEditPlayer.UseVisualStyleBackColor = false;
            this.btnEditPlayer.Click += new System.EventHandler(this.btnEditPlayer_Click);

            // Add Update Player Button to InitializeComponent
            this.btnUpdatePlayer = new System.Windows.Forms.Button();
            this.btnUpdatePlayer.BackColor = System.Drawing.Color.LightGreen;
            this.btnUpdatePlayer.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnUpdatePlayer.Location = new System.Drawing.Point(350, 350); // Adjust position as needed
            this.btnUpdatePlayer.Name = "btnUpdatePlayer";
            this.btnUpdatePlayer.Size = new System.Drawing.Size(150, 40);
            this.btnUpdatePlayer.TabIndex = 4;
            this.btnUpdatePlayer.Text = "Update Name";
            this.btnUpdatePlayer.UseVisualStyleBackColor = false;
            this.btnUpdatePlayer.Click += new System.EventHandler(this.btnUpdatePlayer_Click);
            this.Controls.Add(this.btnUpdatePlayer);



            // 
            // btnDeletePlayer
            // 
            this.btnDeletePlayer.BackColor = System.Drawing.Color.LightCoral;
            this.btnDeletePlayer.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDeletePlayer.Location = new System.Drawing.Point(520, 300);
            this.btnDeletePlayer.Name = "btnDeletePlayer";
            this.btnDeletePlayer.Size = new System.Drawing.Size(150, 40);
            this.btnDeletePlayer.TabIndex = 3;
            this.btnDeletePlayer.Text = "Delete Player";
            this.btnDeletePlayer.UseVisualStyleBackColor = false;
            this.btnDeletePlayer.Click += new System.EventHandler(this.btnDeletePlayer_Click);
            // 
            // ViewPlayersForm
            // 
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.listViewPlayers);
            this.Controls.Add(this.groupBoxPlayerDetails);
            this.Controls.Add(this.btnEditPlayer);
            this.Controls.Add(this.btnDeletePlayer); // Change from object to Button
            this.Name = "ViewPlayersForm";
            this.Text = "View Players";
            this.BackColor = Color.LightSteelBlue;
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.ListView listViewPlayers;
        private System.Windows.Forms.ColumnHeader columnPlayerID;
        private System.Windows.Forms.ColumnHeader columnPlayerName;
        private System.Windows.Forms.GroupBox groupBoxPlayerDetails;
        private System.Windows.Forms.Label lblPlayerDetails;
        private Button btnEditPlayer;
        private Button btnDeletePlayer; // Change from object to Button
        private Button btnUpdatePlayer;

        private void ViewPlayersForm_Load(object sender, EventArgs e)
        {

        }
        private void btnEditPlayer_Click(object sender, EventArgs e)
        {
            string selectedPlayerID = null;
            if (listViewPlayers.SelectedItems.Count > 0)
            {
                selectedPlayerID = listViewPlayers.SelectedItems[0].Text;
            }

            EditPlayerForm editPlayerForm = new EditPlayerForm(connectionString, selectedPlayerID);
            editPlayerForm.ShowDialog();
            LoadPlayers(); // Refresh the player list after editing
        }

        private void btnUpdatePlayer_Click(object sender, EventArgs e)
        {
            string selectedPlayerID = null;
            if (listViewPlayers.SelectedItems.Count > 0)
            {
                selectedPlayerID = listViewPlayers.SelectedItems[0].Text;
            }

            if (selectedPlayerID != null)
            {
                UpdateNameForm updateNameForm = new UpdateNameForm(connectionString, selectedPlayerID);
                updateNameForm.ShowDialog();
                LoadPlayers(); // Refresh the player list after updating
            }
            else
            {
                MessageBox.Show("Please select a player to update.");
            }
        }



        private void btnDeletePlayer_Click(object sender, EventArgs e)
        {
            if (listViewPlayers.SelectedItems.Count > 0)
            {
                string selectedPlayerID = listViewPlayers.SelectedItems[0].Text;

                var confirmResult = MessageBox.Show("Are you sure to delete this player?",
                                                     "Confirm Delete",
                                                     MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        try
                        {
                            conn.Open();
                            string query = "DELETE FROM Player WHERE Player_ID = @PlayerID";
                            SqlCommand cmd = new SqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@PlayerID", selectedPlayerID);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Player deleted successfully.");
                            LoadPlayers(); // Refresh the player list after deletion
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a player to delete.");
            }
        }
    }
}
