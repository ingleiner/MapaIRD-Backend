using ProyectoIRD.Dominio.CustomsEntities;

namespace ProyectoIRD.API.Responses
{
    public class IRDResponse<T>
    {
        public IRDResponse(T data)
        {
            Data = data;
        }
        public object Message { get; set; }
        public T Data { get; set; }
        public MetaData Meta { get; set; }
        
    }
}
