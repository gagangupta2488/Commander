using System.Collections.Generic;
using System.Linq;
using Commander.Models;
using System;
namespace Commander.Data
{
    public class SqlCommanderRepo : ICommenderRepo
    {
        private readonly CommanderContext _Context;

        public SqlCommanderRepo(CommanderContext Context)
        {
            _Context=Context;
        }

        public void CreateCommand(Command cmd)
        {
            if(cmd== null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
        _Context.Commands.Add(cmd);
        }

        public void DeleteCommand(Command cmd)
        {
           if(cmd== null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
        _Context.Commands.Remove(cmd);
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return _Context.Commands.ToList();
         //   throw new System.NotImplementedException();
        }

        public Command GetCommandById(int Id)
        {
            return _Context.Commands.FirstOrDefault(p=> p.Id==Id);
            //throw new System.NotImplementedException();
        }

        public bool SaveChanges()
        {
       return  (_Context.SaveChanges() >=0);
        }

        public void UpdateCommand(Command cmd)
        {
            //Nothing
            
                    }
    }
}