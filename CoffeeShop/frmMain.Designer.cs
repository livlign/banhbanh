namespace CoffeeShop
{
    partial class frmMain
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
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.mnHome = new System.Windows.Forms.ToolStripMenuItem();
            this.mnOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.mnList = new System.Windows.Forms.ToolStripMenuItem();
            this.mnReport = new System.Windows.Forms.ToolStripMenuItem();
            this.mnSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.lblUser = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuMain
            // 
            this.menuMain.BackColor = System.Drawing.Color.DodgerBlue;
            this.menuMain.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnHome,
            this.mnOrder,
            this.mnList,
            this.mnReport,
            this.mnSetting});
            this.menuMain.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(1136, 56);
            this.menuMain.TabIndex = 1;
            this.menuMain.Text = "menuStrip2";
            // 
            // mnHome
            // 
            this.mnHome.BackColor = System.Drawing.Color.DodgerBlue;
            this.mnHome.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnHome.ForeColor = System.Drawing.Color.White;
            this.mnHome.Image = global::CoffeeShop.Properties.Resources.coffee_48;
            this.mnHome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mnHome.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnHome.Name = "mnHome";
            this.mnHome.ShortcutKeyDisplayString = "Hệ thống";
            this.mnHome.Size = new System.Drawing.Size(175, 52);
            this.mnHome.Tag = "1";
            this.mnHome.Text = "Trang Chủ";
            this.mnHome.Click += new System.EventHandler(this.mnHome_Click);
            // 
            // mnOrder
            // 
            this.mnOrder.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnOrder.ForeColor = System.Drawing.Color.White;
            this.mnOrder.Image = global::CoffeeShop.Properties.Resources.purchase_order_48;
            this.mnOrder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mnOrder.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnOrder.Name = "mnOrder";
            this.mnOrder.ShortcutKeyDisplayString = "Hệ thống";
            this.mnOrder.Size = new System.Drawing.Size(160, 52);
            this.mnOrder.Tag = "1";
            this.mnOrder.Text = "Hóa Đơn";
            this.mnOrder.Click += new System.EventHandler(this.mnOrder_Click);
            // 
            // mnList
            // 
            this.mnList.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnList.ForeColor = System.Drawing.Color.White;
            this.mnList.Image = global::CoffeeShop.Properties.Resources.categorize_48;
            this.mnList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mnList.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnList.Name = "mnList";
            this.mnList.ShortcutKeyDisplayString = "Hệ thống";
            this.mnList.Size = new System.Drawing.Size(174, 52);
            this.mnList.Tag = "1";
            this.mnList.Text = "Danh Mục";
            this.mnList.Click += new System.EventHandler(this.mnList_Click);
            // 
            // mnReport
            // 
            this.mnReport.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnReport.ForeColor = System.Drawing.Color.White;
            this.mnReport.Image = global::CoffeeShop.Properties.Resources.report_2_48;
            this.mnReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mnReport.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnReport.Name = "mnReport";
            this.mnReport.ShortcutKeyDisplayString = "Hệ thống";
            this.mnReport.Size = new System.Drawing.Size(153, 52);
            this.mnReport.Tag = "1";
            this.mnReport.Text = "Báo Cáo";
            this.mnReport.Click += new System.EventHandler(this.mnReport_Click);
            // 
            // mnSetting
            // 
            this.mnSetting.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnSetting.ForeColor = System.Drawing.Color.White;
            this.mnSetting.Image = global::CoffeeShop.Properties.Resources.settings_5_48;
            this.mnSetting.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mnSetting.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnSetting.Name = "mnSetting";
            this.mnSetting.ShortcutKeyDisplayString = "Hệ thống";
            this.mnSetting.Size = new System.Drawing.Size(143, 52);
            this.mnSetting.Tag = "1";
            this.mnSetting.Text = "Cài Đặt";
            this.mnSetting.Click += new System.EventHandler(this.mnSetting_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 56);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1136, 733);
            this.pnlMain.TabIndex = 2;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.BackColor = System.Drawing.Color.DodgerBlue;
            this.lblUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.ForeColor = System.Drawing.Color.White;
            this.lblUser.Location = new System.Drawing.Point(821, 17);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(99, 25);
            this.lblUser.TabIndex = 3;
            this.lblUser.Text = "Duy ngu";
            this.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.DodgerBlue;
            this.pictureBox1.Image = global::CoffeeShop.Properties.Resources.logot;
            this.pictureBox1.Location = new System.Drawing.Point(949, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(187, 56);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(812, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(5, 55);
            this.label1.TabIndex = 0;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 789);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuMain);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cà fê Cô Ba";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem mnHome;
        private System.Windows.Forms.ToolStripMenuItem mnOrder;
        private System.Windows.Forms.ToolStripMenuItem mnReport;
        private System.Windows.Forms.ToolStripMenuItem mnSetting;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.ToolStripMenuItem mnList;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;

    }
}