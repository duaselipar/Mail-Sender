using System;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Microsoft.Extensions.Configuration;

namespace mailsender
{
    public partial class Form1 : Form
    {
        private string dbHost = "";
        private string dbPort = "";
        private string dbUser = "";
        private string dbPassword = "";
        private string dbName = "";
        private string mailMapping = "";
        private string connectionString = "";

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;

            btnSelect1.Click += btnSelect1_Click!;
            btnSelect2.Click += btnSelect2_Click!;
            btnSelect3.Click += btnSelect3_Click!;
            btnSendAll.Click += btnSendAll_Click!;
            btnTemplt.Click += btnTemplt_Click!;
        }

        private void Form1_Load(object? sender, EventArgs e)
        {
            // Step 1: Cuba load config
            try
            {
                LoadConfig();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load MySQL config: " + ex.Message, "Config Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return;
            }

            // Step 2: Cuba test connection
            if (!TestMySqlConnection())
            {
                MessageBox.Show(
                    "Failed to connect to MySQL database!\n\n" +
                    "Please check your config.txt (host/user/password/db).\n\n" +
                    "Connection string: " + connectionString,
                    "MySQL Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                Application.Exit();
                return;
            }

            txtTitle.Text = "Reward";

            txtSender.Text = "DuaSelipar";

            txtBody.Text = "Congratulations! You have received a reward!";

            if (cmbExpiry.Items.Count > 0)
                cmbExpiry.SelectedIndex = 0;

            // Step 3: Set default value untuk item/quantity/gift checkbox
            txtItem1.Text = "0";
            txtQty1.Text = "1";
            chkGift1.Checked = false;

            txtItem2.Text = "0";
            txtQty2.Text = "1";
            chkGift2.Checked = false;

            txtItem3.Text = "0";
            txtQty3.Text = "1";
            chkGift3.Checked = false;

            // Step 4: Set default value untuk gold, EP, PP, moonstone, starstone
            txtgold.Text = "0";         // gold/money
            txtEP.Text = "0";           // emoney
            txtPP.Text = "0";           // emoney2
            txtMoonstone.Text = "0";
            txtStarstone.Text = "0";
        }

        private bool TestMySqlConnection()
        {
            try
            {
                using (var con = new MySqlConnection(connectionString))
                {
                    con.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        private void LoadConfig()
        {
            string configFile = "config.ini";
            if (!File.Exists(configFile))
            {
                File.WriteAllLines(configFile, new[]
                {
            "[database]",
            "host=localhost",
            "port=3306",
            "user=root",
            "password=",
            "database="
        });
                throw new Exception("config.ini generated. Please fill in your MySQL info and restart this app.");
            }

            // Pakai Microsoft.Extensions.Configuration
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddIniFile(configFile, optional: false, reloadOnChange: true);

            var config = builder.Build();

            dbHost = config["database:host"] ?? "localhost";
            dbPort = config["database:port"] ?? "3306";
            dbUser = config["database:user"] ?? "";
            dbPassword = config["database:password"] ?? "";
            dbName = config["database:database"] ?? "";

            mailMapping = dbName.ToUpper();
            connectionString = $"server={dbHost};port={dbPort};user={dbUser};password={dbPassword};database={dbName};SslMode=none;AllowPublicKeyRetrieval=true;";
        }

        // P/Invoke API untuk File Mapping
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr OpenFileMapping(uint dwDesiredAccess, bool bInheritHandle, string lpName);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr MapViewOfFile(IntPtr hFileMappingObject, uint dwDesiredAccess, uint dwFileOffsetHigh, uint dwFileOffsetLow, UIntPtr dwNumberOfBytesToMap);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool UnmapViewOfFile(IntPtr lpBaseAddress);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool CloseHandle(IntPtr hObject);

        const uint FILE_MAP_ALL_ACCESS = 0xF001F;

        private bool TriggerMail(int userId)
        {
            IntPtr hMap = OpenFileMapping(FILE_MAP_ALL_ACCESS, false, "Global\\" + mailMapping);
            if (hMap == IntPtr.Zero)
            {
                hMap = OpenFileMapping(FILE_MAP_ALL_ACCESS, false, mailMapping);
                if (hMap == IntPtr.Zero)
                    return false;
            }

            IntPtr ptr = MapViewOfFile(hMap, FILE_MAP_ALL_ACCESS, 0, 0, (UIntPtr)64);
            if (ptr == IntPtr.Zero)
            {
                CloseHandle(hMap);
                return false;
            }

            Marshal.WriteInt32(ptr, 4, userId);

            UnmapViewOfFile(ptr);
            CloseHandle(hMap);
            return true;
        }

        private void btnSendPersonal_Click(object sender, EventArgs e)
        {
            string userId = txtUserId.Text.Trim();
            string title = txtTitle.Text.Trim();
            string senderName = txtSender.Text.Trim();
            string body = txtBody.Text.Trim();

            string moonstone = txtMoonstone.Text.Trim();
            string starstone = txtStarstone.Text.Trim();
            string gold = txtgold.Text.Trim();     // Untuk money
            string ep = txtEP.Text.Trim();         // Untuk emoney
            string pp = txtPP.Text.Trim();         // Untuk emoney2

            string item1 = txtItem1.Text.Trim();
            string item1Amount = txtQty1.Text.Trim();
            string item1Lock = chkGift1.Checked ? "1" : "0";

            string item2 = txtItem2.Text.Trim();
            string item2Amount = txtQty2.Text.Trim();
            string item2Lock = chkGift2.Checked ? "1" : "0";

            string item3 = txtItem3.Text.Trim();
            string item3Amount = txtQty3.Text.Trim();
            string item3Lock = chkGift3.Checked ? "1" : "0";

            int expiryDays = int.TryParse(cmbExpiry.SelectedItem?.ToString(), out var exp) ? exp : 7;

            if (userId == "" || title == "" || senderName == "" || body == "")
            {
                MessageBox.Show("Please fill in all required fields (User ID, Title, Sender, Body).", "Missing Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (title.Length > 16)
            {
                MessageBox.Show("Title max 16 characters.", "Too Long", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (senderName.Length > 31)
            {
                MessageBox.Show("Sender max 31 characters.", "Too Long", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (body.Length > 250)
            {
                MessageBox.Show("Body max 250 characters.", "Too Long", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ===== VALIDATION SECTION =====
            if (!UserIdExists(userId))
            {
                MessageBox.Show("User ID does not exist in the database!", "Invalid User", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!ItemIdExists(item1))
            {
                MessageBox.Show("Item 1 ID does not exist in the database!", "Invalid Item", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!ItemIdExists(item2))
            {
                MessageBox.Show("Item 2 ID does not exist in the database!", "Invalid Item", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!ItemIdExists(item3))
            {
                MessageBox.Show("Item 3 ID does not exist in the database!", "Invalid Item", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ===== END VALIDATION =====

            long sendTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            int saveDay = expiryDays;
            long endTime = sendTime + (expiryDays * 86400);

            string sql = @"
                INSERT INTO cq_mailinfo 
                (userid, sendtime, saveday, endtime, title, memo, FromName, used, moonvalue, starvalue,
                 money, emoney, emoney2,
                 item1, item1Amount, item1Lock,
                 item2, item2Amount, item2Lock,
                 item3, item3Amount, item3Lock
                ) VALUES (
                 @userId, @sendTime, @saveDay, @endTime, @title, @body, @senderName, 0, @moonstone, @starstone,
                 @money, @emoney, @emoney2,
                 @item1, @item1Amount, @item1Lock,
                 @item2, @item2Amount, @item2Lock,
                 @item3, @item3Amount, @item3Lock
                )
            ";

            try
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@userId", userId);
                        cmd.Parameters.AddWithValue("@sendTime", sendTime);
                        cmd.Parameters.AddWithValue("@saveDay", saveDay);
                        cmd.Parameters.AddWithValue("@endTime", endTime);
                        cmd.Parameters.AddWithValue("@title", title);
                        cmd.Parameters.AddWithValue("@body", body.Replace("\n", "\\n"));
                        cmd.Parameters.AddWithValue("@senderName", senderName);
                        cmd.Parameters.AddWithValue("@moonstone", moonstone);
                        cmd.Parameters.AddWithValue("@starstone", starstone);
                        cmd.Parameters.AddWithValue("@money", gold);
                        cmd.Parameters.AddWithValue("@emoney", ep);
                        cmd.Parameters.AddWithValue("@emoney2", pp);

                        cmd.Parameters.AddWithValue("@item1", item1);
                        cmd.Parameters.AddWithValue("@item1Amount", item1Amount);
                        cmd.Parameters.AddWithValue("@item1Lock", item1Lock);

                        cmd.Parameters.AddWithValue("@item2", item2);
                        cmd.Parameters.AddWithValue("@item2Amount", item2Amount);
                        cmd.Parameters.AddWithValue("@item2Lock", item2Lock);

                        cmd.Parameters.AddWithValue("@item3", item3);
                        cmd.Parameters.AddWithValue("@item3Amount", item3Amount);
                        cmd.Parameters.AddWithValue("@item3Lock", item3Lock);

                        int result = cmd.ExecuteNonQuery();

                        // Trigger instant delivery (memory mapping)
                        bool instantOk = false;
                        if (int.TryParse(userId, out int intUid))
                        {
                            instantOk = TriggerMail(intUid);
                        }

                        if (instantOk)
                            MessageBox.Show("Mail sent INSTANT! Player receives mail immediately.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("Mail sent, but player may need to relog to receive (server not running or mapping name mismatch).", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("DB error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public class UserSearchForm : Form
        {
            public string SelectedId { get; private set; } = string.Empty;

            private DataGridView grid;
            private TextBox txtSearch;
            private BindingSource binding = new BindingSource();
            private List<(string id, string name, string money, string emoney, string emoney2, string moon, string star)> allUsers;

            public UserSearchForm(List<(string id, string name, string money, string emoney, string emoney2, string moon, string star)> users)
            {
                allUsers = users;
                Text = "Search User";
                Size = new Size(800, 400);
                this.StartPosition = FormStartPosition.CenterScreen;

                grid = new DataGridView
                {
                    Dock = DockStyle.Fill,
                    ReadOnly = true,
                    SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                    AutoGenerateColumns = false,
                    AllowUserToAddRows = false,
                    AllowUserToResizeRows = false,
                    AllowUserToResizeColumns = false,
                    RowHeadersVisible = false,
                    AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                    ScrollBars = ScrollBars.Vertical
                };

                grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "id", HeaderText = "User ID", FillWeight = 15 });
                grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "name", HeaderText = "User Name", FillWeight = 25 });
                grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "money", HeaderText = "Gold", FillWeight = 10 });
                grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "emoney", HeaderText = "EP", FillWeight = 10 });
                grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "emoney2", HeaderText = "PP", FillWeight = 10 });
                grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "moon", HeaderText = "Lunar Point", FillWeight = 15 });
                grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "star", HeaderText = "Star Point", FillWeight = 15 });

                grid.DoubleClick += Grid_DoubleClick;

                txtSearch = new TextBox { Dock = DockStyle.Top, PlaceholderText = "Type name or id to filter..." };
                txtSearch.TextChanged += TxtSearch_TextChanged;

                Controls.Add(grid);
                Controls.Add(txtSearch);

                binding.DataSource = allUsers.Select(u => new
                {
                    u.id,
                    u.name,
                    u.money,
                    u.emoney,
                    u.emoney2,
                    moon = u.moon,
                    star = u.star
                }).ToList();
                grid.DataSource = binding;
            }

            private void TxtSearch_TextChanged(object? sender, EventArgs e)
            {
                var q = txtSearch.Text.Trim().ToLower();
                var filtered = allUsers
                    .Where(u =>
                        u.id.Contains(q) ||
                        u.name.ToLower().Contains(q) ||
                        u.money.Contains(q) ||
                        u.emoney.Contains(q) ||
                        u.emoney2.Contains(q) ||
                        u.moon.Contains(q) ||
                        u.star.Contains(q))
                    .Select(u => new { u.id, u.name, u.money, u.emoney, u.emoney2, moon = u.moon, star = u.star })
                    .ToList();
                binding.DataSource = filtered;
            }

            private void Grid_DoubleClick(object? sender, EventArgs e)
            {
                if (grid.SelectedRows.Count > 0 && grid.SelectedRows[0].Cells[0].Value != null)
                {
                    SelectedId = grid.SelectedRows[0].Cells[0].Value?.ToString() ?? string.Empty;
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }



        private void btnFindid_Click(object sender, EventArgs e)
        {
            // Update tuple: id, name, money, emoney, emoney2, moon, star
            var users = new List<(string id, string name, string money, string emoney, string emoney2, string moon, string star)>();
            try
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand("SELECT id, name, money, emoney, emoney2, godfiremoonvalue, godfirestarvalue FROM cq_user_new", conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            users.Add((
                                reader["id"]?.ToString() ?? string.Empty,
                                reader["name"]?.ToString() ?? string.Empty,
                                reader["money"]?.ToString() ?? string.Empty,
                                reader["emoney"]?.ToString() ?? string.Empty,
                                reader["emoney2"]?.ToString() ?? string.Empty,
                                reader["godfiremoonvalue"]?.ToString() ?? string.Empty,
                                reader["godfirestarvalue"]?.ToString() ?? string.Empty
                            ));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading users: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var searchForm = new UserSearchForm(users))
            {
                if (searchForm.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(searchForm.SelectedId))
                {
                    txtUserId.Text = searchForm.SelectedId;
                }
            }
        }





        private void btnSelect1_Click(object sender, EventArgs e)
        {
            var items = new List<(string id, string name, string price, string emoney, string id_action)>();
            try
            {
                using (var con = new MySqlConnection(connectionString))
                {
                    con.Open();
                    using (var cmd = new MySqlCommand("SELECT id, name, price, emoney, id_action FROM cq_itemtype", con))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string id = reader.GetUInt32(0).ToString();
                            string name = reader.GetString(1);
                            string price = reader["price"]?.ToString() ?? string.Empty;
                            string emoney = reader["emoney"]?.ToString() ?? string.Empty;
                            string id_action = reader["id_action"]?.ToString() ?? string.Empty;
                            items.Add((id, name, price, emoney, id_action));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load item list: " + ex.Message, "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            // Popup form sama macam UserSearchForm
            using (var f = new ItemSearchForm(items))
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    txtItem1.Text = f.SelectedId;
                }
            }
        }

        private void btnSelect2_Click(object sender, EventArgs e)
        {
            var items = new List<(string id, string name, string price, string emoney, string id_action)>();
            try
            {
                using (var con = new MySqlConnection(connectionString))
                {
                    con.Open();
                    using (var cmd = new MySqlCommand("SELECT id, name, price, emoney, id_action FROM cq_itemtype", con))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string id = reader.GetUInt32(0).ToString();
                            string name = reader.GetString(1);
                            string price = reader["price"]?.ToString() ?? string.Empty;
                            string emoney = reader["emoney"]?.ToString() ?? string.Empty;
                            string id_action = reader["id_action"]?.ToString() ?? string.Empty;
                            items.Add((id, name, price, emoney, id_action));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load item list: " + ex.Message, "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            // Popup form sama macam UserSearchForm
            using (var f = new ItemSearchForm(items))
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    txtItem2.Text = f.SelectedId;
                }
            }
        }

        private void btnSelect3_Click(object sender, EventArgs e)
        {
            var items = new List<(string id, string name, string price, string emoney, string id_action)>();
            try
            {
                using (var con = new MySqlConnection(connectionString))
                {
                    con.Open();
                    using (var cmd = new MySqlCommand("SELECT id, name, price, emoney, id_action FROM cq_itemtype", con))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string id = reader.GetUInt32(0).ToString();
                            string name = reader.GetString(1);
                            string price = reader["price"]?.ToString() ?? string.Empty;
                            string emoney = reader["emoney"]?.ToString() ?? string.Empty;
                            string id_action = reader["id_action"]?.ToString() ?? string.Empty;
                            items.Add((id, name, price, emoney, id_action));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load item list: " + ex.Message, "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            // Popup form sama macam UserSearchForm
            using (var f = new ItemSearchForm(items))
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    txtItem3.Text = f.SelectedId;
                }
            }
        }


        public class ItemSearchForm : Form
        {
            public string SelectedId { get; private set; } = "";

            private DataGridView grid;
            private TextBox txtSearch;
            private BindingSource binding = new BindingSource();
            private List<(string id, string name, string price, string emoney, string id_action)> allItems;

            public ItemSearchForm(List<(string id, string name, string price, string emoney, string id_action)> items)
            {
                allItems = items;
                Text = "Search Item";
                Size = new Size(700, 400);
                this.StartPosition = FormStartPosition.CenterScreen;

                grid = new DataGridView
                {
                    Dock = DockStyle.Fill,
                    ReadOnly = true,
                    SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                    AutoGenerateColumns = false,
                    AllowUserToAddRows = false,
                    AllowUserToResizeRows = false,
                    AllowUserToResizeColumns = false,
                    RowHeadersVisible = false,
                    AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                    ScrollBars = ScrollBars.Vertical
                };

                grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "id", HeaderText = "Item ID", FillWeight = 20, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
                grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "name", HeaderText = "Item Name", FillWeight = 30, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
                grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "price", HeaderText = "Gold", FillWeight = 15, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
                grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "emoney", HeaderText = "EP", FillWeight = 15, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
                grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "id_action", HeaderText = "Action ID", FillWeight = 20, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });

                grid.DoubleClick += Grid_DoubleClick;

                txtSearch = new TextBox { Dock = DockStyle.Top, PlaceholderText = "Type ID, Name, Gold, EP, or Action..." };
                txtSearch.TextChanged += TxtSearch_TextChanged;

                // Tambah grid dulu, search bar last (supaya sentiasa paling atas)
                Controls.Add(grid);
                Controls.Add(txtSearch);

                binding.DataSource = allItems.Select(u => new { u.id, u.name, u.price, u.emoney, u.id_action }).ToList();
                grid.DataSource = binding;
            }


            // Bila user type kat search, filter semua kolum
            private void TxtSearch_TextChanged(object? sender, EventArgs e)
            {
                string q = txtSearch.Text.ToLower();
                binding.DataSource = allItems
                    .Where(u =>
                        u.id.Contains(q)
                        || u.name.ToLower().Contains(q)
                        || u.price.Contains(q)
                        || u.emoney.Contains(q)
                        || u.id_action.Contains(q)
                    )
                    .Select(u => new { u.id, u.name, u.price, u.emoney, u.id_action })
                    .ToList();
            }

            // Bila double click row, ambil ID
            private void Grid_DoubleClick(object? sender, EventArgs e)
            {
                if (grid.SelectedRows.Count > 0 && grid.SelectedRows[0].Cells[0].Value != null)
                {
                    SelectedId = grid.SelectedRows[0].Cells[0].Value?.ToString() ?? string.Empty;
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }







        private void btnSendAll_Click(object sender, EventArgs e)
        {
            // --- 1. Popup range level dulu ---
            int minLevel = 1, maxLevel = 255;
            using (var dlg = new LevelRangeDialog())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    minLevel = dlg.MinLevel ?? 1;
                    maxLevel = dlg.MaxLevel ?? 255;
                }
                else
                {
                    // User tekan Cancel
                    return;
                }
            }

            // --- 2. Fetch users ikut level range ---
            List<string> userIds = new List<string>();
            try
            {
                using (var con = new MySqlConnection(connectionString))
                {
                    con.Open();
                    string query = "SELECT id FROM cq_user_new WHERE level >= @minLevel AND level <= @maxLevel";
                    using (var cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@minLevel", minLevel);
                        cmd.Parameters.AddWithValue("@maxLevel", maxLevel);
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                                userIds.Add(reader.GetUInt32(0).ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to get user list: " + ex.Message, "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // --- 3. Proceed as normal (ambil data dari textbox) ---
            string title = txtTitle.Text.Trim();
            string senderName = txtSender.Text.Trim();
            string body = txtBody.Text.Trim();
            string moonstone = txtMoonstone.Text.Trim();
            string starstone = txtStarstone.Text.Trim();
            string gold = txtgold.Text.Trim();
            string ep = txtEP.Text.Trim();
            string pp = txtPP.Text.Trim();

            string item1 = txtItem1.Text.Trim();
            string qty1 = txtQty1.Text.Trim();
            string item1Lock = chkGift1.Checked ? "1" : "0";

            string item2 = txtItem2.Text.Trim();
            string qty2 = txtQty2.Text.Trim();
            string item2Lock = chkGift2.Checked ? "1" : "0";

            string item3 = txtItem3.Text.Trim();
            string qty3 = txtQty3.Text.Trim();
            string item3Lock = chkGift3.Checked ? "1" : "0";

            int expiryDays = int.TryParse(cmbExpiry.SelectedItem?.ToString(), out var exp) ? exp : 7;

            long sendTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            int saveDay = expiryDays;
            long endTime = sendTime + (expiryDays * 86400);

            // Confirm dulu (sbb boleh jadi ramai user)
            if (userIds.Count == 0)
            {
                MessageBox.Show("No users found in selected level range.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show($"Are you sure you want to send this reward to {userIds.Count} players (Level {minLevel}-{maxLevel})?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            // Hantar satu-satu
            int success = 0, failed = 0;
            foreach (var userId in userIds)
            {
                try
                {
                    using (var con = new MySqlConnection(connectionString))
                    {
                        con.Open();
                        string sql = @"
INSERT INTO cq_mailinfo 
(userid, sendtime, saveday, endtime, title, memo, FromName, used, moonvalue, starvalue, 
money, emoney, emoney2, 
item1, item1Amount, item1Lock,
item2, item2Amount, item2Lock,
item3, item3Amount, item3Lock
) VALUES (
@userId, @sendTime, @saveDay, @endTime, @title, @body, @senderName, 0, @moonstone, @starstone, 
@money, @emoney, @emoney2, 
@item1, @item1Amount, @item1Lock,
@item2, @item2Amount, @item2Lock,
@item3, @item3Amount, @item3Lock
)";
                        using (var cmd = new MySqlCommand(sql, con))
                        {
                            cmd.Parameters.AddWithValue("@userId", userId);
                            cmd.Parameters.AddWithValue("@sendTime", sendTime);
                            cmd.Parameters.AddWithValue("@saveDay", saveDay);
                            cmd.Parameters.AddWithValue("@endTime", endTime);
                            cmd.Parameters.AddWithValue("@title", title);
                            cmd.Parameters.AddWithValue("@body", body.Replace("\n", "\\n"));
                            cmd.Parameters.AddWithValue("@senderName", senderName);
                            cmd.Parameters.AddWithValue("@moonstone", moonstone);
                            cmd.Parameters.AddWithValue("@starstone", starstone);
                            cmd.Parameters.AddWithValue("@money", gold);
                            cmd.Parameters.AddWithValue("@emoney", ep);
                            cmd.Parameters.AddWithValue("@emoney2", pp);
                            cmd.Parameters.AddWithValue("@item1", item1);
                            cmd.Parameters.AddWithValue("@item1Amount", qty1);
                            cmd.Parameters.AddWithValue("@item1Lock", item1Lock);
                            cmd.Parameters.AddWithValue("@item2", item2);
                            cmd.Parameters.AddWithValue("@item2Amount", qty2);
                            cmd.Parameters.AddWithValue("@item2Lock", item2Lock);
                            cmd.Parameters.AddWithValue("@item3", item3);
                            cmd.Parameters.AddWithValue("@item3Amount", qty3);
                            cmd.Parameters.AddWithValue("@item3Lock", item3Lock);

                            int result = cmd.ExecuteNonQuery();
                            if (result > 0)
                                success++;
                            else
                                failed++;
                        }
                    }
                }
                catch
                {
                    failed++;
                }
            }

            MessageBox.Show($"Mail sent to {success} players (Level {minLevel}-{maxLevel}).\nFailed: {failed}", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }





        private void btnTemplt_Click(object sender, EventArgs e)
        {
            var templates = new List<(string title, string memo, string sender)>();
            try
            {
                using (var con = new MySqlConnection(connectionString))
                {
                    con.Open();
                    using (var cmd = new MySqlCommand("SELECT title, memo, FromName FROM cq_mailtemplate", con))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            templates.Add((
                                reader["title"]?.ToString() ?? string.Empty,
                                reader["memo"]?.ToString() ?? string.Empty,
                                reader["FromName"]?.ToString() ?? string.Empty
                            ));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load templates: " + ex.Message, "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var f = new TemplateSelectForm(templates, connectionString))
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    txtTitle.Text = f.SelectedTitle;
                    txtBody.Text = f.SelectedMemo;
                    txtSender.Text = f.SelectedSender;
                }
            }

        }




        public class TemplateSelectForm : Form
        {
            public string SelectedTitle { get; private set; } = "";
            public string SelectedMemo { get; private set; } = "";
            public string SelectedSender { get; private set; } = "";

            private DataGridView grid;
            private TextBox txtSearch;
            private BindingSource binding = new BindingSource();
            private List<(string title, string memo, string sender)> allTemplates;
            private string _connectionString;

            public TemplateSelectForm(List<(string title, string memo, string sender)> templates, string connectionString = "")
            {
                allTemplates = templates;
                _connectionString = connectionString;
                Text = "Select Mail Template";
                Size = new Size(700, 450);
                StartPosition = FormStartPosition.CenterScreen;

                var panel = new Panel { Dock = DockStyle.Fill };
                Controls.Add(panel);

                // Grid (paling bawah)
                grid = new DataGridView
                {
                    Dock = DockStyle.Fill,
                    ReadOnly = true,
                    SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                    AutoGenerateColumns = false,
                    AllowUserToAddRows = false,
                    AllowUserToResizeRows = false,
                    AllowUserToResizeColumns = false,
                    RowHeadersVisible = false,
                    AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                    ScrollBars = ScrollBars.Vertical
                };
                grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "title", HeaderText = "Title" });
                grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "memo", HeaderText = "Message" });
                grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "sender", HeaderText = "Sender" });
                grid.DoubleClick += Grid_DoubleClick;
                panel.Controls.Add(grid); // PALING BAWAH

                // Search bar (tengah)
                txtSearch = new TextBox { Dock = DockStyle.Top, PlaceholderText = "Type title or body..." };
                txtSearch.TextChanged += TxtSearch_TextChanged;
                panel.Controls.Add(txtSearch); // ATAS GRID

                // Create New button (paling atas)
                var btnCreateNew = new Button
                {
                    Text = "Create New Template",
                    Height = 32,
                    Dock = DockStyle.Top,
                    BackColor = Color.LightSkyBlue
                };
                btnCreateNew.Click += BtnCreateNew_Click!;
                panel.Controls.Add(btnCreateNew); // ATAS SEKALI

                LoadTemplates();
            }


            private void LoadTemplates()
            {
                // Reload allTemplates from DB if _connectionString is given
                if (!string.IsNullOrEmpty(_connectionString))
                {
                    allTemplates = new List<(string title, string memo, string sender)>();
                    try
                    {
                        using (var con = new MySqlConnection(_connectionString))
                        {
                            con.Open();
                            using (var cmd = new MySqlCommand("SELECT title, memo, FromName FROM cq_mailtemplate", con))
                            using (var reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    allTemplates.Add((
                                        reader["title"]?.ToString() ?? string.Empty,
                                        reader["memo"]?.ToString() ?? string.Empty,
                                        reader["FromName"]?.ToString() ?? string.Empty
                                    ));
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to load templates: " + ex.Message, "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                binding.DataSource = allTemplates.Select(t => new { t.title, t.memo, t.sender }).ToList();
                grid.DataSource = binding;
            }

            private void BtnCreateNew_Click(object sender, EventArgs e)
            {
                using (var f = new CreateMailTemplateForm(_connectionString))
                {
                    if (f.ShowDialog() == DialogResult.OK)
                    {
                        LoadTemplates(); // Refresh after new template added
                    }
                }
            }

            private void TxtSearch_TextChanged(object? sender, EventArgs e)
            {
                string q = txtSearch.Text.ToLower();
                binding.DataSource = allTemplates
                    .Where(t => t.title.ToLower().Contains(q) || t.memo.ToLower().Contains(q) || t.sender.ToLower().Contains(q))
                    .Select(t => new { t.title, t.memo, t.sender })
                    .ToList();
            }

            private void Grid_DoubleClick(object? sender, EventArgs e)
            {
                if (grid.SelectedRows.Count > 0 && grid.SelectedRows[0].Cells[0].Value != null)
                {
                    SelectedTitle = grid.SelectedRows[0].Cells[0].Value?.ToString() ?? string.Empty;
                    SelectedMemo = grid.SelectedRows[0].Cells[1].Value?.ToString() ?? string.Empty;
                    SelectedSender = grid.SelectedRows[0].Cells[2].Value?.ToString() ?? string.Empty;
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }




        public class CreateMailTemplateForm : Form
        {
            public CreateMailTemplateForm(string connectionString)
            {
                Text = "Create Mail Template";
                Size = new Size(400, 280);
                StartPosition = FormStartPosition.CenterParent;

                var lblTitle = new Label { Text = "Title", Top = 20, Left = 20, Width = 60 };
                var txtTitle = new TextBox { Top = 20, Left = 100, Width = 250, MaxLength = 32 };

                var lblSender = new Label { Text = "Sender", Top = 60, Left = 20, Width = 60 };
                var txtSender = new TextBox { Top = 60, Left = 100, Width = 250, MaxLength = 32 };

                var lblMemo = new Label { Text = "Message", Top = 100, Left = 20, Width = 60 };
                var txtMemo = new TextBox { Top = 100, Left = 100, Width = 250, Height = 80, Multiline = true };

                var btnSave = new Button { Text = "Save", Top = 200, Left = 100, Width = 100 };
                var btnCancel = new Button { Text = "Cancel", Top = 200, Left = 220, Width = 100 };
                btnCancel.Click += (s, e) => DialogResult = DialogResult.Cancel;

                btnSave.Click += (s, e) =>
                {
                    if (string.IsNullOrWhiteSpace(txtTitle.Text) || string.IsNullOrWhiteSpace(txtSender.Text) || string.IsNullOrWhiteSpace(txtMemo.Text))
                    {
                        MessageBox.Show("All fields required.");
                        return;
                    }
                    try
                    {
                        using (var con = new MySqlConnection(connectionString))
                        {
                            con.Open();
                            string sql = "INSERT INTO cq_mailtemplate (title, memo, FromName) VALUES (@title, @memo, @sender)";
                            using (var cmd = new MySqlCommand(sql, con))
                            {
                                cmd.Parameters.AddWithValue("@title", txtTitle.Text.Trim());
                                cmd.Parameters.AddWithValue("@memo", txtMemo.Text.Trim());
                                cmd.Parameters.AddWithValue("@sender", txtSender.Text.Trim());
                                cmd.ExecuteNonQuery();
                            }
                        }
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("DB error: " + ex.Message);
                    }
                };

                Controls.Add(lblTitle); Controls.Add(txtTitle);
                Controls.Add(lblSender); Controls.Add(txtSender);
                Controls.Add(lblMemo); Controls.Add(txtMemo);
                Controls.Add(btnSave); Controls.Add(btnCancel);
            }
        }








        private void OnlyNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }




        private bool UserIdExists(string userId)
        {
            using (var con = new MySqlConnection(connectionString))
            {
                con.Open();
                using (var cmd = new MySqlCommand("SELECT COUNT(*) FROM cq_user_new WHERE id = @id", con))
                {
                    cmd.Parameters.AddWithValue("@id", userId);
                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
        }

        private bool ItemIdExists(string itemId)
        {
            if (itemId == "0" || string.IsNullOrEmpty(itemId)) return true; // 0 = tak guna item
            using (var con = new MySqlConnection(connectionString))
            {
                con.Open();
                using (var cmd = new MySqlCommand("SELECT COUNT(*) FROM cq_itemtype WHERE id = @id", con))
                {
                    cmd.Parameters.AddWithValue("@id", itemId);
                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
        }








        public class LevelRangeDialog : Form
        {
            public int? MinLevel { get; private set; }
            public int? MaxLevel { get; private set; }

            private NumericUpDown numMin;
            private NumericUpDown numMax;

            public LevelRangeDialog()
            {
                Text = "Set Level Range (Optional)";
                Size = new Size(350, 170);
                StartPosition = FormStartPosition.CenterParent;

                var lblMin = new Label { Text = "Min Level:", Left = 25, Top = 20, Width = 80 };
                numMin = new NumericUpDown { Left = 110, Top = 20, Width = 80, Minimum = 1, Maximum = 255, Value = 1 };
                var lblMax = new Label { Text = "Max Level:", Left = 25, Top = 60, Width = 80 };
                numMax = new NumericUpDown { Left = 110, Top = 60, Width = 80, Minimum = 1, Maximum = 255, Value = 255 };

                var btnOk = new Button { Text = "OK", Left = 75, Top = 100, Width = 80, DialogResult = DialogResult.OK };
                var btnCancel = new Button { Text = "Cancel", Left = 175, Top = 100, Width = 80, DialogResult = DialogResult.Cancel };

                btnOk.Click += (s, e) =>
                {
                    MinLevel = (int)numMin.Value;
                    MaxLevel = (int)numMax.Value;
                    if (MinLevel > MaxLevel)
                    {
                        MessageBox.Show("Min level must be less than or equal to Max level.");
                        DialogResult = DialogResult.None;
                    }
                };

                Controls.Add(lblMin); Controls.Add(numMin);
                Controls.Add(lblMax); Controls.Add(numMax);
                Controls.Add(btnOk); Controls.Add(btnCancel);
            }
        }

        private void toolStripButtonAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Mailsender v1.0\nCreated by nLKicsTA", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }



}
