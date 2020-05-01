using SQLite;

namespace SCLCore.Models
{
    public class Authentification
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string AllowedIP { get; set; }
    }
}
