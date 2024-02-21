using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcCoreEFMultiplesBBDD.Models
{
    [Table("v_empleados")]
    public class Empleado
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("APELLIDO")]
        public string Apellido { get; set; }

        [Column("OFICIO")]
        public string Oficio { get; set;}

        [Column("DEPARTAMENTO")]
        public string Departamento { get; set; }

        [Column("LOCALIDAD")]
        public string Localidad { get; set; }

        [Column("DEPT_NO")]
        public int IdDepartamento { get; set; }
    }
}
