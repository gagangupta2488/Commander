using System.Collections.Generic;
using Commander.Models;
namespace Commander.Data
{
    public interface ICommenderRepo
    {

        bool SaveChanges();
        IEnumerable <Command> GetAllCommands();
        Command  GetCommandById(int Id);
        void CreateCommand(Command cmd);
        void UpdateCommand(Command cmd);
        void DeleteCommand(Command cmd);
    }
}