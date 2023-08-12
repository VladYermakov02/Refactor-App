namespace Interface
{
    partial class Form2
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
            this.lText = new System.Windows.Forms.Label();
            this.rTBText = new System.Windows.Forms.RichTextBox();
            this.lNewName = new System.Windows.Forms.Label();
            this.rTBNewName = new System.Windows.Forms.RichTextBox();
            this.bRefactor = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lText
            // 
            this.lText.AutoSize = true;
            this.lText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lText.Location = new System.Drawing.Point(35, 18);
            this.lText.Name = "lText";
            this.lText.Size = new System.Drawing.Size(65, 28);
            this.lText.TabIndex = 0;
            this.lText.Text = "label1";
            // 
            // rTBText
            // 
            this.rTBText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rTBText.BackColor = System.Drawing.Color.OldLace;
            this.rTBText.Location = new System.Drawing.Point(35, 51);
            this.rTBText.Name = "rTBText";
            this.rTBText.Size = new System.Drawing.Size(351, 88);
            this.rTBText.TabIndex = 1;
            this.rTBText.Text = "";
            // 
            // lNewName
            // 
            this.lNewName.AutoSize = true;
            this.lNewName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lNewName.Location = new System.Drawing.Point(35, 179);
            this.lNewName.Name = "lNewName";
            this.lNewName.Size = new System.Drawing.Size(65, 28);
            this.lNewName.TabIndex = 0;
            this.lNewName.Text = "label1";
            // 
            // rTBNewName
            // 
            this.rTBNewName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rTBNewName.BackColor = System.Drawing.Color.OldLace;
            this.rTBNewName.Location = new System.Drawing.Point(35, 213);
            this.rTBNewName.Name = "rTBNewName";
            this.rTBNewName.Size = new System.Drawing.Size(351, 88);
            this.rTBNewName.TabIndex = 1;
            this.rTBNewName.Text = "";
            // 
            // bRefactor
            // 
            this.bRefactor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bRefactor.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bRefactor.Location = new System.Drawing.Point(260, 336);
            this.bRefactor.Name = "bRefactor";
            this.bRefactor.Size = new System.Drawing.Size(126, 37);
            this.bRefactor.TabIndex = 2;
            this.bRefactor.Text = "Refactor";
            this.bRefactor.UseVisualStyleBackColor = true;
            this.bRefactor.Click += new System.EventHandler(this.bRefactor_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(235)))), ((int)(((byte)(205)))));
            this.ClientSize = new System.Drawing.Size(421, 385);
            this.Controls.Add(this.bRefactor);
            this.Controls.Add(this.rTBNewName);
            this.Controls.Add(this.lNewName);
            this.Controls.Add(this.rTBText);
            this.Controls.Add(this.lText);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lText;
        private System.Windows.Forms.RichTextBox rTBText;
        private System.Windows.Forms.Label lNewName;
        private System.Windows.Forms.RichTextBox rTBNewName;
        private System.Windows.Forms.Button bRefactor;
    }
}