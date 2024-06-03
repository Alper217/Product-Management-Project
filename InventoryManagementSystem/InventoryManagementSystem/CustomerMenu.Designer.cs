namespace InventoryManagementSystem
{
    partial class CustomerMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerMenu));
            this.pnlProducts = new System.Windows.Forms.Panel();
            this.btnSelectOptions = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.lblSelectedP = new System.Windows.Forms.Label();
            this.btnAddCart = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBMax = new System.Windows.Forms.TextBox();
            this.txtBMin = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBSearchName = new System.Windows.Forms.TextBox();
            this.dgvSeeProducts = new System.Windows.Forms.DataGridView();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.pnlMyShoppingCart = new System.Windows.Forms.Panel();
            this.btnBuy = new System.Windows.Forms.Button();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.btnBackTwo = new System.Windows.Forms.Button();
            this.dgvMHC = new System.Windows.Forms.DataGridView();
            this.dgvMO = new System.Windows.Forms.DataGridView();
            this.btnBack2 = new System.Windows.Forms.Button();
            this.pnlMO = new System.Windows.Forms.Panel();
            this.txtBID = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlUS = new System.Windows.Forms.Panel();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnUserSettings = new System.Windows.Forms.Button();
            this.btnMyOrders = new System.Windows.Forms.Button();
            this.btnMySCart = new System.Windows.Forms.Button();
            this.btnSearchProducts = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtBSelected = new System.Windows.Forms.TextBox();
            this.pnlProducts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeeProducts)).BeginInit();
            this.pnlMyShoppingCart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMHC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMO)).BeginInit();
            this.pnlMO.SuspendLayout();
            this.pnlUS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlProducts
            // 
            this.pnlProducts.Controls.Add(this.btnSelectOptions);
            this.pnlProducts.Controls.Add(this.btnBack);
            this.pnlProducts.Controls.Add(this.lblSelectedP);
            this.pnlProducts.Controls.Add(this.btnAddCart);
            this.pnlProducts.Controls.Add(this.label4);
            this.pnlProducts.Controls.Add(this.label3);
            this.pnlProducts.Controls.Add(this.label2);
            this.pnlProducts.Controls.Add(this.txtBMax);
            this.pnlProducts.Controls.Add(this.txtBMin);
            this.pnlProducts.Controls.Add(this.label1);
            this.pnlProducts.Controls.Add(this.txtBSearchName);
            this.pnlProducts.Controls.Add(this.dgvSeeProducts);
            this.pnlProducts.Location = new System.Drawing.Point(265, -1);
            this.pnlProducts.Name = "pnlProducts";
            this.pnlProducts.Size = new System.Drawing.Size(685, 539);
            this.pnlProducts.TabIndex = 4;
            this.pnlProducts.Visible = false;
            // 
            // btnSelectOptions
            // 
            this.btnSelectOptions.Location = new System.Drawing.Point(16, 298);
            this.btnSelectOptions.Name = "btnSelectOptions";
            this.btnSelectOptions.Size = new System.Drawing.Size(156, 28);
            this.btnSelectOptions.TabIndex = 10;
            this.btnSelectOptions.Text = "Select";
            this.btnSelectOptions.UseVisualStyleBackColor = true;
            this.btnSelectOptions.Click += new System.EventHandler(this.btnSelectOptions_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(3, 3);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(83, 33);
            this.btnBack.TabIndex = 5;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lblSelectedP
            // 
            this.lblSelectedP.AutoSize = true;
            this.lblSelectedP.Location = new System.Drawing.Point(48, 429);
            this.lblSelectedP.Name = "lblSelectedP";
            this.lblSelectedP.Size = new System.Drawing.Size(91, 13);
            this.lblSelectedP.TabIndex = 9;
            this.lblSelectedP.Text = "No Stuff Selected";
            // 
            // btnAddCart
            // 
            this.btnAddCart.Location = new System.Drawing.Point(16, 459);
            this.btnAddCart.Name = "btnAddCart";
            this.btnAddCart.Size = new System.Drawing.Size(156, 54);
            this.btnAddCart.TabIndex = 8;
            this.btnAddCart.Text = "Add To Cart";
            this.btnAddCart.UseVisualStyleBackColor = true;
            this.btnAddCart.Click += new System.EventHandler(this.btnAddCart_Click_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(87, 263);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "--";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(122, 244);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Max";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 244);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Min";
            // 
            // txtBMax
            // 
            this.txtBMax.Location = new System.Drawing.Point(116, 260);
            this.txtBMax.Name = "txtBMax";
            this.txtBMax.Size = new System.Drawing.Size(56, 20);
            this.txtBMax.TabIndex = 4;
            // 
            // txtBMin
            // 
            this.txtBMin.Location = new System.Drawing.Point(16, 260);
            this.txtBMin.Name = "txtBMin";
            this.txtBMin.Size = new System.Drawing.Size(55, 20);
            this.txtBMin.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 174);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Search";
            // 
            // txtBSearchName
            // 
            this.txtBSearchName.Location = new System.Drawing.Point(16, 190);
            this.txtBSearchName.Name = "txtBSearchName";
            this.txtBSearchName.Size = new System.Drawing.Size(156, 20);
            this.txtBSearchName.TabIndex = 1;
            // 
            // dgvSeeProducts
            // 
            this.dgvSeeProducts.AllowUserToAddRows = false;
            this.dgvSeeProducts.AllowUserToDeleteRows = false;
            this.dgvSeeProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSeeProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSeeProducts.Location = new System.Drawing.Point(188, 0);
            this.dgvSeeProducts.Name = "dgvSeeProducts";
            this.dgvSeeProducts.ReadOnly = true;
            this.dgvSeeProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSeeProducts.Size = new System.Drawing.Size(494, 536);
            this.dgvSeeProducts.TabIndex = 0;
            this.dgvSeeProducts.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSeeProducts_CellClick);
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.BackColor = System.Drawing.Color.IndianRed;
            this.lblWelcome.Font = new System.Drawing.Font("Myanmar Text", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.ForeColor = System.Drawing.SystemColors.Control;
            this.lblWelcome.Location = new System.Drawing.Point(30, 31);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(85, 29);
            this.lblWelcome.TabIndex = 5;
            this.lblWelcome.Text = "Welcome";
            // 
            // pnlMyShoppingCart
            // 
            this.pnlMyShoppingCart.Controls.Add(this.txtBSelected);
            this.pnlMyShoppingCart.Controls.Add(this.btnBuy);
            this.pnlMyShoppingCart.Controls.Add(this.lblTotalAmount);
            this.pnlMyShoppingCart.Controls.Add(this.btnBackTwo);
            this.pnlMyShoppingCart.Controls.Add(this.dgvMHC);
            this.pnlMyShoppingCart.Location = new System.Drawing.Point(262, -1);
            this.pnlMyShoppingCart.Name = "pnlMyShoppingCart";
            this.pnlMyShoppingCart.Size = new System.Drawing.Size(685, 545);
            this.pnlMyShoppingCart.TabIndex = 11;
            this.pnlMyShoppingCart.Visible = false;
            // 
            // btnBuy
            // 
            this.btnBuy.Location = new System.Drawing.Point(14, 491);
            this.btnBuy.Name = "btnBuy";
            this.btnBuy.Size = new System.Drawing.Size(238, 37);
            this.btnBuy.TabIndex = 13;
            this.btnBuy.Text = "Buy";
            this.btnBuy.UseVisualStyleBackColor = true;
            this.btnBuy.Click += new System.EventHandler(this.btnBuy_Click);
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Location = new System.Drawing.Point(75, 468);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(52, 13);
            this.lblTotalAmount.TabIndex = 12;
            this.lblTotalAmount.Text = "Total : 0$";
            // 
            // btnBackTwo
            // 
            this.btnBackTwo.Location = new System.Drawing.Point(639, 3);
            this.btnBackTwo.Name = "btnBackTwo";
            this.btnBackTwo.Size = new System.Drawing.Size(43, 23);
            this.btnBackTwo.TabIndex = 5;
            this.btnBackTwo.Text = "Back";
            this.btnBackTwo.UseVisualStyleBackColor = true;
            this.btnBackTwo.Click += new System.EventHandler(this.btnBackTwo_Click);
            // 
            // dgvMHC
            // 
            this.dgvMHC.AllowUserToAddRows = false;
            this.dgvMHC.AllowUserToDeleteRows = false;
            this.dgvMHC.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMHC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMHC.Location = new System.Drawing.Point(0, 64);
            this.dgvMHC.Name = "dgvMHC";
            this.dgvMHC.ReadOnly = true;
            this.dgvMHC.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMHC.Size = new System.Drawing.Size(685, 365);
            this.dgvMHC.TabIndex = 0;
            this.dgvMHC.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMHC_CellClick_1);
            // 
            // dgvMO
            // 
            this.dgvMO.AllowUserToAddRows = false;
            this.dgvMO.AllowUserToDeleteRows = false;
            this.dgvMO.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMO.Location = new System.Drawing.Point(0, 32);
            this.dgvMO.Name = "dgvMO";
            this.dgvMO.ReadOnly = true;
            this.dgvMO.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMO.Size = new System.Drawing.Size(685, 442);
            this.dgvMO.TabIndex = 0;
            this.dgvMO.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btnBack2
            // 
            this.btnBack2.Location = new System.Drawing.Point(639, 3);
            this.btnBack2.Name = "btnBack2";
            this.btnBack2.Size = new System.Drawing.Size(43, 23);
            this.btnBack2.TabIndex = 5;
            this.btnBack2.Text = "Back";
            this.btnBack2.UseVisualStyleBackColor = true;
            this.btnBack2.Click += new System.EventHandler(this.btnBack2_Click_1);
            // 
            // pnlMO
            // 
            this.pnlMO.Controls.Add(this.txtBID);
            this.pnlMO.Controls.Add(this.btnCancel);
            this.pnlMO.Controls.Add(this.btnBack2);
            this.pnlMO.Controls.Add(this.dgvMO);
            this.pnlMO.Location = new System.Drawing.Point(262, -1);
            this.pnlMO.Name = "pnlMO";
            this.pnlMO.Size = new System.Drawing.Size(685, 548);
            this.pnlMO.TabIndex = 14;
            this.pnlMO.Visible = false;
            // 
            // txtBID
            // 
            this.txtBID.Location = new System.Drawing.Point(16, 491);
            this.txtBID.Multiline = true;
            this.txtBID.Name = "txtBID";
            this.txtBID.ReadOnly = true;
            this.txtBID.Size = new System.Drawing.Size(40, 29);
            this.txtBID.TabIndex = 7;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(77, 491);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 29);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pnlUS
            // 
            this.pnlUS.BackColor = System.Drawing.Color.LightGray;
            this.pnlUS.Controls.Add(this.textBox6);
            this.pnlUS.Controls.Add(this.textBox4);
            this.pnlUS.Controls.Add(this.button1);
            this.pnlUS.Controls.Add(this.label10);
            this.pnlUS.Controls.Add(this.label9);
            this.pnlUS.Controls.Add(this.label8);
            this.pnlUS.Controls.Add(this.textBox5);
            this.pnlUS.Controls.Add(this.textBox2);
            this.pnlUS.Controls.Add(this.label7);
            this.pnlUS.Controls.Add(this.textBox3);
            this.pnlUS.Controls.Add(this.textBox1);
            this.pnlUS.Controls.Add(this.label6);
            this.pnlUS.Controls.Add(this.label5);
            this.pnlUS.Controls.Add(this.pictureBox2);
            this.pnlUS.Controls.Add(this.button2);
            this.pnlUS.Controls.Add(this.pictureBox3);
            this.pnlUS.Location = new System.Drawing.Point(262, -1);
            this.pnlUS.Name = "pnlUS";
            this.pnlUS.Size = new System.Drawing.Size(688, 548);
            this.pnlUS.TabIndex = 15;
            this.pnlUS.Visible = false;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(355, 392);
            this.textBox6.Multiline = true;
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(181, 31);
            this.textBox6.TabIndex = 22;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(355, 319);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(181, 31);
            this.textBox4.TabIndex = 21;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(348, 450);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(197, 39);
            this.button1.TabIndex = 20;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(355, 376);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "label10";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(355, 303);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "label9";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(355, 233);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "label8";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(355, 249);
            this.textBox5.Multiline = true;
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(181, 31);
            this.textBox5.TabIndex = 14;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(504, 64);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(132, 38);
            this.textBox2.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(268, 124);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "E-Mail";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(271, 140);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(365, 33);
            this.textBox3.TabIndex = 11;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(271, 64);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(132, 38);
            this.textBox1.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(501, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Surname";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(268, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Name";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.DarkGray;
            this.pictureBox2.BackgroundImage = global::InventoryManagementSystem.Properties.Resources.images;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(25, 13);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(200, 205);
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(639, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(43, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Back";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Black;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Location = new System.Drawing.Point(16, 3);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(220, 224);
            this.pictureBox3.TabIndex = 23;
            this.pictureBox3.TabStop = false;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.IndianRed;
            this.btnExit.BackgroundImage = global::InventoryManagementSystem.Properties.Resources.blue1_button;
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Location = new System.Drawing.Point(56, 428);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(153, 81);
            this.btnExit.TabIndex = 16;
            this.btnExit.Text = "Quit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click_1);
            // 
            // btnUserSettings
            // 
            this.btnUserSettings.BackColor = System.Drawing.Color.IndianRed;
            this.btnUserSettings.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnUserSettings.BackgroundImage")));
            this.btnUserSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUserSettings.FlatAppearance.BorderSize = 0;
            this.btnUserSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUserSettings.Location = new System.Drawing.Point(56, 345);
            this.btnUserSettings.Name = "btnUserSettings";
            this.btnUserSettings.Size = new System.Drawing.Size(153, 77);
            this.btnUserSettings.TabIndex = 3;
            this.btnUserSettings.Text = "User Settings";
            this.btnUserSettings.UseVisualStyleBackColor = false;
            this.btnUserSettings.Click += new System.EventHandler(this.btnUS_Click);
            // 
            // btnMyOrders
            // 
            this.btnMyOrders.BackColor = System.Drawing.Color.IndianRed;
            this.btnMyOrders.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMyOrders.BackgroundImage")));
            this.btnMyOrders.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMyOrders.FlatAppearance.BorderSize = 0;
            this.btnMyOrders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMyOrders.Location = new System.Drawing.Point(56, 255);
            this.btnMyOrders.Name = "btnMyOrders";
            this.btnMyOrders.Size = new System.Drawing.Size(153, 84);
            this.btnMyOrders.TabIndex = 2;
            this.btnMyOrders.Text = "My Orders";
            this.btnMyOrders.UseVisualStyleBackColor = false;
            this.btnMyOrders.Click += new System.EventHandler(this.btnMO_Click);
            // 
            // btnMySCart
            // 
            this.btnMySCart.BackColor = System.Drawing.Color.IndianRed;
            this.btnMySCart.BackgroundImage = global::InventoryManagementSystem.Properties.Resources.blue1_button;
            this.btnMySCart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMySCart.FlatAppearance.BorderSize = 0;
            this.btnMySCart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMySCart.Location = new System.Drawing.Point(56, 156);
            this.btnMySCart.Name = "btnMySCart";
            this.btnMySCart.Size = new System.Drawing.Size(153, 84);
            this.btnMySCart.TabIndex = 1;
            this.btnMySCart.Text = "My Shopping Cart";
            this.btnMySCart.UseVisualStyleBackColor = false;
            this.btnMySCart.Click += new System.EventHandler(this.btnMSC_Click);
            // 
            // btnSearchProducts
            // 
            this.btnSearchProducts.BackColor = System.Drawing.Color.IndianRed;
            this.btnSearchProducts.BackgroundImage = global::InventoryManagementSystem.Properties.Resources.blue1_button;
            this.btnSearchProducts.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearchProducts.FlatAppearance.BorderSize = 0;
            this.btnSearchProducts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchProducts.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSearchProducts.Location = new System.Drawing.Point(56, 63);
            this.btnSearchProducts.Name = "btnSearchProducts";
            this.btnSearchProducts.Size = new System.Drawing.Size(153, 79);
            this.btnSearchProducts.TabIndex = 0;
            this.btnSearchProducts.Text = "Search Products";
            this.btnSearchProducts.UseVisualStyleBackColor = false;
            this.btnSearchProducts.Click += new System.EventHandler(this.btnSP_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.IndianRed;
            this.pictureBox1.Location = new System.Drawing.Point(-5, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(267, 548);
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // txtBSelected
            // 
            this.txtBSelected.Location = new System.Drawing.Point(14, 465);
            this.txtBSelected.Name = "txtBSelected";
            this.txtBSelected.ReadOnly = true;
            this.txtBSelected.Size = new System.Drawing.Size(55, 20);
            this.txtBSelected.TabIndex = 15;
            // 
            // CustomerMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(946, 540);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.pnlUS);
            this.Controls.Add(this.pnlMyShoppingCart);
            this.Controls.Add(this.pnlMO);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.pnlProducts);
            this.Controls.Add(this.btnUserSettings);
            this.Controls.Add(this.btnMyOrders);
            this.Controls.Add(this.btnMySCart);
            this.Controls.Add(this.btnSearchProducts);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CustomerMenu";
            this.Text = "CustomerMenu";
            this.Load += new System.EventHandler(this.CustomerMenu_Load);
            this.pnlProducts.ResumeLayout(false);
            this.pnlProducts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeeProducts)).EndInit();
            this.pnlMyShoppingCart.ResumeLayout(false);
            this.pnlMyShoppingCart.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMHC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMO)).EndInit();
            this.pnlMO.ResumeLayout(false);
            this.pnlMO.PerformLayout();
            this.pnlUS.ResumeLayout(false);
            this.pnlUS.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearchProducts;
        private System.Windows.Forms.Button btnMySCart;
        private System.Windows.Forms.Button btnUserSettings;
        private System.Windows.Forms.Button btnMyOrders;
        private System.Windows.Forms.Panel pnlProducts;
        private System.Windows.Forms.DataGridView dgvSeeProducts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBSearchName;
        private System.Windows.Forms.Label lblSelectedP;
        private System.Windows.Forms.Button btnAddCart;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBMax;
        private System.Windows.Forms.TextBox txtBMin;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnSelectOptions;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Panel pnlMyShoppingCart;
        private System.Windows.Forms.Button btnBackTwo;
        private System.Windows.Forms.DataGridView dgvMHC;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Button btnBuy;
        private System.Windows.Forms.DataGridView dgvMO;
        private System.Windows.Forms.Button btnBack2;
        private System.Windows.Forms.Panel pnlMO;
        private System.Windows.Forms.TextBox txtBID;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel pnlUS;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TextBox txtBSelected;
    }
}