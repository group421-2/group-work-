namespace PCI_lab_3
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.trackBarLabelMinimum = new System.Windows.Forms.Label();
            this.trackBarLabelMaximum = new System.Windows.Forms.Label();
            this.trackBarLabelCurrent = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Location = new System.Drawing.Point(12, 52);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 600);
            this.panel1.TabIndex = 0;
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(12, 671);
            this.trackBar1.Maximum = 50;
            this.trackBar1.Minimum = 5;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(600, 45);
            this.trackBar1.TabIndex = 1;
            this.trackBar1.Value = 5;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // trackBarLabelMinimum
            // 
            this.trackBarLabelMinimum.AutoSize = true;
            this.trackBarLabelMinimum.Location = new System.Drawing.Point(12, 655);
            this.trackBarLabelMinimum.Name = "trackBarLabelMinimum";
            this.trackBarLabelMinimum.Size = new System.Drawing.Size(46, 13);
            this.trackBarLabelMinimum.TabIndex = 2;
            this.trackBarLabelMinimum.Text = "(-60; 60)";
            // 
            // trackBarLabelMaximum
            // 
            this.trackBarLabelMaximum.AutoSize = true;
            this.trackBarLabelMaximum.Location = new System.Drawing.Point(578, 655);
            this.trackBarLabelMaximum.Name = "trackBarLabelMaximum";
            this.trackBarLabelMaximum.Size = new System.Drawing.Size(34, 13);
            this.trackBarLabelMaximum.TabIndex = 3;
            this.trackBarLabelMaximum.Text = "(-6; 6)";
            // 
            // trackBarLabelCurrent
            // 
            this.trackBarLabelCurrent.AutoSize = true;
            this.trackBarLabelCurrent.Location = new System.Drawing.Point(289, 719);
            this.trackBarLabelCurrent.Name = "trackBarLabelCurrent";
            this.trackBarLabelCurrent.Size = new System.Drawing.Size(46, 13);
            this.trackBarLabelCurrent.TabIndex = 4;
            this.trackBarLabelCurrent.Text = "(-60; 60)";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.настройкиToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(941, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.настройкиToolStripMenuItem.Text = "Настройки";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(941, 754);
            this.Controls.Add(this.trackBarLabelCurrent);
            this.Controls.Add(this.trackBarLabelMinimum);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.trackBarLabelMaximum);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Пиздатые графики";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label trackBarLabelMinimum;
        private System.Windows.Forms.Label trackBarLabelMaximum;
        private System.Windows.Forms.Label trackBarLabelCurrent;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;

    }
}

