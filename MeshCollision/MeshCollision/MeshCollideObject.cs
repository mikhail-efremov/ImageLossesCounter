using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace MeshCollision
{
	public class MeshCollideObject
	{
		public List<Line> SimilarMesh = new List<Line>();

		private Label hitsLabel = new Label();
		public int Hits {
			get { return Int32.Parse(hitsLabel.Text); }
			set { hitsLabel.Text = value.ToString(); }
		}

		private Label averageCoincidencesLabel = new Label();
		public int AverageCoincidences {
			get { return Int32.Parse(averageCoincidencesLabel.Text); }
			set { averageCoincidencesLabel.Text = value.ToString(); }
		}

		private Label coincidencesWithoutInterruptLabel = new Label();
		public int CoincidencesWithoutInterrupt {
			get { return Int32.Parse(coincidencesWithoutInterruptLabel.Text); }
			set { coincidencesWithoutInterruptLabel.Text = value.ToString(); }
		}
		
		private Label linesCountLabel = new Label();
		public int LinesCount {
			get { return Int32.Parse(linesCountLabel.Text); }
			set { linesCountLabel.Text = value.ToString(); }
		}

		private PictureBox meshColorPictureBox = new PictureBox();
		public Color MeshColor {
			get { return meshColorPictureBox.BackColor; }
			set { meshColorPictureBox.BackColor = value; }
		}

    private Button changeColorButton = new Button();
    public Button ChangeColorButton => changeColorButton;

	  private PictureBox searchingColorPictureBox = new PictureBox();
		public Color SearchingColor {
			get { return searchingColorPictureBox.BackColor; }
			set { searchingColorPictureBox.BackColor = value; }
		}
		
		private Label detectionSensLabel = new Label();
		private TrackBar sensTrackBar = new TrackBar();
		public int DetectionSens {
			get { return Int32.Parse(detectionSensLabel.Text); }
			set { detectionSensLabel.Text = value.ToString(); }
		}

		public MeshCollideObject() {
			var colorBoxSize = new Size(50, 10);
			var colorBoxColor = Color.Red;
			var searchColor = Color.Green;

		  changeColorButton.Text = @"Change color";
		  changeColorButton.Width = 100;
      changeColorButton.Click += (sender, args) =>
      {
        var form = Form1.ActiveForm;
        form.Hide();
        /*
        var newForm = new Form();

        var pic = new PictureBox();
        pic.Image = new Bitmap(Form1.Bitmap.Bitmap);
        newForm.Size = form.Size;
        pic.Size = Form1.Bitmap.Bitmap.Size;
        pic.Click += (o, eventArgs) =>
        {
          var mArgs = (MouseEventArgs) eventArgs;
          Form1.Bitmap.Lock();
          var pixel = Form1.Bitmap.GetPixel(mArgs.X, mArgs.Y);
          Form1.Bitmap.Unlock();
          searchingColorPictureBox.BackColor = Color.FromArgb(pixel.R, pixel.G, pixel.B);
          var form1 = Form1.ActiveForm;
          form1.Hide();

          form.Show();
        };
        newForm.Controls.Add(pic);
        newForm.ShowDialog();
        */
        form.Show();
      };

      searchingColorPictureBox.Size = colorBoxSize;
			searchingColorPictureBox.BackColor = searchColor;
			searchingColorPictureBox.Click += DetectionColorPictureBox_Click;
      
			meshColorPictureBox.Size = colorBoxSize;
			meshColorPictureBox.BackColor = colorBoxColor;
			meshColorPictureBox.Click += MeshColorPictureBox_Click;

			hitsLabel.Text = "0";
			averageCoincidencesLabel.Text = "0";
			coincidencesWithoutInterruptLabel.Text = "0";
			LinesCount = 60; // LINES COUNT
			detectionSensLabel.Text = "0";
			DetectionSens = 0;

			sensTrackBar.Maximum = 255;
			sensTrackBar.ValueChanged += SensTrackBar_ValueChanged;
		}

		private void SensTrackBar_ValueChanged(object sender, EventArgs e) {
			TrackBar track = (TrackBar)sender;
			DetectionSens = track.Value;
		}

		private void DetectionColorPictureBox_Click(object sender, EventArgs e) {
			var form = Form1.ActiveForm;
			form.Hide();
			ColorDialog cd = new ColorDialog();
			cd.ShowDialog();
			searchingColorPictureBox.BackColor = cd.Color;
			form.Show();
		}

		private void MeshColorPictureBox_Click(object sender, EventArgs e) {
			var form = Form1.ActiveForm;
			form.Hide();
			ColorDialog cd = new ColorDialog();
			cd.ShowDialog();
			meshColorPictureBox.BackColor = cd.Color;
			form.Show();
		}

		public static List<Line> GetRawMesh(Bitmap bitmap, int linesCount) {
			float weightIndent = 0;
			float heightIndent = 0;

			if (linesCount >= bitmap.Width) {
				linesCount = bitmap.Width;
			}
			weightIndent = bitmap.Width / (float)linesCount;

			if (linesCount >= bitmap.Height) {
				linesCount = bitmap.Height;
			}
			heightIndent = bitmap.Height / (float)linesCount;

			var lines = new List<Line>();

			//horizontal
			for (int index = 0; index < linesCount; index++) {
				var xpt = new Point(0, (int)Math.Round(index * heightIndent));
				var ypt = new Point(bitmap.Width, (int)Math.Round(heightIndent * index));

				var line = new Line(xpt, ypt, bitmap.Width);
				lines.Add(line);
			}

			//vertical
			for (var index = 0; index < linesCount; index++) {
				Point xpt = new Point((int)Math.Round(index * weightIndent), 0);
				Point ypt = new Point((int)Math.Round(index * weightIndent), bitmap.Height);

				Line line = new Line(xpt, ypt, bitmap.Height);
				lines.Add(line);
			}

			return lines;
		}

		public CustomControl[] GetControlls() {
		  var controlls = new List<CustomControl>
		  {
		    new CustomControl("Hits:", hitsLabel),
		    new CustomControl("Average coincideces length:", averageCoincidencesLabel),
		    new CustomControl("Coincidence without interrupt:", coincidencesWithoutInterruptLabel),
		    new CustomControl("Lines count:", linesCountLabel),
		    new CustomControl("Mesh color:", meshColorPictureBox),
        new CustomControl(string.Empty, ChangeColorButton),
		    new CustomControl("Searching color:", searchingColorPictureBox),
		    new CustomControl("Sens:", detectionSensLabel),
		    new CustomControl("Sens trackbar:", sensTrackBar)
		  };
      
		  return controlls.ToArray();
		}
	}
}