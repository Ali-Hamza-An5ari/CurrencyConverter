using SQLite;
using System.Text;
using ColumnAttribute = SQLite.ColumnAttribute;
using TableAttribute = SQLite.TableAttribute;

namespace CurrencyConverter.Models
{
    [Table("history")]
    public class History
    {
        [PrimaryKey]
        [AutoIncrement]
        [Column("id")]
        public int Id { get; set; }

        [Column("conversion")]
        public string Conversion { get; set; }
    }
}
