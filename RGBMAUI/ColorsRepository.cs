namespace RGBMAUI
{
    internal class ColorsRepository : IColorsRepository
    {

        public IList<NamedColor> NamedColors { get; private set; }
        private Database db;
        public async void AddColor(NamedColor color)
        {

            NamedColors.Add(color);
            await db.AddColorsDb(color);
        }

        public async void DeleteColor(NamedColor color)
        {
            NamedColors.Remove(color);
            await db.DeleteColorDb(color);
        }

        public async Task<IList<NamedColor>> GetColors()
        {
            var colorsDb = await db.GetColorsDb();
            NamedColors = colorsDb.Select(c => new NamedColor(c.Name, c.Red, c.Green, c.Blue)).ToList();
            return NamedColors;
        }

        public ColorsRepository()
        {
            NamedColors = new List<NamedColor>();
            db = new Database();
        }
    }
}