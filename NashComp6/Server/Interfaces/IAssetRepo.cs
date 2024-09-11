using NashComp6.Shared.Models;

namespace NashComp6.Server.Interfaces
{
    public interface IAssetRepo
    {
        IEnumerable<Asset> GetAssets(int page, int pageSize);

        IEnumerable<Asset> GetAllAssets();

        Asset? GetAsset(int id);

        Asset AddAsset(Asset asset);

        void UpdateAsset(Asset asset);

        void DeleteAsset(int id);
    }
}
