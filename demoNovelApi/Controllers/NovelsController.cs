using demoNovelApi.Data;
using demoNovelApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demoNovelApi.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class NovelsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public NovelsController(ApplicationDbContext context)
        {

            this._context = context;
        }

        [HttpPost("{NovelName}")]
        public IActionResult RegisterNovel(string NovelName)
        {
            try
            {
                Novel newBook = new Novel();
                newBook.Name = NovelName;
                this._context.Books.Add(newBook);
                int result = this._context.SaveChanges();

                if (result > 0)
                {
                    return this.Ok(new { success = true, Message = "Novel is added." });
                }
                else
                {
                    return this.BadRequest(new { success = false, Message = "Novel is not added." });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { success = false, Message = ex.Message, InnerException = ex.InnerException });
            }
        }

        [HttpGet]
        public IActionResult GetAllNovels()
        {
            try
            {
                var Novels = this._context.Books.ToList();
                if (Novels != null)
                {
                    return this.Ok(new { success = true, data = Novels });
                }
                else
                {
                    return this.NotFound(new { Message = "Novels not found" });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { success = false, Message = ex.Message, InnerException = ex.InnerException });
            }
        }

        [HttpGet("{Id}")]
        public IActionResult GetNovelById(int Id)
        {
            try
            {
                var Novel = this._context.Books.FirstOrDefault(x => x.Id == Id);
                if (Novel != null)
                {
                    return this.Ok(new { success = true, data = Novel });
                }
                else
                {
                    return this.NotFound(new { Message = "Novels not found" });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { success = false, Message = ex.Message, InnerException = ex.InnerException });
            }
        }
    }
}
