namespace TurtleGraphicsCode
{
    public class LSystem2
    {
        public Turtle Create(int iterations)
        {
            // F, +, -, [, ],
            // 'F' -> 
            // "FF+[+F-F-F]-[-F+F+F]"
            // F => Forward by 5
            // + => Rotate by 25
            // - => Rotate by -25
            // [ => Store position
            // ] => Restore position

            string start = "F";

            for (int i = 0; i < iterations; i++)
            {
                start = Generate(start);
            }

            return new Turtle();
        }

        private string Generate(string current)
        {
            if (current == "F")
            {
                return "FF+[+F-F-F]-[-F+F+F]";
            }
            return current;
        }
    }
}
