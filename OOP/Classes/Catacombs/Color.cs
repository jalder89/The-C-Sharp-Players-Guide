namespace PlayersGuide.Classes.Catacombs
{

    /// <summary>
    /// The second pedestal asks you to create a Color class to represent a color. 
    /// The pedestal includes an etching of this diagram that illustrates its potential usage: 
    /// The color consists of three parts or channels: red, green, and blue, which indicate how much those 
    /// channels are lit up. Each channel can be from 0 to 255. 0 means completely off; 255 means completely on.
    /// 
    /// The pedestal also includes some color names, with a set of numbers indicating their specific values for
    /// each channel. These are commonly used colors: White (255, 255, 255), Black (0, 0, 0), Red (255, 0, 0), 
    /// Orange (255,165, 0), Yellow (255, 255, 0), Green (0, 128, 0), Blue (0, 0, 255), Purple (128, 0, 128).
    /// 
    /// Objectives:
    /// • Define a new Color class with properties for its red, green, and blue channels.
    /// • Add appropriate constructors that you feel make sense for creating new Color objects.
    /// • Create static properties to define the eight commonly used colors for easy access.
    /// • In your main method, make two Color-typed variables. Use a constructor to create a color instance and use a 
    ///   static property for the other. Display each of their red, green, and blue channel values.
    /// </summary>
    public class Color
    {
        public int R { get; }
        public int G { get; }
        public int B { get; }

        public static readonly Color Red = new Color(255, 0, 0);
        public static readonly Color Green = new Color(0, 255, 0);
        public static readonly Color Blue = new Color(0, 0, 255);
        public static readonly Color Black = new Color(0, 0, 0);
        public static readonly Color White = new Color(255, 255, 255);
        public static readonly Color Orange = new Color(255, 165, 0);
        public static readonly Color Yellow = new Color(255, 255, 0);
        public static readonly Color Purple = new Color(128, 0, 128);

        public Color() : this(0, 0, 0)
        {

        }

        public Color(int red, int green, int blue)
        {
            R = Math.Clamp(red, 0, 255);
            G = Math.Clamp(green, 0, 255);
            B = Math.Clamp(blue, 0, 255);
        }
    }
}
