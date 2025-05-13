using Microsoft.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;
using WebVisorofStackTraceC_.Models;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.Globalization;
using WebVisorofStackTraceC_.Services;

namespace WebVisorofStackTraceC_.Services
{
    public class SolicitudService : ISolicitudService

    {
        private readonly IConfiguration _config;

        public SolicitudService(IConfiguration config)
        {
            _config = config;
        }
        public async Task<DataTable> ObtenerStacktracePorIdStacktraceAsync(int nIDLogErr)
        {
            var connectionString = _config.GetConnectionString("DefaultConnection");
            DataTable dt = new DataTable();

            DataTable dtplanpago = new DataTable();

            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                using (var cmd = new SqlCommand("SELECT nIDLogErr,\r\n    cNomModGen,\r\n    cNomForGen,\r\n    cNomObjGen,\r\n    cTipErrGen,\r\n    nLinGenErr,\r\n    cCabErrGen,\r\n    REPLACE(cDesErrGen, '     ', CHAR(10)) AS cDesErrGen,\r\n    dFecHorGen,\r\n    cAuditUser,\r\n    cAuditStation,\r\n    cAuditClient,\r\n    dAuditDate  FROM SI_SYNMLogErrores WHERE nIDLogErr = @nIDLogErr", connection))
                {
                    cmd.CommandType = CommandType.Text; // Esto es opcional, ya que Text es el valor por defecto

                    cmd.Parameters.AddWithValue("@nIDLogErr", nIDLogErr);

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        dt.Load(reader); // Carga los datos directamente en un DataTable
                    }
                }
            }


            return dt;
        }


 

    }
}