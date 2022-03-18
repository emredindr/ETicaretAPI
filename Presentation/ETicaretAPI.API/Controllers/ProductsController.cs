using ETicaretAPI.Application.Abstractions;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Persistence.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public readonly IProductReadRepository _productReadRepository;
        public readonly IProductWriteRepository _productWriteRepository;

        public readonly IOrderReadRepository _orderReadRepository;
        private readonly IOrderWriteRepository _orderWriteRepository;  

        public readonly ICustomerReadRepository _customerReadRepository;
        public readonly ICustomerWriteRepository _customerWriteRepository;

        public ProductsController
            (
            IProductWriteRepository productWriteRepository,
            IProductReadRepository productReadRepository,
            ICustomerWriteRepository customerWriteRepository,
            ICustomerReadRepository customerReadRepository,
            IOrderReadRepository orderReadRepository,
            IOrderWriteRepository orderWriteRepository
            
            )
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
            _customerWriteRepository = customerWriteRepository;
            _customerReadRepository = customerReadRepository;
            _orderReadRepository = orderReadRepository;
            _orderWriteRepository = orderWriteRepository;
        }

        [HttpGet]
        public async Task Get()
        {
           Order order= await _orderReadRepository.GetByIdAsync("d9752f12-374b-4bab-8eb4-6df3b30c9abb");
           order.Address = "paris";
           await _orderWriteRepository.SaveAsync();
        }


    }
}



//[HttpGet]
//public async Task Get()
//{
//    var customerId=Guid.NewGuid();
//    await _customerWriteRepository.AddAsync(new() { Id = customerId, Name = "Emree" });
//    await _orderWriteRepository.AddAsync(new() { Description="Sipariş emre tarafından verildi",Address="Konya" ,CustomerId=customerId});
//    await _orderWriteRepository.AddAsync(new() { Description = "Yemeksepeti", Address = "Yalova", CustomerId = customerId });


//    await _orderWriteRepository.SaveAsync();
//}



//[HttpGet]
//public async Task Get()
//{
//    //await _productWriteRepository.AddRangeAsync(new()
//    //{
//    //    new() { Id = Guid.NewGuid(), Name = "Product 1", CreatedDate = DateTime.UtcNow, Price = 100, Stock = 10 },
//    //    new() { Id = Guid.NewGuid(), Name = "Product 2", CreatedDate = DateTime.UtcNow, Price = 200, Stock = 20 },
//    //    new() { Id = Guid.NewGuid(), Name = "Product 3", CreatedDate = DateTime.UtcNow, Price = 300, Stock = 30 }
//    //});

//    //var count = await _productWriteRepository.SaveAsync();

//    //Product p = await _productReadRepository.GetByIdAsync("6f2b77fc-1741-461f-b9b7-42db7b1ed1b1");
//    //p.Name = "Mehmet";
//    //_productWriteRepository.SaveAsync();
//    await _productWriteRepository.AddAsync(new()
//    {
//        Name = "Product C",
//        Price = 1.500f,
//        Stock = 619,
//        CreatedDate = DateTime.UtcNow
//    });
//    await _productWriteRepository.SaveAsync();

//}
//[HttpGet("id")]
//public async Task<IActionResult> Get(string id)
//{
//    Product product = await _productReadRepository.GetByIdAsync(id);
//    return Ok(product);
//}