using System.Data;
using System.Threading.Tasks;
using WebVisorofStackTraceC_.Models;

namespace WebVisorofStackTraceC_.Services
{
    public interface ISolicitudService
    {
      
        Task<DataTable> ObtenerStacktracePorIdStacktraceAsync(int nIDLogErr);

        // New method added

    }
}
