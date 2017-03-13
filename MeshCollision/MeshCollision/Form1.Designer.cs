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
      this.buttonDraw = new System.Windows.Forms.Button();
      this.buttonLoadImage = new System.Windows.Forms.Button();
      this.colorDialog1 = new System.Windows.Forms.ColorDialog();
      this.panel1 = new System.Windows.Forms.Panel();
      this.maxPictureBox = new System.Windows.Forms.PictureBox();
      this.minPictureBox = new System.Windows.Forms.PictureBox();
      this.buttonAddNewMeshSet = new System.Windows.Forms.Button();
      this.button1 = new System.Windows.Forms.Button();
      this.hslCointeinerPictureBox = new System.Windows.Forms.PictureBox();
      this.sValueTrackBar = new System.Windows.Forms.TrackBar();
      this.lValueTrackBar = new System.Windows.Forms.TrackBar();
      this.sValueInfoLabel = new System.Windows.Forms.Label();
      this.lValueInfoLable = new System.Windows.Forms.Label();
      this.linesCountInfoLabel = new System.Windows.Forms.Label();
      this.linesCountTextBox = new System.Windows.Forms.TextBox();
      this.selectionRangeSlider1 = new MeshCollision.SelectionRangeSlider();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.maxPictureBox)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.minPictureBox)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.hslCointeinerPictureBox)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.sValueTrackBar)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.lValueTrackBar)).BeginInit();
      this.SuspendLayout();
      // 
      // pictureBox1
      // 
      this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.pictureBox1.Location = new System.Drawing.Point(257, 12);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(459, 250);
      this.pictureBox1.TabIndex = 0;
      this.pictureBox1.TabStop = false;
      this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
      this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
      // 
      // buttonDraw
      // 
      this.buttonDraw.Location = new System.Drawing.Point(107, 12);
      this.buttonDraw.Name = "buttonDraw";
      this.buttonDraw.Size = new System.Drawing.Size(89, 23);
      this.buttonDraw.TabIndex = 5;
      this.buttonDraw.Text = "Update";
      this.buttonDraw.UseVisualStyleBackColor = true;
      this.buttonDraw.Click += new System.EventHandler(this.buttonDraw_Click);
      // 
      // buttonLoadImage
      // 
      this.buttonLoadImage.Location = new System.Drawing.Point(12, 12);
      this.buttonLoadImage.Name = "buttonLoadImage";
      this.buttonLoadImage.Size = new System.Drawing.Size(89, 23);
      this.buttonLoadImage.TabIndex = 8;
      this.buttonLoadImage.Text = "Upload image";
      this.buttonLoadImage.UseVisualStyleBackColor = true;
      this.buttonLoadImage.Click += new System.EventHandler(this.buttonLoadImage_Click);
      // 
      // panel1
      // 
      this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
      this.panel1.Location = new System.Drawing.Point(12, 70);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(239, 0);
      this.panel1.TabIndex = 14;
      // 
      // maxPictureBox
      // 
      this.maxPictureBox.Location = new System.Drawing.Point(698, 343);
      this.maxPictureBox.Name = "maxPictureBox";
      this.maxPictureBox.Size = new System.Drawing.Size(18, 15);
      this.maxPictureBox.TabIndex = 20;
      this.maxPictureBox.TabStop = false;
      // 
      // minPictureBox
      // 
      this.minPictureBox.Location = new System.Drawing.Point(674, 343);
      this.minPictureBox.Name = "minPictureBox";
      this.minPictureBox.Size = new System.Drawing.Size(18, 15);
      this.minPictureBox.TabIndex = 19;
      this.minPictureBox.TabStop = false;
      // 
      // buttonAddNewMeshSet
      // 
      this.buttonAddNewMeshSet.Location = new System.Drawing.Point(12, 41);
      this.buttonAddNewMeshSet.Name = "buttonAddNewMeshSet";
      this.buttonAddNewMeshSet.Size = new System.Drawing.Size(184, 23);
      this.buttonAddNewMeshSet.TabIndex = 15;
      this.buttonAddNewMeshSet.Text = "Add new mesh set";
      this.buttonAddNewMeshSet.UseVisualStyleBackColor = true;
      this.buttonAddNewMeshSet.Click += new System.EventHandler(this.button1_Click);
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(107, 335);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(75, 23);
      this.button1.TabIndex = 17;
      this.button1.Text = "button1";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click_1);
      // 
      // hslCointeinerPictureBox
      // 
      this.hslCointeinerPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.hslCointeinerPictureBox.Location = new System.Drawing.Point(12, 383);
      this.hslCointeinerPictureBox.Name = "hslCointeinerPictureBox";
      this.hslCointeinerPictureBox.Size = new System.Drawing.Size(701, 16);
      this.hslCointeinerPictureBox.TabIndex = 18;
      this.hslCointeinerPictureBox.TabStop = false;
      // 
      // sValueTrackBar
      // 
      this.sValueTrackBar.Location = new System.Drawing.Point(35, 405);
      this.sValueTrackBar.Maximum = 1000;
      this.sValueTrackBar.Name = "sValueTrackBar";
      this.sValueTrackBar.Size = new System.Drawing.Size(156, 45);
      this.sValueTrackBar.TabIndex = 20;
      this.sValueTrackBar.Value = 1;
      this.sValueTrackBar.ValueChanged += new System.EventHandler(this.sValueTrackBar_ValueChanged);
      // 
      // lValueTrackBar
      // 
      this.lValueTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.lValueTrackBar.Location = new System.Drawing.Point(557, 405);
      this.lValueTrackBar.Maximum = 1000;
      this.lValueTrackBar.Name = "lValueTrackBar";
      this.lValueTrackBar.Size = new System.Drawing.Size(156, 45);
      this.lValueTrackBar.TabIndex = 21;
      this.lValueTrackBar.Value = 1;
      this.lValueTrackBar.ValueChanged += new System.EventHandler(this.lValueTrackBar_ValueChanged);
      // 
      // sValueInfoLabel
      // 
      this.sValueInfoLabel.AutoSize = true;
      this.sValueInfoLabel.Location = new System.Drawing.Point(12, 405);
      this.sValueInfoLabel.Name = "sValueInfoLabel";
      this.sValueInfoLabel.Size = new System.Drawing.Size(17, 13);
      this.sValueInfoLabel.TabIndex = 22;
      this.sValueInfoLabel.Text = "S:";
      // 
      // lValueInfoLable
      // 
      this.lValueInfoLable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.lValueInfoLable.AutoSize = true;
      this.lValueInfoLable.Location = new System.Drawing.Point(534, 405);
      this.lValueInfoLable.Name = "lValueInfoLable";
      this.lValueInfoLable.Size = new System.Drawing.Size(16, 13);
      this.lValueInfoLable.TabIndex = 23;
      this.lValueInfoLable.Text = "L:";
      // 
      // linesCountInfoLabel
      // 
      this.linesCountInfoLabel.AutoSize = true;
      this.linesCountInfoLabel.Location = new System.Drawing.Point(12, 107);
      this.linesCountInfoLabel.Name = "linesCountInfoLabel";
      this.linesCountInfoLabel.Size = new System.Drawing.Size(35, 13);
      this.linesCountInfoLabel.TabIndex = 24;
      this.linesCountInfoLabel.Text = "Lines:";
      // 
      // linesCountTextBox
      // 
      this.linesCountTextBox.Location = new System.Drawing.Point(53, 104);
      this.linesCountTextBox.Name = "linesCountTextBox";
      this.linesCountTextBox.Size = new System.Drawing.Size(100, 20);
      this.linesCountTextBox.TabIndex = 25;
      // 
      // selectionRangeSlider1
      // 
      this.selectionRangeSlider1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.selectionRangeSlider1.Location = new System.Drawing.Point(12, 364);
      this.selectionRangeSlider1.Name = "selectionRangeSlider1";
      this.selectionRangeSlider1.Size = new System.Drawing.Size(701, 13);
      this.selectionRangeSlider1.TabIndex = 16;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(728, 449);
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
      this.Controls.Add(this.buttonAddNewMeshSet);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.buttonLoadImage);
      this.Controls.Add(this.buttonDraw);
      this.Controls.Add(this.pictureBox1);
      this.Name = "Form1";
      this.Text = "Form1";
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.maxPictureBox)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.minPictureBox)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.hslCointeinerPictureBox)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.sValueTrackBar)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.lValueTrackBar)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonDraw;
        private System.Windows.Forms.Button buttonLoadImage;
        private System.Windows.Forms.ColorDialog colorDialog1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button buttonAddNewMeshSet;
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
  }
}

