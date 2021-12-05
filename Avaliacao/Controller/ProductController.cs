using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
namespace API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        protected readonly IMapper _mapper;
        private readonly IProductService _productService;

        public ProductController(
            IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }



        [HttpGet("{sku}")]
        public async Task<ActionResult> Get(long sku)
        {
            var entity = await _productService.GetProduct(sku);
            if (entity == null)
                return NotFound();

            var model = _mapper.Map<Product>(entity);
            return Ok(model);
        }



        [HttpPost]
        public ActionResult Post([FromBody] Product value)
        {
            try
            {
                if (_productService.ValidationId(value.SKU))
                {
                    return BadRequest("SKU de Produto já existente!");
                }

                var entity = _mapper.Map<Product>(value);
                _productService.Add(entity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }




        [HttpPut("{sku}")]
        public ActionResult Put(long sku, [FromBody] Product value)
        {
            try
            {
                if (sku <= 0)
                {
                    return BadRequest("SKU inválido");
                }
                var entity = _mapper.Map<Product>(value);
                _productService.UpdateProduct(entity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }


        [HttpDelete("{sku}")]
        public ActionResult Delete(long sku)
        {
            try
            {
                _productService.Delete(sku);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }
    }
}
