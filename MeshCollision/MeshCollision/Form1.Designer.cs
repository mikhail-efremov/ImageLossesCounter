namespace MeshCollision
{
    partial class Form1
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
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.buttonLoadImage = new System.Windows.Forms.Button();
      this.colorDialog1 = new System.Windows.Forms.ColorDialog();
      this.maxPictureBox = new System.Windows.Forms.PictureBox();
      this.minPictureBox = new System.Windows.Forms.PictureBox();
      this.button1 = new System.Windows.Forms.Button();
      this.hslCointeinerPictureBox = new System.Windows.Forms.PictureBox();
      this.sValueTrackBar = new System.Windows.Forms.TrackBar();
      this.lValueTrackBar = new System.Windows.Forms.TrackBar();
      this.sValueInfoLabel = new System.Windows.Forms.Label();
      this.lValueInfoLable = new System.Windows.Forms.Label();
      this.linesCountInfoLabel = new System.Windows.Forms.Label();
      this.linesCountTextBox = new System.Windows.Forms.TextBox();
      this.buttonGetLinesCount = new System.Windows.Forms.Button();
      this.linesColorInfoLabel = new System.Windows.Forms.Label();
      this.colorGetPictureBox = new System.Windows.Forms.PictureBox();
      this.hitsInfoLabel = new System.Windows.Forms.Label();
      this.hitsTextBox = new System.Windows.Forms.TextBox();
      this.selectionRangeSlider1 = new MeshCollision.SelectionRangeSlider();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.maxPictureBox)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.minPictureBox)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.hslCointeinerPictureBox)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.sValueTrackBar)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.lValueTrackBar)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.colorGetPictureBox)).BeginInit();
      this.SuspendLayout();
      // 
      // pictureBox1
      // 
      this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.pictureBox1.Location = new System.Drawing.Point(12, 12);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(704, 293);
      this.pictureBox1.TabIndex = 0;
      this.pictureBox1.TabStop = false;
      this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
      this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
      // 
      // buttonLoadImage
      // 
      this.buttonLoadImage.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
      this.buttonLoadImage.Location = new System.Drawing.Point(11, 311);
      this.buttonLoadImage.Name = "buttonLoadImage";
      this.buttonLoadImage.Size = new System.Drawing.Size(89, 23);
      this.buttonLoadImage.TabIndex = 8;
      this.buttonLoadImage.Text = "Upload image";
      this.buttonLoadImage.UseVisualStyleBackColor = true;
      this.buttonLoadImage.Click += new System.EventHandler(this.buttonLoadImage_Click);
      // 
      // maxPictureBox
      // 
      this.maxPictureBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
      this.maxPictureBox.Location = new System.Drawing.Point(213, 393);
      this.maxPictureBox.Name = "maxPictureBox";
      this.maxPictureBox.Size = new System.Drawing.Size(19, 18);
      this.maxPictureBox.TabIndex = 20;
      this.maxPictureBox.TabStop = false;
      // 
      // minPictureBox
      // 
      this.minPictureBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
      this.minPictureBox.Location = new System.Drawing.Point(188, 393);
      this.minPictureBox.Name = "minPictureBox";
      this.minPictureBox.Size = new System.Drawing.Size(19, 18);
      this.minPictureBox.TabIndex = 19;
      this.minPictureBox.TabStop = false;
      // 
      // button1
      // 
      this.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
      this.button1.Location = new System.Drawing.Point(107, 311);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(75, 23);
      this.button1.TabIndex = 17;
      this.button1.Text = "Add";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click_1);
      // 
      // hslCointeinerPictureBox
      // 
      this.hslCointeinerPictureBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
      this.hslCointeinerPictureBox.Location = new System.Drawing.Point(11, 372);
      this.hslCointeinerPictureBox.Name = "hslCointeinerPictureBox";
      this.hslCointeinerPictureBox.Size = new System.Drawing.Size(701, 13);
      this.hslCointeinerPictureBox.TabIndex = 18;
      this.hslCointeinerPictureBox.TabStop = false;
      // 
      // sValueTrackBar
      // 
      this.sValueTrackBar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
      this.sValueTrackBar.Location = new System.Drawing.Point(261, 391);
      this.sValueTrackBar.Maximum = 1000;
      this.sValueTrackBar.Name = "sValueTrackBar";
      this.sValueTrackBar.Size = new System.Drawing.Size(211, 45);
      this.sValueTrackBar.TabIndex = 20;
      this.sValueTrackBar.Value = 1;
      this.sValueTrackBar.ValueChanged += new System.EventHandler(this.sValueTrackBar_ValueChanged);
      // 
      // lValueTrackBar
      // 
      this.lValueTrackBar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
      this.lValueTrackBar.Location = new System.Drawing.Point(501, 391);
      this.lValueTrackBar.Maximum = 1000;
      this.lValueTrackBar.Name = "lValueTrackBar";
      this.lValueTrackBar.Size = new System.Drawing.Size(211, 45);
      this.lValueTrackBar.TabIndex = 21;
      this.lValueTrackBar.Value = 1;
      this.lValueTrackBar.ValueChanged += new System.EventHandler(this.lValueTrackBar_ValueChanged);
      // 
      // sValueInfoLabel
      // 
      this.sValueInfoLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
      this.sValueInfoLabel.AutoSize = true;
      this.sValueInfoLabel.Location = new System.Drawing.Point(238, 391);
      this.sValueInfoLabel.Name = "sValueInfoLabel";
      this.sValueInfoLabel.Size = new System.Drawing.Size(17, 13);
      this.sValueInfoLabel.TabIndex = 22;
      this.sValueInfoLabel.Text = "S:";
      // 
      // lValueInfoLable
      // 
      this.lValueInfoLable.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
      this.lValueInfoLable.AutoSize = true;
      this.lValueInfoLable.Location = new System.Drawing.Point(478, 391);
      this.lValueInfoLable.Name = "lValueInfoLable";
      this.lValueInfoLable.Size = new System.Drawing.Size(16, 13);
      this.lValueInfoLable.TabIndex = 23;
      this.lValueInfoLable.Text = "L:";
      // 
      // linesCountInfoLabel
      // 
      this.linesCountInfoLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
      this.linesCountInfoLabel.AutoSize = true;
      this.linesCountInfoLabel.Location = new System.Drawing.Point(11, 394);
      this.linesCountInfoLabel.Name = "linesCountInfoLabel";
      this.linesCountInfoLabel.Size = new System.Drawing.Size(35, 13);
      this.linesCountInfoLabel.TabIndex = 24;
      this.linesCountInfoLabel.Text = "Lines:";
      // 
      // linesCountTextBox
      // 
      this.linesCountTextBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
      this.linesCountTextBox.Location = new System.Drawing.Point(73, 391);
      this.linesCountTextBox.Name = "linesCountTextBox";
      this.linesCountTextBox.Size = new System.Drawing.Size(79, 20);
      this.linesCountTextBox.TabIndex = 25;
      // 
      // buttonGetLinesCount
      // 
      this.buttonGetLinesCount.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
      this.buttonGetLinesCount.Location = new System.Drawing.Point(157, 388);
      this.buttonGetLinesCount.Name = "buttonGetLinesCount";
      this.buttonGetLinesCount.Size = new System.Drawing.Size(25, 23);
      this.buttonGetLinesCount.TabIndex = 26;
      this.buttonGetLinesCount.Text = "S";
      this.buttonGetLinesCount.UseVisualStyleBackColor = true;
      this.buttonGetLinesCount.Click += new System.EventHandler(this.buttonGetLinesCount_Click);
      // 
      // linesColorInfoLabel
      // 
      this.linesColorInfoLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
      this.linesColorInfoLabel.AutoSize = true;
      this.linesColorInfoLabel.Location = new System.Drawing.Point(11, 423);
      this.linesColorInfoLabel.Name = "linesColorInfoLabel";
      this.linesColorInfoLabel.Size = new System.Drawing.Size(61, 13);
      this.linesColorInfoLabel.TabIndex = 27;
      this.linesColorInfoLabel.Text = "Lines color:";
      // 
      // colorGetPictureBox
      // 
      this.colorGetPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.colorGetPictureBox.Location = new System.Drawing.Point(73, 416);
      this.colorGetPictureBox.Name = "colorGetPictureBox";
      this.colorGetPictureBox.Size = new System.Drawing.Size(79, 20);
      this.colorGetPictureBox.TabIndex = 28;
      this.colorGetPictureBox.TabStop = false;
      this.colorGetPictureBox.Click += new System.EventHandler(this.colorGetPictureBox_Click);
      // 
      // hitsInfoLabel
      // 
      this.hitsInfoLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
      this.hitsInfoLabel.AutoSize = true;
      this.hitsInfoLabel.Location = new System.Drawing.Point(11, 446);
      this.hitsInfoLabel.Name = "hitsInfoLabel";
      this.hitsInfoLabel.Size = new System.Drawing.Size(28, 13);
      this.hitsInfoLabel.TabIndex = 29;
      this.hitsInfoLabel.Text = "Hits:";
      // 
      // hitsTextBox
      // 
      this.hitsTextBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
      this.hitsTextBox.Location = new System.Drawing.Point(73, 439);
      this.hitsTextBox.Name = "hitsTextBox";
      this.hitsTextBox.ReadOnly = true;
      this.hitsTextBox.Size = new System.Drawing.Size(79, 20);
      this.hitsTextBox.TabIndex = 30;
      // 
      // selectionRangeSlider1
      // 
      this.selectionRangeSlider1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
      this.selectionRangeSlider1.Location = new System.Drawing.Point(11, 353);
      this.selectionRangeSlider1.Name = "selectionRangeSlider1";
      this.selectionRangeSlider1.Size = new System.Drawing.Size(701, 13);
      this.selectionRangeSlider1.TabIndex = 16;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(728, 468);
      this.Controls.Add(this.hitsTextBox);
      this.Controls.Add(this.hitsInfoLabel);
      this.Controls.Add(this.colorGetPictureBox);
      this.Controls.Add(this.linesColorInfoLabel);
      this.Controls.Add(this.buttonGetLinesCount);
      this.Controls.Add(this.linesCountTextBox);
      this.Controls.Add(this.linesCountInfoLabel);
      this.Controls.Add(this.minPictureBox);
      this.Controls.Add(this.maxPictureBox);
      this.Controls.Add(this.lValueInfoLable);
      this.Controls.Add(this.sValueInfoLabel);
      this.Controls.Add(this.lValueTrackBar);
      this.Controls.Add(this.sValueTrackBar);
      this.Controls.Add(this.hslCointeinerPictureBox);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.selectionRangeSlider1);
      this.Controls.Add(this.buttonLoadImage);
      this.Controls.Add(this.pictureBox1);
      this.Name = "Form1";
      this.Text = "Form1";
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.maxPictureBox)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.minPictureBox)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.hslCointeinerPictureBox)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.sValueTrackBar)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.lValueTrackBar)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.colorGetPictureBox)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonLoadImage;
        private System.Windows.Forms.ColorDialog colorDialog1;
    private SelectionRangeSlider selectionRangeSlider1;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.PictureBox hslCointeinerPictureBox;
    private System.Windows.Forms.PictureBox maxPictureBox;
    private System.Windows.Forms.PictureBox minPictureBox;
    private System.Windows.Forms.TrackBar sValueTrackBar;
    private System.Windows.Forms.TrackBar lValueTrackBar;
    private System.Windows.Forms.Label sValueInfoLabel;
    private System.Windows.Forms.Label lValueInfoLable;
    private System.Windows.Forms.Label linesCountInfoLabel;
    private System.Windows.Forms.TextBox linesCountTextBox;
    private System.Windows.Forms.Button buttonGetLinesCount;
    private System.Windows.Forms.Label linesColorInfoLabel;
    private System.Windows.Forms.PictureBox colorGetPictureBox;
    private System.Windows.Forms.Label hitsInfoLabel;
    private System.Windows.Forms.TextBox hitsTextBox;
  }
}

