namespace RaceTask5
{
    partial class FormMain
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.новаяГонкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.остановитьГонкуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьНовогоУчастникаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавить4УчастникаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.очиститьУчастниковToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изменитьРазмерыТрассыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.новаяГонкаToolStripMenuItem,
            this.остановитьГонкуToolStripMenuItem,
            this.добавитьНовогоУчастникаToolStripMenuItem,
            this.добавить4УчастникаToolStripMenuItem,
            this.очиститьУчастниковToolStripMenuItem,
            this.изменитьРазмерыТрассыToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1149, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // новаяГонкаToolStripMenuItem
            // 
            this.новаяГонкаToolStripMenuItem.Name = "новаяГонкаToolStripMenuItem";
            this.новаяГонкаToolStripMenuItem.Size = new System.Drawing.Size(108, 24);
            this.новаяГонкаToolStripMenuItem.Text = "Новая гонка";
            this.новаяГонкаToolStripMenuItem.Click += new System.EventHandler(this.новаяГонкаToolStripMenuItem_Click);
            // 
            // остановитьГонкуToolStripMenuItem
            // 
            this.остановитьГонкуToolStripMenuItem.Name = "остановитьГонкуToolStripMenuItem";
            this.остановитьГонкуToolStripMenuItem.Size = new System.Drawing.Size(144, 24);
            this.остановитьГонкуToolStripMenuItem.Text = "Остановить гонку";
            this.остановитьГонкуToolStripMenuItem.Click += new System.EventHandler(this.остановитьГонкуToolStripMenuItem_Click);
            // 
            // добавитьНовогоУчастникаToolStripMenuItem
            // 
            this.добавитьНовогоУчастникаToolStripMenuItem.Name = "добавитьНовогоУчастникаToolStripMenuItem";
            this.добавитьНовогоУчастникаToolStripMenuItem.Size = new System.Drawing.Size(215, 24);
            this.добавитьНовогоУчастникаToolStripMenuItem.Text = "Добавить нового участника";
            this.добавитьНовогоУчастникаToolStripMenuItem.Click += new System.EventHandler(this.добавитьНовогоУчастникаToolStripMenuItem_Click);
            // 
            // добавить4УчастникаToolStripMenuItem
            // 
            this.добавить4УчастникаToolStripMenuItem.Name = "добавить4УчастникаToolStripMenuItem";
            this.добавить4УчастникаToolStripMenuItem.Size = new System.Drawing.Size(173, 24);
            this.добавить4УчастникаToolStripMenuItem.Text = "Добавить 4 участника";
            this.добавить4УчастникаToolStripMenuItem.Click += new System.EventHandler(this.добавить4УчастникаToolStripMenuItem_Click);
            // 
            // очиститьУчастниковToolStripMenuItem
            // 
            this.очиститьУчастниковToolStripMenuItem.Name = "очиститьУчастниковToolStripMenuItem";
            this.очиститьУчастниковToolStripMenuItem.Size = new System.Drawing.Size(167, 24);
            this.очиститьУчастниковToolStripMenuItem.Text = "Очистить участников";
            this.очиститьУчастниковToolStripMenuItem.Click += new System.EventHandler(this.очиститьУчастниковToolStripMenuItem_Click);
            // 
            // изменитьРазмерыТрассыToolStripMenuItem
            // 
            this.изменитьРазмерыТрассыToolStripMenuItem.Name = "изменитьРазмерыТрассыToolStripMenuItem";
            this.изменитьРазмерыТрассыToolStripMenuItem.Size = new System.Drawing.Size(209, 24);
            this.изменитьРазмерыТрассыToolStripMenuItem.Text = "Изменить размеры трассы";
            this.изменитьРазмерыТрассыToolStripMenuItem.Click += new System.EventHandler(this.изменитьРазмерыТрассыToolStripMenuItem_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1149, 483);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Name = "FormMain";
            this.Text = "FormMain";
            this.ResizeEnd += new System.EventHandler(this.FormMain_ResizeEnd);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormMain_Paint);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem новаяГонкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem остановитьГонкуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьНовогоУчастникаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавить4УчастникаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem очиститьУчастниковToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem изменитьРазмерыТрассыToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
    }
}