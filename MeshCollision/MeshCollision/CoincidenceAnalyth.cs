using System.Drawing;
using System.Collections.Generic;

namespace MeshCollision
{
	public class CoincidenceAnalyth
	{
		public static List<Line> GetCoincidence(List<Line> lines) 
		{
			List<Line> result = new List<Line>();
			Point lastPoint = default(Point);
			Line currentLine = null;

			foreach (Line line in lines)
			{
				foreach (Point point in line.Points) {
					if (lastPoint == default(Point)) {
						lastPoint = point;
						currentLine = new Line();
						currentLine.Points.Add(lastPoint);
						continue;
					}
					if (StaticMethods.PointIsBeside(point, lastPoint)) {
						lastPoint = point;
						currentLine.Points.Add(lastPoint);
					}
					else {
						lastPoint = default(Point);
						result.Add(currentLine);
						currentLine = null;
					}
				}
			}
			return result;
		}
	}
}