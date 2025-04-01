using SQLite;

namespace RGBMAUI
{
    public class ColorDb
    {
        [PrimaryKey, MaxLength (100)]
        public string Name { get; set; }
        public int Red { get; set; }
        public int Green { get; set; }
        public int Blue { get; set; }

    }
}
