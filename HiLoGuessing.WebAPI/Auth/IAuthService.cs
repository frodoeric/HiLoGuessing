using HiloGuessing.Domain.Entities;
using HiLoGuessing.Application.Models;

public interface IAuthService
{
    Task<(int, string)> Registeration(UserRegistrationModel model, string role);
    Task<(int, string)> Login(UserDto model);
}