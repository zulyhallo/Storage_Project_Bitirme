using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Storage.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        //Dosya yedeklerinin alınacağı klasör
        private readonly string backUpPath = @"D:\Projeler\Storage_Project_Bitirme\Storage_Project_Bitirme\BackUpFile\";
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "dosya1", "dosya2" };
        }

        
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        
        [HttpPost]
        public void CreateFile([FromForm] string fileContent, [FromForm] string fileName)
        {


            try
            {
                var filePath = backUpPath + fileName;
                System.IO.File.WriteAllBytes(filePath, string.IsNullOrEmpty(fileContent) ? new byte[0] : Convert.FromBase64String(fileContent));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        
        [HttpPost()]
        public void Delete([FromForm] string fileName)
        {
            var filePathh = backUpPath + fileName;
            System.IO.File.Delete(filePathh);

        }
    }
}
