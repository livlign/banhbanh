namespace CoffeeShop.FormUI
{
    partial class ConfirmOrder
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvOrderItem = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTotalPrice = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblOrderNumber = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.rdoCash = new System.Windows.Forms.RadioButton();
            this.rdoATM = new System.Windows.Forms.RadioButton();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.lblOrderRef = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlDiscount = new System.Windows.Forms.Panel();
            this.txtAddonDiscount = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.rdoDiscountPercent = new System.Windows.Forms.RadioButton();
            this.rdoDiscountCash = new System.Windows.Forms.RadioButton();
            this.txtCustCash = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblReturn = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblVoucherText = new System.Windows.Forms.Label();
            this.btnVoucher = new System.Windows.Forms.Button();
            this.txtVoucherCode = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderItem)).BeginInit();
            this.pnlDiscount.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvOrderItem
            // 
            this.dgvOrderItem.AllowUserToAddRows = false;
            this.dgvOrderItem.AllowUserToDeleteRows = false;
            this.dgvOrderItem.AllowUserToResizeColumns = false;
            this.dgvOrderItem.AllowUserToResizeRows = false;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvOrderItem.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle17;
            this.dgvOrderItem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOrderItem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrderItem.BackgroundColor = System.Drawing.Color.White;
            this.dgvOrderItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrderItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dgvOrderItem.Location = new System.Drawing.Point(3, 87);
            this.dgvOrderItem.Name = "dgvOrderItem";
            this.dgvOrderItem.ReadOnly = true;
            this.dgvOrderItem.RowHeadersVisible = false;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvOrderItem.RowsDefaultCellStyle = dataGridViewCellStyle20;
            this.dgvOrderItem.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvOrderItem.RowTemplate.Height = 40;
            this.dgvOrderItem.Size = new System.Drawing.Size(694, 347);
            this.dgvOrderItem.TabIndex = 100;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "ProductName";
            this.Column2.HeaderText = "Sản phẩm";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Price";
            dataGridViewCellStyle18.Format = "N0";
            this.Column3.DefaultCellStyle = dataGridViewCellStyle18;
            this.Column3.HeaderText = "Đơn giá";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "Qty";
            this.Column4.HeaderText = "Số lượng";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "TotalPrice";
            dataGridViewCellStyle19.Format = "N0";
            this.Column5.DefaultCellStyle = dataGridViewCellStyle19;
            this.Column5.HeaderText = "Thành tiền";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label2.Location = new System.Drawing.Point(4, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 24);
            this.label2.TabIndex = 25;
            this.label2.Text = "Ngày:";
            // 
            // lblTotalPrice
            // 
            this.lblTotalPrice.AutoSize = true;
            this.lblTotalPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPrice.ForeColor = System.Drawing.Color.Red;
            this.lblTotalPrice.Location = new System.Drawing.Point(209, 478);
            this.lblTotalPrice.Name = "lblTotalPrice";
            this.lblTotalPrice.Size = new System.Drawing.Size(170, 46);
            this.lblTotalPrice.TabIndex = 24;
            this.lblTotalPrice.Text = "100.000";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label8.Location = new System.Drawing.Point(34, 489);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(118, 25);
            this.label8.TabIndex = 23;
            this.label8.Text = "Tổng tiền:";
            // 
            // lblOrderNumber
            // 
            this.lblOrderNumber.AutoSize = true;
            this.lblOrderNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderNumber.ForeColor = System.Drawing.Color.Red;
            this.lblOrderNumber.Location = new System.Drawing.Point(99, 37);
            this.lblOrderNumber.Name = "lblOrderNumber";
            this.lblOrderNumber.Size = new System.Drawing.Size(66, 46);
            this.lblOrderNumber.TabIndex = 22;
            this.lblOrderNumber.Text = "01";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label4.Location = new System.Drawing.Point(4, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 24);
            this.label4.TabIndex = 21;
            this.label4.Text = "Số bàn:";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblDate.Location = new System.Drawing.Point(97, 9);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(194, 24);
            this.lblDate.TabIndex = 26;
            this.lblDate.Text = "10/05/2016 23:00:00";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblUser.Location = new System.Drawing.Point(418, 9);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(88, 24);
            this.lblUser.TabIndex = 28;
            this.lblUser.Text = "Duy ngu";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label6.Location = new System.Drawing.Point(296, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 24);
            this.label6.TabIndex = 14;
            this.label6.Text = "Nhân viên:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label9.Location = new System.Drawing.Point(31, 11);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(125, 25);
            this.label9.TabIndex = 29;
            this.label9.Text = "Chiết khấu";
            // 
            // txtDiscount
            // 
            this.txtDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiscount.Location = new System.Drawing.Point(214, 8);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(173, 31);
            this.txtDiscount.TabIndex = 1;
            this.txtDiscount.Tag = "1";
            this.txtDiscount.TextChanged += new System.EventHandler(this.txtDiscount_TextChanged);
            this.txtDiscount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDiscount_KeyPress);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirm.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.ForeColor = System.Drawing.Color.White;
            this.btnConfirm.Location = new System.Drawing.Point(205, 783);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(138, 73);
            this.btnConfirm.TabIndex = 33;
            this.btnConfirm.Text = "Xác nhận (Enter)";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(349, 783);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(138, 73);
            this.btnCancel.TabIndex = 34;
            this.btnCancel.Text = "Hủy (Esc)";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.Red;
            this.lblTotal.Location = new System.Drawing.Point(209, 666);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(170, 46);
            this.lblTotal.TabIndex = 36;
            this.lblTotal.Text = "100.000";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label11.Location = new System.Drawing.Point(34, 679);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(131, 25);
            this.label11.TabIndex = 35;
            this.label11.Text = "Thanh toán";
            // 
            // rdoCash
            // 
            this.rdoCash.AutoSize = true;
            this.rdoCash.Checked = true;
            this.rdoCash.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoCash.Location = new System.Drawing.Point(445, 675);
            this.rdoCash.Name = "rdoCash";
            this.rdoCash.Size = new System.Drawing.Size(137, 35);
            this.rdoCash.TabIndex = 37;
            this.rdoCash.TabStop = true;
            this.rdoCash.Text = "Tiền mặt";
            this.rdoCash.UseVisualStyleBackColor = true;
            // 
            // rdoATM
            // 
            this.rdoATM.AutoSize = true;
            this.rdoATM.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoATM.Location = new System.Drawing.Point(588, 675);
            this.rdoATM.Name = "rdoATM";
            this.rdoATM.Size = new System.Drawing.Size(79, 35);
            this.rdoATM.TabIndex = 38;
            this.rdoATM.Text = "Thẻ";
            this.rdoATM.UseVisualStyleBackColor = true;
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(701, 863);
            this.shapeContainer1.TabIndex = 0;
            this.shapeContainer1.TabStop = false;
            // 
            // lineShape1
            // 
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 0;
            this.lineShape1.X2 = 698;
            this.lineShape1.Y1 = 663;
            this.lineShape1.Y2 = 662;
            // 
            // txtNote
            // 
            this.txtNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNote.Location = new System.Drawing.Point(3, 401);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.ReadOnly = true;
            this.txtNote.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtNote.Size = new System.Drawing.Size(694, 74);
            this.txtNote.TabIndex = 40;
            // 
            // lblOrderRef
            // 
            this.lblOrderRef.AutoSize = true;
            this.lblOrderRef.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderRef.ForeColor = System.Drawing.Color.Red;
            this.lblOrderRef.Location = new System.Drawing.Point(417, 51);
            this.lblOrderRef.Name = "lblOrderRef";
            this.lblOrderRef.Size = new System.Drawing.Size(41, 29);
            this.lblOrderRef.TabIndex = 42;
            this.lblOrderRef.Text = "01";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label3.Location = new System.Drawing.Point(296, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 24);
            this.label3.TabIndex = 41;
            this.label3.Text = "Số hóa đơn:";
            // 
            // pnlDiscount
            // 
            this.pnlDiscount.Controls.Add(this.rdoDiscountPercent);
            this.pnlDiscount.Controls.Add(this.rdoDiscountCash);
            this.pnlDiscount.Controls.Add(this.txtDiscount);
            this.pnlDiscount.Controls.Add(this.label9);
            this.pnlDiscount.Location = new System.Drawing.Point(3, 517);
            this.pnlDiscount.Name = "pnlDiscount";
            this.pnlDiscount.Size = new System.Drawing.Size(686, 49);
            this.pnlDiscount.TabIndex = 43;
            // 
            // txtAddonDiscount
            // 
            this.txtAddonDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddonDiscount.Location = new System.Drawing.Point(217, 628);
            this.txtAddonDiscount.Name = "txtAddonDiscount";
            this.txtAddonDiscount.Size = new System.Drawing.Size(173, 31);
            this.txtAddonDiscount.TabIndex = 2;
            this.txtAddonDiscount.Tag = "1";
            this.txtAddonDiscount.TextChanged += new System.EventHandler(this.txtAddonDiscount_TextChanged);
            this.txtAddonDiscount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAddonDiscount_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label10.Location = new System.Drawing.Point(34, 631);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(124, 25);
            this.label10.TabIndex = 42;
            this.label10.Text = "Giảm thêm";
            // 
            // rdoDiscountPercent
            // 
            this.rdoDiscountPercent.AutoSize = true;
            this.rdoDiscountPercent.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoDiscountPercent.Location = new System.Drawing.Point(585, 7);
            this.rdoDiscountPercent.Name = "rdoDiscountPercent";
            this.rdoDiscountPercent.Size = new System.Drawing.Size(56, 35);
            this.rdoDiscountPercent.TabIndex = 40;
            this.rdoDiscountPercent.Text = "%";
            this.rdoDiscountPercent.UseVisualStyleBackColor = true;
            this.rdoDiscountPercent.CheckedChanged += new System.EventHandler(this.txtDiscount_TextChanged);
            // 
            // rdoDiscountCash
            // 
            this.rdoDiscountCash.AutoSize = true;
            this.rdoDiscountCash.Checked = true;
            this.rdoDiscountCash.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoDiscountCash.Location = new System.Drawing.Point(442, 7);
            this.rdoDiscountCash.Name = "rdoDiscountCash";
            this.rdoDiscountCash.Size = new System.Drawing.Size(137, 35);
            this.rdoDiscountCash.TabIndex = 39;
            this.rdoDiscountCash.TabStop = true;
            this.rdoDiscountCash.Text = "Tiền mặt";
            this.rdoDiscountCash.UseVisualStyleBackColor = true;
            this.rdoDiscountCash.CheckedChanged += new System.EventHandler(this.txtDiscount_TextChanged);
            // 
            // txtCustCash
            // 
            this.txtCustCash.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustCash.Location = new System.Drawing.Point(217, 723);
            this.txtCustCash.Name = "txtCustCash";
            this.txtCustCash.Size = new System.Drawing.Size(173, 31);
            this.txtCustCash.TabIndex = 0;
            this.txtCustCash.TextChanged += new System.EventHandler(this.txtCustCash_TextChanged);
            this.txtCustCash.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDiscount_KeyPress);
            this.txtCustCash.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustCash_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label1.Location = new System.Drawing.Point(34, 726);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 25);
            this.label1.TabIndex = 44;
            this.label1.Text = "Tiền khách đưa";
            // 
            // lblReturn
            // 
            this.lblReturn.AutoSize = true;
            this.lblReturn.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReturn.ForeColor = System.Drawing.Color.Red;
            this.lblReturn.Location = new System.Drawing.Point(475, 717);
            this.lblReturn.Name = "lblReturn";
            this.lblReturn.Size = new System.Drawing.Size(43, 46);
            this.lblReturn.TabIndex = 47;
            this.lblReturn.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label7.Location = new System.Drawing.Point(400, 729);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 25);
            this.label7.TabIndex = 46;
            this.label7.Text = "Trả lại";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblVoucherText);
            this.panel2.Controls.Add(this.btnVoucher);
            this.panel2.Controls.Add(this.txtVoucherCode);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(3, 571);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(686, 57);
            this.panel2.TabIndex = 44;
            // 
            // lblVoucherText
            // 
            this.lblVoucherText.AutoSize = true;
            this.lblVoucherText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVoucherText.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblVoucherText.Location = new System.Drawing.Point(213, 37);
            this.lblVoucherText.Name = "lblVoucherText";
            this.lblVoucherText.Size = new System.Drawing.Size(0, 16);
            this.lblVoucherText.TabIndex = 30;
            // 
            // btnVoucher
            // 
            this.btnVoucher.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnVoucher.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVoucher.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoucher.ForeColor = System.Drawing.Color.White;
            this.btnVoucher.Location = new System.Drawing.Point(532, 4);
            this.btnVoucher.Name = "btnVoucher";
            this.btnVoucher.Size = new System.Drawing.Size(120, 31);
            this.btnVoucher.TabIndex = 4;
            this.btnVoucher.Text = "Áp dụng";
            this.btnVoucher.UseVisualStyleBackColor = false;
            this.btnVoucher.Click += new System.EventHandler(this.btnVoucher_Click);
            // 
            // txtVoucherCode
            // 
            this.txtVoucherCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVoucherCode.Location = new System.Drawing.Point(214, 4);
            this.txtVoucherCode.Name = "txtVoucherCode";
            this.txtVoucherCode.Size = new System.Drawing.Size(312, 31);
            this.txtVoucherCode.TabIndex = 3;
            this.txtVoucherCode.Tag = "1";
            this.txtVoucherCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtVoucherCode_KeyUp);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label5.Location = new System.Drawing.Point(31, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(140, 25);
            this.label5.TabIndex = 29;
            this.label5.Text = "Mã giảm giá";
            // 
            // ConfirmOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 863);
            this.Controls.Add(this.txtAddonDiscount);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lblReturn);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtCustCash);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlDiscount);
            this.Controls.Add(this.lblOrderRef);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.rdoATM);
            this.Controls.Add(this.rdoCash);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTotalPrice);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblOrderNumber);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvOrderItem);
            this.Controls.Add(this.shapeContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfirmOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xác nhận hóa đơn";
            this.Load += new System.EventHandler(this.ConfirmOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderItem)).EndInit();
            this.pnlDiscount.ResumeLayout(false);
            this.pnlDiscount.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvOrderItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTotalPrice;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblOrderNumber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.RadioButton rdoCash;
        private System.Windows.Forms.RadioButton rdoATM;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.Label lblOrderRef;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnlDiscount;
        private System.Windows.Forms.RadioButton rdoDiscountPercent;
        private System.Windows.Forms.RadioButton rdoDiscountCash;
        private System.Windows.Forms.TextBox txtCustCash;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblReturn;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnVoucher;
        private System.Windows.Forms.TextBox txtVoucherCode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblVoucherText;
        private System.Windows.Forms.TextBox txtAddonDiscount;
        private System.Windows.Forms.Label label10;
    }
}