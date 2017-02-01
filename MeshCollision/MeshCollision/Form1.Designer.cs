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
			this.buttonAddNewMeshSet = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pictureBox1.Location = new System.Drawing.Point(228, 12);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(401, 495);
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
			this.panel1.Size = new System.Drawing.Size(210, 434);
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
			this.ClientSize = new System.Drawing.Size(641, 516);
			this.Controls.Add(this.buttonAddNewMeshSet);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.buttonLoadImage);
			this.Controls.Add(this.buttonDraw);
			this.Controls.Add(this.pictureBox1);
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonDraw;
        private System.Windows.Forms.Button buttonLoadImage;
        private System.Windows.Forms.ColorDialog colorDialog1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button buttonAddNewMeshSet;
	}
}

