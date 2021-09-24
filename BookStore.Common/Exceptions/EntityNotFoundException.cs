using System.Collections.Generic;

namespace BookStore.Common.Exceptions
{
    public class EntityNotFoundException : KeyNotFoundException
    {
        public EntityNotFoundException(string entityName, int id) : base($"{entityName} with Id={id} is not found.")
        {
        }
    }
}
