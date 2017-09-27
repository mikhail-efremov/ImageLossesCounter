using System.Collections.Generic;
using System.Drawing;
using Accord.Controls;
using Accord.MachineLearning;
using Accord.Math.Distances;
using Accord.Statistics.Distributions.DensityKernels;

namespace utorials.Clustering.Hard
{
  public class Clastering
  {
    public static int[] StartKMeans(List<Point> points, int clastersCount)
    {
      var p = ConvertPoints(points);

      return Kmeans(p, clastersCount, false);
    }

    public static int[] StartBinarySplit(List<Point> points, int clustersCount)
    {
      var p = ConvertPoints(points);

      return BinarySplit(p, clustersCount, false);
    }

    private static double[][] ConvertPoints(List<Point> points)
    {
      var ints = new double[points.Count][];
      for (var i = 0; i < points.Count; i++)
      {
        ints[i] = new[] { points[i].X, (double)points[i].Y };
      }
      return ints;
    }

    private static void Start(double[][] inputs)
    {
      ScatterplotBox.Show("Three groups", inputs).Hold();

      Kmeans(inputs, 1, false);
      BinarySplit(inputs, 1, false);
    }

    public static int[] Kmeans(double[][] inputs, int clustersCount, bool protGrapth)
    {
      var kmeans = new KMeans(k: clustersCount)
      {
        Distance = new SquareEuclidean(),
        MaxIterations = 1000        
      };

      var model = kmeans.Learn(inputs);

      var prediction = model.Decide(inputs);

      if (protGrapth)
        ScatterplotBox.Show("KMeans's answer", inputs, prediction).Hold();

      return prediction;
    }

    private static int[] BinarySplit(double[][] inputs, int clustersCount, bool protGrath)
    {
      var binarySplit = new BinarySplit(k: clustersCount)
      {
        Distance = new SquareEuclidean(),
        MaxIterations = 1000
      };

      var model = binarySplit.Learn(inputs);

      var prediction = model.Decide(inputs);

      if (protGrath)
        ScatterplotBox.Show("Binary Split's answer", inputs, prediction).Hold();

      return prediction;
        }

        private static void meanShift(double[][] inputs)
        {
            // Create a mean-shfit algorithm
            var kmeans = new MeanShift()
            {
                Bandwidth = 0.1,
                Kernel = new EpanechnikovKernel(),
                Distance = new Euclidean(),
                MaxIterations = 1000
            };

            // Use it to learn a data model
            var model = kmeans.Learn(inputs);

            // Use the model to group new instances
            int[] prediction = model.Decide(inputs);

            // Plot the results
            ScatterplotBox.Show("Mean-Shift's answer", inputs, prediction).Hold();
        }
  }
}