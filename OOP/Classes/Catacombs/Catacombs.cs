using PlayersGuide.Classes.Catacombs;

namespace PlayersGuide.Classes.Catacombs
{
    /// <summary>
    /// Each point is represented by an x-coordinate (x), a side-to-side distance from a special central point called the origin,
    /// and a y-coordinate (y), an up-and-down distance away from the origin.
    /// Objectives:
    /// • Define a new Point class with properties for X and Y.
    /// • Add a constructor to create a point from a specific x- and y-coordinate.
    /// • Add a parameterless constructor to create a point at the origin (0, 0).
    /// • In your main method, create a point at (2, 3) and another at (-4, 0). 
    ///      • Display these points on the console window in the format (x, y) to illustrate that the class works.
    /// • Answer this question: Are your X and Y properties immutable? Why did you choose what you did?
    /// </summary>
    public static class Catacombs
    {
        private static Point[]? _points;
        public static void Run()
        {
            _points = new Point[2];
            _points[0] = PointManager.CreatePoint(2, 3);
            _points[1] = PointManager.CreatePoint(-4, 0);

            int i = 0;
            foreach (Point point in _points)
            {
                Console.WriteLine($"Location of point {i + 1}: ({_points[i].X}, {_points[i].Y})");
                i++;
            }

            Color orange = Color.Orange;
            Console.WriteLine($"A new color was born! R:{orange.R} G:{orange.G} B: {orange.B}");

            Color newColor = new Color(234, 45, 174);
            Console.WriteLine($"A new color was born! R:{newColor.R} G:{newColor.G} B: {newColor.B}");

        }
    }
}

