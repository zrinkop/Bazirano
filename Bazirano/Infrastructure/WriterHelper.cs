﻿using Bazirano.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazirano.Infrastructure
{
    public class WriterHelper
    {
        public static bool IsImageFile(IFormFile file)
        {
            return file.ContentType.StartsWith("image");
        }

        public static async Task UploadImage(BoardPost post, IFormFile file)
        {
            Random rnd = new Random();
            string fileName = rnd.Next(10000, 99999).ToString() + file.FileName;

            string filePath = Path.Combine(Directory.GetCurrentDirectory(),
                                           "wwwroot\\images",
                                           fileName);
            post.Image = fileName;

            if (IsImageFile(file))
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }
        }
    }
}
