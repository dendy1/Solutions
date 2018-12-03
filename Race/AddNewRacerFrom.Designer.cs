namespace Race
{
    partial class AddNewRacerFrom
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
            this.NameComboBox = new System.Windows.Forms.ComboBox();
            this.ОКButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // NameComboBox
            // 
            this.NameComboBox.FormattingEnabled = true;
            this.NameComboBox.Items.AddRange(new object[] {
            "RedBull",
            "ForceIndia",
            "Mercedes",
            "Ferrari",
            "Renault"});
            this.NameComboBox.Location = new System.Drawing.Point(12, 12);
            this.NameComboBox.Name = "NameComboBox";
            this.NameComboBox.Size = new System.Drawing.Size(121, 24);
            this.NameComboBox.TabIndex = 1;
            this.NameComboBox.Text = "Название";
            // 
            // ОКButton
            // 
            this.ОКButton.Location = new System.Drawing.Point(35, 53);
            this.ОКButton.Name = "ОКButton";
            this.ОКButton.Size = new System.Drawing.Size(75, 23);
            this.ОКButton.TabIndex = 2;
            this.ОКButton.Text = "OK";
            this.ОКButton.UseVisualStyleBackColor = true;
            this.ОКButton.Click += new System.EventHandler(this.ОКButton_Click);
            // 
            // AddNewRacerFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(156, 91);
            this.Controls.Add(this.ОКButton);
            this.Controls.Add(this.NameComboBox);
            this.Name = "AddNewRacerFrom";
            this.Text = "Добавить нового участника";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox NameComboBox;
        private System.Windows.Forms.Button ОКButton;
    }
}