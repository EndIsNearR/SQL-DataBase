using System;
using System.Drawing;
using System.Windows.Forms;

namespace SimpleTeamViewer
{
    public partial class MainMenuForm : Form
    {
        public MainMenuForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.labelWelcome = new System.Windows.Forms.Label();
            this.btnViewTeams = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnViewPlayers = new System.Windows.Forms.Button();
            this.btnViewCoaches = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.btnViewGoals = new System.Windows.Forms.Button();
            this.btnViewTournaments = new System.Windows.Forms.Button();
            this.btnViewSchedule = new System.Windows.Forms.Button();
            this.viewRefereeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelWelcome
            // 
            this.labelWelcome.AutoSize = true;
            this.labelWelcome.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.labelWelcome.Location = new System.Drawing.Point(377, 34);
            this.labelWelcome.Name = "labelWelcome";
            this.labelWelcome.Size = new System.Drawing.Size(330, 32);
            this.labelWelcome.TabIndex = 0;
            this.labelWelcome.Text = "Welcome to the League!";
            // 
            // btnViewTeams
            // 
            this.btnViewTeams.BackColor = System.Drawing.Color.Blue;
            this.btnViewTeams.FlatAppearance.BorderSize = 0;
            this.btnViewTeams.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewTeams.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnViewTeams.ForeColor = System.Drawing.Color.White;
            this.btnViewTeams.Location = new System.Drawing.Point(310, 148);
            this.btnViewTeams.Name = "btnViewTeams";
            this.btnViewTeams.Size = new System.Drawing.Size(200, 50);
            this.btnViewTeams.TabIndex = 1;
            this.btnViewTeams.Text = "View Teams";
            this.toolTip.SetToolTip(this.btnViewTeams, "Click to view team details.");
            this.btnViewTeams.UseVisualStyleBackColor = false;
            this.btnViewTeams.Click += new System.EventHandler(this.BtnViewTeams_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(559, 447);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(200, 50);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Exit";
            this.toolTip.SetToolTip(this.btnExit, "Click to exit the application.");
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // btnViewPlayers
            // 
            this.btnViewPlayers.BackColor = System.Drawing.Color.Green;
            this.btnViewPlayers.FlatAppearance.BorderSize = 0;
            this.btnViewPlayers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewPlayers.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnViewPlayers.ForeColor = System.Drawing.Color.White;
            this.btnViewPlayers.Location = new System.Drawing.Point(549, 148);
            this.btnViewPlayers.Name = "btnViewPlayers";
            this.btnViewPlayers.Size = new System.Drawing.Size(200, 50);
            this.btnViewPlayers.TabIndex = 3;
            this.btnViewPlayers.Text = "View Players";
            this.toolTip.SetToolTip(this.btnViewPlayers, "Click to view player details.");
            this.btnViewPlayers.UseVisualStyleBackColor = false;
            this.btnViewPlayers.Click += new System.EventHandler(this.BtnViewPlayers_Click);
            // 
            // btnViewCoaches
            // 
            this.btnViewCoaches.BackColor = System.Drawing.Color.Orange;
            this.btnViewCoaches.FlatAppearance.BorderSize = 0;
            this.btnViewCoaches.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewCoaches.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnViewCoaches.ForeColor = System.Drawing.Color.White;
            this.btnViewCoaches.Location = new System.Drawing.Point(310, 236);
            this.btnViewCoaches.Name = "btnViewCoaches";
            this.btnViewCoaches.Size = new System.Drawing.Size(200, 50);
            this.btnViewCoaches.TabIndex = 4;
            this.btnViewCoaches.Text = "View Coaches";
            this.toolTip.SetToolTip(this.btnViewCoaches, "Click to view coach details.");
            this.btnViewCoaches.UseVisualStyleBackColor = false;
            this.btnViewCoaches.Click += new System.EventHandler(this.BtnViewCoaches_Click);
            // 
            // btnViewGoals
            // 
            this.btnViewGoals.BackColor = System.Drawing.Color.Purple;
            this.btnViewGoals.FlatAppearance.BorderSize = 0;
            this.btnViewGoals.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewGoals.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnViewGoals.ForeColor = System.Drawing.Color.White;
            this.btnViewGoals.Location = new System.Drawing.Point(549, 236);
            this.btnViewGoals.Name = "btnViewGoals";
            this.btnViewGoals.Size = new System.Drawing.Size(200, 50);
            this.btnViewGoals.TabIndex = 5;
            this.btnViewGoals.Text = "View Goals";
            this.toolTip.SetToolTip(this.btnViewGoals, "Click to view goal details.");
            this.btnViewGoals.UseVisualStyleBackColor = false;
            this.btnViewGoals.Click += new System.EventHandler(this.BtnViewGoals_Click);
            // 
            // btnViewTournaments
            // 
            this.btnViewTournaments.BackColor = System.Drawing.Color.Purple;
            this.btnViewTournaments.FlatAppearance.BorderSize = 0;
            this.btnViewTournaments.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewTournaments.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnViewTournaments.ForeColor = System.Drawing.Color.White;
            this.btnViewTournaments.Location = new System.Drawing.Point(310, 336);
            this.btnViewTournaments.Name = "btnViewTournaments";
            this.btnViewTournaments.Size = new System.Drawing.Size(200, 50);
            this.btnViewTournaments.TabIndex = 5;
            this.btnViewTournaments.Text = "View Tournaments";
            this.btnViewTournaments.UseVisualStyleBackColor = false;
            this.btnViewTournaments.Click += new System.EventHandler(this.BtnViewTournaments_Click);
            // 
            // btnViewSchedule
            // 
            this.btnViewSchedule.BackColor = System.Drawing.Color.Purple;
            this.btnViewSchedule.FlatAppearance.BorderSize = 0;
            this.btnViewSchedule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewSchedule.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnViewSchedule.ForeColor = System.Drawing.Color.White;
            this.btnViewSchedule.Location = new System.Drawing.Point(559, 333);
            this.btnViewSchedule.Name = "btnViewSchedule";
            this.btnViewSchedule.Size = new System.Drawing.Size(200, 53);
            this.btnViewSchedule.TabIndex = 2;
            this.btnViewSchedule.Text = "View Schedule";
            this.btnViewSchedule.UseVisualStyleBackColor = false;
            this.btnViewSchedule.Click += new System.EventHandler(this.btnViewSchedule_Click);
            // 
            // viewRefereeButton
            // 
            this.viewRefereeButton.BackColor = System.Drawing.Color.Blue;
            this.viewRefereeButton.FlatAppearance.BorderSize = 0;
            this.viewRefereeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.viewRefereeButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.viewRefereeButton.ForeColor = System.Drawing.Color.White;
            this.viewRefereeButton.Location = new System.Drawing.Point(310, 447);
            this.viewRefereeButton.Name = "viewRefereeButton";
            this.viewRefereeButton.Size = new System.Drawing.Size(200, 50);
            this.viewRefereeButton.TabIndex = 3;
            this.viewRefereeButton.Text = "View Referee";
            this.viewRefereeButton.UseVisualStyleBackColor = false;
            this.viewRefereeButton.Click += new System.EventHandler(this.viewRefereeButton_Click);
            // 
            // MainMenuForm
            // 
            this.BackgroundImage = global::Project2.Properties.Resources.WhatsApp_Image_2024_11_08_at_15_05_03_0c51af6a;
            this.ClientSize = new System.Drawing.Size(1035, 595);
            this.Controls.Add(this.btnViewPlayers);
            this.Controls.Add(this.btnViewCoaches);
            this.Controls.Add(this.labelWelcome);
            this.Controls.Add(this.btnViewTeams);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnViewGoals);
            this.Controls.Add(this.btnViewSchedule);
            this.Controls.Add(this.btnViewTournaments);
            this.Controls.Add(this.viewRefereeButton);
            this.Name = "MainMenuForm";
            this.Text = "Main Menu";
            this.Load += new System.EventHandler(this.MainMenuForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        private void btnViewSchedule_Click(object sender, EventArgs e)
        {
            ViewScheduleForm viewScheduleForm = new ViewScheduleForm();
            viewScheduleForm.ShowDialog();
        }


        private void viewRefereeButton_Click(object sender, EventArgs e)
        {
            ViewRefereeForm viewRefereeForm = new ViewRefereeForm();
            viewRefereeForm.Show();
        }


        // Event handler to open TournamentForm
        private void BtnViewTournaments_Click(object sender, EventArgs e)
        {
            TournamentForm formTournaments = new TournamentForm();
            formTournaments.Show();
        }

        // Event handler to open the ViewGoalsForm
        private void BtnViewGoals_Click(object sender, EventArgs e)
        {
            ViewGoalsForm formGoals = new ViewGoalsForm();
            formGoals.Show();
        }


        private void BtnViewTeams_Click(object sender, EventArgs e)
        {
            // Open the Form1 to view teams
            Form1 formTeams = new Form1();
            formTeams.Show();
        }

        private void BtnViewPlayers_Click(object sender, EventArgs e)
        {
            // Open the ViewPlayersForm to view players
            ViewPlayersForm formPlayers = new ViewPlayersForm();
            formPlayers.Show();
        }

        private void BtnViewCoaches_Click(object sender, EventArgs e)
        {
            // Open the ViewCoachesForm to view coaches
            ViewCoachesForm formCoaches = new ViewCoachesForm();
            formCoaches.Show();
        }

        private void BtnClickHandler(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;

            if (clickedButton == btnViewTeams)
            {
                // Open the Form1 to view teams
                Form1 formTeams = new Form1();
                formTeams.Show();
            }
            else if (clickedButton == btnViewPlayers)
            {
                // Open the ViewPlayersForm to view players
                ViewPlayersForm formPlayers = new ViewPlayersForm();
                formPlayers.Show();
            }
            else if (clickedButton == btnViewCoaches)
            {
                // Open the ViewCoachesForm to view coaches
                ViewCoachesForm formCoaches = new ViewCoachesForm();
                formCoaches.Show();
            }
            else if (clickedButton == btnExit)
            {
                Application.Exit();
            }
        }


        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private System.Windows.Forms.Label labelWelcome;
        private System.Windows.Forms.Button btnViewTeams;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnViewPlayers;
        private System.Windows.Forms.Button btnViewCoaches;
        private System.Windows.Forms.Button btnViewGoals;
        private System.Windows.Forms.Button btnViewTournaments;
        private System.Windows.Forms.Button btnViewSchedule;
        private System.Windows.Forms.Button viewRefereeButton;

        private void MainMenuForm_Load(object sender, EventArgs e)
        {

        }

        private ToolTip toolTip;
        private System.ComponentModel.IContainer components;
    }
}
