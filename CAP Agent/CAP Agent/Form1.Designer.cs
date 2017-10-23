namespace CAP_Agent
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
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
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.HostIP = new System.Windows.Forms.Label();
            this.HostName = new System.Windows.Forms.Label();
            this.HostOS = new System.Windows.Forms.Label();
            this.CoreCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.UserDomain = new System.Windows.Forms.Label();
            this.UserName = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.MS_Office = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ServiceTag = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.PCModel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // HostIP
            // 
            this.HostIP.AutoSize = true;
            this.HostIP.Location = new System.Drawing.Point(144, 49);
            this.HostIP.Name = "HostIP";
            this.HostIP.Size = new System.Drawing.Size(53, 17);
            this.HostIP.TabIndex = 0;
            this.HostIP.Text = "Host IP";
            // 
            // HostName
            // 
            this.HostName.AutoSize = true;
            this.HostName.Location = new System.Drawing.Point(144, 23);
            this.HostName.Name = "HostName";
            this.HostName.Size = new System.Drawing.Size(78, 17);
            this.HostName.TabIndex = 1;
            this.HostName.Text = "Host Name";
            // 
            // HostOS
            // 
            this.HostOS.AutoSize = true;
            this.HostOS.Location = new System.Drawing.Point(144, 75);
            this.HostOS.Name = "HostOS";
            this.HostOS.Size = new System.Drawing.Size(61, 17);
            this.HostOS.TabIndex = 2;
            this.HostOS.Text = "Host OS";
            // 
            // CoreCount
            // 
            this.CoreCount.AutoSize = true;
            this.CoreCount.Location = new System.Drawing.Point(143, 103);
            this.CoreCount.Name = "CoreCount";
            this.CoreCount.Size = new System.Drawing.Size(79, 17);
            this.CoreCount.TabIndex = 3;
            this.CoreCount.Text = "Core Count";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Host Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Host IP:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Host OS:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Core Count:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "User Domain:";
            // 
            // UserDomain
            // 
            this.UserDomain.AutoSize = true;
            this.UserDomain.Location = new System.Drawing.Point(144, 131);
            this.UserDomain.Name = "UserDomain";
            this.UserDomain.Size = new System.Drawing.Size(90, 17);
            this.UserDomain.TabIndex = 8;
            this.UserDomain.Text = "User Domain";
            // 
            // UserName
            // 
            this.UserName.AutoSize = true;
            this.UserName.Location = new System.Drawing.Point(144, 157);
            this.UserName.Name = "UserName";
            this.UserName.Size = new System.Drawing.Size(79, 17);
            this.UserName.TabIndex = 10;
            this.UserName.Text = "User Name";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(38, 157);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "User Name:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(38, 242);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 17);
            this.label7.TabIndex = 14;
            this.label7.Text = "MS Office:";
            // 
            // MS_Office
            // 
            this.MS_Office.FormattingEnabled = true;
            this.MS_Office.HorizontalScrollbar = true;
            this.MS_Office.ItemHeight = 16;
            this.MS_Office.Location = new System.Drawing.Point(146, 242);
            this.MS_Office.Name = "MS_Office";
            this.MS_Office.ScrollAlwaysVisible = true;
            this.MS_Office.Size = new System.Drawing.Size(328, 148);
            this.MS_Office.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(38, 184);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 17);
            this.label8.TabIndex = 17;
            this.label8.Text = "Service Tag:";
            // 
            // ServiceTag
            // 
            this.ServiceTag.AutoSize = true;
            this.ServiceTag.Location = new System.Drawing.Point(144, 184);
            this.ServiceTag.Name = "ServiceTag";
            this.ServiceTag.Size = new System.Drawing.Size(80, 17);
            this.ServiceTag.TabIndex = 16;
            this.ServiceTag.Text = "ServiceTag";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(38, 211);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 17);
            this.label9.TabIndex = 19;
            this.label9.Text = "PC Model:";
            // 
            // PCModel
            // 
            this.PCModel.AutoSize = true;
            this.PCModel.Location = new System.Drawing.Point(144, 211);
            this.PCModel.Name = "PCModel";
            this.PCModel.Size = new System.Drawing.Size(64, 17);
            this.PCModel.TabIndex = 18;
            this.PCModel.Text = "PCModel";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 413);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.PCModel);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.ServiceTag);
            this.Controls.Add(this.MS_Office);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.UserName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.UserDomain);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CoreCount);
            this.Controls.Add(this.HostOS);
            this.Controls.Add(this.HostName);
            this.Controls.Add(this.HostIP);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label HostIP;
        private System.Windows.Forms.Label HostName;
        private System.Windows.Forms.Label HostOS;
        private System.Windows.Forms.Label CoreCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label UserDomain;
        private System.Windows.Forms.Label UserName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox MS_Office;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label ServiceTag;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label PCModel;
    }
}

