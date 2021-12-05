using API.DTO;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        private readonly IProductService _productService;
        public ProductController(ILogger<ProductController> logger,
            IProductRepository repository,
            IMapper mapper,
            IProductService productService)
        {
            _productService = productService;
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> Get()
        {

            var products = await _productService.FindAll();

            return Ok(_mapper.Map<List<ProductDTO>>(products));
        }

        [HttpGet("{sku}")]
        public async Task<ActionResult> Get(long sku)
        {
            var entity = await _productService.FindById(sku);
            if (entity == null)
                return NotFound();

            var model = _mapper.Map<ProductDTO>(entity);
            return Ok(model);
        }

        [HttpPost]
        public ActionResult Post([FromBody] Product value)
        {
            try
            {
                var entity = _mapper.Map<Product>(value);
                _productService.AddProduct(entity);
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
                    return BadRequest("SKU inválido");

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
                _productService.DeleteProduct(sku);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }


    }
}