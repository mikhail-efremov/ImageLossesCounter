using MeshCollision.Controlls;

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
      this.buttonDraw = new System.Windows.Forms.Button();
      this.inProgressLabel = new System.Windows.Forms.Label();
      this.examplePictureBox = new System.Windows.Forms.PictureBox();
      this.compareImagesButton = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.exampleToAnalythLabel = new System.Windows.Forms.Label();
      this.selectionRangeSlider1 = new SelectionRangeSlider();
      this.analythPictureBox = new System.Windows.Forms.PictureBox();
      this.textBoxRadius = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.textBoxColorSens = new System.Windows.Forms.TextBox();
      ((System.ComponentModel.ISupportInitialize)(this.maxPictureBox)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.minPictureBox)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.hslCointeinerPictureBox)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.sValueTrackBar)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.lValueTrackBar)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.examplePictureBox)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.analythPictureBox)).BeginInit();
      this.SuspendLayout();
      // 
      // buttonLoadImage
      // 
      this.buttonLoadImage.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
      this.buttonLoadImage.Location = new System.Drawing.Point(23, 452);
      this.buttonLoadImage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.buttonLoadImage.Name = "buttonLoadImage";
      this.buttonLoadImage.Size = new System.Drawing.Size(134, 35);
      this.buttonLoadImage.TabIndex = 8;
      this.buttonLoadImage.Text = "Upload image";
      this.buttonLoadImage.UseVisualStyleBackColor = true;
      this.buttonLoadImage.Click += new System.EventHandler(this.buttonLoadImage_Click);
      // 
      // maxPictureBox
      // 
      this.maxPictureBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
      this.maxPictureBox.Location = new System.Drawing.Point(327, 579);
      this.maxPictureBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.maxPictureBox.Name = "maxPictureBox";
      this.maxPictureBox.Size = new System.Drawing.Size(28, 28);
      this.maxPictureBox.TabIndex = 20;
      this.maxPictureBox.TabStop = false;
      // 
      // minPictureBox
      // 
      this.minPictureBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
      this.minPictureBox.Location = new System.Drawing.Point(289, 579);
      this.minPictureBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.minPictureBox.Name = "minPictureBox";
      this.minPictureBox.Size = new System.Drawing.Size(28, 28);
      this.minPictureBox.TabIndex = 19;
      this.minPictureBox.TabStop = false;
      // 
      // button1
      // 
      this.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
      this.button1.Location = new System.Drawing.Point(167, 452);
      this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(112, 35);
      this.button1.TabIndex = 17;
      this.button1.Text = "Add";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click_1);
      // 
      // hslCointeinerPictureBox
      // 
      this.hslCointeinerPictureBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
      this.hslCointeinerPictureBox.Location = new System.Drawing.Point(23, 546);
      this.hslCointeinerPictureBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.hslCointeinerPictureBox.Name = "hslCointeinerPictureBox";
      this.hslCointeinerPictureBox.Size = new System.Drawing.Size(1052, 20);
      this.hslCointeinerPictureBox.TabIndex = 18;
      this.hslCointeinerPictureBox.TabStop = false;
      // 
      // sValueTrackBar
      // 
      this.sValueTrackBar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
      this.sValueTrackBar.Location = new System.Drawing.Point(399, 576);
      this.sValueTrackBar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.sValueTrackBar.Maximum = 1000;
      this.sValueTrackBar.Name = "sValueTrackBar";
      this.sValueTrackBar.Size = new System.Drawing.Size(316, 69);
      this.sValueTrackBar.TabIndex = 20;
      this.sValueTrackBar.Value = 1;
      this.sValueTrackBar.ValueChanged += new System.EventHandler(this.sValueTrackBar_ValueChanged);
      // 
      // lValueTrackBar
      // 
      this.lValueTrackBar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
      this.lValueTrackBar.Location = new System.Drawing.Point(759, 576);
      this.lValueTrackBar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.lValueTrackBar.Maximum = 1000;
      this.lValueTrackBar.Name = "lValueTrackBar";
      this.lValueTrackBar.Size = new System.Drawing.Size(316, 69);
      this.lValueTrackBar.TabIndex = 21;
      this.lValueTrackBar.Value = 1;
      this.lValueTrackBar.ValueChanged += new System.EventHandler(this.lValueTrackBar_ValueChanged);
      // 
      // sValueInfoLabel
      // 
      this.sValueInfoLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
      this.sValueInfoLabel.AutoSize = true;
      this.sValueInfoLabel.Location = new System.Drawing.Point(364, 576);
      this.sValueInfoLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.sValueInfoLabel.Name = "sValueInfoLabel";
      this.sValueInfoLabel.Size = new System.Drawing.Size(24, 20);
      this.sValueInfoLabel.TabIndex = 22;
      this.sValueInfoLabel.Text = "S:";
      // 
      // lValueInfoLable
      // 
      this.lValueInfoLable.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
      this.lValueInfoLable.AutoSize = true;
      this.lValueInfoLable.Location = new System.Drawing.Point(724, 576);
      this.lValueInfoLable.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lValueInfoLable.Name = "lValueInfoLable";
      this.lValueInfoLable.Size = new System.Drawing.Size(22, 20);
      this.lValueInfoLable.TabIndex = 23;
      this.lValueInfoLable.Text = "L:";
      // 
      // buttonDraw
      // 
      this.buttonDraw.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
      this.buttonDraw.Location = new System.Drawing.Point(289, 452);
      this.buttonDraw.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.buttonDraw.Name = "buttonDraw";
      this.buttonDraw.Size = new System.Drawing.Size(112, 35);
      this.buttonDraw.TabIndex = 31;
      this.buttonDraw.Text = "Draw";
      this.buttonDraw.UseVisualStyleBackColor = true;
      this.buttonDraw.Click += new System.EventHandler(this.buttonDraw_Click);
      // 
      // inProgressLabel
      // 
      this.inProgressLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
      this.inProgressLabel.AutoSize = true;
      this.inProgressLabel.Location = new System.Drawing.Point(529, 459);
      this.inProgressLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.inProgressLabel.Name = "inProgressLabel";
      this.inProgressLabel.Size = new System.Drawing.Size(93, 20);
      this.inProgressLabel.TabIndex = 32;
      this.inProgressLabel.Text = "no progress";
      // 
      // examplePictureBox
      // 
      this.examplePictureBox.Location = new System.Drawing.Point(16, 18);
      this.examplePictureBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.examplePictureBox.Name = "examplePictureBox";
      this.examplePictureBox.Size = new System.Drawing.Size(530, 425);
      this.examplePictureBox.TabIndex = 33;
      this.examplePictureBox.TabStop = false;
      this.examplePictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.examplePictureBox_Paint);
      this.examplePictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.examplePictureBox_MouseDown);
      this.examplePictureBox.MouseLeave += new System.EventHandler(this.examplePictureBox_MouseLeave);
      this.examplePictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.examplePictureBox_MouseMove);
      this.examplePictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.examplePictureBox_MouseUp);
      // 
      // compareImagesButton
      // 
      this.compareImagesButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
      this.compareImagesButton.Location = new System.Drawing.Point(409, 452);
      this.compareImagesButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.compareImagesButton.Name = "compareImagesButton";
      this.compareImagesButton.Size = new System.Drawing.Size(112, 35);
      this.compareImagesButton.TabIndex = 34;
      this.compareImagesButton.Text = "Compare";
      this.compareImagesButton.UseVisualStyleBackColor = true;
      this.compareImagesButton.Click += new System.EventHandler(this.compareImagesButton_Click);
      // 
      // label1
      // 
      this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(630, 459);
      this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(116, 20);
      this.label1.TabIndex = 35;
      this.label1.Text = "Погрешность:";
      // 
      // exampleToAnalythLabel
      // 
      this.exampleToAnalythLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
      this.exampleToAnalythLabel.AutoSize = true;
      this.exampleToAnalythLabel.Location = new System.Drawing.Point(755, 459);
      this.exampleToAnalythLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.exampleToAnalythLabel.Name = "exampleToAnalythLabel";
      this.exampleToAnalythLabel.Size = new System.Drawing.Size(72, 20);
      this.exampleToAnalythLabel.TabIndex = 39;
      this.exampleToAnalythLabel.Text = "100.00%";
      // 
      // selectionRangeSlider1
      // 
      this.selectionRangeSlider1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
      this.selectionRangeSlider1.Location = new System.Drawing.Point(23, 517);
      this.selectionRangeSlider1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.selectionRangeSlider1.Name = "selectionRangeSlider1";
      this.selectionRangeSlider1.Size = new System.Drawing.Size(1052, 20);
      this.selectionRangeSlider1.TabIndex = 16;
      // 
      // analythPictureBox
      // 
      this.analythPictureBox.Location = new System.Drawing.Point(542, 18);
      this.analythPictureBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.analythPictureBox.Name = "analythPictureBox";
      this.analythPictureBox.Size = new System.Drawing.Size(540, 425);
      this.analythPictureBox.TabIndex = 0;
      this.analythPictureBox.TabStop = false;
      this.analythPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
      // 
      // textBoxRadius
      // 
      this.textBoxRadius.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
      this.textBoxRadius.Location = new System.Drawing.Point(115, 579);
      this.textBoxRadius.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.textBoxRadius.Name = "textBoxRadius";
      this.textBoxRadius.Size = new System.Drawing.Size(116, 26);
      this.textBoxRadius.TabIndex = 40;
      this.textBoxRadius.Text = "1000";
      // 
      // label2
      // 
      this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(25, 582);
      this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(87, 20);
      this.label2.TabIndex = 41;
      this.label2.Text = "Hull radius:";
      // 
      // label3
      // 
      this.label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(25, 625);
      this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(88, 20);
      this.label3.TabIndex = 43;
      this.label3.Text = "Color sens:";
      // 
      // textBoxColorSens
      // 
      this.textBoxColorSens.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
      this.textBoxColorSens.Location = new System.Drawing.Point(115, 622);
      this.textBoxColorSens.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.textBoxColorSens.Name = "textBoxColorSens";
      this.textBoxColorSens.Size = new System.Drawing.Size(116, 26);
      this.textBoxColorSens.TabIndex = 42;
      this.textBoxColorSens.Text = "100";
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1092, 694);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.textBoxColorSens);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.textBoxRadius);
      this.Controls.Add(this.exampleToAnalythLabel);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.compareImagesButton);
      this.Controls.Add(this.examplePictureBox);
      this.Controls.Add(this.inProgressLabel);
      this.Controls.Add(this.buttonDraw);
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
      this.Controls.Add(this.analythPictureBox);
      this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.Name = "Form1";
      this.Text = "Mikhail Efremov IT-12M";
      this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
      ((System.ComponentModel.ISupportInitialize)(this.maxPictureBox)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.minPictureBox)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.hslCointeinerPictureBox)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.sValueTrackBar)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.lValueTrackBar)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.examplePictureBox)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.analythPictureBox)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion
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
    private System.Windows.Forms.Button buttonDraw;
    private System.Windows.Forms.Label inProgressLabel;
    private System.Windows.Forms.PictureBox examplePictureBox;
    private System.Windows.Forms.Button compareImagesButton;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label exampleToAnalythLabel;
    private System.Windows.Forms.PictureBox analythPictureBox;
    private System.Windows.Forms.TextBox textBoxRadius;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox textBoxColorSens;
  }
}

