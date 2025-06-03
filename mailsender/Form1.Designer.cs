namespace mailsender
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            txtUserId = new TextBox();
            txtTitle = new TextBox();
            txtSender = new TextBox();
            txtBody = new TextBox();
            cmbExpiry = new ComboBox();
            txtItem1 = new TextBox();
            btnSelect1 = new Button();
            txtQty1 = new TextBox();
            chkGift1 = new CheckBox();
            txtItem2 = new TextBox();
            btnSelect2 = new Button();
            txtQty2 = new TextBox();
            chkGift2 = new CheckBox();
            txtItem3 = new TextBox();
            btnSelect3 = new Button();
            txtQty3 = new TextBox();
            chkGift3 = new CheckBox();
            txtEP = new TextBox();
            txtPP = new TextBox();
            txtMoonstone = new TextBox();
            txtStarstone = new TextBox();
            btnSendPersonal = new Button();
            btnSendAll = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            label14 = new Label();
            label15 = new Label();
            txtgold = new TextBox();
            label16 = new Label();
            btnFindid = new Button();
            btnTemplt = new Button();
            toolStrip1 = new ToolStrip();
            toolStripButtonAbout = new ToolStripButton();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // txtUserId
            // 
            txtUserId.Location = new Point(88, 52);
            txtUserId.Name = "txtUserId";
            txtUserId.Size = new Size(135, 23);
            txtUserId.TabIndex = 1;
            txtUserId.KeyPress += OnlyNumber_KeyPress;
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(88, 78);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(135, 23);
            txtTitle.TabIndex = 3;
            // 
            // txtSender
            // 
            txtSender.Location = new Point(88, 107);
            txtSender.Name = "txtSender";
            txtSender.Size = new Size(200, 23);
            txtSender.TabIndex = 5;
            // 
            // txtBody
            // 
            txtBody.Location = new Point(88, 136);
            txtBody.Multiline = true;
            txtBody.Name = "txtBody";
            txtBody.Size = new Size(200, 80);
            txtBody.TabIndex = 7;
            // 
            // cmbExpiry
            // 
            cmbExpiry.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbExpiry.Items.AddRange(new object[] { "3", "7", "15", "30", "180", "365" });
            cmbExpiry.Location = new Point(88, 222);
            cmbExpiry.Name = "cmbExpiry";
            cmbExpiry.Size = new Size(200, 23);
            cmbExpiry.TabIndex = 9;
            // 
            // txtItem1
            // 
            txtItem1.Location = new Point(88, 251);
            txtItem1.Name = "txtItem1";
            txtItem1.Size = new Size(135, 23);
            txtItem1.TabIndex = 11;
            txtItem1.KeyPress += OnlyNumber_KeyPress;
            // 
            // btnSelect1
            // 
            btnSelect1.Location = new Point(233, 251);
            btnSelect1.Name = "btnSelect1";
            btnSelect1.Size = new Size(55, 23);
            btnSelect1.TabIndex = 12;
            btnSelect1.Text = "Select";
            // 
            // txtQty1
            // 
            txtQty1.Location = new Point(88, 280);
            txtQty1.Name = "txtQty1";
            txtQty1.Size = new Size(135, 23);
            txtQty1.TabIndex = 13;
            txtQty1.KeyPress += OnlyNumber_KeyPress;
            // 
            // chkGift1
            // 
            chkGift1.Location = new Point(238, 280);
            chkGift1.Name = "chkGift1";
            chkGift1.Size = new Size(50, 23);
            chkGift1.TabIndex = 14;
            chkGift1.Text = "Gift";
            // 
            // txtItem2
            // 
            txtItem2.Location = new Point(88, 309);
            txtItem2.Name = "txtItem2";
            txtItem2.Size = new Size(135, 23);
            txtItem2.TabIndex = 16;
            txtItem2.KeyPress += OnlyNumber_KeyPress;
            // 
            // btnSelect2
            // 
            btnSelect2.Location = new Point(233, 309);
            btnSelect2.Name = "btnSelect2";
            btnSelect2.Size = new Size(55, 23);
            btnSelect2.TabIndex = 17;
            btnSelect2.Text = "Select";
            // 
            // txtQty2
            // 
            txtQty2.Location = new Point(88, 338);
            txtQty2.Name = "txtQty2";
            txtQty2.Size = new Size(135, 23);
            txtQty2.TabIndex = 18;
            txtQty2.KeyPress += OnlyNumber_KeyPress;
            // 
            // chkGift2
            // 
            chkGift2.Location = new Point(238, 338);
            chkGift2.Name = "chkGift2";
            chkGift2.Size = new Size(50, 23);
            chkGift2.TabIndex = 19;
            chkGift2.Text = "Gift";
            // 
            // txtItem3
            // 
            txtItem3.Location = new Point(88, 367);
            txtItem3.Name = "txtItem3";
            txtItem3.Size = new Size(135, 23);
            txtItem3.TabIndex = 21;
            txtItem3.KeyPress += OnlyNumber_KeyPress;
            // 
            // btnSelect3
            // 
            btnSelect3.Location = new Point(233, 366);
            btnSelect3.Name = "btnSelect3";
            btnSelect3.Size = new Size(55, 23);
            btnSelect3.TabIndex = 22;
            btnSelect3.Text = "Select";
            // 
            // txtQty3
            // 
            txtQty3.Location = new Point(88, 397);
            txtQty3.Name = "txtQty3";
            txtQty3.Size = new Size(135, 23);
            txtQty3.TabIndex = 23;
            txtQty3.KeyPress += OnlyNumber_KeyPress;
            // 
            // chkGift3
            // 
            chkGift3.Location = new Point(238, 397);
            chkGift3.Name = "chkGift3";
            chkGift3.Size = new Size(50, 23);
            chkGift3.TabIndex = 24;
            chkGift3.Text = "Gift";
            // 
            // txtEP
            // 
            txtEP.Location = new Point(88, 455);
            txtEP.Name = "txtEP";
            txtEP.Size = new Size(200, 23);
            txtEP.TabIndex = 26;
            txtEP.KeyPress += OnlyNumber_KeyPress;
            // 
            // txtPP
            // 
            txtPP.Location = new Point(88, 484);
            txtPP.Name = "txtPP";
            txtPP.Size = new Size(200, 23);
            txtPP.TabIndex = 28;
            txtPP.KeyPress += OnlyNumber_KeyPress;
            // 
            // txtMoonstone
            // 
            txtMoonstone.Location = new Point(88, 513);
            txtMoonstone.Name = "txtMoonstone";
            txtMoonstone.Size = new Size(200, 23);
            txtMoonstone.TabIndex = 30;
            txtMoonstone.KeyPress += OnlyNumber_KeyPress;
            // 
            // txtStarstone
            // 
            txtStarstone.Location = new Point(88, 542);
            txtStarstone.Name = "txtStarstone";
            txtStarstone.Size = new Size(200, 23);
            txtStarstone.TabIndex = 32;
            txtStarstone.KeyPress += OnlyNumber_KeyPress;
            // 
            // btnSendPersonal
            // 
            btnSendPersonal.Location = new Point(88, 571);
            btnSendPersonal.Name = "btnSendPersonal";
            btnSendPersonal.Size = new Size(200, 30);
            btnSendPersonal.TabIndex = 33;
            btnSendPersonal.Text = "Send Personal Mail";
            btnSendPersonal.UseVisualStyleBackColor = true;
            btnSendPersonal.Click += btnSendPersonal_Click;
            // 
            // btnSendAll
            // 
            btnSendAll.Location = new Point(88, 607);
            btnSendAll.Name = "btnSendAll";
            btnSendAll.Size = new Size(200, 30);
            btnSendAll.TabIndex = 34;
            btnSendAll.Text = "Send All (Ignore user id)";
            btnSendAll.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(32, 55);
            label1.Name = "label1";
            label1.Size = new Size(50, 15);
            label1.TabIndex = 35;
            label1.Text = "User ID :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(46, 81);
            label2.Name = "label2";
            label2.Size = new Size(36, 15);
            label2.TabIndex = 36;
            label2.Text = "Title :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(33, 110);
            label3.Name = "label3";
            label3.Size = new Size(49, 15);
            label3.TabIndex = 37;
            label3.Text = "Sender :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(23, 139);
            label4.Name = "label4";
            label4.Size = new Size(59, 15);
            label4.TabIndex = 38;
            label4.Text = "Message :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(3, 225);
            label5.Name = "label5";
            label5.Size = new Size(79, 15);
            label5.TabIndex = 39;
            label5.Text = "Expiry (days) :";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(36, 255);
            label6.Name = "label6";
            label6.Size = new Size(46, 15);
            label6.TabIndex = 40;
            label6.Text = "Item 1 :";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(26, 285);
            label7.Name = "label7";
            label7.Size = new Size(59, 15);
            label7.TabIndex = 41;
            label7.Text = "Quantity :";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(36, 313);
            label8.Name = "label8";
            label8.Size = new Size(46, 15);
            label8.TabIndex = 42;
            label8.Text = "Item 2 :";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(26, 341);
            label9.Name = "label9";
            label9.Size = new Size(59, 15);
            label9.TabIndex = 43;
            label9.Text = "Quantity :";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(36, 370);
            label10.Name = "label10";
            label10.Size = new Size(46, 15);
            label10.TabIndex = 44;
            label10.Text = "Item 3 :";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(26, 400);
            label11.Name = "label11";
            label11.Size = new Size(59, 15);
            label11.TabIndex = 45;
            label11.Text = "Quantity :";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(56, 458);
            label12.Name = "label12";
            label12.Size = new Size(26, 15);
            label12.TabIndex = 46;
            label12.Text = "EP :";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(55, 487);
            label13.Name = "label13";
            label13.Size = new Size(27, 15);
            label13.TabIndex = 47;
            label13.Text = "PP :";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(8, 516);
            label14.Name = "label14";
            label14.Size = new Size(74, 15);
            label14.TabIndex = 48;
            label14.Text = "Lunar Point :";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(18, 545);
            label15.Name = "label15";
            label15.Size = new Size(64, 15);
            label15.TabIndex = 49;
            label15.Text = "Star Point :";
            // 
            // txtgold
            // 
            txtgold.Location = new Point(88, 426);
            txtgold.Name = "txtgold";
            txtgold.Size = new Size(198, 23);
            txtgold.TabIndex = 50;
            txtgold.KeyPress += OnlyNumber_KeyPress;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(44, 429);
            label16.Name = "label16";
            label16.Size = new Size(38, 15);
            label16.TabIndex = 51;
            label16.Text = "Gold :";
            // 
            // btnFindid
            // 
            btnFindid.Location = new Point(229, 51);
            btnFindid.Name = "btnFindid";
            btnFindid.Size = new Size(59, 23);
            btnFindid.TabIndex = 52;
            btnFindid.Text = "Find";
            btnFindid.UseVisualStyleBackColor = true;
            btnFindid.Click += btnFindid_Click;
            // 
            // btnTemplt
            // 
            btnTemplt.Location = new Point(231, 79);
            btnTemplt.Name = "btnTemplt";
            btnTemplt.Size = new Size(57, 23);
            btnTemplt.TabIndex = 53;
            btnTemplt.Text = "Select";
            btnTemplt.UseVisualStyleBackColor = true;
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButtonAbout });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(661, 25);
            toolStrip1.TabIndex = 54;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonAbout
            // 
            toolStripButtonAbout.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButtonAbout.Image = (Image)resources.GetObject("toolStripButtonAbout.Image");
            toolStripButtonAbout.ImageTransparentColor = Color.Magenta;
            toolStripButtonAbout.Name = "toolStripButtonAbout";
            toolStripButtonAbout.Size = new Size(44, 22);
            toolStripButtonAbout.Text = "About";
            toolStripButtonAbout.Click += toolStripButtonAbout_Click;
            // 
            // Form1
            // 
            ClientSize = new Size(661, 740);
            Controls.Add(toolStrip1);
            Controls.Add(txtUserId);
            Controls.Add(btnTemplt);
            Controls.Add(btnSendAll);
            Controls.Add(txtSender);
            Controls.Add(btnFindid);
            Controls.Add(txtTitle);
            Controls.Add(btnSendPersonal);
            Controls.Add(txtBody);
            Controls.Add(label16);
            Controls.Add(cmbExpiry);
            Controls.Add(txtStarstone);
            Controls.Add(label1);
            Controls.Add(txtgold);
            Controls.Add(txtItem1);
            Controls.Add(txtMoonstone);
            Controls.Add(label2);
            Controls.Add(label15);
            Controls.Add(btnSelect1);
            Controls.Add(txtPP);
            Controls.Add(label3);
            Controls.Add(label14);
            Controls.Add(txtQty1);
            Controls.Add(txtEP);
            Controls.Add(label4);
            Controls.Add(label13);
            Controls.Add(chkGift1);
            Controls.Add(chkGift3);
            Controls.Add(label5);
            Controls.Add(label12);
            Controls.Add(txtItem2);
            Controls.Add(txtQty3);
            Controls.Add(label6);
            Controls.Add(label11);
            Controls.Add(btnSelect2);
            Controls.Add(btnSelect3);
            Controls.Add(label7);
            Controls.Add(label10);
            Controls.Add(txtQty2);
            Controls.Add(txtItem3);
            Controls.Add(label8);
            Controls.Add(label9);
            Controls.Add(chkGift2);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Mail Sender By DuaSelipar";
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        // Declare all controls
        private System.Windows.Forms.TextBox txtUserId;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtSender;
        private System.Windows.Forms.TextBox txtBody;
        private System.Windows.Forms.ComboBox cmbExpiry;
        private System.Windows.Forms.TextBox txtItem1;
        private System.Windows.Forms.Button btnSelect1;
        private System.Windows.Forms.TextBox txtQty1;
        private System.Windows.Forms.CheckBox chkGift1;
        private System.Windows.Forms.TextBox txtItem2;
        private System.Windows.Forms.Button btnSelect2;
        private System.Windows.Forms.TextBox txtQty2;
        private System.Windows.Forms.CheckBox chkGift2;
        private System.Windows.Forms.TextBox txtItem3;
        private System.Windows.Forms.Button btnSelect3;
        private System.Windows.Forms.TextBox txtQty3;
        private System.Windows.Forms.CheckBox chkGift3;
        private System.Windows.Forms.TextBox txtEP;
        private System.Windows.Forms.TextBox txtPP;
        private System.Windows.Forms.TextBox txtMoonstone;
        private System.Windows.Forms.TextBox txtStarstone;

        private System.Windows.Forms.Button btnSendPersonal;
        private System.Windows.Forms.Button btnSendAll;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private TextBox txtgold;
        private Label label16;
        private System.Windows.Forms.Button btnFindid;
        private System.Windows.Forms.Button btnTemplt;
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButtonAbout;
    }
}
