using CalculatingGameCombinations.Logic;

namespace CalculatingGameCombinations
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label_maxCardTitle = new System.Windows.Forms.Label();
            this.label_minCardLabel = new System.Windows.Forms.Label();
            this.checkBox_useJokers = new System.Windows.Forms.CheckBox();
            this.button_createPool = new System.Windows.Forms.Button();
            this.button_clearPool = new System.Windows.Forms.Button();
            this.label_cardCount = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.numericUpDown_maxCard = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_minCard = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.listBox_pool = new System.Windows.Forms.ListBox();
            this.groupBox_gameType = new System.Windows.Forms.GroupBox();
            this.button_secondGameType = new System.Windows.Forms.Button();
            this.button_firstGameType = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_maxCard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_minCard)).BeginInit();
            this.groupBox_gameType.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_maxCardTitle
            // 
            this.label_maxCardTitle.AutoSize = true;
            this.label_maxCardTitle.Location = new System.Drawing.Point(124, 225);
            this.label_maxCardTitle.Name = "label_maxCardTitle";
            this.label_maxCardTitle.Size = new System.Drawing.Size(54, 16);
            this.label_maxCardTitle.TabIndex = 28;
            this.label_maxCardTitle.Text = "label18";
            // 
            // label_minCardLabel
            // 
            this.label_minCardLabel.AutoSize = true;
            this.label_minCardLabel.Location = new System.Drawing.Point(124, 196);
            this.label_minCardLabel.Name = "label_minCardLabel";
            this.label_minCardLabel.Size = new System.Drawing.Size(54, 16);
            this.label_minCardLabel.TabIndex = 27;
            this.label_minCardLabel.Text = "label17";
            // 
            // checkBox_useJokers
            // 
            this.checkBox_useJokers.AutoSize = true;
            this.checkBox_useJokers.Location = new System.Drawing.Point(22, 252);
            this.checkBox_useJokers.Name = "checkBox_useJokers";
            this.checkBox_useJokers.Size = new System.Drawing.Size(96, 20);
            this.checkBox_useJokers.TabIndex = 26;
            this.checkBox_useJokers.Text = "Use Jokers";
            this.checkBox_useJokers.UseVisualStyleBackColor = true;
            this.checkBox_useJokers.CheckedChanged += new System.EventHandler(this.checkBox_useJokers_CheckedChanged_1);
            // 
            // button_createPool
            // 
            this.button_createPool.Location = new System.Drawing.Point(158, 308);
            this.button_createPool.Name = "button_createPool";
            this.button_createPool.Size = new System.Drawing.Size(142, 29);
            this.button_createPool.TabIndex = 25;
            this.button_createPool.Text = "Create Pool";
            this.button_createPool.UseVisualStyleBackColor = true;
            this.button_createPool.Click += new System.EventHandler(this.button_createPool_Click_1);
            // 
            // button_clearPool
            // 
            this.button_clearPool.Location = new System.Drawing.Point(3, 308);
            this.button_clearPool.Name = "button_clearPool";
            this.button_clearPool.Size = new System.Drawing.Size(142, 29);
            this.button_clearPool.TabIndex = 24;
            this.button_clearPool.Text = "Clear Pool";
            this.button_clearPool.UseVisualStyleBackColor = true;
            this.button_clearPool.Click += new System.EventHandler(this.button_clearPool_Click_1);
            // 
            // label_cardCount
            // 
            this.label_cardCount.AutoSize = true;
            this.label_cardCount.Location = new System.Drawing.Point(17, 290);
            this.label_cardCount.Name = "label_cardCount";
            this.label_cardCount.Size = new System.Drawing.Size(0, 16);
            this.label_cardCount.TabIndex = 23;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(17, 225);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(64, 16);
            this.label15.TabIndex = 22;
            this.label15.Text = "MaxCard";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(17, 196);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(61, 16);
            this.label14.TabIndex = 21;
            this.label14.Text = "MinCard";
            // 
            // numericUpDown_maxCard
            // 
            this.numericUpDown_maxCard.Location = new System.Drawing.Point(84, 223);
            this.numericUpDown_maxCard.Maximum = new decimal(new int[] {
            14,
            0,
            0,
            0});
            this.numericUpDown_maxCard.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDown_maxCard.Name = "numericUpDown_maxCard";
            this.numericUpDown_maxCard.Size = new System.Drawing.Size(34, 23);
            this.numericUpDown_maxCard.TabIndex = 20;
            this.numericUpDown_maxCard.Value = new decimal(new int[] {
            14,
            0,
            0,
            0});
            this.numericUpDown_maxCard.ValueChanged += new System.EventHandler(this.numericUpDown_maxCard_ValueChanged_1);
            // 
            // numericUpDown_minCard
            // 
            this.numericUpDown_minCard.Location = new System.Drawing.Point(84, 194);
            this.numericUpDown_minCard.Maximum = new decimal(new int[] {
            13,
            0,
            0,
            0});
            this.numericUpDown_minCard.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDown_minCard.Name = "numericUpDown_minCard";
            this.numericUpDown_minCard.Size = new System.Drawing.Size(34, 23);
            this.numericUpDown_minCard.TabIndex = 19;
            this.numericUpDown_minCard.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDown_minCard.ValueChanged += new System.EventHandler(this.numericUpDown_minCard_ValueChanged_1);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(108, 48);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(78, 16);
            this.label13.TabIndex = 18;
            this.label13.Text = "Cards Pool";
            // 
            // listBox_pool
            // 
            this.listBox_pool.FormattingEnabled = true;
            this.listBox_pool.ItemHeight = 16;
            this.listBox_pool.Location = new System.Drawing.Point(3, 67);
            this.listBox_pool.Name = "listBox_pool";
            this.listBox_pool.Size = new System.Drawing.Size(297, 116);
            this.listBox_pool.TabIndex = 17;
            // 
            // groupBox_gameType
            // 
            this.groupBox_gameType.Controls.Add(this.button_secondGameType);
            this.groupBox_gameType.Controls.Add(this.button_firstGameType);
            this.groupBox_gameType.Location = new System.Drawing.Point(3, 353);
            this.groupBox_gameType.Name = "groupBox_gameType";
            this.groupBox_gameType.Size = new System.Drawing.Size(297, 203);
            this.groupBox_gameType.TabIndex = 16;
            this.groupBox_gameType.TabStop = false;
            this.groupBox_gameType.Text = "GameType";
            // 
            // button_secondGameType
            // 
            this.button_secondGameType.Location = new System.Drawing.Point(9, 59);
            this.button_secondGameType.Name = "button_secondGameType";
            this.button_secondGameType.Size = new System.Drawing.Size(279, 31);
            this.button_secondGameType.TabIndex = 1;
            this.button_secondGameType.Text = "Second game type";
            this.button_secondGameType.UseVisualStyleBackColor = true;
            this.button_secondGameType.Click += new System.EventHandler(this.button_secondGameType_Click);
            // 
            // button_firstGameType
            // 
            this.button_firstGameType.Location = new System.Drawing.Point(9, 22);
            this.button_firstGameType.Name = "button_firstGameType";
            this.button_firstGameType.Size = new System.Drawing.Size(279, 31);
            this.button_firstGameType.TabIndex = 0;
            this.button_firstGameType.Text = "First game type";
            this.button_firstGameType.UseVisualStyleBackColor = true;
            this.button_firstGameType.Click += new System.EventHandler(this.button_firstGameType_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F);
            this.label1.Location = new System.Drawing.Point(35, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 18);
            this.label1.TabIndex = 15;
            this.label1.Text = "Calculating Game Combinations";
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(304, 561);
            this.Controls.Add(this.label_maxCardTitle);
            this.Controls.Add(this.label_minCardLabel);
            this.Controls.Add(this.checkBox_useJokers);
            this.Controls.Add(this.button_createPool);
            this.Controls.Add(this.button_clearPool);
            this.Controls.Add(this.label_cardCount);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.numericUpDown_maxCard);
            this.Controls.Add(this.numericUpDown_minCard);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.listBox_pool);
            this.Controls.Add(this.groupBox_gameType);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial", 10F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CGC";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_maxCard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_minCard)).EndInit();
            this.groupBox_gameType.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_maxCardTitle;
        private System.Windows.Forms.Label label_minCardLabel;
        private System.Windows.Forms.CheckBox checkBox_useJokers;
        private System.Windows.Forms.Button button_createPool;
        private System.Windows.Forms.Button button_clearPool;
        private System.Windows.Forms.Label label_cardCount;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown numericUpDown_maxCard;
        private System.Windows.Forms.NumericUpDown numericUpDown_minCard;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ListBox listBox_pool;
        private System.Windows.Forms.GroupBox groupBox_gameType;
        private System.Windows.Forms.Button button_secondGameType;
        private System.Windows.Forms.Button button_firstGameType;
        private System.Windows.Forms.Label label1;
    }
}

