
namespace GifReader
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
            this.processBtn = new System.Windows.Forms.Button();
            this.filePathTxtInput = new System.Windows.Forms.TextBox();
            this.outputBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // processBtn
            // 
            this.processBtn.Location = new System.Drawing.Point(495, 76);
            this.processBtn.Name = "processBtn";
            this.processBtn.Size = new System.Drawing.Size(130, 29);
            this.processBtn.TabIndex = 0;
            this.processBtn.Text = "معالجة الملف";
            this.processBtn.UseVisualStyleBackColor = true;
            this.processBtn.Click += new System.EventHandler(this.processBtn_Click);
            // 
            // filePathTxtInput
            // 
            this.filePathTxtInput.Location = new System.Drawing.Point(38, 78);
            this.filePathTxtInput.Name = "filePathTxtInput";
            this.filePathTxtInput.Size = new System.Drawing.Size(393, 27);
            this.filePathTxtInput.TabIndex = 1;
            // 
            // outputBox
            // 
            this.outputBox.Location = new System.Drawing.Point(38, 129);
            this.outputBox.Multiline = true;
            this.outputBox.Name = "outputBox";
            this.outputBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.outputBox.Size = new System.Drawing.Size(393, 347);
            this.outputBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(348, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "مسار الملف";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 515);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.outputBox);
            this.Controls.Add(this.filePathTxtInput);
            this.Controls.Add(this.processBtn);
            this.Name = "Form1";
            this.Text = "Gif Reader";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button processBtn;
        private System.Windows.Forms.TextBox filePathTxtInput;
        private System.Windows.Forms.TextBox outputBox;
        private System.Windows.Forms.Label label1;
    }
}

