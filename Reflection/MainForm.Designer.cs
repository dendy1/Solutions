namespace Reflection
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.openBTN = new System.Windows.Forms.Button();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.ClassesOutputListBox = new System.Windows.Forms.ListBox();
            this.MethodsOutputListVox = new System.Windows.Forms.ListBox();
            this.methodBTN = new System.Windows.Forms.Button();
            this.createObjectBTN = new System.Windows.Forms.Button();
            this.objectListBox = new System.Windows.Forms.ListBox();
            this.currentObjectInfo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // openBTN
            // 
            this.openBTN.Location = new System.Drawing.Point(569, 38);
            this.openBTN.Margin = new System.Windows.Forms.Padding(2);
            this.openBTN.Name = "openBTN";
            this.openBTN.Size = new System.Drawing.Size(119, 47);
            this.openBTN.TabIndex = 0;
            this.openBTN.Text = "Открыть библиотеку";
            this.openBTN.UseVisualStyleBackColor = true;
            this.openBTN.Click += new System.EventHandler(this.openBTN_Click);
            // 
            // ofd
            // 
            this.ofd.DefaultExt = "dll";
            this.ofd.FileName = "Библиотека";
            // 
            // ClassesOutputListBox
            // 
            this.ClassesOutputListBox.FormattingEnabled = true;
            this.ClassesOutputListBox.Location = new System.Drawing.Point(12, 24);
            this.ClassesOutputListBox.Name = "ClassesOutputListBox";
            this.ClassesOutputListBox.Size = new System.Drawing.Size(184, 173);
            this.ClassesOutputListBox.TabIndex = 3;
            this.ClassesOutputListBox.SelectedIndexChanged += new System.EventHandler(this.OutputListBox_SelectedIndexChanged);
            // 
            // MethodsOutputListVox
            // 
            this.MethodsOutputListVox.FormattingEnabled = true;
            this.MethodsOutputListVox.Location = new System.Drawing.Point(202, 24);
            this.MethodsOutputListVox.Name = "MethodsOutputListVox";
            this.MethodsOutputListVox.Size = new System.Drawing.Size(339, 173);
            this.MethodsOutputListVox.TabIndex = 4;
            // 
            // methodBTN
            // 
            this.methodBTN.Location = new System.Drawing.Point(250, 238);
            this.methodBTN.Name = "methodBTN";
            this.methodBTN.Size = new System.Drawing.Size(156, 39);
            this.methodBTN.TabIndex = 5;
            this.methodBTN.Text = "Выполнить метод";
            this.methodBTN.UseVisualStyleBackColor = true;
            this.methodBTN.Click += new System.EventHandler(this.methodBTN_Click);
            // 
            // createObjectBTN
            // 
            this.createObjectBTN.Location = new System.Drawing.Point(547, 90);
            this.createObjectBTN.Name = "createObjectBTN";
            this.createObjectBTN.Size = new System.Drawing.Size(156, 39);
            this.createObjectBTN.TabIndex = 7;
            this.createObjectBTN.Text = "Создать экземпляр класса";
            this.createObjectBTN.UseVisualStyleBackColor = true;
            this.createObjectBTN.Click += new System.EventHandler(this.createObjectBTN_Click);
            // 
            // objectListBox
            // 
            this.objectListBox.FormattingEnabled = true;
            this.objectListBox.Location = new System.Drawing.Point(12, 238);
            this.objectListBox.Name = "objectListBox";
            this.objectListBox.Size = new System.Drawing.Size(219, 173);
            this.objectListBox.TabIndex = 8;
            this.objectListBox.SelectedIndexChanged += new System.EventHandler(this.objectListBox_SelectedIndexChanged);
            // 
            // currentObjectInfo
            // 
            this.currentObjectInfo.Location = new System.Drawing.Point(426, 238);
            this.currentObjectInfo.Multiline = true;
            this.currentObjectInfo.Name = "currentObjectInfo";
            this.currentObjectInfo.Size = new System.Drawing.Size(277, 173);
            this.currentObjectInfo.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(79, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Классы";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(359, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Методы";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(63, 222);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Созданные объекты";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(507, 222);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Информация об объекте";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.currentObjectInfo);
            this.Controls.Add(this.objectListBox);
            this.Controls.Add(this.createObjectBTN);
            this.Controls.Add(this.methodBTN);
            this.Controls.Add(this.MethodsOutputListVox);
            this.Controls.Add(this.ClassesOutputListBox);
            this.Controls.Add(this.openBTN);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button openBTN;
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.ListBox ClassesOutputListBox;
        private System.Windows.Forms.ListBox MethodsOutputListVox;
        private System.Windows.Forms.Button methodBTN;
        private System.Windows.Forms.Button createObjectBTN;
        private System.Windows.Forms.ListBox objectListBox;
        private System.Windows.Forms.TextBox currentObjectInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

