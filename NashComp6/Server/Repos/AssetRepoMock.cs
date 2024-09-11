using Microsoft.EntityFrameworkCore;
using NashComp6.Server.Interfaces;
using NashComp6.Shared.Models;

namespace NashComp6.Server.Repos
{
    public class AssetRepoMock : IAssetRepo
    {
        private List<Asset> assets;

        public AssetRepoMock()
        {
            assets = new List<Asset>();
            for (int i =1; i < 100; i++)
            {
                assets.Add(new Asset
                {
                    Id = i,
                    StartingValue = -1,
                    SalvageValue = -1,
                    EnteredInventory = DateTime.Now,
                    LeftInventroy = DateTime.Now,
                });
            }
        }

        //Orders posts for page display
        public IEnumerable<Asset> GetAssets(int page, int pageSize)
        {
            return assets.OrderByDescending(p => p.EnteredInventory).Skip((page - 1) * pageSize).Take(pageSize);
        }

        public Asset? GetAsset(int id)
        {
            return assets.Where(p=> p.Id == id).FirstOrDefault();
        }

        public IEnumerable<Asset> GetAllAssets()
        {
            return assets;
        }

        public void InsertAsset(Asset asset)
        {
            assets.Add(asset);
        }

        public Asset AddAsset(Asset asset)
        {
            asset.Id = assets.Count() + 1;
            assets.Add(asset);
            return asset;
        }

        public void UpdateAsset(Asset asset)
        {
            Asset? currentAsset = assets.Find(p =>p.Id == asset.Id);

            if (currentAsset != null)
            {
                currentAsset.StartingValue = asset.StartingValue;
                currentAsset.SalvageValue = asset.SalvageValue;
                currentAsset.EnteredInventory = asset.EnteredInventory;
                currentAsset.LeftInventroy = asset.LeftInventroy;
            }
        }

        public void DeleteAsset(int id)
        {
            Asset? assetRemoving = assets.Where(p=> p.Id == id).FirstOrDefault();
            if (assetRemoving != null)
            {
                assets.Remove(assetRemoving);
            }
        }
    }
}
