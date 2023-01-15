
namespace PemesananTiketBus.View
{
    partial class FrmLaporan
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
            this.label2 = new System.Windows.Forms.Label();
            this.radioButtonSemua = new System.Windows.Forms.RadioButton();
            this.radioButtonID = new System.Windows.Forms.RadioButton();
            this.radioButtonNama = new System.Windows.Forms.RadioButton();
            this.textNamaPelanggan = new System.Windows.Forms.TextBox();
            this.textIDPembayaran = new System.Windows.Forms.TextBox();
            this.btnTampilkanData = new System.Windows.Forms.Button();
            this.listLaporan = new System.Windows.Forms.ListView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 11;
            // 
            // radioButtonSemua
            // 
            this.radioButtonSemua.AutoSize = true;
            this.radioButtonSemua.Location = new System.Drawing.Point(12, 12);
            this.radioButtonSemua.Name = "radioButtonSemua";
            this.radioButtonSemua.Size = new System.Drawing.Size(120, 17);
            this.radioButtonSemua.TabIndex = 12;
            this.radioButtonSemua.TabStop = true;
            this.radioButtonSemua.Text = "Semua Pembayaran";
            this.radioButtonSemua.UseVisualStyleBackColor = true;
            // 
            // radioButtonID
            // 
            this.radioButtonID.AutoSize = true;
            this.radioButtonID.Location = new System.Drawing.Point(12, 40);
            this.radioButtonID.Name = "radioButtonID";
            this.radioButtonID.Size = new System.Drawing.Size(98, 17);
            this.radioButtonID.TabIndex = 13;
            this.radioButtonID.TabStop = true;
            this.radioButtonID.Text = "ID Pembayaran";
            this.radioButtonID.UseVisualStyleBackColor = true;
            // 
            // radioButtonNama
            // 
            this.radioButtonNama.AutoSize = true;
            this.radioButtonNama.Location = new System.Drawing.Point(12, 69);
            this.radioButtonNama.Name = "radioButtonNama";
            this.radioButtonNama.Size = new System.Drawing.Size(107, 17);
            this.radioButtonNama.TabIndex = 14;
            this.radioButtonNama.TabStop = true;
            this.radioButtonNama.Text = "Nama Pelanggan";
            this.radioButtonNama.UseVisualStyleBackColor = true;
            // 
            // textNamaPelanggan
            // 
            this.textNamaPelanggan.Location = new System.Drawing.Point(143, 68);
            this.textNamaPelanggan.Name = "textNamaPelanggan";
            this.textNamaPelanggan.Size = new System.Drawing.Size(260, 20);
            this.textNamaPelanggan.TabIndex = 34;
            this.textNamaPelanggan.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textNamaPelanggan_KeyUp);
            // 
            // textIDPembayaran
            // 
            this.textIDPembayaran.Location = new System.Drawing.Point(143, 39);
            this.textIDPembayaran.Name = "textIDPembayaran";
            this.textIDPembayaran.Size = new System.Drawing.Size(155, 20);
            this.textIDPembayaran.TabIndex = 35;
            this.textIDPembayaran.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textIDPembayaran_KeyUp);
            // 
            // btnTampilkanData
            // 
            this.btnTampilkanData.Location = new System.Drawing.Point(428, 12);
            this.btnTampilkanData.Name = "btnTampilkanData";
            this.btnTampilkanData.Size = new System.Drawing.Size(107, 76);
            this.btnTampilkanData.TabIndex = 42;
            this.btnTampilkanData.Text = "Tampilkan Data";
            this.btnTampilkanData.UseVisualStyleBackColor = true;
            this.btnTampilkanData.Click += new System.EventHandler(this.btnTampilakData_Click);
            // 
            // listLaporan
            // 
            this.listLaporan.HideSelection = false;
            this.listLaporan.Location = new System.Drawing.Point(0, 19);
            this.listLaporan.Name = "listLaporan";
            this.listLaporan.Size = new System.Drawing.Size(523, 309);
            this.listLaporan.TabIndex = 0;
            this.listLaporan.UseCompatibleStateImageBehavior = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listLaporan);
            this.groupBox1.Location = new System.Drawing.Point(12, 110);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(523, 328);
            this.groupBox1.TabIndex = 46;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Data Laporan";
            // 
            // FrmLaporan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnTampilkanData);
            this.Controls.Add(this.textIDPembayaran);
            this.Controls.Add(this.textNamaPelanggan);
            this.Controls.Add(this.radioButtonNama);
            this.Controls.Add(this.radioButtonID);
            this.Controls.Add(this.radioButtonSemua);
            this.Controls.Add(this.label2);
            this.Name = "FrmLaporan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Laporan Pembayaran";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioButtonSemua;
        private System.Windows.Forms.RadioButton radioButtonID;
        private System.Windows.Forms.RadioButton radioButtonNama;
        private System.Windows.Forms.TextBox textNamaPelanggan;
        private System.Windows.Forms.TextBox textIDPembayaran;
        private System.Windows.Forms.Button btnTampilkanData;
        private System.Windows.Forms.ListView listLaporan;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}