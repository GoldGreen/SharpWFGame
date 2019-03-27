namespace GameNewEra
{
    partial class MainWindow
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.MainRefresh = new System.Windows.Forms.Timer(this.components);
            this.EnemyHitMainHero = new System.Windows.Forms.Timer(this.components);
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.progressBar3 = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // MainRefresh
            // 
            this.MainRefresh.Enabled = true;
            this.MainRefresh.Interval = 12;
            this.MainRefresh.Tick += new System.EventHandler(this.MainRefresh_Tick);
            // 
            // EnemyHitMainHero
            // 
            this.EnemyHitMainHero.Enabled = true;
            this.EnemyHitMainHero.Interval = 1000;
            this.EnemyHitMainHero.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.Color.DarkOrange;
            this.progressBar1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.progressBar1.Location = new System.Drawing.Point(124, 646);
            this.progressBar1.MarqueeAnimationSpeed = 3000;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(76, 16);
            this.progressBar1.Step = 1000;
            this.progressBar1.TabIndex = 2;
            this.progressBar1.Value = 100;
            // 
            // progressBar2
            // 
            this.progressBar2.BackColor = System.Drawing.Color.GhostWhite;
            this.progressBar2.Location = new System.Drawing.Point(25, 646);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(76, 16);
            this.progressBar2.TabIndex = 3;
            this.progressBar2.Value = 100;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(380, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(244, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "Режим Ожидания Действий";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::GameNewEra.VisualNature.Cursor_clicked;
            this.pictureBox1.Location = new System.Drawing.Point(452, 466);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 30);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // progressBar3
            // 
            this.progressBar3.Location = new System.Drawing.Point(316, 681);
            this.progressBar3.Name = "progressBar3";
            this.progressBar3.Size = new System.Drawing.Size(662, 23);
            this.progressBar3.TabIndex = 6;
            this.progressBar3.Value = 100;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.DarkBlue;
            this.BackgroundImage = global::GameNewEra.VisualNature.BackGround1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1264, 729);
            this.Controls.Add(this.progressBar3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar2);
            this.Controls.Add(this.progressBar1);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1280, 768);
            this.MinimizeBox = false;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SpaceBattleWarIdealPerfectCosmisiimmoShooterStrategy";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainWindow_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyDown);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MainWindow_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer MainRefresh;
        private System.Windows.Forms.Timer EnemyHitMainHero;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.ProgressBar progressBar3;
        public System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

