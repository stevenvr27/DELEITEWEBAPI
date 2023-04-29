using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DELEITEWEBAPI.Models;
using DELEITEWEBAPI.Tools;
using DELEITEWEBAPI.ModelsDTOs;

namespace DELEITEWEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DeleiteContext _context;
        public Crypto MYCrypto { get; set; }
       

        public UsersController(DeleiteContext context)
        {
            _context = context;
             MYCrypto = new Crypto();
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
          if (_context.Users == null)
          {
              return NotFound();
          }
            return await _context.Users.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
          if (_context.Users == null)
          {
              return NotFound();
          }
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

 [HttpGet("ValidateUserLogin")]
        public async Task<ActionResult<User>> ValidateUserLogin(string pUserName, string pPassword)
        {
            // encriptalas contraseñas y las valida en Bd 
            string EncriptedPassword = MYCrypto.EncriptarEnUnSentido(pPassword);



            var user = await _context.Users.SingleOrDefaultAsync(e => e.Email == pUserName && e.Password == EncriptedPassword);
            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, UserDTO user)
        {
            if (id != user.IDusuario)
            {
                return BadRequest();
            }

            string Password = "";
            if (user.Contraseña.Length <= 60)
            {
                //se presume que el usuario digitó un nuevo password que debe ser encriptado 
                Password = MYCrypto.EncriptarEnUnSentido(user.Contraseña);
            }
            else
            {
                //el usuario no modificó el password 
                Password = user.Contraseña;
            }

            //tenemos que crear un objeto de tipo user, y usar los atrib que vienen en el DTO
            //para llenar la info 
            User NuevoUsuario = new()
            {
                UserId = user.IDusuario,
                Name = user.Nombre,
                CardId = user.CardId,
                Address = user.Dirreccion,
                Password = Password,
                Email = user.Correo,
                UserRoleId = user.UserRoleId,
                UserStatusId = user.UserStatusId,
                UserRole = null,
                UserStatus = null
            };

            _context.Entry(NuevoUsuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok();

        }



        [HttpGet("GetData")]
        public ActionResult<IEnumerable<UserDTO>> GetData(string email)
        {
            var query = (from u in _context.Users
                         join ur in _context.UserRoles on u.UserRoleId equals ur.UserRoleId
                         join us in _context.UserStatuses on u.UserStatusId equals us.UserStatusId
                         where u.Email == email && u.UserStatusId != 2
                         select new
                         {
                             IDusuario = u.UserId,
                             Nombre = u.Name,
                             Correo = u.Email,
                             Cedula = u.CardId,
                             Contraseña = u.Password,
                             Direccion = u.Address,
                              
                             UsuarioRoleId = u.UserRoleId,
                             UsuarioEstadoId = u.UserStatusId,

                             UserRole = ur.UserRoleId,
                             UserStatus = us.UserStatusId,
                         }).ToList();
            List<UserDTO> list = new List<UserDTO>();
            foreach (var item in query)
            {
                UserDTO newitem = new UserDTO()
                {
                    IDusuario = item.IDusuario,
                    Nombre = item.Nombre,
                    Correo = item.Correo,
                    CardId = item.Cedula,
                    Contraseña = item.Contraseña,
                    Dirreccion = item.Direccion,
                    
                    UserRoleId = item.UsuarioRoleId,
                    UserStatusId = item.UsuarioEstadoId


                };
                list.Add(newitem);
            }
            if (list == null)
            {
                return NotFound();
            }
            return list;
        }

       

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpPost]
        public async Task<ActionResult<User>> PostUsers(User user)
        {
          string EncriptedPassword = MYCrypto.EncriptarEnUnSentido(user.Password);

            user.Password = EncriptedPassword;
          
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

          return CreatedAtAction("GetUser", new { id = user.UserId }, user);
         
         }



        private bool UserExists(int id)
        {
            return (_context.Users?.Any(e => e.UserId == id)).GetValueOrDefault();
        }
    }
}
