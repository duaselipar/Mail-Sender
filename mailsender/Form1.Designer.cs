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
            tabPage2 = new TabPage();
            richTextBox1 = new RichTextBox();
            label1 = new Label();
            txtUserId = new TextBox();
            txtSender = new TextBox();
            txtItem3 = new TextBox();
            txtQty2 = new TextBox();
            txtTitle = new TextBox();
            txtBody = new TextBox();
            txtStarstone = new TextBox();
            txtQty3 = new TextBox();
            txtgold = new TextBox();
            txtItem2 = new TextBox();
            txtItem1 = new TextBox();
            txtMoonstone = new TextBox();
            txtPP = new TextBox();
            txtEP = new TextBox();
            txtQty1 = new TextBox();
            chkGift2 = new CheckBox();
            btnTemplt = new Button();
            label9 = new Label();
            btnSendAll = new Button();
            label8 = new Label();
            btnFindid = new Button();
            label10 = new Label();
            btnSendPersonal = new Button();
            label7 = new Label();
            btnSelect3 = new Button();
            label16 = new Label();
            btnSelect2 = new Button();
            cmbExpiry = new ComboBox();
            label11 = new Label();
            label6 = new Label();
            label12 = new Label();
            label5 = new Label();
            label2 = new Label();
            chkGift3 = new CheckBox();
            label15 = new Label();
            chkGift1 = new CheckBox();
            btnSelect1 = new Button();
            label13 = new Label();
            label4 = new Label();
            label3 = new Label();
            label14 = new Label();
            tabPage1 = new TabPage();
            tabControl1 = new TabControl();
            tabPage2.SuspendLayout();
            tabPage1.SuspendLayout();
            tabControl1.SuspendLayout();
            SuspendLayout();
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(richTextBox1);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(581, 374);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "About";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(0, 0);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.Size = new Size(581, 374);
            richTextBox1.TabIndex = 0;
            richTextBox1.Text = resources.GetString("richTextBox1.Text");
            richTextBox1.TextChanged += richTextBox1_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(36, 13);
            label1.Name = "label1";
            label1.Size = new Size(50, 15);
            label1.TabIndex = 35;
            label1.Text = "User ID :";
            // 
            // txtUserId
            // 
            txtUserId.Location = new Point(92, 10);
            txtUserId.Name = "txtUserId";
            txtUserId.Size = new Size(135, 23);
            txtUserId.TabIndex = 1;
            txtUserId.KeyPress += OnlyNumber_KeyPress;
            // 
            // txtSender
            // 
            txtSender.Location = new Point(92, 65);
            txtSender.Name = "txtSender";
            txtSender.Size = new Size(200, 23);
            txtSender.TabIndex = 5;
            // 
            // txtItem3
            // 
            txtItem3.Location = new Point(362, 296);
            txtItem3.Name = "txtItem3";
            txtItem3.Size = new Size(135, 23);
            txtItem3.TabIndex = 21;
            txtItem3.KeyPress += OnlyNumber_KeyPress;
            // 
            // txtQty2
            // 
            txtQty2.Location = new Point(362, 267);
            txtQty2.Name = "txtQty2";
            txtQty2.Size = new Size(135, 23);
            txtQty2.TabIndex = 18;
            txtQty2.KeyPress += OnlyNumber_KeyPress;
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(92, 36);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(135, 23);
            txtTitle.TabIndex = 3;
            // 
            // txtBody
            // 
            txtBody.Location = new Point(92, 94);
            txtBody.Multiline = true;
            txtBody.Name = "txtBody";
            txtBody.Size = new Size(470, 80);
            txtBody.TabIndex = 7;
            // 
            // txtStarstone
            // 
            txtStarstone.Location = new Point(92, 325);
            txtStarstone.Name = "txtStarstone";
            txtStarstone.Size = new Size(200, 23);
            txtStarstone.TabIndex = 32;
            txtStarstone.KeyPress += OnlyNumber_KeyPress;
            // 
            // txtQty3
            // 
            txtQty3.Location = new Point(362, 324);
            txtQty3.Name = "txtQty3";
            txtQty3.Size = new Size(135, 23);
            txtQty3.TabIndex = 23;
            txtQty3.KeyPress += OnlyNumber_KeyPress;
            // 
            // txtgold
            // 
            txtgold.Location = new Point(92, 209);
            txtgold.Name = "txtgold";
            txtgold.Size = new Size(198, 23);
            txtgold.TabIndex = 50;
            txtgold.KeyPress += OnlyNumber_KeyPress;
            // 
            // txtItem2
            // 
            txtItem2.Location = new Point(362, 238);
            txtItem2.Name = "txtItem2";
            txtItem2.Size = new Size(135, 23);
            txtItem2.TabIndex = 16;
            txtItem2.KeyPress += OnlyNumber_KeyPress;
            // 
            // txtItem1
            // 
            txtItem1.Location = new Point(362, 180);
            txtItem1.Name = "txtItem1";
            txtItem1.Size = new Size(135, 23);
            txtItem1.TabIndex = 11;
            txtItem1.KeyPress += OnlyNumber_KeyPress;
            // 
            // txtMoonstone
            // 
            txtMoonstone.Location = new Point(92, 296);
            txtMoonstone.Name = "txtMoonstone";
            txtMoonstone.Size = new Size(200, 23);
            txtMoonstone.TabIndex = 30;
            txtMoonstone.KeyPress += OnlyNumber_KeyPress;
            // 
            // txtPP
            // 
            txtPP.Location = new Point(92, 267);
            txtPP.Name = "txtPP";
            txtPP.Size = new Size(200, 23);
            txtPP.TabIndex = 28;
            txtPP.KeyPress += OnlyNumber_KeyPress;
            // 
            // txtEP
            // 
            txtEP.Location = new Point(92, 238);
            txtEP.Name = "txtEP";
            txtEP.Size = new Size(200, 23);
            txtEP.TabIndex = 26;
            txtEP.KeyPress += OnlyNumber_KeyPress;
            // 
            // txtQty1
            // 
            txtQty1.Location = new Point(362, 209);
            txtQty1.Name = "txtQty1";
            txtQty1.Size = new Size(135, 23);
            txtQty1.TabIndex = 13;
            txtQty1.KeyPress += OnlyNumber_KeyPress;
            // 
            // chkGift2
            // 
            chkGift2.Location = new Point(512, 267);
            chkGift2.Name = "chkGift2";
            chkGift2.Size = new Size(50, 23);
            chkGift2.TabIndex = 19;
            chkGift2.Text = "Gift";
            // 
            // btnTemplt
            // 
            btnTemplt.Location = new Point(235, 37);
            btnTemplt.Name = "btnTemplt";
            btnTemplt.Size = new Size(57, 23);
            btnTemplt.TabIndex = 53;
            btnTemplt.Text = "Select";
            btnTemplt.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(297, 270);
            label9.Name = "label9";
            label9.Size = new Size(59, 15);
            label9.TabIndex = 43;
            label9.Text = "Quantity :";
            // 
            // btnSendAll
            // 
            btnSendAll.Location = new Point(333, 49);
            btnSendAll.Name = "btnSendAll";
            btnSendAll.Size = new Size(200, 30);
            btnSendAll.TabIndex = 34;
            btnSendAll.Text = "Send All (Ignore user id)";
            btnSendAll.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(310, 242);
            label8.Name = "label8";
            label8.Size = new Size(46, 15);
            label8.TabIndex = 42;
            label8.Text = "Item 2 :";
            // 
            // btnFindid
            // 
            btnFindid.Location = new Point(233, 9);
            btnFindid.Name = "btnFindid";
            btnFindid.Size = new Size(59, 23);
            btnFindid.TabIndex = 52;
            btnFindid.Text = "Find";
            btnFindid.UseVisualStyleBackColor = true;
            btnFindid.Click += btnFindid_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(310, 299);
            label10.Name = "label10";
            label10.Size = new Size(46, 15);
            label10.TabIndex = 44;
            label10.Text = "Item 3 :";
            // 
            // btnSendPersonal
            // 
            btnSendPersonal.Location = new Point(333, 13);
            btnSendPersonal.Name = "btnSendPersonal";
            btnSendPersonal.Size = new Size(200, 30);
            btnSendPersonal.TabIndex = 33;
            btnSendPersonal.Text = "Send Personal Mail";
            btnSendPersonal.UseVisualStyleBackColor = true;
            btnSendPersonal.Click += btnSendPersonal_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(296, 212);
            label7.Name = "label7";
            label7.Size = new Size(59, 15);
            label7.TabIndex = 41;
            label7.Text = "Quantity :";
            // 
            // btnSelect3
            // 
            btnSelect3.Location = new Point(507, 295);
            btnSelect3.Name = "btnSelect3";
            btnSelect3.Size = new Size(55, 23);
            btnSelect3.TabIndex = 22;
            btnSelect3.Text = "Select";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(48, 212);
            label16.Name = "label16";
            label16.Size = new Size(38, 15);
            label16.TabIndex = 51;
            label16.Text = "Gold :";
            // 
            // btnSelect2
            // 
            btnSelect2.Location = new Point(507, 238);
            btnSelect2.Name = "btnSelect2";
            btnSelect2.Size = new Size(55, 23);
            btnSelect2.TabIndex = 17;
            btnSelect2.Text = "Select";
            // 
            // cmbExpiry
            // 
            cmbExpiry.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbExpiry.Items.AddRange(new object[] { "3", "7", "15", "30", "180", "365" });
            cmbExpiry.Location = new Point(92, 180);
            cmbExpiry.Name = "cmbExpiry";
            cmbExpiry.Size = new Size(200, 23);
            cmbExpiry.TabIndex = 9;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(297, 327);
            label11.Name = "label11";
            label11.Size = new Size(59, 15);
            label11.TabIndex = 45;
            label11.Text = "Quantity :";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(310, 184);
            label6.Name = "label6";
            label6.Size = new Size(46, 15);
            label6.TabIndex = 40;
            label6.Text = "Item 1 :";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(60, 241);
            label12.Name = "label12";
            label12.Size = new Size(26, 15);
            label12.TabIndex = 46;
            label12.Text = "EP :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(7, 183);
            label5.Name = "label5";
            label5.Size = new Size(79, 15);
            label5.TabIndex = 39;
            label5.Text = "Expiry (days) :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(50, 39);
            label2.Name = "label2";
            label2.Size = new Size(36, 15);
            label2.TabIndex = 36;
            label2.Text = "Title :";
            // 
            // chkGift3
            // 
            chkGift3.Location = new Point(512, 326);
            chkGift3.Name = "chkGift3";
            chkGift3.Size = new Size(50, 23);
            chkGift3.TabIndex = 24;
            chkGift3.Text = "Gift";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(22, 328);
            label15.Name = "label15";
            label15.Size = new Size(64, 15);
            label15.TabIndex = 49;
            label15.Text = "Star Point :";
            // 
            // chkGift1
            // 
            chkGift1.Location = new Point(512, 209);
            chkGift1.Name = "chkGift1";
            chkGift1.Size = new Size(50, 23);
            chkGift1.TabIndex = 14;
            chkGift1.Text = "Gift";
            // 
            // btnSelect1
            // 
            btnSelect1.Location = new Point(507, 180);
            btnSelect1.Name = "btnSelect1";
            btnSelect1.Size = new Size(55, 23);
            btnSelect1.TabIndex = 12;
            btnSelect1.Text = "Select";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(59, 270);
            label13.Name = "label13";
            label13.Size = new Size(27, 15);
            label13.TabIndex = 47;
            label13.Text = "PP :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(27, 97);
            label4.Name = "label4";
            label4.Size = new Size(59, 15);
            label4.TabIndex = 38;
            label4.Text = "Message :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(37, 68);
            label3.Name = "label3";
            label3.Size = new Size(49, 15);
            label3.TabIndex = 37;
            label3.Text = "Sender :";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(12, 299);
            label14.Name = "label14";
            label14.Size = new Size(74, 15);
            label14.TabIndex = 48;
            label14.Text = "Lunar Point :";
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(btnFindid);
            tabPage1.Controls.Add(txtUserId);
            tabPage1.Controls.Add(label10);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(label8);
            tabPage1.Controls.Add(txtSender);
            tabPage1.Controls.Add(btnSendPersonal);
            tabPage1.Controls.Add(label14);
            tabPage1.Controls.Add(btnSendAll);
            tabPage1.Controls.Add(txtItem3);
            tabPage1.Controls.Add(label7);
            tabPage1.Controls.Add(label9);
            tabPage1.Controls.Add(txtQty2);
            tabPage1.Controls.Add(btnSelect3);
            tabPage1.Controls.Add(label13);
            tabPage1.Controls.Add(btnTemplt);
            tabPage1.Controls.Add(txtTitle);
            tabPage1.Controls.Add(label16);
            tabPage1.Controls.Add(btnSelect1);
            tabPage1.Controls.Add(chkGift2);
            tabPage1.Controls.Add(txtBody);
            tabPage1.Controls.Add(btnSelect2);
            tabPage1.Controls.Add(chkGift1);
            tabPage1.Controls.Add(txtQty1);
            tabPage1.Controls.Add(txtStarstone);
            tabPage1.Controls.Add(cmbExpiry);
            tabPage1.Controls.Add(label15);
            tabPage1.Controls.Add(txtEP);
            tabPage1.Controls.Add(txtQty3);
            tabPage1.Controls.Add(label11);
            tabPage1.Controls.Add(chkGift3);
            tabPage1.Controls.Add(txtPP);
            tabPage1.Controls.Add(txtgold);
            tabPage1.Controls.Add(label6);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(txtMoonstone);
            tabPage1.Controls.Add(txtItem2);
            tabPage1.Controls.Add(label12);
            tabPage1.Controls.Add(label5);
            tabPage1.Controls.Add(txtItem1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(581, 374);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Main Setting";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(1, 2);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(589, 402);
            tabControl1.TabIndex = 54;
            // 
            // Form1
            // 
            ClientSize = new Size(591, 404);
            Controls.Add(tabControl1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Mail Sender By DuaSelipar";
            tabPage2.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabControl1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private TabPage tabPage2;
        private Label label1;
        private TextBox txtUserId;
        private TextBox txtSender;
        private TextBox txtItem3;
        private TextBox txtQty2;
        private TextBox txtTitle;
        private TextBox txtBody;
        private TextBox txtStarstone;
        private TextBox txtQty3;
        private TextBox txtgold;
        private TextBox txtItem2;
        private TextBox txtItem1;
        private TextBox txtMoonstone;
        private TextBox txtPP;
        private TextBox txtEP;
        private TextBox txtQty1;
        private CheckBox chkGift2;
        private Button btnTemplt;
        private Label label9;
        private Button btnSendAll;
        private Label label8;
        private Button btnFindid;
        private Label label10;
        private Button btnSendPersonal;
        private Label label7;
        private Button btnSelect3;
        private Label label16;
        private Button btnSelect2;
        private ComboBox cmbExpiry;
        private Label label11;
        private Label label6;
        private Label label12;
        private Label label5;
        private Label label2;
        private CheckBox chkGift3;
        private Label label15;
        private CheckBox chkGift1;
        private Button btnSelect1;
        private Label label13;
        private Label label4;
        private Label label3;
        private Label label14;
        private TabPage tabPage1;
        private TabControl tabControl1;
        private RichTextBox richTextBox1;
    }
}
