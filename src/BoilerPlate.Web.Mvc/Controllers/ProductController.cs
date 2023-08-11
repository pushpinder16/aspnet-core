using Abp.AspNetCore.Mvc.Authorization;
using Abp.Domain.Uow;
using BoilerPlate.Authorization;
using BoilerPlate.Controllers;
using BoilerPlate.Product;
using BoilerPlate.Web.Models.Product;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BoilerPlate.Web.Controllers
{

    [AbpMvcAuthorize(PermissionNames.Pages_Product)]
    public class ProductController : BoilerPlateControllerBase
    {
        private readonly IProductAppService _productAppService;


        public ProductController(IProductAppService productAppService)
        {
            _productAppService = productAppService;

        }
        [UnitOfWork]
        public async Task<IActionResult> Index()
        {
            var productDtos = await _productAppService.GetProductAsync();



            var productViewModel = new ProductViewModel
            {
                products = productDtos

            };

            return View(productViewModel);

        }


        public async Task<IActionResult> EditModal(int id)
        {
            var productDto = await _productAppService.GetProductByIdAsync(id);
            if (productDto == null)
            {
                return NotFound();
            }

            var model = new EditProductViewModel
            {
                Product = productDto
            };

            return PartialView("_EditModal", model);
        }

        //public async Task<IActionResult> DeleteAsync(int id)
        //{
        //    try
        //    {
        //        var product = await _productAppService.GetProductByIdAsync(id);

        //        //_productManager.Delete(product);
        //        _productAppService.DeleteAsync(product);
        //        return View("Index", product);
        //    }
        //    catch (Exception ex)
        //    {
        //        ViewBag.ErrorMessage = ex.Message;



        //        return View("Index");
        //    }
        //}
        [UnitOfWork]
        public async Task<ActionResult> Delete(int id)
        {
          var p =  await _productAppService.GetProductByIdAsync(id);
            _productAppService.DeleteAsync(p);

            return Ok();
        }

    }
}

