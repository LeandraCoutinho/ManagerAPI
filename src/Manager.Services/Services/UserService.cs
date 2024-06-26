using AutoMapper;
using Manager.Core.Exceptions;
using Manager.Domain.Entities;
using Manager.Infra.Interfaces;
using Manager.Services.DTO;
using Manager.Services.Interfaces;

namespace Manager.Services.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<UserDTO> Create(UserDTO userDto)
    {
        var userExists = await _userRepository.GetByEmail(userDto.Email);

        if (userExists != null)
            throw new DomainException("Já existe um usuário cadastrado com o email inofrmado.");

        var user = _mapper.Map<User>(userDto);
        user.Validate();

        var userCreated = await _userRepository.Create(user);

        return _mapper.Map<UserDTO>(userCreated);
    }

    public async Task<UserDTO> Update(UserDTO userDto)
    {
        var userExists = await _userRepository.Get(userDto.Id);

        if (userExists == null)
            throw new DomainException("Não existe nenhum usuário com o id informado.");

        var user = _mapper.Map<User>(userDto);

        var userUpdated = await _userRepository.Update(user);

        return _mapper.Map<UserDTO>(userUpdated);
    }

    public async Task Remove(long id)
    {
        await _userRepository.Remove(id);
    }

    public async Task<UserDTO> Get(long id)
    {
        var user = await _userRepository.Get(id);

        return _mapper.Map<UserDTO>(user);
    }

    public async Task<List<UserDTO>> Get()
    {
        var allUsers = await _userRepository.Get();

        return _mapper.Map<List<UserDTO>>(allUsers);
    }

    public async Task<List<UserDTO>> SearchByName(string nome)
    {
        var allUsers = await _userRepository.SearchByName(nome);

        return _mapper.Map<List<UserDTO>>(allUsers);
    }

    public async Task<List<UserDTO>> SearchByEmail(string email)
    {
        var allUsers = await _userRepository.SearchByEmail(email);

        return _mapper.Map<List<UserDTO>>(allUsers);
    }

    public async Task<UserDTO> GetByEmail(string email)
    {
        var user = await _userRepository.GetByEmail(email);

        return _mapper.Map<UserDTO>(user);
    }
}