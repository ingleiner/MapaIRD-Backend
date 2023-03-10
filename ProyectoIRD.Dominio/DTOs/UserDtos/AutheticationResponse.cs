namespace ProyectoIRD.Dominio.DTOs.UserDtos
{
    public class AutheticationResponse
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
