using AcademyProject_API.Model.Dtos;
using AcademyProject_API.Model.Entities;
using AcademyProject_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie_Api.Handler;
using Movie_Api.Mappers;

namespace AcademyProject_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<T> : ControllerBase where T : class
    {
        readonly IGenaricRepo<T> _service;
        public BaseController(IGenaricRepo<T> service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<T>>> GetAllItems()
        {
            var Allitems = await _service.GetAll();
            if (Allitems == null)
                throw new ApiException($"Has No Data Back", StatusCodes.Status204NoContent);


            return Ok(APIRespone<IEnumerable<T>>.CreateSuccess(Allitems));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetItemById(int id)
        {
            var item = await _service.GetById(id);
            if (item == null)
                throw new ApiException($"Not Found", StatusCodes.Status404NotFound);


            return Ok(APIRespone<T>.CreateSuccess(item));
        }
        [HttpPost]
        public async Task<ActionResult> AddItem(T item)
        {
            if (item == null)
                throw new ApiException($"BadRequest from body", StatusCodes.Status400BadRequest);
            await _service.Add(item);
            return Ok(APIRespone<T>.CreateSuccess(item));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateItemById(int id, [FromBody] T itemUpdated)
        {
            if (itemUpdated == null)
                throw new ApiException($"BadRequest from body", StatusCodes.Status400BadRequest);

            var item = await _service.GetById(id);
            if (item == null)
                throw new ApiException($"NoContent", StatusCodes.Status204NoContent);

            await _service.UpdateAsync(item, itemUpdated);

            return Ok(APIRespone<T>.CreateSuccess(itemUpdated));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteItemById(int id)
        {

            var item = await _service.GetById(id);
            if (item == null)
                throw new ApiException($"NoContent", StatusCodes.Status204NoContent);

            await _service.Delete(item);

            return Ok(APIRespone<T>.CreateSuccess(item));
        }
    }
}
