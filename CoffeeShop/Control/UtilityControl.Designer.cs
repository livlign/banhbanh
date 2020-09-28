namespace CoffeeShop.Control
{
    partial class UtilityControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSaveOrderNote = new System.Windows.Forms.Button();
            this.txtOrderNote = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnMainNote = new System.Windows.Forms.Button();
            this.txtMainNote = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSaveOrderNote);
            this.groupBox1.Controls.Add(this.txtOrderNote);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(530, 288);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ghi chú hóa đơn";
            // 
            // btnSaveOrderNote
            // 
            this.btnSaveOrderNote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveOrderNote.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSaveOrderNote.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveOrderNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveOrderNote.ForeColor = System.Drawing.Color.White;
            this.btnSaveOrderNote.Location = new System.Drawing.Point(6, 245);
            this.btnSaveOrderNote.Name = "btnSaveOrderNote";
            this.btnSaveOrderNote.Size = new System.Drawing.Size(91, 37);
            this.btnSaveOrderNote.TabIndex = 16;
            this.btnSaveOrderNote.Text = "Lưu";
            this.btnSaveOrderNote.UseVisualStyleBackColor = false;
            this.btnSaveOrderNote.Click += new System.EventHandler(this.btnSaveOrderNote_Click);
            // 
            // txtOrderNote
            // 
            this.txtOrderNote.Location = new System.Drawing.Point(6, 19);
            this.txtOrderNote.Multiline = true;
            this.txtOrderNote.Name = "txtOrderNote";
            this.txtOrderNote.Size = new System.Drawing.Size(518, 219);
            this.txtOrderNote.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnMainNote);
            this.groupBox2.Controls.Add(this.txtMainNote);
            this.groupBox2.Location = new System.Drawing.Point(3, 321);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(530, 288);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ghi chú trang chủ";
            // 
            // btnMainNote
            // 
            this.btnMainNote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMainNote.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnMainNote.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMainNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMainNote.ForeColor = System.Drawing.Color.White;
            this.btnMainNote.Location = new System.Drawing.Point(6, 245);
            this.btnMainNote.Name = "btnMainNote";
            this.btnMainNote.Size = new System.Drawing.Size(91, 37);
            this.btnMainNote.TabIndex = 16;
            this.btnMainNote.Text = "Lưu";
            this.btnMainNote.UseVisualStyleBackColor = false;
            this.btnMainNote.Click += new System.EventHandler(this.btnMainNote_Click);
            // 
            // txtMainNote
            // 
            this.txtMainNote.Location = new System.Drawing.Point(6, 19);
            this.txtMainNote.Multiline = true;
            this.txtMainNote.Name = "txtMainNote";
            this.txtMainNote.Size = new System.Drawing.Size(518, 219);
            this.txtMainNote.TabIndex = 0;
            // 
            // UtilityControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "UtilityControl";
            this.Size = new System.Drawing.Size(1064, 650);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtOrderNote;
        private System.Windows.Forms.Button btnSaveOrderNote;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnMainNote;
        private System.Windows.Forms.TextBox txtMainNote;
    }
}
