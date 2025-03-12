using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGBMAUI
{
    class FakeColorRepository : IColorsRepository
    {
        public IList<NamedColor> NamedColors { get; private set; }
        public void AddColor(NamedColor color)
        {
            var test = new NamedColor
            {
                Name = "Gray",
                Red = 173,
                Green = 173,
                Blue = 173
            };
            NamedColors.Add(test);
        }

        public void DeleteColor(NamedColor color)
        {
            NamedColors.Remove(color);
        }

        public IList<NamedColor> GetColors()
        {
            return NamedColors;
        }

        public FakeColorRepository()
        {
            NamedColors = new List<NamedColor>();

            NamedColors.Add(new NamedColor
            {
                Name = "Red",
                Red = 255,
                Green = 0,
                Blue = 0
            });

            NamedColors.Add(new NamedColor
            {
                Name = "Blue",
                Red = 0,
                Green = 0,
                Blue = 255

            });

            NamedColors.Add(new NamedColor
            {
                Name = "Green",
                Red = 0,
                Green = 255,
                Blue = 0

            });

            NamedColors.Add(new NamedColor
            {
                Name = "Yellow",
                Red = 255,
                Green = 255,
                Blue = 0

            });

            NamedColors.Add(new NamedColor
            {
                Name = "White",
                Red = 255,
                Green = 255,
                Blue = 255

            });

            NamedColors.Add(new NamedColor
            {
                Name = "Black",
                Red = 0,
                Green = 0,
                Blue = 0

            });

            NamedColors.Add(new NamedColor
            {
                Name = "Orange",
                Red = 255,
                Green = 165,
                Blue = 0

            });

            NamedColors.Add(new NamedColor
            {
                Name = "Brown",
                Red = 66,
                Green = 40,
                Blue = 20

            });

            NamedColors.Add(new NamedColor
            {
                Name = "Violet",
                Red = 255,
                Green = 0,
                Blue = 255

            });

            NamedColors.Add(new NamedColor
            {
                Name = "Cyan",
                Red = 0,
                Green = 255,
                Blue = 255

            });
            System.Diagnostics.Debug.WriteLine("Hello");
        }
    }
}
