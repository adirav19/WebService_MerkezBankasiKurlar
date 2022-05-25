using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebService_MerkezBankasiKurlar.Serializer
{
    public interface IXmlSerializer
    {
        T Deserializer<T>(string value);
        string Serializer(object value);

    }
}
