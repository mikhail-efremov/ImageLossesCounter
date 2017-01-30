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
			this.labelHitsCount = new System.Windows.Forms.Label();
			this.labelLabelCountInfo = new System.Windows.Forms.Label();
			this.textBoxLinesCount = new System.Windows.Forms.TextBox();
			this.buttonDraw = new System.Windows.Forms.Button();
			this.checkBoxDrawMesh = new System.Windows.Forms.CheckBox();
			this.pictureColorBox = new System.Windows.Forms.PictureBox();
			this.buttonLoadImage = new System.Windows.Forms.Button();
			this.trackBarSens = new System.Windows.Forms.TrackBar();
			this.labelSens = new System.Windows.Forms.Label();
			this.colorDialog1 = new System.Windows.Forms.ColorDialog();
			this.averageLabel = new System.Windows.Forms.Label();
			this.coincidenceLabel = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.buttonAddNewMeshSet = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureColorBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBarSens)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pictureBox1.Location = new System.Drawing.Point(228, 12);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(841, 495);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
			this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
			// 
			// labelHitsCount
			// 
			this.labelHitsCount.AutoSize = true;
			this.labelHitsCount.Location = new System.Drawing.Point(149, 348);
			this.labelHitsCount.Name = "labelHitsCount";
			this.labelHitsCount.Size = new System.Drawing.Size(13, 13);
			this.labelHitsCount.TabIndex = 2;
			this.labelHitsCount.Text = "0";
			// 
			// labelLabelCountInfo
			// 
			this.labelLabelCountInfo.AutoSize = true;
			this.labelLabelCountInfo.Location = new System.Drawing.Point(9, 351);
			this.labelLabelCountInfo.Name = "labelLabelCountInfo";
			this.labelLabelCountInfo.Size = new System.Drawing.Size(65, 13);
			this.labelLabelCountInfo.TabIndex = 3;
			this.labelLabelCountInfo.Text = "Lines count:";
			// 
			// textBoxLinesCount
			// 
			this.textBoxLinesCount.Location = new System.Drawing.Point(80, 348);
			this.textBoxLinesCount.Name = "textBoxLinesCount";
			this.textBoxLinesCount.Size = new System.Drawing.Size(63, 20);
			this.textBoxLinesCount.TabIndex = 4;
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
			// checkBoxDrawMesh
			// 
			this.checkBoxDrawMesh.AutoSize = true;
			this.checkBoxDrawMesh.Checked = true;
			this.checkBoxDrawMesh.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxDrawMesh.Location = new System.Drawing.Point(12, 374);
			this.checkBoxDrawMesh.Name = "checkBoxDrawMesh";
			this.checkBoxDrawMesh.Size = new System.Drawing.Size(79, 17);
			this.checkBoxDrawMesh.TabIndex = 6;
			this.checkBoxDrawMesh.Text = "Draw mesh";
			this.checkBoxDrawMesh.UseVisualStyleBackColor = true;
			// 
			// pictureColorBox
			// 
			this.pictureColorBox.Location = new System.Drawing.Point(12, 398);
			this.pictureColorBox.Name = "pictureColorBox";
			this.pictureColorBox.Size = new System.Drawing.Size(79, 20);
			this.pictureColorBox.TabIndex = 7;
			this.pictureColorBox.TabStop = false;
			this.pictureColorBox.Click += new System.EventHandler(this.pictureColorBox_Click);
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
			// trackBarSens
			// 
			this.trackBarSens.Location = new System.Drawing.Point(12, 459);
			this.trackBarSens.Maximum = 255;
			this.trackBarSens.Name = "trackBarSens";
			this.trackBarSens.Size = new System.Drawing.Size(131, 45);
			this.trackBarSens.TabIndex = 9;
			this.trackBarSens.ValueChanged += new System.EventHandler(this.trackBarSens_ValueChanged);
			// 
			// labelSens
			// 
			this.labelSens.AutoSize = true;
			this.labelSens.Location = new System.Drawing.Point(98, 404);
			this.labelSens.Name = "labelSens";
			this.labelSens.Size = new System.Drawing.Size(13, 13);
			this.labelSens.TabIndex = 10;
			this.labelSens.Text = "0";
			// 
			// averageLabel
			// 
			this.averageLabel.AutoSize = true;
			this.averageLabel.Location = new System.Drawing.Point(127, 378);
			this.averageLabel.Name = "averageLabel";
			this.averageLabel.Size = new System.Drawing.Size(35, 13);
			this.averageLabel.TabIndex = 11;
			this.averageLabel.Text = "label1";
			// 
			// coincidenceLabel
			// 
			this.coincidenceLabel.AutoSize = true;
			this.coincidenceLabel.Location = new System.Drawing.Point(127, 405);
			this.coincidenceLabel.Name = "coincidenceLabel";
			this.coincidenceLabel.Size = new System.Drawing.Size(35, 13);
			this.coincidenceLabel.TabIndex = 12;
			this.coincidenceLabel.Text = "label2";
			// 
			// panel1
			// 
			this.panel1.Location = new System.Drawing.Point(12, 70);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(210, 272);
			this.panel1.TabIndex = 14;
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
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1078, 516);
			this.Controls.Add(this.buttonAddNewMeshSet);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.coincidenceLabel);
			this.Controls.Add(this.averageLabel);
			this.Controls.Add(this.labelSens);
			this.Controls.Add(this.trackBarSens);
			this.Controls.Add(this.buttonLoadImage);
			this.Controls.Add(this.pictureColorBox);
			this.Controls.Add(this.checkBoxDrawMesh);
			this.Controls.Add(this.buttonDraw);
			this.Controls.Add(this.textBoxLinesCount);
			this.Controls.Add(this.labelLabelCountInfo);
			this.Controls.Add(this.labelHitsCount);
			this.Controls.Add(this.pictureBox1);
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureColorBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBarSens)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelHitsCount;
        private System.Windows.Forms.Label labelLabelCountInfo;
        private System.Windows.Forms.TextBox textBoxLinesCount;
        private System.Windows.Forms.Button buttonDraw;
        private System.Windows.Forms.CheckBox checkBoxDrawMesh;
        private System.Windows.Forms.PictureBox pictureColorBox;
        private System.Windows.Forms.Button buttonLoadImage;
        private System.Windows.Forms.TrackBar trackBarSens;
        private System.Windows.Forms.Label labelSens;
        private System.Windows.Forms.ColorDialog colorDialog1;
		private System.Windows.Forms.Label averageLabel;
		private System.Windows.Forms.Label coincidenceLabel;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button buttonAddNewMeshSet;
	}
}

