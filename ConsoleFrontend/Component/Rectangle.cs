namespace Juke.UI.Console.Component
{
    public class Rectangle : ScreenComponent
    {
        private int width, height;

        public Rectangle(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public void Render()
        {
            var currentLeft = System.Console.CursorLeft;
            var currentTop = System.Console.CursorTop;

            var topLine = "";
            for (var x = 0; x < width; x++)
            {
                topLine += "* ";
            }

            System.Console.WriteLine(topLine);
            System.Console.CursorLeft = currentLeft;
            var verticalLine = "";
            for (var y = 0; y < height; y++)
            {
                System.Console.CursorLeft = currentLeft;
                System.Console.CursorTop = currentTop + 1 + y;
                System.Console.Out.Write("*");
            }

            for (var y = 0; y <= height; y++)
            {
                System.Console.CursorLeft = currentLeft + width*2;
                System.Console.CursorTop = currentTop + y;
                System.Console.Out.Write("*");
            }


            System.Console.Write(verticalLine);

            System.Console.CursorLeft = currentLeft;
            System.Console.CursorTop = currentTop + height;
            System.Console.WriteLine(topLine);

            System.Console.CursorLeft = currentLeft;
            System.Console.CursorTop = currentTop + height+1;
        }
    }
}