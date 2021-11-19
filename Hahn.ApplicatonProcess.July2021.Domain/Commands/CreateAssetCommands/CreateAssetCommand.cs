using MediatR;

namespace Hahn.ApplicatonProcess.July2021.Domain.Commands.CreateAssetCommands
{
    public class CreateAssetCommand : IRequest<int>
    {
        public int UserId { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
    }
}
