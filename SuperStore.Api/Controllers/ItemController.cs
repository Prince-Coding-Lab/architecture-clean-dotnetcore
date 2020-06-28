using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperStore.Core.Entities;
using SuperStore.Core.Interfaces;
using SuperStore.Core.Services;

namespace SuperStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;
        private readonly IMapper _mapper;
        public ItemController(IItemService itemService, IMapper mapper)
        {
            _itemService = itemService;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync(Item Item)
        {
            var user = await _itemService.CreateItemAsync(Item);

            return Ok("success");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Item Item, int id)
        {
            await _itemService.UpdateItemAsync(Item, id);
            return Ok("success");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _itemService.DeleteItemAsync(id);
            return Ok("success");
        }
        [HttpGet]
        public IActionResult GetAsync()
        {
            return Ok("success");
        }
        [HttpGet("getbyid/{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var item = await _itemService.GetItemByIdAsync(id);
            return Ok(item);
        }
    }
}