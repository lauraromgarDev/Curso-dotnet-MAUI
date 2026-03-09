using SQLite;

namespace DoToo.Models
{

    public class TodoItem
    {
        [PrimaryKey, AutoIncrement] //esto le dice a SQLite que esta propiedad es la clave primaria y que se autoincremente

        public int Id { get; set; }
        public string Title { get; set; }
        public bool Completed { get; set; }
        public DateTime Due { get; set; }
    }
}
