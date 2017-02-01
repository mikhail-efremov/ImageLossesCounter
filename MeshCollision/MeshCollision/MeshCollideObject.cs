using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Threading.Tasks;

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

			searchingColorPictureBox.Size = colorBoxSize;
			searchingColorPictureBox.BackColor = searchColor;
			searchingColorPictureBox.Click += DetectionColorPictureBox_Click;

			meshColorPictureBox.Size = colorBoxSize;
			meshColorPictureBox.BackColor = colorBoxColor;
			meshColorPictureBox.Click += MeshColorPictureBox_Click;

			hitsLabel.Text = "0";
			averageCoincidencesLabel.Text = "0";
			coincidencesWithoutInterruptLabel.Text = "0";
			LinesCount = 30;
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

		public List<Line> GetRawMesh(Bitmap bitmap) {
			float weightIndent = 0;
			float heightIndent = 0;
			int linesCount = LinesCount;

			if (linesCount >= bitmap.Width) {
				linesCount = bitmap.Width;
			}
			weightIndent = bitmap.Width / (float)linesCount;

			if (linesCount >= bitmap.Height) {
				linesCount = bitmap.Height;
			}
			heightIndent = bitmap.Height / (float)linesCount;

			List<Line> lines = new List<Line>();

			//horizontal
			for (int index = 0; index < linesCount; index++) {
				Point xpt = new Point(0, (int)Math.Round(index * heightIndent));
				Point ypt = new Point(bitmap.Width, (int)Math.Round(heightIndent * index));

				Line line = new Line(xpt, ypt, bitmap.Width);
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

		public List<Line> GetSimilarMesh(List<Line> lines, Bitmap bitmap, List<MeshCollideObject> except) {
			Color customColor = searchingColorPictureBox.BackColor;
			int sens = DetectionSens;

			SimilarMesh.Clear();

			foreach (Line line in lines) {
				Line searchLine = new Line();

				foreach (Point point in line.Points) {
					if (StaticMethods.ColorSimilar(customColor, bitmap.GetPixel(point.X, point.Y), (byte)sens)) {
						if (!SimilarMesh.Contains(searchLine)) {
							SimilarMesh.Add(searchLine);
						}
						/*
						bool add = true;
						foreach (var exc in except) {
							/*							if(exc.SimilarMesh.Count <= exc.SimilarMesh.IndexOf(searchLine))
															if (exc.SimilarMesh[exc.SimilarMesh.IndexOf(searchLine)].Points.Contains(point)) 
															{
																add = false;
															}
													}
							*/
							/*
						foreach (var l in exc.SimilarMesh) {
								foreach (var p in l.Points) {
									if (point.X == p.X) {
										if (point.Y == p.Y) {
											add = false;
											goto HACK;
										}
									}
								}
							}
						}
						HACK:
					*/
			//			if(add)
							SimilarMesh[SimilarMesh.IndexOf(searchLine)].Points.Add(point);
					}
				}
			}

			return SimilarMesh;
		}

		public CustomControl[] GetControlls() {
			var controlls = new List<CustomControl>();

			controlls.Add(new CustomControl("Hits:", hitsLabel));
			controlls.Add(new CustomControl("Average coincideces length:", averageCoincidencesLabel));
			controlls.Add(new CustomControl("Coincidence without interrupt:", coincidencesWithoutInterruptLabel));
			controlls.Add(new CustomControl("Lines count:", linesCountLabel));
			controlls.Add(new CustomControl("Mesh color:", meshColorPictureBox));
			controlls.Add(new CustomControl("Searching color:", searchingColorPictureBox));
			controlls.Add(new CustomControl("Sens:", detectionSensLabel));
			controlls.Add(new CustomControl("Sens trackbar:", sensTrackBar));
			
			return controlls.ToArray();
		}
	}
}