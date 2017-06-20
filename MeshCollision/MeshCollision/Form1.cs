using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Threading.Tasks;
using MeshCollision.ColorSpaces;

namespace MeshCollision
{
  public partial class Form1 : Form
  {
    private ImageAnalyzer _imageAnalyzer;

    public Form1()
    {
      InitializeComponent();
      
      colorGetPictureBox.BackColor = Color.Black;
      
      sValueTrackBar.Value = 1000;
      lValueTrackBar.Value = 500;

      UploadImage();
    }
    
    private bool UploadImage() {
      var open = new OpenFileDialog
      {
        Filter = @"Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp"
      };

      var image = open.ShowDialog() == DialogResult.OK ? new Bitmap(open.FileName) : null;

      if (image == null)
        return false;
      
      _imageAnalyzer = new ImageAnalyzer(image);
      pictureBox1.Image = image;
      return true;
    }

    private void InvalidateImage()
    {
      if (pictureBox1.Image == null)
        return;
      pictureBox1.Invalidate();
    }
    
    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
      PaintHslCointeinerPictureBox();
      InvalidateImage();
    }

    private void PaintHslCointeinerPictureBox() 
    {
      if (selectionRangeSlider1.CurrentSelectionElement == null)
        return;

      var image = new Bitmap(hslCointeinerPictureBox.InitialImage, hslCointeinerPictureBox.Size);
      var width = hslCointeinerPictureBox.Size.Width;
      
      for (var i = 0; i < width; i++)
      {
        var color = HslColorSpace.ColorFromHsl((double)i / width,
          selectionRangeSlider1.CurrentSelectionElement.SValue1,
          selectionRangeSlider1.CurrentSelectionElement.LValue1);

        for (var j = 0; j < image.Size.Height; j++)
        {
          image.SetPixel(i, j, color);
        }
      }

      hslCointeinerPictureBox.Image = image;
    }

    private void buttonLoadImage_Click(object sender, EventArgs e)
    {
      UploadImage();
      InvalidateImage();
    }

    private void SuperSliderAddeder(SelectionRangeSlider slider) {
      var mMin = 0;
      var mMax = 360;

      foreach (var sli in slider.Sliders) {
        if (sli.SelectedMin == 0 && sli.SelectedMax == mMax) {
          return;
        }
        if (sli.SelectedMax != mMax)
          if (sli.SelectedMax > mMin) {
            mMin = sli.SelectedMax + 1;
            continue;
          }
        if (sli.SelectedMin != 0)
          if (sli.SelectedMin < mMax) {
            mMax = sli.SelectedMin - 1;
          }
      }
      var slide = new SelectionElement(mMax, mMin, colorGetPictureBox.BackColor);
      slider.AddSelectionElement(slide);

      slide.SelectionChanged += OnSlideSelectionChanged;
      slide.ElementSelected += OnSliderElementSelected;
      OnSlideSelectionChanged(slide, null);
    }

    private void OnSlideSelectionChanged(object sender, EventArgs eventArgs) {
      selectionRangeSlider1.Invalidate();
      
      var element = (SelectionElement) sender;
      SetMinMaxColorBoxes(element);
    }

    private void DrawMesh(SelectionRangeSlider selectionRangeSlider, int minH, int maxH)
    {
      var element = selectionRangeSlider.CurrentSelectionElement;

      element.SelectedMin = minH;
      element.SelectedMax = maxH;

      selectionRangeSlider.Invalidate();
    }

    private void OnSliderElementSelected(object sender, EventArgs eventArgs) 
    {
      var element = (SelectionElement)sender;
      colorGetPictureBox.BackColor = element.LinesColor;
      sValueTrackBar.Value = element.SValue1000;
      lValueTrackBar.Value = element.LValue1000;
      OnSlideSelectionChanged(sender, eventArgs);
      hitsTextBox.Text = element.Hits.ToString();
    }

    private void SetMinMaxColorBoxes(SelectionElement element)
    {
      var min = element.SelectedMin;
      var max = element.SelectedMax;

      var minColor = HslColorSpace.ColorFromHsl((double)min / element.Max, element.SValue1, element.LValue1);
      var maxColor = HslColorSpace.ColorFromHsl((double)max / element.Max, element.SValue1, element.LValue1);

      SetColorPictureBox(maxPictureBox, maxColor);
      SetColorPictureBox(minPictureBox, minColor);
    }

    private void SetColorPictureBox(PictureBox pictureBox, Color color)
    {
      var newPic = new Bitmap(pictureBox.InitialImage);

      for (var i = 0; i < newPic.Width; i++) {
        for (var j = 0; j < newPic.Height; j++) {
          newPic.SetPixel(i, j, color);
        }
      }
      pictureBox.Image = newPic;
    }

    private void button1_Click_1(object sender, EventArgs e)
    {
      SuperSliderAddeder(selectionRangeSlider1);
    }

    private void sValueTrackBar_ValueChanged(object sender, EventArgs e)
    {
      if (selectionRangeSlider1.CurrentSelectionElement == null) return;
      selectionRangeSlider1.CurrentSelectionElement.SValue1000 = sValueTrackBar.Value;
      OnSlideSelectionChanged(selectionRangeSlider1.CurrentSelectionElement, null);
    }

    private void lValueTrackBar_ValueChanged(object sender, EventArgs e) 
    {
      if (selectionRangeSlider1.CurrentSelectionElement == null) return;
      selectionRangeSlider1.CurrentSelectionElement.LValue1000 = lValueTrackBar.Value;
      OnSlideSelectionChanged(selectionRangeSlider1.CurrentSelectionElement, null);
    }
    
    private void colorGetPictureBox_Click(object sender, EventArgs e) {
      var form = ActiveForm;
      if (form == null) return;
      form.Hide();
      var cd = new ColorDialog();
      cd.ShowDialog();
      colorGetPictureBox.BackColor = cd.Color;
      form.Show();
      if(selectionRangeSlider1.CurrentSelectionElement == null)
        return;
      selectionRangeSlider1.CurrentSelectionElement.LinesColor = cd.Color;
    }

    private void buttonDraw_Click(object sender, EventArgs e)
    {
      AnalizeImageAsync();
    }

    private async void AnalizeImageAsync() 
    {
      var analizedImage = await _imageAnalyzer.Analize(selectionRangeSlider1.CurrentSelectionElement);
      if (analizedImage != null)
        pictureBox1.Image = analizedImage;
    }
  }
}