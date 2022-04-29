namespace Kyrsach.Forms.FormSdelka
{
    partial class FormAddSdelka
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
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnChenge = new System.Windows.Forms.Button();
            this.cbNameFlower = new System.Windows.Forms.ComboBox();
            this.tbPryse = new System.Windows.Forms.TextBox();
            this.tbKolichestvo = new System.Windows.Forms.TextBox();
            this.cbProdovec = new System.Windows.Forms.ComboBox();
            this.tbSumm = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbTime = new System.Windows.Forms.TextBox();
            this.tbP_Name = new System.Windows.Forms.TextBox();
            this.tbP_Familaya = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(3, 280);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(207, 28);
            this.label6.TabIndex = 35;
            this.label6.Text = "Фамилия продовца";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(3, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(223, 28);
            this.label4.TabIndex = 32;
            this.label4.Text = "Фамилия покупателя";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(3, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 28);
            this.label3.TabIndex = 31;
            this.label3.Text = "Количество";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(3, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 28);
            this.label2.TabIndex = 30;
            this.label2.Text = "Цена за 1 шт.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(3, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(180, 28);
            this.label5.TabIndex = 29;
            this.label5.Text = "Название товара";
            // 
            // btnChenge
            // 
            this.btnChenge.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnChenge.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnChenge.FlatAppearance.BorderSize = 0;
            this.btnChenge.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChenge.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnChenge.Location = new System.Drawing.Point(0, 403);
            this.btnChenge.Name = "btnChenge";
            this.btnChenge.Size = new System.Drawing.Size(532, 67);
            this.btnChenge.TabIndex = 26;
            this.btnChenge.Text = "Добавить";
            this.btnChenge.UseVisualStyleBackColor = false;
            this.btnChenge.Click += new System.EventHandler(this.btnChenge_Click);
            // 
            // cbNameFlower
            // 
            this.cbNameFlower.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbNameFlower.FormattingEnabled = true;
            this.cbNameFlower.Location = new System.Drawing.Point(322, 73);
            this.cbNameFlower.Name = "cbNameFlower";
            this.cbNameFlower.Size = new System.Drawing.Size(201, 33);
            this.cbNameFlower.TabIndex = 36;
            this.cbNameFlower.SelectedIndexChanged += new System.EventHandler(this.cbNameFlower_SelectedIndexChanged);
            this.cbNameFlower.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbNameFlower_KeyDown);
            // 
            // tbPryse
            // 
            this.tbPryse.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbPryse.Location = new System.Drawing.Point(322, 112);
            this.tbPryse.Name = "tbPryse";
            this.tbPryse.Size = new System.Drawing.Size(201, 34);
            this.tbPryse.TabIndex = 37;
            // 
            // tbKolichestvo
            // 
            this.tbKolichestvo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbKolichestvo.Location = new System.Drawing.Point(322, 152);
            this.tbKolichestvo.Name = "tbKolichestvo";
            this.tbKolichestvo.Size = new System.Drawing.Size(201, 34);
            this.tbKolichestvo.TabIndex = 38;
            this.tbKolichestvo.TextChanged += new System.EventHandler(this.tbKolichestvo_TextChanged);
            this.tbKolichestvo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbKolichestvo_KeyDown);
            this.tbKolichestvo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbKolichestvo_KeyPress);
            // 
            // cbProdovec
            // 
            this.cbProdovec.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbProdovec.FormattingEnabled = true;
            this.cbProdovec.Location = new System.Drawing.Point(322, 272);
            this.cbProdovec.Name = "cbProdovec";
            this.cbProdovec.Size = new System.Drawing.Size(201, 36);
            this.cbProdovec.TabIndex = 40;
            this.cbProdovec.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbProdovec_KeyDown);
            // 
            // tbSumm
            // 
            this.tbSumm.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbSumm.Location = new System.Drawing.Point(322, 314);
            this.tbSumm.Name = "tbSumm";
            this.tbSumm.Size = new System.Drawing.Size(201, 34);
            this.tbSumm.TabIndex = 41;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 317);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 28);
            this.label1.TabIndex = 42;
            this.label1.Text = "Итоговая цена";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Cyan;
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(532, 45);
            this.panel1.TabIndex = 44;
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.ForeColor = System.Drawing.Color.Blue;
            this.button2.Location = new System.Drawing.Point(459, -10);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(27, 34);
            this.button2.TabIndex = 14;
            this.button2.Text = "o";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.button1.Location = new System.Drawing.Point(482, -10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(27, 34);
            this.button1.TabIndex = 13;
            this.button1.Text = "o";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnClose.ForeColor = System.Drawing.Color.Red;
            this.btnClose.Location = new System.Drawing.Point(505, -10);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(27, 34);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "o";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(158, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(207, 28);
            this.label7.TabIndex = 0;
            this.label7.Text = "Добавление сделку";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(3, 354);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(221, 28);
            this.label8.TabIndex = 45;
            this.label8.Text = "Дата и время сделки";
            // 
            // tbTime
            // 
            this.tbTime.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbTime.Location = new System.Drawing.Point(322, 357);
            this.tbTime.Name = "tbTime";
            this.tbTime.Size = new System.Drawing.Size(201, 34);
            this.tbTime.TabIndex = 46;
            this.tbTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbTime_KeyPress);
            // 
            // tbP_Name
            // 
            this.tbP_Name.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbP_Name.Location = new System.Drawing.Point(322, 232);
            this.tbP_Name.Name = "tbP_Name";
            this.tbP_Name.Size = new System.Drawing.Size(201, 34);
            this.tbP_Name.TabIndex = 47;
            this.tbP_Name.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbP_Name_KeyDown);
            this.tbP_Name.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbP_Name_KeyPress);
            // 
            // tbP_Familaya
            // 
            this.tbP_Familaya.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbP_Familaya.Location = new System.Drawing.Point(322, 192);
            this.tbP_Familaya.Name = "tbP_Familaya";
            this.tbP_Familaya.Size = new System.Drawing.Size(201, 34);
            this.tbP_Familaya.TabIndex = 48;
            this.tbP_Familaya.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbP_Familaya_KeyDown);
            this.tbP_Familaya.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbP_Familaya_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(3, 235);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(0, 28);
            this.label9.TabIndex = 49;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(3, 238);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(173, 28);
            this.label10.TabIndex = 50;
            this.label10.Text = "Имя покупателя";
            // 
            // FormAddSdelka
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 470);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tbP_Familaya);
            this.Controls.Add(this.tbP_Name);
            this.Controls.Add(this.tbTime);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbSumm);
            this.Controls.Add(this.cbProdovec);
            this.Controls.Add(this.tbKolichestvo);
            this.Controls.Add(this.tbPryse);
            this.Controls.Add(this.cbNameFlower);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnChenge);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormAddSdelka";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormAddSdelka";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnChenge;
        private System.Windows.Forms.ComboBox cbNameFlower;
        private System.Windows.Forms.TextBox tbPryse;
        private System.Windows.Forms.TextBox tbKolichestvo;
        private System.Windows.Forms.ComboBox cbProdovec;
        private System.Windows.Forms.TextBox tbSumm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbTime;
        private System.Windows.Forms.TextBox tbP_Name;
        private System.Windows.Forms.TextBox tbP_Familaya;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
    }
}