using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace LABRADDOM23.Models
{
    [Table("Estudiantes")]
    public class Estudiantes
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }

        [MaxLength(100)]
        public string nombres { get; set; }
        [MaxLength(100)]
        public string apellidos { get; set; }

        [NotNull]
        public DateTime fechanac { get; set; }


        [NotNull]
        public string id_carrera { get; set; }

        [NotNull, Unique]
        public string telefono { get; set; }

        public byte[] foto { get; set; }
    }
}
