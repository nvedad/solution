using DataServices.DBModels;
using DataServices.Model;
using DataServices.UnitofWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BookStore.Controllers
{
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IUoW _context;
        public BooksController(IUoW context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("api/GetAllBooks")]
        public IList<Title> GetAllBooks()
        {
            return _context.GetTitlesRepo.GetTitles();

            
        }


        [HttpPost]
        [Route("api/submitOrder")]
        public IActionResult SubmitOrder(string title, int qty)
        {
            if (title == null || qty < 1)
            {
                return BadRequest("Invalid order data");
            }

            //_context.SubmitOrderRepo.Info(BookName);
            _context.SubmitOrderRepo.SubmitOrder(title,qty);
            return Created("","Order placed successfully");
        }

        [HttpGet]
        [Route("api/GetReceipt")]
        public IActionResult Receipt(string id)
        {
            //List<Sale>
            if (id == null)
            {
                return BadRequest("Invalid order ID");
            }
            List<Sale> result = _context.GetReceiptRepo.GetReceipt(id);
            if(result.Count>0)
            return Ok(result);

            return BadRequest("Receipt not found");
        }

    }
}

