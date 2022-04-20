using StoreBK.Models;
using StoreBK.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;
using MongoDB.Driver;



namespace StoreBK.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private readonly ShopService _shopService;
        public ShopController(ShopService shopService)
        {
            _shopService = shopService;
        }

        [HttpGet]
        public ActionResult<List<Shop>> GetAllShop() => _shopService.GetAllShop();

        [HttpGet("{id}")]
        public ActionResult<Shop> GetShopById(string id)
        {
            var shop = _shopService.GetShopById(id);
            
            if (shop == null)
            {
                return NotFound();
            }
            return shop;
        }

        [HttpPost]
        public Shop CreateShop([FromBody] Shop shop)
        {
            var data = _shopService.GetAllShopForApi();
            int number = data.Count();
            shop.ShopId = "S-0" + number.ToString();
            shop.Status = "Open";
            _shopService.CreateShop(shop);
            return shop;
        }

        [HttpPut("{id}")]
        public IActionResult EditShop([FromBody] Shop shop, string id)
        {
            var shops = _shopService.GetShopById(id);
            if (shops == null)
            {
                return NotFound();
            }
            shop.ShopId = id;
            _shopService.EditShop(id, shop);
            return NoContent();
        }

        [HttpGet("{shopId}")]
        public IActionResult DeleteShop(string shopId)
        {
            var shops = _shopService.GetShopById(shopId);
            var statusChange = shops.Status;
            if (shops == null)
            {
                return NotFound();
            }
            if (statusChange == "Open")
            {
                statusChange = "Close";
            }
            shops.Status = statusChange;
            _shopService.DeleteShop(shopId, shops);
            return NoContent();
        }

    }
}