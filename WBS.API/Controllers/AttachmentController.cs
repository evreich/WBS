using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WBS.DAL;
using WBS.DAL.Data.Models;

namespace WBS.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class AttachmentController : Controller
    {
        private IHttpContextAccessor httpContextAccessor;
        //TODO: сдедать DAL
        private readonly WBSContext _context;

        public AttachmentController(IHttpContextAccessor httpContextAccessor, WBSContext context)
        {
            this.httpContextAccessor = httpContextAccessor;
            _context = context;
        }


        [HttpPost("Upload")]
        //[Authorize]
        public IActionResult Upload()
        {
            var request = httpContextAccessor.HttpContext.Request;
            var files = request.Form.Files;

            string fileName = files[0].FileName;

            Stream stream = files[0].OpenReadStream();
            List<byte> data = new List<byte>();
            int b = stream.ReadByte();

            while (b != -1)
            {
                data.Add((byte)b);
                b = stream.ReadByte(); 
            }
            stream.Close();
            
            System.IO.File.WriteAllBytes(Environment.CurrentDirectory + "\\" + fileName, data.ToArray());

            var newAttachment = _context.Attachments.Add(new Attachment() { Data = data.ToArray(), FileName = fileName });
            _context.SaveChanges();

            return Ok(new { success = true, id = newAttachment.Entity.Id });
        }

        [HttpGet]
        [Produces("text/html")]
        public IActionResult GetAttachment(int id)
        {
            var attachment = _context.Attachments.FirstOrDefault(a => a.Id == id);

            var result = new FileContentResult(attachment.Data, "text/html; charset=utf-8");
            result.FileDownloadName = attachment.FileName;
            HttpContext.Response.Headers.Add("Access-Control-Expose-Headers", "Content-Disposition");
            return result;
        }

        [HttpDelete("Delete")]
        public IActionResult DeleteAttachment(int id)
        {
            var attachment = _context.Attachments.FirstOrDefault(a => a.Id == id);
            _context.Attachments.Remove(attachment);
            _context.SaveChanges();
            return Ok();
        }
        
    }

}