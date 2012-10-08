namespace PCI_lab_3
{
    partial class graphicForm
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
            this.graphPanel = new System.Windows.Forms.Panel();
            this.scaleBar = new System.Windows.Forms.TrackBar();
            this.trackBarLabelMinimum = new System.Windows.Forms.Label();
            this.trackBarLabelMaximum = new System.Windows.Forms.Label();
            this.trackBarLabelCurrent = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.scaleBar)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // graphPanel
            // 
            this.graphPanel.BackColor = System.Drawing.SystemColors.Control;
            this.graphPanel.Location = new System.Drawing.Point(12, 52);
            this.graphPanel.Name = "graphPanel";
            this.graphPanel.Size = new System.Drawing.Size(400, 400);
            this.graphPanel.TabIndex = 0;
            this.graphPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.graphPanel_Paint);
            // 
            // scaleBar
            // 
            this.scaleBar.Location = new System.Drawing.Point(12, 458);
            this.scaleBar.Maximum = 50;
            this.scaleBar.Minimum = 5;
            this.scaleBar.Name = "scaleBar";
            this.scaleBar.Size = new System.Drawing.Size(400, 45);
            this.scaleBar.TabIndex = 1;
            this.scaleBar.Value = 5;
            this.scaleBar.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // trackBarLabelMinimum
            // 
            this.trackBarLabelMinimum.AutoSize = true;
            this.trackBarLabelMinimum.Location = new System.Drawing.Point(12, 506);
            this.trackBarLabelMinimum.Name = "trackBarLabelMinimum";
            this.trackBarLabelMinimum.Size = new System.Drawing.Size(46, 13);
            this.trackBarLabelMinimum.TabIndex = 2;
            this.trackBarLabelMinimum.Text = "(-40; 40)";
            // 
            // trackBarLabelMaximum
            // 
            this.trackBarLabelMaximum.AutoSize = true;
            this.trackBarLabelMaximum.Location = new System.Drawing.Point(378, 506);
            this.trackBarLabelMaximum.Name = "trackBarLabelMaximum";
            this.trackBarLabelMaximum.Size = new System.Drawing.Size(34, 13);
            this.trackBarLabelMaximum.TabIndex = 3;
            this.trackBarLabelMaximum.Text = "(-4; 4)";
            // 
            // trackBarLabelCurrent
            // 
            this.trackBarLabelCurrent.AutoSize = true;
            this.trackBarLabelCurrent.Location = new System.Drawing.Point(178, 506);
            this.trackBarLabelCurrent.Name = "trackBarLabelCurrent";
            this.trackBarLabelCurrent.Size = new System.Drawing.Size(43, 13);
            this.trackBarLabelCurrent.TabIndex = 4;
            this.trackBarLabelCurrent.Text = "(-40;40)";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.настройкиToolStripMenuItem,
            this.оПрограммеToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(457, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.настройкиToolStripMenuItem.Text = "Настройки";
            this.настройкиToolStripMenuItem.Click += new System.EventHandler(this.настройкиToolStripMenuItem_Click);
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.выходToolStripMenuItem.Text = "Выход";
            // 
            // graphicForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(457, 550);
            this.Controls.Add(this.trackBarLabelCurrent);
            this.Controls.Add(this.trackBarLabelMinimum);
            this.Controls.Add(this.scaleBar);
            this.Controls.Add(this.trackBarLabelMaximum);
            this.Controls.Add(this.graphPanel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "graphicForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Пиздатые графики";
            ((System.ComponentModel.ISupportInitialize)(this.scaleBar)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel graphPanel;
        private System.Windows.Forms.TrackBar scaleBar;
        private System.Windows.Forms.Label trackBarLabelMinimum;
        private System.Windows.Forms.Label trackBarLabelMaximum;
        private System.Windows.Forms.Label trackBarLabelCurrent;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;

    }
}

