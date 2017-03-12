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
      this.label2 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.pictureBox2 = new System.Windows.Forms.PictureBox();
      this.buttonAddNewMeshSet = new System.Windows.Forms.Button();
      this.trackBar1 = new System.Windows.Forms.TrackBar();
      this.button1 = new System.Windows.Forms.Button();
      this.colorCointeinerPictureBox = new System.Windows.Forms.PictureBox();
      this.selectionRangeSlider1 = new MeshCollision.SelectionRangeSlider();
      this.minPictureBox = new System.Windows.Forms.PictureBox();
      this.maxPictureBox = new System.Windows.Forms.PictureBox();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.panel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.colorCointeinerPictureBox)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.minPictureBox)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.maxPictureBox)).BeginInit();
      this.SuspendLayout();
      // 
      // pictureBox1
      // 
      this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.pictureBox1.Location = new System.Drawing.Point(257, 12);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(459, 381);
      this.pictureBox1.TabIndex = 0;
      this.pictureBox1.TabStop = false;
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
      this.panel1.Controls.Add(this.maxPictureBox);
      this.panel1.Controls.Add(this.minPictureBox);
      this.panel1.Controls.Add(this.label2);
      this.panel1.Controls.Add(this.label1);
      this.panel1.Controls.Add(this.pictureBox2);
      this.panel1.Location = new System.Drawing.Point(12, 70);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(239, 323);
      this.panel1.TabIndex = 14;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(16, 93);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(35, 13);
      this.label2.TabIndex = 17;
      this.label2.Text = "label2";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(16, 80);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(35, 13);
      this.label1.TabIndex = 16;
      this.label1.Text = "label1";
      // 
      // pictureBox2
      // 
      this.pictureBox2.Location = new System.Drawing.Point(3, 27);
      this.pictureBox2.Name = "pictureBox2";
      this.pictureBox2.Size = new System.Drawing.Size(100, 50);
      this.pictureBox2.TabIndex = 1;
      this.pictureBox2.TabStop = false;
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
      // trackBar1
      // 
      this.trackBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.trackBar1.Location = new System.Drawing.Point(12, 470);
      this.trackBar1.Maximum = 3619;
      this.trackBar1.Minimum = -1;
      this.trackBar1.Name = "trackBar1";
      this.trackBar1.Size = new System.Drawing.Size(704, 45);
      this.trackBar1.TabIndex = 0;
      this.trackBar1.Value = 1;
      this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(107, 400);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(75, 23);
      this.button1.TabIndex = 17;
      this.button1.Text = "button1";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click_1);
      // 
      // colorCointeinerPictureBox
      // 
      this.colorCointeinerPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.colorCointeinerPictureBox.Location = new System.Drawing.Point(15, 448);
      this.colorCointeinerPictureBox.Name = "colorCointeinerPictureBox";
      this.colorCointeinerPictureBox.Size = new System.Drawing.Size(701, 16);
      this.colorCointeinerPictureBox.TabIndex = 18;
      this.colorCointeinerPictureBox.TabStop = false;
      // 
      // selectionRangeSlider1
      // 
      this.selectionRangeSlider1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.selectionRangeSlider1.Location = new System.Drawing.Point(15, 424);
      this.selectionRangeSlider1.Name = "selectionRangeSlider1";
      this.selectionRangeSlider1.Size = new System.Drawing.Size(701, 18);
      this.selectionRangeSlider1.TabIndex = 16;
      // 
      // minPictureBox
      // 
      this.minPictureBox.Location = new System.Drawing.Point(3, 147);
      this.minPictureBox.Name = "minPictureBox";
      this.minPictureBox.Size = new System.Drawing.Size(100, 50);
      this.minPictureBox.TabIndex = 19;
      this.minPictureBox.TabStop = false;
      // 
      // maxPictureBox
      // 
      this.maxPictureBox.Location = new System.Drawing.Point(109, 147);
      this.maxPictureBox.Name = "maxPictureBox";
      this.maxPictureBox.Size = new System.Drawing.Size(100, 50);
      this.maxPictureBox.TabIndex = 20;
      this.maxPictureBox.TabStop = false;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(728, 516);
      this.Controls.Add(this.colorCointeinerPictureBox);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.selectionRangeSlider1);
      this.Controls.Add(this.buttonAddNewMeshSet);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.buttonLoadImage);
      this.Controls.Add(this.trackBar1);
      this.Controls.Add(this.buttonDraw);
      this.Controls.Add(this.pictureBox1);
      this.Name = "Form1";
      this.Text = "Form1";
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.colorCointeinerPictureBox)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.minPictureBox)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.maxPictureBox)).EndInit();
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
    private System.Windows.Forms.PictureBox pictureBox2;
    private System.Windows.Forms.TrackBar trackBar1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label1;
    private SelectionRangeSlider selectionRangeSlider1;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.PictureBox colorCointeinerPictureBox;
    private System.Windows.Forms.PictureBox maxPictureBox;
    private System.Windows.Forms.PictureBox minPictureBox;
  }
}

