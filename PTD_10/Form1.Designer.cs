namespace PTD_10
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btn_Added = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txb_AddedPhase = new System.Windows.Forms.TextBox();
            this.txb_DeletedPhase = new System.Windows.Forms.TextBox();
            this.btn_Deleted = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cb_RaisedBy = new System.Windows.Forms.ComboBox();
            this.cb_ChangeType = new System.Windows.Forms.ComboBox();
            this.txb_ChangeRevision = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_info = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Added
            // 
            this.btn_Added.Location = new System.Drawing.Point(88, 144);
            this.btn_Added.Name = "btn_Added";
            this.btn_Added.Size = new System.Drawing.Size(75, 23);
            this.btn_Added.TabIndex = 5;
            this.btn_Added.Text = "Added";
            this.btn_Added.UseVisualStyleBackColor = true;
            this.btn_Added.Click += new System.EventHandler(this.btn_Added_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Added Phase";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Change type";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Raised by";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Deleted Phase";
            // 
            // txb_AddedPhase
            // 
            this.txb_AddedPhase.Location = new System.Drawing.Point(144, 12);
            this.txb_AddedPhase.Name = "txb_AddedPhase";
            this.txb_AddedPhase.Size = new System.Drawing.Size(100, 20);
            this.txb_AddedPhase.TabIndex = 0;
            this.txb_AddedPhase.Text = "0";
            this.txb_AddedPhase.TextChanged += new System.EventHandler(this.txb_AddedPhase_TextChanged);
            // 
            // txb_DeletedPhase
            // 
            this.txb_DeletedPhase.Location = new System.Drawing.Point(144, 38);
            this.txb_DeletedPhase.Name = "txb_DeletedPhase";
            this.txb_DeletedPhase.Size = new System.Drawing.Size(100, 20);
            this.txb_DeletedPhase.TabIndex = 1;
            this.txb_DeletedPhase.Text = "0";
            this.txb_DeletedPhase.TextChanged += new System.EventHandler(this.txb_DeletedPhase_TextChanged);
            // 
            // btn_Deleted
            // 
            this.btn_Deleted.Location = new System.Drawing.Point(169, 144);
            this.btn_Deleted.Name = "btn_Deleted";
            this.btn_Deleted.Size = new System.Drawing.Size(75, 23);
            this.btn_Deleted.TabIndex = 6;
            this.btn_Deleted.Text = "Deleted";
            this.btn_Deleted.UseVisualStyleBackColor = true;
            this.btn_Deleted.Click += new System.EventHandler(this.btn_Deleted_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 149);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Mark bar as:";
            // 
            // cb_RaisedBy
            // 
            this.cb_RaisedBy.FormattingEnabled = true;
            this.cb_RaisedBy.Items.AddRange(new object[] {
            " ",
            "BYLOR",
            "EDVANCE",
            "CNEPE",
            "NNB",
            "SET"});
            this.cb_RaisedBy.Location = new System.Drawing.Point(123, 91);
            this.cb_RaisedBy.Name = "cb_RaisedBy";
            this.cb_RaisedBy.Size = new System.Drawing.Size(121, 21);
            this.cb_RaisedBy.TabIndex = 3;
            // 
            // cb_ChangeType
            // 
            this.cb_ChangeType.FormattingEnabled = true;
            this.cb_ChangeType.Items.AddRange(new object[] {
            " ",
            "FCR",
            "DEN",
            "NCR",
            "RFI"});
            this.cb_ChangeType.Location = new System.Drawing.Point(123, 64);
            this.cb_ChangeType.Name = "cb_ChangeType";
            this.cb_ChangeType.Size = new System.Drawing.Size(121, 21);
            this.cb_ChangeType.TabIndex = 2;
            // 
            // txb_ChangeRevision
            // 
            this.txb_ChangeRevision.Location = new System.Drawing.Point(144, 118);
            this.txb_ChangeRevision.Name = "txb_ChangeRevision";
            this.txb_ChangeRevision.Size = new System.Drawing.Size(100, 20);
            this.txb_ChangeRevision.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 121);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Change Revision";
            // 
            // lbl_info
            // 
            this.lbl_info.AutoSize = true;
            this.lbl_info.Location = new System.Drawing.Point(16, 175);
            this.lbl_info.Name = "lbl_info";
            this.lbl_info.Size = new System.Drawing.Size(96, 13);
            this.lbl_info.TabIndex = 16;
            this.lbl_info.Text = "2020 by PTD team";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(121, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(17, 18);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(121, 40);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(17, 18);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 18;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Visible = false;
            // 
            // toolTip1
            // 
            this.toolTip1.Active = false;
            // 
            // toolTip2
            // 
            this.toolTip2.Active = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(256, 199);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lbl_info);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txb_ChangeRevision);
            this.Controls.Add(this.cb_ChangeType);
            this.Controls.Add(this.cb_RaisedBy);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btn_Deleted);
            this.Controls.Add(this.txb_DeletedPhase);
            this.Controls.Add(this.txb_AddedPhase);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Added);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "SDLT Change Management";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Added;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txb_AddedPhase;
        private System.Windows.Forms.TextBox txb_DeletedPhase;
        private System.Windows.Forms.Button btn_Deleted;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cb_RaisedBy;
        private System.Windows.Forms.ComboBox cb_ChangeType;
        private System.Windows.Forms.TextBox txb_ChangeRevision;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbl_info;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolTip toolTip2;
    }
}

