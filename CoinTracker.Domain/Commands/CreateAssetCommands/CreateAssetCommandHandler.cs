using CoinTracker.Domain.Contracts.Repository;
using CoinTracker.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CoinTracker.Domain.Commands.CreateAssetCommands
{
    public class CreateAssetCommandHandler : IRequestHandler<CreateAssetCommand, int>
    {
        private readonly IAssetRepository assetRepository;
        private readonly IUserRepository userRepository;

        public CreateAssetCommandHandler(IAssetRepository AssetRepository, IUserRepository UserRepository)
        {
            assetRepository = AssetRepository;
            userRepository = UserRepository;
        }

        public async Task<int> Handle(CreateAssetCommand command, CancellationToken cancellationToken)
        {
            var user = userRepository.GetById(command.UserId);

            if (user == null)
            {
                throw new Exception();
            }

            var asset = new Asset(command);
            assetRepository.Add(asset);

            var id = await assetRepository.SaveChangesAsync();

            return id;
        }
    }
}

