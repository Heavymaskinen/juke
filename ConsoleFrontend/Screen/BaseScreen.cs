using System.Collections.Generic;
using System.IO;
using System.Linq;
using Juke.UI.Console.Component;

namespace Juke.UI.Console.Screen
{
    public class BaseScreen
    {
        protected IList<ScreenComponent> components;

        public BaseScreen()
        {
            components = new List<ScreenComponent>();
        }

        public void AddComponent(ScreenComponent component)
        {
            components.Add(component);
        }

        public void Render()
        {
            foreach (var component in components)
            {
                component.Render();
            }
        }
    }
}