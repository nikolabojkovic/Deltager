using MediatR;

namespace Application
{
    public class CreateProductCommand : IRequest
    {
        public string Name { get; set; }
        public string Type { get; set; }
    }
}
