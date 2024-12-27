using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace SimpleTeamViewer
{
    public partial class ViewGoalsForm : Form
    {
        private string connectionString = "Data Source=20RK-ASUS;Initial Catalog=Project;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        public ViewGoalsForm()
        {
            InitializeComponent();
            LoadGoals();
        }

        private void LoadGoals()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT Goal_ID, Scorer_ID FROM Goal";
                    SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    listViewGoals.Items.Clear();
                    foreach (DataRow row in dt.Rows)
                    {
                        ListViewItem item = new ListViewItem(row["Goal_ID"].ToString());
                        item.SubItems.Add(row["Scorer_ID"].ToString());
                        listViewGoals.Items.Add(item);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void listViewGoals_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewGoals.SelectedItems.Count > 0)
            {
                string selectedGoalID = listViewGoals.SelectedItems[0].Text;
                LoadGoalDetails(selectedGoalID);
            }
        }

        private void LoadGoalDetails(string goalID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                SELECT g.Goal_ID, g.Scorer_ID, g.Assist_ID, 
                       scorer.Name AS Scorer_Name, assister.Name AS Assist_Name,
                       m.Match_ID, m.Date, m.Stadium, 
                       t1.Team_Name AS Team1, t2.Team_Name AS Team2, m.Score
                FROM Goal g
                INNER JOIN Match m ON g.Match_ID = m.Match_ID
                INNER JOIN Team t1 ON m.Team1_ID = t1.Team_ID
                INNER JOIN Team t2 ON m.Team2_ID = t2.Team_ID
                LEFT JOIN Player scorer ON g.Scorer_ID = scorer.Player_ID
                LEFT JOIN Player assister ON g.Assist_ID = assister.Player_ID
                WHERE g.Goal_ID = @GoalID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@GoalID", goalID);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        lblGoalDetails.Text = $"Goal ID: {reader["Goal_ID"]}\n" +
                                              $"Scorer: {reader["Scorer_Name"]} (ID: {reader["Scorer_ID"]})\n" +
                                              $"Assist: {reader["Assist_Name"]} (ID: {reader["Assist_ID"]})\n" +
                                              $"Match ID: {reader["Match_ID"]}\n" +
                                              $"Date: {reader["Date"]}\n" +
                                              $"Stadium: {reader["Stadium"]}\n" +
                                              $"Teams: {reader["Team1"]} vs {reader["Team2"]}\n" +
                                              $"Score: {reader["Score"]}";
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
            this.listViewGoals = new System.Windows.Forms.ListView();
            this.columnGoalID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnScorerID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBoxGoalDetails = new System.Windows.Forms.GroupBox();
            this.lblGoalDetails = new System.Windows.Forms.Label();
            this.groupBoxGoalDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewGoals
            // 
            this.listViewGoals.BackColor = System.Drawing.Color.WhiteSmoke;
            this.listViewGoals.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnGoalID,
            this.columnScorerID});
            this.listViewGoals.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.listViewGoals.FullRowSelect = true;
            this.listViewGoals.GridLines = true;
            this.listViewGoals.HideSelection = false;
            this.listViewGoals.Location = new System.Drawing.Point(30, 30);
            this.listViewGoals.Name = "listViewGoals";
            this.listViewGoals.Size = new System.Drawing.Size(300, 400);
            this.listViewGoals.TabIndex = 0;
            this.listViewGoals.UseCompatibleStateImageBehavior = false;
            this.listViewGoals.View = System.Windows.Forms.View.Details;
            this.listViewGoals.SelectedIndexChanged += new System.EventHandler(this.listViewGoals_SelectedIndexChanged);
            // 
            // columnGoalID
            // 
            this.columnGoalID.Text = "Goal ID";
            this.columnGoalID.Width = 100;
            // 
            // columnScorerID
            // 
            this.columnScorerID.Text = "Scorer ID";
            this.columnScorerID.Width = 150;
            // 
            // groupBoxGoalDetails
            // 
            this.groupBoxGoalDetails.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBoxGoalDetails.Controls.Add(this.lblGoalDetails);
            this.groupBoxGoalDetails.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.groupBoxGoalDetails.Location = new System.Drawing.Point(350, 30);
            this.groupBoxGoalDetails.Name = "groupBoxGoalDetails";
            this.groupBoxGoalDetails.Size = new System.Drawing.Size(400, 250);
            this.groupBoxGoalDetails.TabIndex = 1;
            this.groupBoxGoalDetails.TabStop = false;
            this.groupBoxGoalDetails.Text = "Goal Details";
            // 
            // lblGoalDetails
            // 
            this.lblGoalDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblGoalDetails.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblGoalDetails.Location = new System.Drawing.Point(10, 30);
            this.lblGoalDetails.Name = "lblGoalDetails";
            this.lblGoalDetails.Size = new System.Drawing.Size(380, 200);
            this.lblGoalDetails.TabIndex = 0;
            // 
            // ViewGoalsForm
            // 
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.listViewGoals);
            this.Controls.Add(this.groupBoxGoalDetails);
            this.Name = "ViewGoalsForm";
            this.Text = "View Goals";
            this.Load += new System.EventHandler(this.ViewGoalsForm_Load);
            this.groupBoxGoalDetails.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.ListView listViewGoals;
        private System.Windows.Forms.ColumnHeader columnGoalID;
        private System.Windows.Forms.ColumnHeader columnScorerID;
        private System.Windows.Forms.GroupBox groupBoxGoalDetails;
        private System.Windows.Forms.Label lblGoalDetails;

        private void ViewGoalsForm_Load(object sender, EventArgs e)
        {

        }
    }
}
