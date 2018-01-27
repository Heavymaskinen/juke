using System;
using Juke.UI.Console.Component;
using Juke.UI.Console.Screen;

namespace Juke.UI.Console
{
    public class MainLogic
    {
        private BaseScreen screen;

        public MainLogic()
        {
            screen = new BaseScreen();
            screen.AddComponent(new Label("Hejhejhej") {Color = ConsoleColor.Blue});
            screen.AddComponent(new Label("Hejhejhej2") {Color = ConsoleColor.DarkGreen});
            screen.AddComponent(new Rectangle(10,10));
        }

        public void Run()
        {
            var input = "";
            while (input != "exit")
            {
                System.Console.Clear();
                screen.Render();
                input = System.Console.ReadLine();
            }
        }
    }
}