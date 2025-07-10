using Application.DTOs;
using Domain.Entities;

namespace Application.DTOMappers;

public static class UserMapper
{
    public static UserDto ToUserDto(this User user)
    {
        return new UserDto(
            user.FirstName.Name,
            user.LastName.Name,
            user.Email.Address);
    }
}