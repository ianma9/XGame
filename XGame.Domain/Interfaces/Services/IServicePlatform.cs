using XGame.Domain.Arguments.Platform;

namespace XGame.Domain.Interfaces.Services
{
    public interface IServicePlatform
    {
        AddPlatformResponse AddPlatform(AddPlatformRequest request);
    }
}
