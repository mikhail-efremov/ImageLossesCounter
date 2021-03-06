﻿using MeshCollision.Controlls;

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
      this.hslCointeinerPictureBox = new System.Windows.Forms.PictureBox();
      this.sValueTrackBar = new System.Windows.Forms.TrackBar();
      this.lValueTrackBar = new System.Windows.Forms.TrackBar();
      this.sValueInfoLabel = new System.Windows.Forms.Label();
      this.lValueInfoLable = new System.Windows.Forms.Label();
      this.buttonDraw = new System.Windows.Forms.Button();
      this.examplePictureBox = new System.Windows.Forms.PictureBox();
      this.label1 = new System.Windows.Forms.Label();
      this.exampleToAnalythLabel = new System.Windows.Forms.Label();
      this.analythPictureBox = new System.Windows.Forms.PictureBox();
      this.label3 = new System.Windows.Forms.Label();
      this.textBoxColorSens = new System.Windows.Forms.TextBox();
      this.labelTestValues = new System.Windows.Forms.Label();
      this.executionInformation = new System.Windows.Forms.Label();
      this.panel1 = new System.Windows.Forms.Panel();
      this.loadSettingButton = new System.Windows.Forms.Button();
      this.saveSettingButton = new System.Windows.Forms.Button();
      this.label5 = new System.Windows.Forms.Label();
      this.lineWidthTextBox = new System.Windows.Forms.TextBox();
      this.buttonVisualDraw = new System.Windows.Forms.Button();
      this.label4 = new System.Windows.Forms.Label();
      this.concaveTextBox = new System.Windows.Forms.TextBox();
      this.clusterDistanceTextBox = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.paintModeCheckBox = new System.Windows.Forms.CheckBox();
      this.cuttingPictureBox = new System.Windows.Forms.PictureBox();
      this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
      this.selectionRangeSlider1 = new MeshCollision.Controlls.SelectionRangeSlider();
      this.label6 = new System.Windows.Forms.Label();
      this.etalonLineWithTextBox = new System.Windows.Forms.TextBox();
      ((System.ComponentModel.ISupportInitialize)(this.maxPictureBox)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.minPictureBox)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.hslCointeinerPictureBox)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.sValueTrackBar)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.lValueTrackBar)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.examplePictureBox)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.analythPictureBox)).BeginInit();
      this.panel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.cuttingPictureBox)).BeginInit();
      this.SuspendLayout();
      // 
      // buttonLoadImage
      // 
      this.buttonLoadImage.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
      this.buttonLoadImage.Location = new System.Drawing.Point(632, 65);
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
      this.maxPictureBox.Location = new System.Drawing.Point(493, 201);
      this.maxPictureBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.maxPictureBox.Name = "maxPictureBox";
      this.maxPictureBox.Size = new System.Drawing.Size(28, 28);
      this.maxPictureBox.TabIndex = 20;
      this.maxPictureBox.TabStop = false;
      // 
      // minPictureBox
      // 
      this.minPictureBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
      this.minPictureBox.Location = new System.Drawing.Point(457, 201);
      this.minPictureBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.minPictureBox.Name = "minPictureBox";
      this.minPictureBox.Size = new System.Drawing.Size(28, 28);
      this.minPictureBox.TabIndex = 19;
      this.minPictureBox.TabStop = false;
      // 
      // hslCointeinerPictureBox
      // 
      this.hslCointeinerPictureBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
      this.hslCointeinerPictureBox.Location = new System.Drawing.Point(37, 34);
      this.hslCointeinerPictureBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.hslCointeinerPictureBox.Name = "hslCointeinerPictureBox";
      this.hslCointeinerPictureBox.Size = new System.Drawing.Size(1052, 20);
      this.hslCointeinerPictureBox.TabIndex = 18;
      this.hslCointeinerPictureBox.TabStop = false;
      // 
      // sValueTrackBar
      // 
      this.sValueTrackBar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
      this.sValueTrackBar.Location = new System.Drawing.Point(308, 64);
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
      this.lValueTrackBar.Location = new System.Drawing.Point(306, 135);
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
      this.sValueInfoLabel.Location = new System.Drawing.Point(276, 80);
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
      this.lValueInfoLable.Location = new System.Drawing.Point(276, 148);
      this.lValueInfoLable.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lValueInfoLable.Name = "lValueInfoLable";
      this.lValueInfoLable.Size = new System.Drawing.Size(22, 20);
      this.lValueInfoLable.TabIndex = 23;
      this.lValueInfoLable.Text = "L:";
      // 
      // buttonDraw
      // 
      this.buttonDraw.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
      this.buttonDraw.Location = new System.Drawing.Point(774, 64);
      this.buttonDraw.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.buttonDraw.Name = "buttonDraw";
      this.buttonDraw.Size = new System.Drawing.Size(112, 35);
      this.buttonDraw.TabIndex = 31;
      this.buttonDraw.Text = "Draw";
      this.buttonDraw.UseVisualStyleBackColor = true;
      this.buttonDraw.Click += new System.EventHandler(this.buttonDraw_Click);
      // 
      // examplePictureBox
      // 
      this.examplePictureBox.Location = new System.Drawing.Point(16, 18);
      this.examplePictureBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.examplePictureBox.Name = "examplePictureBox";
      this.examplePictureBox.Size = new System.Drawing.Size(412, 259);
      this.examplePictureBox.TabIndex = 33;
      this.examplePictureBox.TabStop = false;
      this.examplePictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.examplePictureBox_Paint);
      this.examplePictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.examplePictureBox_MouseDown);
      this.examplePictureBox.MouseLeave += new System.EventHandler(this.examplePictureBox_MouseLeave);
      this.examplePictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.examplePictureBox_MouseMove);
      this.examplePictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.examplePictureBox_MouseUp);
      // 
      // label1
      // 
      this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(630, 184);
      this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(89, 20);
      this.label1.TabIndex = 35;
      this.label1.Text = "Покрытие:";
      // 
      // exampleToAnalythLabel
      // 
      this.exampleToAnalythLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
      this.exampleToAnalythLabel.AutoSize = true;
      this.exampleToAnalythLabel.Location = new System.Drawing.Point(727, 184);
      this.exampleToAnalythLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.exampleToAnalythLabel.Name = "exampleToAnalythLabel";
      this.exampleToAnalythLabel.Size = new System.Drawing.Size(72, 20);
      this.exampleToAnalythLabel.TabIndex = 39;
      this.exampleToAnalythLabel.Text = "100.00%";
      // 
      // analythPictureBox
      // 
      this.analythPictureBox.Location = new System.Drawing.Point(436, 18);
      this.analythPictureBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.analythPictureBox.Name = "analythPictureBox";
      this.analythPictureBox.Size = new System.Drawing.Size(432, 259);
      this.analythPictureBox.TabIndex = 0;
      this.analythPictureBox.TabStop = false;
      this.analythPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
      // 
      // label3
      // 
      this.label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(124, 62);
      this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(88, 20);
      this.label3.TabIndex = 43;
      this.label3.Text = "Color sens:";
      // 
      // textBoxColorSens
      // 
      this.textBoxColorSens.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
      this.textBoxColorSens.Location = new System.Drawing.Point(214, 59);
      this.textBoxColorSens.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.textBoxColorSens.Name = "textBoxColorSens";
      this.textBoxColorSens.Size = new System.Drawing.Size(38, 26);
      this.textBoxColorSens.TabIndex = 42;
      this.textBoxColorSens.Text = "100";
      // 
      // labelTestValues
      // 
      this.labelTestValues.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
      this.labelTestValues.AutoSize = true;
      this.labelTestValues.Location = new System.Drawing.Point(304, 198);
      this.labelTestValues.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.labelTestValues.Name = "labelTestValues";
      this.labelTestValues.Size = new System.Drawing.Size(145, 20);
      this.labelTestValues.TabIndex = 44;
      this.labelTestValues.Text = "H:[50:100] S:1 L0.5";
      // 
      // executionInformation
      // 
      this.executionInformation.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.executionInformation.Location = new System.Drawing.Point(628, 110);
      this.executionInformation.Name = "executionInformation";
      this.executionInformation.Size = new System.Drawing.Size(461, 74);
      this.executionInformation.TabIndex = 45;
      this.executionInformation.Text = "Execution info";
      // 
      // panel1
      // 
      this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.panel1.BackColor = System.Drawing.SystemColors.Window;
      this.panel1.Controls.Add(this.label6);
      this.panel1.Controls.Add(this.etalonLineWithTextBox);
      this.panel1.Controls.Add(this.loadSettingButton);
      this.panel1.Controls.Add(this.saveSettingButton);
      this.panel1.Controls.Add(this.label5);
      this.panel1.Controls.Add(this.lineWidthTextBox);
      this.panel1.Controls.Add(this.buttonVisualDraw);
      this.panel1.Controls.Add(this.label4);
      this.panel1.Controls.Add(this.concaveTextBox);
      this.panel1.Controls.Add(this.clusterDistanceTextBox);
      this.panel1.Controls.Add(this.label2);
      this.panel1.Controls.Add(this.paintModeCheckBox);
      this.panel1.Controls.Add(this.buttonLoadImage);
      this.panel1.Controls.Add(this.executionInformation);
      this.panel1.Controls.Add(this.selectionRangeSlider1);
      this.panel1.Controls.Add(this.labelTestValues);
      this.panel1.Controls.Add(this.label3);
      this.panel1.Controls.Add(this.hslCointeinerPictureBox);
      this.panel1.Controls.Add(this.textBoxColorSens);
      this.panel1.Controls.Add(this.sValueTrackBar);
      this.panel1.Controls.Add(this.exampleToAnalythLabel);
      this.panel1.Controls.Add(this.lValueTrackBar);
      this.panel1.Controls.Add(this.label1);
      this.panel1.Controls.Add(this.sValueInfoLabel);
      this.panel1.Controls.Add(this.lValueInfoLable);
      this.panel1.Controls.Add(this.maxPictureBox);
      this.panel1.Controls.Add(this.minPictureBox);
      this.panel1.Controls.Add(this.buttonDraw);
      this.panel1.Location = new System.Drawing.Point(12, 451);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(1137, 231);
      this.panel1.TabIndex = 46;
      // 
      // loadSettingButton
      // 
      this.loadSettingButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
      this.loadSettingButton.Location = new System.Drawing.Point(1014, 103);
      this.loadSettingButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.loadSettingButton.Name = "loadSettingButton";
      this.loadSettingButton.Size = new System.Drawing.Size(112, 35);
      this.loadSettingButton.TabIndex = 55;
      this.loadSettingButton.Text = "Load setting";
      this.loadSettingButton.UseVisualStyleBackColor = true;
      this.loadSettingButton.Click += new System.EventHandler(this.loadSettingButton_Click);
      // 
      // saveSettingButton
      // 
      this.saveSettingButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
      this.saveSettingButton.Location = new System.Drawing.Point(1014, 64);
      this.saveSettingButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.saveSettingButton.Name = "saveSettingButton";
      this.saveSettingButton.Size = new System.Drawing.Size(112, 35);
      this.saveSettingButton.TabIndex = 54;
      this.saveSettingButton.Text = "Save setting";
      this.saveSettingButton.UseVisualStyleBackColor = true;
      this.saveSettingButton.Click += new System.EventHandler(this.saveSettingButton_Click);
      // 
      // label5
      // 
      this.label5.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(122, 148);
      this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(84, 20);
      this.label5.TabIndex = 53;
      this.label5.Text = "Line width:";
      // 
      // lineWidthTextBox
      // 
      this.lineWidthTextBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
      this.lineWidthTextBox.Location = new System.Drawing.Point(214, 148);
      this.lineWidthTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.lineWidthTextBox.Name = "lineWidthTextBox";
      this.lineWidthTextBox.Size = new System.Drawing.Size(38, 26);
      this.lineWidthTextBox.TabIndex = 52;
      this.lineWidthTextBox.Text = "1";
      // 
      // buttonVisualDraw
      // 
      this.buttonVisualDraw.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
      this.buttonVisualDraw.Location = new System.Drawing.Point(894, 64);
      this.buttonVisualDraw.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.buttonVisualDraw.Name = "buttonVisualDraw";
      this.buttonVisualDraw.Size = new System.Drawing.Size(112, 35);
      this.buttonVisualDraw.TabIndex = 51;
      this.buttonVisualDraw.Text = "Visual";
      this.buttonVisualDraw.UseVisualStyleBackColor = true;
      this.buttonVisualDraw.Click += new System.EventHandler(this.buttonVisualDraw_Click);
      // 
      // label4
      // 
      this.label4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(125, 120);
      this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(81, 20);
      this.label4.TabIndex = 50;
      this.label4.Text = "Concavity:";
      // 
      // concaveTextBox
      // 
      this.concaveTextBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
      this.concaveTextBox.Location = new System.Drawing.Point(214, 117);
      this.concaveTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.concaveTextBox.Name = "concaveTextBox";
      this.concaveTextBox.Size = new System.Drawing.Size(38, 26);
      this.concaveTextBox.TabIndex = 49;
      this.concaveTextBox.Text = "0,3";
      // 
      // clusterDistanceTextBox
      // 
      this.clusterDistanceTextBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
      this.clusterDistanceTextBox.Location = new System.Drawing.Point(214, 87);
      this.clusterDistanceTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.clusterDistanceTextBox.Name = "clusterDistanceTextBox";
      this.clusterDistanceTextBox.Size = new System.Drawing.Size(38, 26);
      this.clusterDistanceTextBox.TabIndex = 48;
      this.clusterDistanceTextBox.Text = "10";
      // 
      // label2
      // 
      this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(114, 90);
      this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(92, 20);
      this.label2.TabIndex = 47;
      this.label2.Text = "Cluster dist:";
      // 
      // paintModeCheckBox
      // 
      this.paintModeCheckBox.AutoSize = true;
      this.paintModeCheckBox.Location = new System.Drawing.Point(6, 197);
      this.paintModeCheckBox.Name = "paintModeCheckBox";
      this.paintModeCheckBox.Size = new System.Drawing.Size(71, 24);
      this.paintModeCheckBox.TabIndex = 46;
      this.paintModeCheckBox.Text = "Paint";
      this.paintModeCheckBox.UseVisualStyleBackColor = true;
      this.paintModeCheckBox.CheckedChanged += new System.EventHandler(this.paintModeCheckBox_CheckedChanged);
      // 
      // cuttingPictureBox
      // 
      this.cuttingPictureBox.Location = new System.Drawing.Point(876, 14);
      this.cuttingPictureBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.cuttingPictureBox.Name = "cuttingPictureBox";
      this.cuttingPictureBox.Size = new System.Drawing.Size(432, 432);
      this.cuttingPictureBox.TabIndex = 47;
      this.cuttingPictureBox.TabStop = false;
      // 
      // selectionRangeSlider1
      // 
      this.selectionRangeSlider1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
      this.selectionRangeSlider1.Location = new System.Drawing.Point(37, 5);
      this.selectionRangeSlider1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.selectionRangeSlider1.Name = "selectionRangeSlider1";
      this.selectionRangeSlider1.Size = new System.Drawing.Size(1052, 20);
      this.selectionRangeSlider1.TabIndex = 16;
      // 
      // label6
      // 
      this.label6.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(78, 180);
      this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(128, 20);
      this.label6.TabIndex = 57;
      this.label6.Text = "Etalon line width:";
      // 
      // etalonLineWithTextBox
      // 
      this.etalonLineWithTextBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
      this.etalonLineWithTextBox.Location = new System.Drawing.Point(214, 177);
      this.etalonLineWithTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.etalonLineWithTextBox.Name = "etalonLineWithTextBox";
      this.etalonLineWithTextBox.Size = new System.Drawing.Size(38, 26);
      this.etalonLineWithTextBox.TabIndex = 56;
      this.etalonLineWithTextBox.Text = "1";
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1159, 694);
      this.Controls.Add(this.cuttingPictureBox);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.examplePictureBox);
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
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.cuttingPictureBox)).EndInit();
      this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonLoadImage;
        private System.Windows.Forms.ColorDialog colorDialog1;
    private SelectionRangeSlider selectionRangeSlider1;
    private System.Windows.Forms.PictureBox hslCointeinerPictureBox;
    private System.Windows.Forms.PictureBox maxPictureBox;
    private System.Windows.Forms.PictureBox minPictureBox;
    private System.Windows.Forms.TrackBar sValueTrackBar;
    private System.Windows.Forms.TrackBar lValueTrackBar;
    private System.Windows.Forms.Label sValueInfoLabel;
    private System.Windows.Forms.Label lValueInfoLable;
    private System.Windows.Forms.Button buttonDraw;
    private System.Windows.Forms.PictureBox examplePictureBox;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label exampleToAnalythLabel;
    private System.Windows.Forms.PictureBox analythPictureBox;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox textBoxColorSens;
    private System.Windows.Forms.Label labelTestValues;
    private System.Windows.Forms.Label executionInformation;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.CheckBox paintModeCheckBox;
    private System.Windows.Forms.TextBox clusterDistanceTextBox;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox concaveTextBox;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.PictureBox cuttingPictureBox;
    private System.Windows.Forms.Button buttonVisualDraw;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TextBox lineWidthTextBox;
    private System.Windows.Forms.Button saveSettingButton;
    private System.Windows.Forms.Button loadSettingButton;
    private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.TextBox etalonLineWithTextBox;
  }
}

