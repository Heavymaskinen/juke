using System;
using System.IO;

namespace Juke.UI.Console.Component
{
    public class Label:ScreenComponent
    {
        private string text;

        public ConsoleColor Color { get; set; }

        public Label(string text)
        {
            this.text = text;
        }

        public void Render()
        {
            var currentColor = System.Console.ForegroundColor;
            System.Console.ForegroundColor = Color;
            System.Console.WriteLine(text);
            System.Console.ForegroundColor = currentColor;
        }
    }
}