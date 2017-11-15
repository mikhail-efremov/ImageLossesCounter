using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MeshCollision.Controlls
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
    public Button ChangeColorButton { get { return changeColorButton; } }

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
			var form = Form.ActiveForm;
			form.Hide();
			var cd = new ColorDialog();
			cd.ShowDialog();
			searchingColorPictureBox.BackColor = cd.Color;
			form.Show();
		}

		private void MeshColorPictureBox_Click(object sender, EventArgs e) {
			var form = Form.ActiveForm;
			form.Hide();
			var cd = new ColorDialog();
			cd.ShowDialog();
			meshColorPictureBox.BackColor = cd.Color;
			form.Show();
		}

		public static List<Line> GetRawMesh(Bitmap bitmap, float indent)
		{
			var weightIndent = indent;
			var heightIndent = indent;
      
      var	widthLinesCount = bitmap.Width / weightIndent;      
      var	heightLinesCount = bitmap.Height / heightIndent;
      
			var lines = new List<Line>();

			//horizontal
			for (var index = 0; index < heightLinesCount; index++)
			{
			  var coordinate = (int)Math.Round(index * heightIndent);

			  var xpt = new Point(0, coordinate);
        var ypt = new Point(bitmap.Width, coordinate);

				var line = new Line(xpt, ypt, bitmap.Width);
				lines.Add(line);
			}
      
			//vertical
			for (var index = 0; index < widthLinesCount; index++)
			{
			  var coordinate = (int)Math.Round(index * weightIndent);

				var xpt = new Point(coordinate, 0);
				var ypt = new Point(coordinate, bitmap.Height);

				var line = new Line(xpt, ypt, bitmap.Height);
				lines.Add(line);
			}
      //meybe need to remove dublicats

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