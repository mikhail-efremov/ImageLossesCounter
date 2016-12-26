﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MeshCollision
{
    public partial class Form1 : Form
    {
        private Bitmap bitmap;
        private int linesCount = 1;
        private byte _sens = 1;

        public Form1()
        {
            InitializeComponent();
            LoadImage();
            FillColorPickRegion(Color.Black);
        }

        private void LoadImage()
        {
            Image image = UploadImage();

            if (image == null)
                return;

            pictureBox1.Image = image;
            bitmap = new Bitmap(image);
        }

        private void InvalidateImage()
        {
            if (bitmap == null)
                return;

            int count;
            if (int.TryParse(textBoxLinesCount.Text, out count))
            {
                linesCount = count;
            }
            
            pictureBox1.Invalidate();
        }

        public Bitmap UploadImage()
        {
            var open = new OpenFileDialog
            {
                Filter = @"Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp"
            };

            return open.ShowDialog() == DialogResult.OK ? new Bitmap(open.FileName) : null;
        }
        
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            float weightIndent = bitmap.Width / (float)linesCount;
            float heightIndent = bitmap.Height / (float)linesCount;

            List<Line> lines = new List<Line>();
            Graphics graphics = e.Graphics;
            Brush brush = Brushes.Red;

//horizontal
            for (int index = 0; index < linesCount; index++)
            {
                Point xpt = new Point(0, (int)Math.Round(index * heightIndent));
                Point ypt = new Point(bitmap.Width, (int)Math.Round(heightIndent * index));
                
                Line line = new Line(xpt, ypt, bitmap.Width);
                lines.Add(line);
            }

//vertical
            for (var index = 0; index < linesCount; index++)
            {
                Point xpt = new Point((int)Math.Round(index* weightIndent), 0);
                Point ypt = new Point((int)Math.Round(index* weightIndent), bitmap.Height);

                Line line = new Line(xpt, ypt, bitmap.Height);
                lines.Add(line);
            }
          
            Color customColor = pictureColorBox.BackColor;
            int hits = 0;
            try
            {
                foreach (Line line in lines)
                {
                    foreach (Point point in line.Points)
                    {
                        if (StaticMethods.ColorSimilar(customColor, bitmap.GetPixel(point.X, point.Y), _sens))
                        {
                            hits++;
                            e.Graphics.FillRectangle(new SolidBrush(customColor), point.X, point.Y, 1, 1);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            if (checkBoxDrawMesh.Checked)
            {
                foreach (Line line in lines)
                {
                    foreach (Point point in line.Points)
                    {
                        e.Graphics.FillRectangle(brush, point.X, point.Y, 1, 1);
                    }
                }
            }

            pictureBox1.Image = bitmap;
            InvalidateImage();

            labelHitsCount.Text = @"Hits: " + hits;
        }

        private void buttonDraw_Click(object sender, EventArgs e)
        {
            InvalidateImage();
        }

        private void FillColorPickRegion(Color color)
        {
            int regionSize = 30;

            Bitmap flag = new Bitmap(regionSize, regionSize);
            Graphics flagGraphics = Graphics.FromImage(flag);
            int iterator = 0;
            while (iterator <= regionSize)
            {
                var myBrush = new SolidBrush(colorDialog1.Color);
                flagGraphics.FillRectangle(myBrush, 0, iterator, regionSize, regionSize);
                iterator++;
            }
            pictureColorBox.Image = flag;
            pictureColorBox.BackColor = color;
        }

        private void buttonLoadImage_Click(object sender, EventArgs e)
        {
            LoadImage();
            InvalidateImage();
        }

        private void trackBarSens_ValueChanged(object sender, EventArgs e)
        {
            labelSens.Text = trackBarSens.Value.ToString();
            _sens = (byte)trackBarSens.Value;
            InvalidateImage();
        }

        private void pictureColorBox_Click(object sender, EventArgs e)
        {
            this.Hide();
            DialogResult result = colorDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                FillColorPickRegion(colorDialog1.Color);
                InvalidateImage();
            }
            this.Show();
        }
    }
}