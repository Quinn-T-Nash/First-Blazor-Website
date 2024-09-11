using NashComp6.Server.Data;
using NashComp6.Server.Interfaces;
using NashComp6.Shared.Models;

namespace NashComp6.Server.Repos
{
    public class AssetRepo : IAssetRepo
    {
        //Sends in the context so all methods can access, Dependency Inejction Model
        private ApplicationDbContext _context;

        public AssetRepo(ApplicationDbContext context) 
        {
            _context = context;
        }

        public Asset AddAsset(Asset asset)
        {
            _context.Assets.Add(asset);
            
            //Since we made modifications to the database save it
            _context.SaveChanges();

            //Will this asset have the new id field??
            return asset;
        }

        public void DeleteAsset(int id)
        {
            Asset? assetRemoving = _context.Assets.Where(p =>
                p.Id == id).FirstOrDefault();

            if (assetRemoving != null)
            {
                _context.Assets.Remove(assetRemoving);
            }

            _context.SaveChanges();
        }

        public Asset? GetAsset(int id)
        {
            return _context.Assets.Where(p => p.Id == id).FirstOrDefault();            
        }

        public IEnumerable<Asset> GetAssets(int page, int pageSize)
        {
            return _context.Assets.OrderByDescending(p => p.EnteredInventory).Skip((page - 1) * pageSize).Take(pageSize);
        }

        public IEnumerable<Asset> GetAllAssets()
        {
            return _context.Assets.OrderByDescending(p => p.LeftInventroy);
        }

        public void UpdateAsset(Asset asset)
        {
            Asset? currentAsset = _context.Assets.Where(p => 
                p.Id == asset.Id).FirstOrDefault();

            if (currentAsset != null)
            {
                currentAsset.Title = asset.Title;
                currentAsset.StartingValue = asset.StartingValue;
                currentAsset.SalvageValue = asset.SalvageValue;
                currentAsset.EnteredInventory = asset.EnteredInventory;
                currentAsset.LeftInventroy = asset.LeftInventroy;
            }

            //remember call save changes
            _context.SaveChanges();
        }
    }
}
