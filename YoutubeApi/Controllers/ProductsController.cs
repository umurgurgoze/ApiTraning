using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using YoutubeApi.Entities;

namespace YoutubeApi.Controllers
{
    // ROUTE = ysk.com.tr/api/Products
    //HttpGet, HttpPost, HttpPut, HttpDelete
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly YoutubeContext _context;
        public ProductsController(YoutubeContext context)
        {
            _context = context;
        }
        //api/products/getproducts için [httpget("[action]")] yazmamız gerekiyor.
        //Bir işlemi başarıyla döndürürsek 200 Ok dönmemiz gerekiyor.
        //Bir güncelleme ve silme işlemi baraşıyla gerçekleştiyse No Content döneriz.
        //Bir ekleme işleminde Created 201 dönmemiz gerekli.Bunlar kabul edilmiş best practiseler.
        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(_context.Products.ToList());
        }
        //api/products?id=1 ==> Bu şekilde bir istek yapacaksak FromQuery yazabiliriz.
        //api/products/1 ==> Bu şekilde istekte FromRoute yazarız.Bu şekilde gelecekse otomatik mapler yazmamıza gerek yok.
                      //  ==> FromBody ise istek için gelen değerlerdir.
        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            return Ok(_context.Products.FirstOrDefault(p => p.Id == id));
        }
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, Product product)
        {
            var updatedProduct = _context.Products.FirstOrDefault(x => x.Id == id);
            updatedProduct.Name = product.Name;
            _context.SaveChanges();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var deletedProduct = _context.Products.FirstOrDefault(x => x.Id == id);
            _context.Remove(deletedProduct);
            _context.SaveChanges();
            return NoContent();
        }
        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            _context.Add(product);
            _context.SaveChanges();
            return Created("", product);
        }

    }
}
