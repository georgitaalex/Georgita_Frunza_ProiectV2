using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Georgita_Frunza_Proiect.Models
{
    public class ListSport
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [ForeignKey(typeof(SSList))]
        public int SSListID { get; set; }
        public int SportID { get; set; }
    }
}
