﻿namespace AduanaShipping
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Server_Start = new System.Windows.Forms.Button();
            this.Server_Stop = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.Up_Since = new System.Windows.Forms.Label();
            this.HangFS = new System.Windows.Forms.CheckBox();
            this.Procced = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.FSTI_Trans = new System.Windows.Forms.Button();
            this.FSTI_CloseClient = new System.Windows.Forms.Button();
            this.FSTI_Login = new System.Windows.Forms.Button();
            this.FSTI_Ini = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.textConfig = new System.Windows.Forms.TextBox();
            this.FS_Pass = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.FS_User = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.listResult = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(4, 4);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(915, 476);
            this.dataGridView1.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Server_Start
            // 
            this.Server_Start.Enabled = false;
            this.Server_Start.Location = new System.Drawing.Point(27, 305);
            this.Server_Start.Margin = new System.Windows.Forms.Padding(4);
            this.Server_Start.Name = "Server_Start";
            this.Server_Start.Size = new System.Drawing.Size(100, 28);
            this.Server_Start.TabIndex = 1;
            this.Server_Start.Text = "Start";
            this.Server_Start.UseVisualStyleBackColor = true;
            this.Server_Start.Click += new System.EventHandler(this.button1_Click);
            // 
            // Server_Stop
            // 
            this.Server_Stop.Enabled = false;
            this.Server_Stop.Location = new System.Drawing.Point(135, 305);
            this.Server_Stop.Margin = new System.Windows.Forms.Padding(4);
            this.Server_Stop.Name = "Server_Stop";
            this.Server_Stop.Size = new System.Drawing.Size(100, 28);
            this.Server_Stop.TabIndex = 2;
            this.Server_Stop.Text = "Stop";
            this.Server_Stop.UseVisualStyleBackColor = true;
            this.Server_Stop.Click += new System.EventHandler(this.button2_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(931, 513);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.Up_Since);
            this.tabPage1.Controls.Add(this.HangFS);
            this.tabPage1.Controls.Add(this.Procced);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.FSTI_Trans);
            this.tabPage1.Controls.Add(this.FSTI_CloseClient);
            this.tabPage1.Controls.Add(this.FSTI_Login);
            this.tabPage1.Controls.Add(this.FSTI_Ini);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.textConfig);
            this.tabPage1.Controls.Add(this.FS_Pass);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.FS_User);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.Server_Stop);
            this.tabPage1.Controls.Add(this.Server_Start);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(923, 484);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Server Configuraton";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(617, 58);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(153, 35);
            this.button1.TabIndex = 33;
            this.button1.Text = "Clear Log";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Up_Since
            // 
            this.Up_Since.AutoSize = true;
            this.Up_Since.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Up_Since.Location = new System.Drawing.Point(614, 24);
            this.Up_Since.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Up_Since.Name = "Up_Since";
            this.Up_Since.Size = new System.Drawing.Size(165, 17);
            this.Up_Since.TabIndex = 20;
            this.Up_Since.Text = "Up Since: 06/03/1987";
            // 
            // HangFS
            // 
            this.HangFS.AutoSize = true;
            this.HangFS.Enabled = false;
            this.HangFS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HangFS.Location = new System.Drawing.Point(27, 203);
            this.HangFS.Margin = new System.Windows.Forms.Padding(4);
            this.HangFS.Name = "HangFS";
            this.HangFS.Size = new System.Drawing.Size(221, 21);
            this.HangFS.TabIndex = 19;
            this.HangFS.Text = "STAY CONNECTED TO FS";
            this.HangFS.UseVisualStyleBackColor = true;
            // 
            // Procced
            // 
            this.Procced.AutoSize = true;
            this.Procced.Enabled = false;
            this.Procced.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Procced.Location = new System.Drawing.Point(148, 395);
            this.Procced.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Procced.Name = "Procced";
            this.Procced.Size = new System.Drawing.Size(0, 20);
            this.Procced.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Enabled = false;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(23, 351);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(163, 20);
            this.label6.TabIndex = 17;
            this.label6.Text = "FSTI Transactions";
            // 
            // FSTI_Trans
            // 
            this.FSTI_Trans.Enabled = false;
            this.FSTI_Trans.Location = new System.Drawing.Point(27, 391);
            this.FSTI_Trans.Margin = new System.Windows.Forms.Padding(4);
            this.FSTI_Trans.Name = "FSTI_Trans";
            this.FSTI_Trans.Size = new System.Drawing.Size(100, 28);
            this.FSTI_Trans.TabIndex = 16;
            this.FSTI_Trans.Text = "Proceed";
            this.FSTI_Trans.UseVisualStyleBackColor = true;
            this.FSTI_Trans.Click += new System.EventHandler(this.FSTI_Trans_Click);
            // 
            // FSTI_CloseClient
            // 
            this.FSTI_CloseClient.Enabled = false;
            this.FSTI_CloseClient.Location = new System.Drawing.Point(243, 231);
            this.FSTI_CloseClient.Margin = new System.Windows.Forms.Padding(4);
            this.FSTI_CloseClient.Name = "FSTI_CloseClient";
            this.FSTI_CloseClient.Size = new System.Drawing.Size(100, 28);
            this.FSTI_CloseClient.TabIndex = 15;
            this.FSTI_CloseClient.Text = "Close Client";
            this.FSTI_CloseClient.UseVisualStyleBackColor = true;
            this.FSTI_CloseClient.Visible = false;
            this.FSTI_CloseClient.Click += new System.EventHandler(this.FSTI_CloseClient_Click);
            // 
            // FSTI_Login
            // 
            this.FSTI_Login.Enabled = false;
            this.FSTI_Login.Location = new System.Drawing.Point(135, 231);
            this.FSTI_Login.Margin = new System.Windows.Forms.Padding(4);
            this.FSTI_Login.Name = "FSTI_Login";
            this.FSTI_Login.Size = new System.Drawing.Size(100, 28);
            this.FSTI_Login.TabIndex = 14;
            this.FSTI_Login.Text = "Login";
            this.FSTI_Login.UseVisualStyleBackColor = true;
            this.FSTI_Login.Visible = false;
            this.FSTI_Login.Click += new System.EventHandler(this.FSTI_Login_Click);
            // 
            // FSTI_Ini
            // 
            this.FSTI_Ini.Enabled = false;
            this.FSTI_Ini.Location = new System.Drawing.Point(27, 231);
            this.FSTI_Ini.Margin = new System.Windows.Forms.Padding(4);
            this.FSTI_Ini.Name = "FSTI_Ini";
            this.FSTI_Ini.Size = new System.Drawing.Size(100, 28);
            this.FSTI_Ini.TabIndex = 13;
            this.FSTI_Ini.Text = "Initialize";
            this.FSTI_Ini.UseVisualStyleBackColor = true;
            this.FSTI_Ini.Visible = false;
            this.FSTI_Ini.Click += new System.EventHandler(this.FSTI_Ini_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(23, 166);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(221, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "FSTI Client Configuration";
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(740, 119);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(39, 28);
            this.button3.TabIndex = 11;
            this.button3.Text = "...";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textConfig
            // 
            this.textConfig.Enabled = false;
            this.textConfig.Location = new System.Drawing.Point(113, 122);
            this.textConfig.Margin = new System.Windows.Forms.Padding(4);
            this.textConfig.Name = "textConfig";
            this.textConfig.Size = new System.Drawing.Size(617, 22);
            this.textConfig.TabIndex = 10;
            this.textConfig.Text = "m:\\mfgsys\\fs.cfg";
            // 
            // FS_Pass
            // 
            this.FS_Pass.Location = new System.Drawing.Point(113, 90);
            this.FS_Pass.Margin = new System.Windows.Forms.Padding(4);
            this.FS_Pass.Name = "FS_Pass";
            this.FS_Pass.Size = new System.Drawing.Size(132, 22);
            this.FS_Pass.TabIndex = 8;
            this.FS_Pass.Text = "fstiapp";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 94);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Password:";
            // 
            // FS_User
            // 
            this.FS_User.Location = new System.Drawing.Point(113, 58);
            this.FS_User.Margin = new System.Windows.Forms.Padding(4);
            this.FS_User.Name = "FS_User";
            this.FS_User.Size = new System.Drawing.Size(132, 22);
            this.FS_User.TabIndex = 6;
            this.FS_User.Text = "IMPT";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 62);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "User:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 21);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(216, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Forth Shift Configuration";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 274);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Server Status";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridView1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(923, 484);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Pending Item Movements";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.listResult);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage3.Size = new System.Drawing.Size(923, 484);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "History Movements";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // listResult
            // 
            this.listResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listResult.FormattingEnabled = true;
            this.listResult.HorizontalScrollbar = true;
            this.listResult.ItemHeight = 16;
            this.listResult.Location = new System.Drawing.Point(4, 4);
            this.listResult.Margin = new System.Windows.Forms.Padding(4);
            this.listResult.Name = "listResult";
            this.listResult.Size = new System.Drawing.Size(915, 476);
            this.listResult.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 513);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Customs - Shipping Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button Server_Start;
        private System.Windows.Forms.Button Server_Stop;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox FS_User;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textConfig;
        ////private System.Windows.Forms.Label CFG_File;
        private System.Windows.Forms.TextBox FS_Pass;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button FSTI_Ini;
        private System.Windows.Forms.Button FSTI_Login;
        private System.Windows.Forms.Button FSTI_CloseClient;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ListBox listResult;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button FSTI_Trans;
        private System.Windows.Forms.Label Procced;
        private System.Windows.Forms.CheckBox HangFS;
        private System.Windows.Forms.Label Up_Since;
        private System.Windows.Forms.Button button1;
    }
}
