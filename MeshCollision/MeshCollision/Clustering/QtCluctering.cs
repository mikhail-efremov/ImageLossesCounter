using System.Collections.Generic;
using System.Drawing;

public static class PointExt
{
  public static int DistanceSquared(this Point p1, Point p2)
  {
    var diffX = p2.X - p1.X;
    var diffY = p2.Y - p1.Y;
    return diffX * diffX + diffY * diffY;
  }
}

static class QtClustering
{
  public static List<List<Point>> Start(List<Point> points, double maxDiameter)
  {
    return GetClusters(points, maxDiameter);
  }

  static List<List<Point>> GetClusters(List<Point> points, double maxDiameter)
  {
    if (points == null) return null;
    points = new List<Point>(points); // leave original List unaltered 
    var clusters = new List<List<Point>>();
    while (points.Count > 0)
    {
      var bestCandidate = GetBestCandidate(points, maxDiameter);
      clusters.Add(bestCandidate);
    }

    return clusters;
  }
  /* 
      GetBestCandidate() returns first candidate cluster encountered if there is more than one
      with the maximum number of points.
  */
  static List<Point> GetBestCandidate(List<Point> points, double maxDiameter)
  {
    var maxDiameterSquared = maxDiameter * maxDiameter; // square maximum diameter        
    var candidates = new List<List<Point>>(); // stores all candidate clusters
    var candidateNumbers = new int[points.Count]; // keeps track of candidate numbers to which points have been allocated
    var totalPointsAllocated = 0; // total number of points already allocated to candidates
    var currentCandidateNumber = 0; // current candidate number
    for (var i = 0; i < points.Count; i++)
    {
      if (totalPointsAllocated == points.Count)
        break; // no need to continue further 
      if (candidateNumbers[i] > 0)
        continue; // point already allocated to a candidate
      currentCandidateNumber++;
      var currentCandidate = new List<Point> {points[i]}; // stores current candidate cluster
      // add the current point to it
      candidateNumbers[i] = currentCandidateNumber;
      totalPointsAllocated++;
      var latestPoint = points[i]; // latest point added to current cluster
      var diametersSquared = new int[points.Count]; // diameters squared of each point when added to current cluster
                                                      // iterate through any remaining points
                                                      // successively selecting the point closest to the group until the threshold is exceeded
      while (true)
      {
        if (totalPointsAllocated == points.Count)
          break; // no need to continue further                
        var closest = -1; // index of closest point to current candidate cluster
        var minDiameterSquared = int.MaxValue; // minimum diameter squared, initialized to impossible value 
        for (var j = i + 1; j < points.Count; j++)
        {
          if (candidateNumbers[j] > 0)
            continue; // point already allocated to a candidate           
                                                 // update diameters squared to allow for latest point added to current cluster 
          var distSquared = latestPoint.DistanceSquared(points[j]);
          if (distSquared > diametersSquared[j]) diametersSquared[j] = distSquared;
          // check if closer than previous closest point
          if (diametersSquared[j] < minDiameterSquared)
          {
            minDiameterSquared = diametersSquared[j];
            closest = j;
          }
        }

        // if closest point is within maxDiameter, add it to the current candidate and mark it accordingly
        if (minDiameterSquared <= maxDiameterSquared)
        {
          currentCandidate.Add(points[closest]);
          candidateNumbers[closest] = currentCandidateNumber;
          totalPointsAllocated++;
        }
        else // otherwise finished with current candidate
        {
          break;
        }
      }
      // add current candidate to candidates list
      candidates.Add(currentCandidate);
    }
    // now find the candidate cluster with the largest number of points
    int maxPoints = -1; // impossibly small value
    int bestCandidateNumber = 0; // ditto
    for (int i = 0; i < candidates.Count; i++)
    {
      if (candidates[i].Count > maxPoints)
      {
        maxPoints = candidates[i].Count;
        bestCandidateNumber = i + 1; // counting from 1 rather than 0
      }
    }
    // iterating backwards to avoid indexing problems, remove points in best candidate from points list
    // this will automatically be persisted to caller as List<Point> is a reference type
    for (var i = candidateNumbers.Length - 1; i >= 0; i--)
    {
      if (candidateNumbers[i] == bestCandidateNumber)
        points.RemoveAt(i);
    }

    // return best candidate to caller                
    return candidates[bestCandidateNumber - 1];
  }
}