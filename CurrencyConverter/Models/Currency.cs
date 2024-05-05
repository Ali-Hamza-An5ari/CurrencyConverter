using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ColumnAttribute = SQLite.ColumnAttribute;
using TableAttribute = SQLite.TableAttribute;

namespace CurrencyConverter.Models
{
    [Table("currency")]
    public class Currency
    {
        [PrimaryKey]
        [AutoIncrement]
        [Column("id")]
        public int Id { get; set; }

        [Column("flag_image_source")]
        public string FlagImageSource { get; set; }

        [Column("currency_name")]
        public string CurrencyName { get; set; }

        [Column("symbol")]
        public string Symbol { get; set; }

        [Column("exchange_rate_to_usd")]
        public double ExchangeRateToUSD { get; set; }
    }
}
