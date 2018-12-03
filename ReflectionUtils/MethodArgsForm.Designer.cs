namespace ReflectionUtils
{
    partial class MethodArgsForm
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
            this.OKBTN = new System.Windows.Forms.Button();
            this.InputTextBox = new System.Windows.Forms.TextBox();
            this.MethodsListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // OKBTN
            // 
            this.OKBTN.Location = new System.Drawing.Point(361, 74);
            this.OKBTN.Name = "OKBTN";
            this.OKBTN.Size = new System.Drawing.Size(75, 23);
            this.OKBTN.TabIndex = 5;
            this.OKBTN.Text = "OK";
            this.OKBTN.UseVisualStyleBackColor = true;
            this.OKBTN.Click += new System.EventHandler(this.OKBTN_Click);
            // 
            // InputTextBox
            // 
            this.InputTextBox.Location = new System.Drawing.Point(12, 48);
            this.InputTextBox.Name = "InputTextBox";
            this.InputTextBox.Size = new System.Drawing.Size(776, 20);
            this.InputTextBox.TabIndex = 4;
            // 
            // MethodsListBox
            // 
            this.MethodsListBox.FormattingEnabled = true;
            this.MethodsListBox.Location = new System.Drawing.Point(12, 12);
            this.MethodsListBox.Name = "MethodsListBox";
            this.MethodsListBox.Size = new System.Drawing.Size(776, 30);
            this.MethodsListBox.TabIndex = 3;
            // 
            // MethodArgsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 103);
            this.Controls.Add(this.OKBTN);
            this.Controls.Add(this.InputTextBox);
            this.Controls.Add(this.MethodsListBox);
            this.Name = "MethodArgsForm";
            this.Text = "Вводите аргументы через запятую!";
            this.Load += new System.EventHandler(this.MethodArgsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OKBTN;
        private System.Windows.Forms.TextBox InputTextBox;
        private System.Windows.Forms.ListBox MethodsListBox;
    }
}