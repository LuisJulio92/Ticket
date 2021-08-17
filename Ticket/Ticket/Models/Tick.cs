using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ticket.Models
{
    public class Tick
    {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Titulo { get; set; }
        public string Description { get; set; }
    }
}
