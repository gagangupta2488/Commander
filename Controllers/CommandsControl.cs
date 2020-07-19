using System.Collections.Generic;
using Commander.Models;
using Microsoft.AspNetCore.Mvc;
using Commander.Data;
using AutoMapper;
using Commander.Dtos;
using Microsoft.AspNetCore.JsonPatch;

namespace Commander.Controllers

{
    [Route("api/Commands")]
    [ApiController]
    //Get api/Commands
public class CommanderControl:ControllerBase
{
        private readonly ICommenderRepo _repository;
        private readonly IMapper _mapper;

        public CommanderControl(ICommenderRepo repository,IMapper mapper)
   {
       _repository=repository;
       _mapper=mapper;
   }
   
    [HttpGet]
   
    public ActionResult <IEnumerable<Command>> GetAllCommands()
{
    var CommandItems=_repository.GetAllCommands();
    return Ok(CommandItems);

}
//Get api/commands/{Id}
[HttpGet("{Id}",Name="GetCommandById")]
public ActionResult <Command> GetCommandById(int Id)
{
var CommandItem=_repository.GetCommandById(Id);
if(CommandItem!= null)
{
return Ok (CommandItem);
}
return NotFound();
}
    [HttpPost]
 public ActionResult CreateCommand(Command cmd)
 {
     
     _repository.CreateCommand(cmd);
     _repository.SaveChanges();
     return CreatedAtRoute(nameof(GetCommandById), new {Id=cmd.Id},cmd);
     
 }
 [HttpPut("{Id}")]
public ActionResult UpdateCommand(int Id ,CommandUpdateDto commandupdatedto)
{
var CommandModelRepo=_repository.GetCommandById(Id);
if(CommandModelRepo==null)
{
    return NotFound();
}
_mapper.Map(commandupdatedto,CommandModelRepo);
_repository.UpdateCommand(CommandModelRepo);
_repository.SaveChanges();
return NoContent();
}
 [HttpPatch("{Id}")]
 public ActionResult PartialCommandUpdate(int Id,JsonPatchDocument<CommandUpdateDto> patchDoc )
 {
var CommandModelRepo=_repository.GetCommandById(Id);
if(CommandModelRepo==null)
{
    return NotFound();
}
var CommandToPatch=_mapper.Map<CommandUpdateDto>(CommandModelRepo);
patchDoc.ApplyTo(CommandToPatch,ModelState);
if(!TryValidateModel(CommandToPatch))
{
    return ValidationProblem(ModelState);
}
_mapper.Map(CommandToPatch,CommandModelRepo);
_repository.UpdateCommand(CommandModelRepo);
_repository.SaveChanges();
return NoContent();
 }
[HttpDelete("{Id}")]
public ActionResult DeleteCommand(int Id)
{
 var CommandModelRepo=_repository.GetCommandById(Id);
if(CommandModelRepo==null)
{
    return NotFound();
}
_repository.DeleteCommand(CommandModelRepo);
_repository.SaveChanges();
return NoContent();   
}
}
}