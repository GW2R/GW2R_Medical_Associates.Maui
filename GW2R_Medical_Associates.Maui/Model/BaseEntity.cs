using SQLite;

namespace GW2R_Medical_Associates.Maui.EMR_Management
{
    public abstract class BaseEntity
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
    }
}
