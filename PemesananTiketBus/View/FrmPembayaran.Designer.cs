
namespace PemesananTiketBus.View
{
    partial class FrmPembayaran
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
            this.textIDBayar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textIDTiket = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textNamaPelanggan = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dateBayar = new System.Windows.Forms.DateTimePicker();
            this.btnCariIDTiket = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textTotalBayar = new System.Windows.Forms.TextBox();
            this.btnBayar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listPembayaran = new System.Windows.Forms.ListView();
            this.btnLaporan = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textIDBayar
            // 
            this.textIDBayar.Location = new System.Drawing.Point(142, 12);
            this.textIDBayar.Name = "textIDBayar";
            this.textIDBayar.Size = new System.Drawing.Size(143, 20);
            this.textIDBayar.TabIndex = 34;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Leelawadee UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.TabIndex = 33;
            this.label1.Text = "ID Bayar";
            // 
            // textIDTiket
            // 
            this.textIDTiket.Location = new System.Drawing.Point(142, 84);
            this.textIDTiket.Name = "textIDTiket";
            this.textIDTiket.Size = new System.Drawing.Size(143, 20);
            this.textIDTiket.TabIndex = 36;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Leelawadee UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 20);
            this.label2.TabIndex = 35;
            this.label2.Text = "ID Tiket";
            // 
            // textNamaPelanggan
            // 
            this.textNamaPelanggan.Location = new System.Drawing.Point(142, 121);
            this.textNamaPelanggan.Name = "textNamaPelanggan";
            this.textNamaPelanggan.Size = new System.Drawing.Size(246, 20);
            this.textNamaPelanggan.TabIndex = 38;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Leelawadee UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 20);
            this.label3.TabIndex = 37;
            this.label3.Text = "Nama Pelanggan";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Leelawadee UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 20);
            this.label4.TabIndex = 39;
            this.label4.Text = "Tanggal Bayar";
            // 
            // dateBayar
            // 
            this.dateBayar.Location = new System.Drawing.Point(142, 48);
            this.dateBayar.Name = "dateBayar";
            this.dateBayar.Size = new System.Drawing.Size(200, 20);
            this.dateBayar.TabIndex = 40;
            // 
            // btnCariIDTiket
            // 
            this.btnCariIDTiket.Location = new System.Drawing.Point(313, 84);
            this.btnCariIDTiket.Name = "btnCariIDTiket";
            this.btnCariIDTiket.Size = new System.Drawing.Size(75, 23);
            this.btnCariIDTiket.TabIndex = 41;
            this.btnCariIDTiket.Text = "Cari";
            this.btnCariIDTiket.UseVisualStyleBackColor = true;
            this.btnCariIDTiket.Click += new System.EventHandler(this.btnCariIDTiket_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Leelawadee UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 20);
            this.label5.TabIndex = 42;
            this.label5.Text = "Total Bayar";
            // 
            // textTotalBayar
            // 
            this.textTotalBayar.Location = new System.Drawing.Point(142, 156);
            this.textTotalBayar.Name = "textTotalBayar";
            this.textTotalBayar.Size = new System.Drawing.Size(200, 20);
            this.textTotalBayar.TabIndex = 43;
            // 
            // btnBayar
            // 
            this.btnBayar.Location = new System.Drawing.Point(200, 200);
            this.btnBayar.Name = "btnBayar";
            this.btnBayar.Size = new System.Drawing.Size(127, 23);
            this.btnBayar.TabIndex = 44;
            this.btnBayar.Text = "Bayar";
            this.btnBayar.UseVisualStyleBackColor = true;
            this.btnBayar.Click += new System.EventHandler(this.btnBayar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listPembayaran);
            this.groupBox1.Location = new System.Drawing.Point(17, 233);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(484, 171);
            this.groupBox1.TabIndex = 45;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Data Pembayaran";
            // 
            // listPembayaran
            // 
            this.listPembayaran.HideSelection = false;
            this.listPembayaran.Location = new System.Drawing.Point(0, 19);
            this.listPembayaran.Name = "listPembayaran";
            this.listPembayaran.Size = new System.Drawing.Size(484, 152);
            this.listPembayaran.TabIndex = 0;
            this.listPembayaran.UseCompatibleStateImageBehavior = false;
            this.listPembayaran.SelectedIndexChanged += new System.EventHandler(this.listPembayaran_SelectedIndexChanged);
            // 
            // btnLaporan
            // 
            this.btnLaporan.Location = new System.Drawing.Point(230, 410);
            this.btnLaporan.Name = "btnLaporan";
            this.btnLaporan.Size = new System.Drawing.Size(75, 23);
            this.btnLaporan.TabIndex = 46;
            this.btnLaporan.Text = "Laporan";
            this.btnLaporan.UseVisualStyleBackColor = true;
            this.btnLaporan.Click += new System.EventHandler(this.btnLaporan_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(374, 200);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(127, 23);
            this.btnDelete.TabIndex = 47;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // FrmPembayaran
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 441);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnLaporan);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnBayar);
            this.Controls.Add(this.textTotalBayar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnCariIDTiket);
            this.Controls.Add(this.dateBayar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textNamaPelanggan);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textIDTiket);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textIDBayar);
            this.Controls.Add(this.label1);
            this.Name = "FrmPembayaran";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Pembayaran";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textIDBayar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textIDTiket;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textNamaPelanggan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateBayar;
        private System.Windows.Forms.Button btnCariIDTiket;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textTotalBayar;
        private System.Windows.Forms.Button btnBayar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnLaporan;
        private System.Windows.Forms.ListView listPembayaran;
        private System.Windows.Forms.Button btnDelete;
    }
}