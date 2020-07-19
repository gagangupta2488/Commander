using AutoMapper;
using Commander.Dtos;
using Commander.Models;

namespace Commander.profiles
{
    public class CommandsProfiles:Profile
    {
public CommandsProfiles()
{
    CreateMap<CommandUpdateDto,Command>();
    CreateMap<Command,CommandUpdateDto>();
}
    }
}