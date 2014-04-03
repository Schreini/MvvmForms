namespace MvvmWinForms.Example
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.TxtDate = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.TxtDate2 = new System.Windows.Forms.TextBox();
            this.LblDate = new System.Windows.Forms.Label();
            this.CbxEmpty = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // TxtDate
            // 
            this.TxtDate.Location = new System.Drawing.Point(13, 13);
            this.TxtDate.Name = "TxtDate";
            this.TxtDate.Size = new System.Drawing.Size(100, 20);
            this.TxtDate.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(291, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TxtDate2
            // 
            this.TxtDate2.Location = new System.Drawing.Point(13, 65);
            this.TxtDate2.Name = "TxtDate2";
            this.TxtDate2.Size = new System.Drawing.Size(100, 20);
            this.TxtDate2.TabIndex = 2;
            // 
            // LblDate
            // 
            this.LblDate.AutoSize = true;
            this.LblDate.Location = new System.Drawing.Point(13, 114);
            this.LblDate.Name = "LblDate";
            this.LblDate.Size = new System.Drawing.Size(0, 13);
            this.LblDate.TabIndex = 3;
            // 
            // CbxEmpty
            // 
            this.CbxEmpty.AutoSize = true;
            this.CbxEmpty.Location = new System.Drawing.Point(16, 190);
            this.CbxEmpty.Name = "CbxEmpty";
            this.CbxEmpty.Size = new System.Drawing.Size(55, 17);
            this.CbxEmpty.TabIndex = 4;
            this.CbxEmpty.Text = "Empty";
            this.CbxEmpty.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 253);
            this.Controls.Add(this.CbxEmpty);
            this.Controls.Add(this.LblDate);
            this.Controls.Add(this.TxtDate2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TxtDate);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtDate;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox TxtDate2;
        private System.Windows.Forms.Label LblDate;
        private System.Windows.Forms.CheckBox CbxEmpty;
    }
}

