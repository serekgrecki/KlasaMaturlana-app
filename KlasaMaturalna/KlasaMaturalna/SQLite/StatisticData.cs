using SQLite;

namespace KlasaMaturalna.SQLite
{
    public class StatisticData
    {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int IdQuestion { get; set; }

        public bool Answer { get; set; }
    }
}