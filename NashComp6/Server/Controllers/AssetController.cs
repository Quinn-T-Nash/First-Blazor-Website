//for api controler
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using NashComp6.Server.Interfaces;
using NashComp6.Shared.Models;

namespace NashComp6.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetController : ControllerBase
    {
        private readonly IAssetRepo _assetRepo;
        public AssetController(IAssetRepo assetRepo) 
        {
            _assetRepo = assetRepo;
        }

        [HttpGet]
        [Route("{page:int}/{pageSize:int}")]
        public IEnumerable<Asset> GetAssets(int page, int pageSize)
        {
            return _assetRepo.GetAssets(page, pageSize);
        }

        [HttpGet]
        [Route("{id:int}")]
        public Asset? GetAsset(int id)
        {
            return _assetRepo.GetAsset(id);
        }

        [HttpGet]
        public IEnumerable<Asset> GetAllAssets()
        {
            return _assetRepo.GetAllAssets();
        }

        [HttpPost]
        public void PostAsset(Asset asset)
        {
            _assetRepo.AddAsset(asset);
        }

        [HttpPut]
        public void PutAsset(Asset asset)
        {
            _assetRepo.UpdateAsset(asset);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public void DeleteAsset(int id)
        {
            _assetRepo.DeleteAsset(id);
        }
    }
}
