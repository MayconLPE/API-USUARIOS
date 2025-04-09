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

        public Task<UserModelResponse<List<UserModel>>> AtualizarUser(int idUser, UserModel userModel)
        {
            throw new NotImplementedException();
        }

        public async Task<UserModelResponse<UserModel>> BuscarUserPorId(int idUser)
        {
            UserModelResponse<UserModel> resposta = new UserModelResponse<UserModel>();
            try
            {
                var user = await _context.Users.FindAsync(idUser); // pegar usuario pelo id
                if (user == null)
                {
                    resposta.Mensagem = "Usuario não encontrado!";
                    resposta.Status = false;
                    return resposta;
                }
                resposta.Dados = user;
                resposta.Mensagem = "Usuario encontrado com sucesso!";

                return resposta;
            }
            catch (Exception ex)
            { 
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            };
        }

        public async Task<UserModelResponse<List<UserModel>>> CriarUser(CriarUserDto criarUserDto)
        {
            UserModelResponse<List<UserModel>> resposta = new UserModelResponse<List<UserModel>>();
            try
            {
                if (string.IsNullOrEmpty(criarUserDto.Name) || string.IsNullOrEmpty(criarUserDto.UserName) || string.IsNullOrEmpty(criarUserDto.Password) || string.IsNullOrEmpty(criarUserDto.Email))
                {
                    resposta.Mensagem = "Preencha todos os campos!";
                    resposta.Status = false;
                    return resposta;
                }

                if (await _context.Users.AnyAsync(u => u.UserName == criarUserDto.UserName)) // verificar se o usuario ja existe
                {
                    resposta.Mensagem = "Usuario já existe!";
                    resposta.Status = false;
                    return resposta;
                }
                
                var user = new UserModel()
                {
                    Name = criarUserDto.Name,
                    UserName = criarUserDto.UserName,
                    Password = criarUserDto.Password,
                    Email = criarUserDto.Email
                };
                await _context.Users.AddAsync(user); // adicionar usuario no banco
                await _context.SaveChangesAsync(); // salvar as alterações no banco

                resposta.Dados = new List<UserModel>() { user };
                resposta.Mensagem = "Usuario criado com sucesso!";

                return resposta;
            }
            catch (Exception ex)
            { 
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            };
        }

        public async Task<UserModelResponse<List<UserModel>>> DeletarUser(int idUser)
        {
            UserModelResponse<List<UserModel>> resposta = new UserModelResponse<List<UserModel>>();
            try
            {
                var user = await _context.Users.FindAsync(idUser); // pegar usuario pelo id
                if (user == null)
                {
                    resposta.Mensagem = "Usuario não encontrado!";
                    resposta.Status = false;
                    return resposta;
                }
                _context.Users.Remove(user); // remover usuario do banco
                await _context.SaveChangesAsync(); // salvar as alterações no banco

                resposta.Dados = new List<UserModel>() { user };
                resposta.Mensagem = "Usuario deletado com sucesso!";

                return resposta;
            }
            catch (Exception ex)
            { 
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            };
           
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

        public async Task<UserModelResponse<List<UserModel>>> ListarUsuariosPorNome(string nome)
        {
            UserModelResponse<List<UserModel>> resposta = new UserModelResponse<List<UserModel>>();
            try
            {
                if (string.IsNullOrEmpty(nome))
                {
                    resposta.Mensagem = "Preencha o campo nome!";
                    resposta.Status = false;
                    return resposta;
                }
                if (nome.Length < 3)
                {
                    resposta.Mensagem = "O nome deve ter pelo menos 3 caracteres!";
                    resposta.Status = false;
                    return resposta;
                }
                if (nome.Length > 50)
                {
                    resposta.Mensagem = "O nome deve ter no máximo 50 caracteres!";
                    resposta.Status = false;
                    return resposta;
                }
                var users = await _context.Users.Where(u => u.Name.Contains(nome)).ToListAsync(); // pegar usuarios pelo nome
                if (users == null || users.Count == 0)
                {
                    resposta.Mensagem = "Usuario não encontrado!";
                    resposta.Status = false;
                    return resposta;
                }
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

        public Task<UserModelResponse<List<UserModel>>> ListarUsuariosPorNomeOuEmail(string nome, string email)
        {
            throw new NotImplementedException();
        }
    }
}