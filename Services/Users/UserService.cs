using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_USUARIOS.Data;
using API_USUARIOS.Models;
using API_USUARIOS.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace API_USUARIOS.Services.Users
{
    public class UserService : IUserService
    {
        private readonly AppDbcontext _context;
        public UserService(AppDbcontext context)
        {
            _context = context;
        }

        public Task<UserModelResponse<UserModel>> BuscarUserPorId(int idUser)
        {
            throw new NotImplementedException();
        }

        public async Task<UserModelResponse<List<UserModel>>> ListarUsuarios()
        {
            UserModelResponse<List<UserModel>> resposta = new UserModelResponse<List<UserModel>>();
            try
            {
                var users = await _context.Users.ToListAsync(); // pegar todos os usuarios do banco
                resposta.Dados = users;
                resposta.Mensagem = "Lista de usuarios retornada com sucesso!";

                return resposta;
            }
            catch (Exception ex)
            { 
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            };
        }
    }
}