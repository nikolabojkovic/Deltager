using System.Net;

namespace Application
{
      public class NotFoundException : ApiException
    {
        public NotFoundException(string entity, int key) 
            : base($"Entity \"{entity}\" ({key}) was not found.", HttpStatusCode.NotFound) { }
    }
}