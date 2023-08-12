namespace Interface
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rTB_Code = new System.Windows.Forms.RichTextBox();
            this.cB_Action = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rTB_Code
            // 
            this.rTB_Code.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rTB_Code.BackColor = System.Drawing.Color.OldLace;
            this.rTB_Code.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rTB_Code.HideSelection = false;
            this.rTB_Code.Location = new System.Drawing.Point(35, 101);
            this.rTB_Code.Name = "rTB_Code";
            this.rTB_Code.Size = new System.Drawing.Size(837, 512);
            this.rTB_Code.TabIndex = 0;
            this.rTB_Code.Text = "";
            this.rTB_Code.WordWrap = false;
            // 
            // cB_Action
            // 
            this.cB_Action.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(229)))), ((int)(((byte)(190)))));
            this.cB_Action.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cB_Action.FormattingEnabled = true;
            this.cB_Action.Items.AddRange(new object[] {
            "Variable rename",
            "Method extraction",
            "Method rename",
            "Replace magic number"});
            this.cB_Action.Location = new System.Drawing.Point(35, 25);
            this.cB_Action.Name = "cB_Action";
            this.cB_Action.Size = new System.Drawing.Size(217, 36);
            this.cB_Action.TabIndex = 1;
            this.cB_Action.Text = "Refactor";
            this.cB_Action.SelectedIndexChanged += new System.EventHandler(this.cB_Action_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(35, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 28);
            this.label1.TabIndex = 4;
            this.label1.Text = "Your code";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(235)))), ((int)(((byte)(205)))));
            this.ClientSize = new System.Drawing.Size(908, 644);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cB_Action);
            this.Controls.Add(this.rTB_Code);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rTB_Code;
        private System.Windows.Forms.ComboBox cB_Action;
        private System.Windows.Forms.Label label1;
    }
}

