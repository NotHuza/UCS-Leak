using UCS.Files.CSV;

namespace UCS.Files.Logic
{
    internal class ExperienceLevelData : Data
    {
        public ExperienceLevelData(CSVRow row, DataTable dt): base(row, dt)
        {
            LoadData(this, GetType(), row);
        }

        public string Name { get; set; }
        public int ExpPoints { get; set; }
    }
}
