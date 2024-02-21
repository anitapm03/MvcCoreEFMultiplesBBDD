using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using MvcCoreEFMultiplesBBDD.Data;
using MvcCoreEFMultiplesBBDD.Models;
#region SQL
//CREATE VIEW v_empleados 
//AS
//	SELECT ISNULL(E.EMP_NO, 0) AS ID,
//    E.APELLIDO, E.OFICIO, E.SALARIO,
//    D.DNOMBRE AS DEPARTAMENTO,
//    D.LOC AS LOCALIDAD,
//    D.DEPT_NO
//	FROM EMP E 
//	INNER JOIN DEPT D
//	ON E.DEPT_NO = D.DEPT_NO
//GO

//CREATE PROCEDURE SP_ALL_EMPLEADOS
//AS
//	SELECT * FROM v_empleados
//GO
#endregion
namespace MvcCoreEFMultiplesBBDD.Repositories
{
    public class RepositoryEmpleados: IRepositoryEmpleados
    {
        private HospitalContext context;

        public RepositoryEmpleados(HospitalContext context)
        {
            this.context = context;
        }

        public async Task<List<Empleado>> GetEmpleadosAsync()
        {
            string sql = "SP_ALL_EMPLEADOS";
            var consulta = this.context.Empleados.FromSqlRaw(sql);
                
                /*from datos in this.context.Empleados
                           select datos;*/
            return await consulta.ToListAsync();
        }

        public Empleado FindEmpleado(int id)
        {
            var consulta = from datos in this.context.Empleados
                           where datos.Id == id
                           select datos;
            return consulta.First();

        }


    }
}
