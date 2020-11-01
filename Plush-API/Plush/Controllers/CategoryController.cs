using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Plush.BusinessLogicLayer.Service.Interface;
using Plush.DataAccessLayer.Domain.Domain;
using Plush.DataAccessLayer.Domain.Models;
using Plush.Utils;

namespace Plush.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [Route("InsertCategory")]
        [HttpPost]
        public async Task<IActionResult> InsertCategory(CategoryInsert categoryInsert)
        {
            if (categoryInsert == null)
            {
                return StatusCode(Codes.Number_204, Messages.NoContent_204NoContent);
            }

            var request = new Category
            {
                Ages=categoryInsert.Ages,
                Name=categoryInsert.Name
            };

            if(await categoryService.GetCategoryByNameAsync(request) != null)
            {
                return StatusCode(Codes.Number_409, Messages.AlreadyExist_409Conflict);
            }

            if(await categoryService.InsertCategoryAsync(request) == false)
            {
                return StatusCode(Codes.Number_400, Messages.SthWentWrong_400BadRequest);
            }

            return Ok();
        }

        [Route("GetCategories")]
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await categoryService.GetCategoriesAsync();

            return StatusCode(Codes.Number_200, categories);
        }

        [Route("DeleteCategory")]
        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            if (id == 0)
            {
                return StatusCode(Codes.Number_204, Messages.NoContent_204NoContent);
            }

            if (await categoryService.GetCategoryByIdAsync(new Category { CategoryID=id}) == null)
            {
                return StatusCode(Codes.Number_404, Messages.NotFound_4040NotFound);
            }

            if (await categoryService.DeleteCategoryAsync(id) == false)
            {
                return StatusCode(Codes.Number_400, Messages.SthWentWrong_400BadRequest);
            }

            return Ok();
        }
    }
}