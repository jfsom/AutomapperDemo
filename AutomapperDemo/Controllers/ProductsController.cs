using AutoMapper;
using AutomapperDemo.Data;
using AutomapperDemo.DTOs;
using AutomapperDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutomapperDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductDBContext _context;
        private readonly IMapper _mapper;

        public ProductsController(ProductDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/product
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProducts()
        {
            try
            {
                var products = await _context.Products.ToListAsync();

                // Use AutoMapper to map Product entities to ProductDTOs
                var productDTOs = _mapper.Map<List<ProductDTO>>(products);

                return Ok(productDTOs);
            }
            catch (Exception ex)
            {
                // Handles any unexpected errors
                return StatusCode(500, new { Message = "An error occurred while retrieving products.", Details = ex.Message });
            }

        }

        // GET: api/products/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProductById(int id)
        {
            try
            {
                var product = await _context.Products.FindAsync(id);

                if (product == null)
                    return NotFound();

                // Use AutoMapper to map Product entity to ProductDTO
                var productDTO = _mapper.Map<ProductDTO>(product);

                return Ok(productDTO);
            }
            catch (Exception ex)
            {
                // Handles any unexpected errors
                return StatusCode(500, new { Message = "An error occurred while retrieving the product.", Details = ex.Message });
            }
        }

        // POST: api/product
        [HttpPost]
        public async Task<ActionResult<ProductCreateDTO>> AddProduct(ProductCreateDTO productCreateDTO)
        {
            try
            {
                if (productCreateDTO == null)
                    return BadRequest("Invalid product data.");

                // Use AutoMapper to map ProductCreateDTO to Product entity
                var product = _mapper.Map<Product>(productCreateDTO);
                product.IsAvailable = product.StockQuantity > 0;

                _context.Products.Add(product);
                await _context.SaveChangesAsync();

                // Return the created product's details
                return CreatedAtAction(nameof(GetProducts), new { id = product.Id }, productCreateDTO);
            }
            catch (Exception ex)
            {
                // Handles any unexpected errors
                return StatusCode(500, new { Message = "An error occurred while creating the product.", Details = ex.Message });
            }
        }
    }
}