namespace swimGUIAssignment4
{
    partial class Home
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.panel1 = new System.Windows.Forms.Panel();
            this.swimMeetFormDirector = new System.Windows.Forms.Button();
            this.eventFormDirector = new System.Windows.Forms.Button();
            this.coachFormDirector = new System.Windows.Forms.Button();
            this.swimmerFormDirector = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.clubFormDirector = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.panel1.Controls.Add(this.swimMeetFormDirector);
            this.panel1.Controls.Add(this.eventFormDirector);
            this.panel1.Controls.Add(this.coachFormDirector);
            this.panel1.Controls.Add(this.swimmerFormDirector);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.clubFormDirector);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 518);
            this.panel1.TabIndex = 0;
            // 
            // swimMeetFormDirector
            // 
            this.swimMeetFormDirector.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(68)))), ((int)(((byte)(173)))));
            this.swimMeetFormDirector.FlatAppearance.BorderSize = 0;
            this.swimMeetFormDirector.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.swimMeetFormDirector.Font = new System.Drawing.Font("Candara", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.swimMeetFormDirector.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.swimMeetFormDirector.Image = ((System.Drawing.Image)(resources.GetObject("swimMeetFormDirector.Image")));
            this.swimMeetFormDirector.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.swimMeetFormDirector.Location = new System.Drawing.Point(0, 421);
            this.swimMeetFormDirector.Name = "swimMeetFormDirector";
            this.swimMeetFormDirector.Size = new System.Drawing.Size(200, 56);
            this.swimMeetFormDirector.TabIndex = 5;
            this.swimMeetFormDirector.Text = "     Swim Meet";
            this.swimMeetFormDirector.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.swimMeetFormDirector.UseVisualStyleBackColor = false;
            this.swimMeetFormDirector.Click += new System.EventHandler(this.swimMeetFormDirector_Click);
            // 
            // eventFormDirector
            // 
            this.eventFormDirector.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.eventFormDirector.FlatAppearance.BorderSize = 0;
            this.eventFormDirector.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.eventFormDirector.Font = new System.Drawing.Font("Candara", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eventFormDirector.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.eventFormDirector.Image = ((System.Drawing.Image)(resources.GetObject("eventFormDirector.Image")));
            this.eventFormDirector.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.eventFormDirector.Location = new System.Drawing.Point(0, 347);
            this.eventFormDirector.Name = "eventFormDirector";
            this.eventFormDirector.Size = new System.Drawing.Size(200, 56);
            this.eventFormDirector.TabIndex = 4;
            this.eventFormDirector.Text = "     Event";
            this.eventFormDirector.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.eventFormDirector.UseVisualStyleBackColor = false;
            this.eventFormDirector.Click += new System.EventHandler(this.eventFormDirector_Click);
            // 
            // coachFormDirector
            // 
            this.coachFormDirector.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(84)))), ((int)(((byte)(0)))));
            this.coachFormDirector.FlatAppearance.BorderSize = 0;
            this.coachFormDirector.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.coachFormDirector.Font = new System.Drawing.Font("Candara", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.coachFormDirector.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.coachFormDirector.Image = ((System.Drawing.Image)(resources.GetObject("coachFormDirector.Image")));
            this.coachFormDirector.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.coachFormDirector.Location = new System.Drawing.Point(0, 270);
            this.coachFormDirector.Name = "coachFormDirector";
            this.coachFormDirector.Size = new System.Drawing.Size(200, 56);
            this.coachFormDirector.TabIndex = 3;
            this.coachFormDirector.Text = "     Coach";
            this.coachFormDirector.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.coachFormDirector.UseVisualStyleBackColor = false;
            this.coachFormDirector.Click += new System.EventHandler(this.coachFormDirector_Click);
            // 
            // swimmerFormDirector
            // 
            this.swimmerFormDirector.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.swimmerFormDirector.FlatAppearance.BorderSize = 0;
            this.swimmerFormDirector.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.swimmerFormDirector.Font = new System.Drawing.Font("Candara", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.swimmerFormDirector.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.swimmerFormDirector.Image = ((System.Drawing.Image)(resources.GetObject("swimmerFormDirector.Image")));
            this.swimmerFormDirector.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.swimmerFormDirector.Location = new System.Drawing.Point(0, 193);
            this.swimmerFormDirector.Name = "swimmerFormDirector";
            this.swimmerFormDirector.Size = new System.Drawing.Size(200, 56);
            this.swimmerFormDirector.TabIndex = 2;
            this.swimmerFormDirector.Text = "     Swimmer";
            this.swimmerFormDirector.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.swimmerFormDirector.UseVisualStyleBackColor = false;
            this.swimmerFormDirector.Click += new System.EventHandler(this.swimmerFormDirector_Click);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 111);
            this.label1.TabIndex = 1;
            this.label1.Text = "           MENU          ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // clubFormDirector
            // 
            this.clubFormDirector.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.clubFormDirector.FlatAppearance.BorderSize = 0;
            this.clubFormDirector.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clubFormDirector.Font = new System.Drawing.Font("Candara", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clubFormDirector.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.clubFormDirector.Image = ((System.Drawing.Image)(resources.GetObject("clubFormDirector.Image")));
            this.clubFormDirector.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.clubFormDirector.Location = new System.Drawing.Point(0, 114);
            this.clubFormDirector.Name = "clubFormDirector";
            this.clubFormDirector.Size = new System.Drawing.Size(200, 56);
            this.clubFormDirector.TabIndex = 0;
            this.clubFormDirector.Text = "     Club";
            this.clubFormDirector.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.clubFormDirector.UseVisualStyleBackColor = false;
            this.clubFormDirector.Click += new System.EventHandler(this.clubFormDirector_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(87)))), ((int)(((byte)(51)))));
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(200, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(600, 39);
            this.panel2.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(600, 39);
            this.label2.TabIndex = 0;
            this.label2.Text = "Parth Chandgadhiya   -  300986134";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(200, 39);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(600, 479);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 518);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Home";
            this.Text = "Swim Application";
            this.Load += new System.EventHandler(this.Home_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button clubFormDirector;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button swimMeetFormDirector;
        private System.Windows.Forms.Button eventFormDirector;
        private System.Windows.Forms.Button coachFormDirector;
        private System.Windows.Forms.Button swimmerFormDirector;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
    }
}

