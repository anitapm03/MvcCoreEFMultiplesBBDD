using Microsoft.EntityFrameworkCore;
using MvcCoreEFMultiplesBBDD.Data;
using MvcCoreEFMultiplesBBDD.Models;
using Oracle.ManagedDataAccess.Client;

namespace MvcCoreEFMultiplesBBDD.Repositories
{
    public class RepositoryEmpleadosOracle: IRepositoryEmpleados
    {
        private HospitalContext context;

        public RepositoryEmpleadosOracle(HospitalContext context)
        {
            this.context = context;
        }

        public async Task<List<Empleado>> GetEmpleadosAsync()
        {
            string sql = "BEGIN ";
            sql += " SP_ALL_EMPLEADOS(:P_CURSOR_EMP); ";
            sql += " END;";
            OracleParameter cursor = new OracleParameter();
            cursor.ParameterName = "P_CURSOR_EMP";
            cursor.Value = null;
            cursor.Direction = System.Data.ParameterDirection.Output;
            //como es un tipo de oracle propio (Cursor) debemos
            //ponerlo de forma manual
            cursor.OracleDbType = OracleDbType.RefCursor;
            
            var consulta = 
                this.context.Empleados.FromSqlRaw(sql, cursor);
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
