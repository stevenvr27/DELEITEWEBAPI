using DELEITEWEBAPI.Models;

namespace DELEITEWEBAPI.ModelsDTOs
{
    public class UserDTO
    {
        public int IDusuario { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }
        public string? Dirreccion { get; set; } = null;
        public string? CardId { get; set; } = null;
        public int UserRoleId { get; set; }
        public int UserStatusId { get; set; }
        public virtual UserRole? UserRole { get; set; } = null!;
        public virtual UserStatus? UserStatus { get; set; } = null!;


    }
}
