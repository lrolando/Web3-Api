using Nethereum.Signer;

namespace WebApi.Utilities
{
    public class EnumHelper
    {
        private readonly IConfiguration _configuration;

        public EnumHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetStringBasedOnEnum(Chain chain)
        {
            switch (chain)
            {
                case Chain.MainNet:
                    return _configuration["User:MainnetProvider"];
                case Chain.Sepolia:
                    return _configuration["User:SepoliaProvider"];
                default:
                    return "NO NETWORK GIVEN";
            }
        }

    }
}
