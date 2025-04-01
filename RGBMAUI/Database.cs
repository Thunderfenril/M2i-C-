using SQLite;

namespace RGBMAUI
{
    public class Database
    {

        SQLiteAsyncConnection db;

        async Task Init()
        {
            if (db is not null)
            {
                return;
            }

            db = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            var result = await db.CreateTableAsync<ColorDb>();
        }

        public async Task<List<ColorDb>> GetColorsDb()
        {
            await Init();
            return await db.Table<ColorDb>().ToListAsync();
        }

        public async Task AddColorsDb(NamedColor color)
        {
            await Init();
            var colorDb = new ColorDb
            {
                Name = color.Name,
                Red = color.Red,
                Green = color.Green,
                Blue = color.Blue
            };
            await db.InsertAsync(colorDb);
        }

        public async Task DeleteColorDb(NamedColor color)
        {
            await Init();
            var colorDb = new ColorDb
            {
                Name = color.Name,
                Red = color.Red,
                Green = color.Green,
                Blue = color.Blue
            };
            await db.DeleteAsync(colorDb);
        }
    }
}
