using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_USUARIOS.Models;
using API_USUARIOS.Models.DTOs;

namespace API_USUARIOS.Services.Users
{
    public interface IUserService
    {
        Task<UserModelResponse<List<UserModel>>> ListarUsuarios();
        Task<UserModelResponse<UserModel>> BuscarUserPorId(int idUser);
    }
}