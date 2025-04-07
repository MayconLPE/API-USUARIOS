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
        Task<UserModelResponse<List<UserModel>>> CriarUser(CriarUserDto criarUserDto);
        Task<UserModelResponse<List<UserModel>>> AtualizarUser(int idUser, UserModel userModel);
        Task<UserModelResponse<List<UserModel>>> DeletarUser(int idUser);
        Task<UserModelResponse<List<UserModel>>> ListarUsuariosPorNome(string nome);
        Task<UserModelResponse<List<UserModel>>> ListarUsuariosPorNomeOuEmail(string nome, string email);

    }
}