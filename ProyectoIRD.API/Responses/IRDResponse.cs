namespace ProyectoIRD.API.Responses
{
    public class IRDResponse<T>
    {
        public IRDResponse(T data)
        {
            Data = data;
        }

        public T Data { get; set; }
    }
}
