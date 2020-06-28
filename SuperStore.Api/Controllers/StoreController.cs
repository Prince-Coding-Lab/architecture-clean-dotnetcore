using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperStore.Core.Entities;
using SuperStore.Core.Interfaces;

namespace SuperStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IStoreService _storeService;
        private readonly IMapper _mapper;
        public StoreController(IStoreService storeService, IMapper mapper)
        {
            _storeService = storeService;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync(Store store)
        {
            var user = await _storeService.CreateStoreAsync(store);
            return Ok("success");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Store store,int id)
        {
            await _storeService.UpdateStoreAsync(store, id);
            return Ok("success");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _storeService.DeleteStoreAsync(id);

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
           var store =  await _storeService.GetStoreByIdAsync(id);

            return Ok(store);
        }
    }
}