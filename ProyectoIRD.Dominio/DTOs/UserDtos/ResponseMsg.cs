namespace ProyectoIRD.Dominio.DTOs.UserDtos
{
    public class ResponseMsg
    {
        public string Message { get; set; }
        public bool Status { get; set; }
        public virtual AutheticationResponse AuthResponse { get; set; }
        public virtual UserDto UserDto { get; set; }
    }
}
