using api.Data;
using api.DTOs;
using api.Entities;
using api.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers;

[Authorize]
public class UsersController : BaseApiController
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public UsersController(IUserRepository userRepository, IMapper mapper) 
    {
        _mapper = mapper;
        _userRepository = userRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsersList()
    {
        
        var users = await _userRepository.GetMembersAsync();

        return Ok(users);
    }

    [HttpGet("{username}")] //api/users/[username]
    public async Task<ActionResult<MemberDto>> getUser(string username)
    {
        return await  _userRepository.GetMemberAsync(username);

    }

    // [Authorize]
    // [HttpGet("{id}")] //api/users/[idNum]
    // public async Task<ActionResult<AppUser>> getUser(int id)
    // {
    //     return await _userRepository.GetUserByIdASync(id);
    // }

}
