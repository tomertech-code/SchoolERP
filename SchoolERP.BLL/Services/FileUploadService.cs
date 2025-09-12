using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace SchoolERP.BLL.Services
{
    public class FileUploadService
    {
        private readonly string[] _allowedFileTypes = { "pdf", "jpg", "jpeg", "png" };
        private readonly long _maxFileSize = 5 * 1024 * 1024; // 5MB

        public async Task<string> UploadFileAsync(IFormFile file, string uploadDirectory = "wwwroot/uploads/")
        {
            // Check if the file is null
            if (file == null)
            {
                return "Error: No file uploaded.";
            }

            // Check file type
            var fileExtension = Path.GetExtension(file.FileName).ToLowerInvariant().TrimStart('.');
            if (!_allowedFileTypes.Contains(fileExtension))
            {
                return "Error: Only PDF, JPG, PNG files are allowed.";
            }

            // Check file size
            if (file.Length > _maxFileSize)
            {
                return "Error: File size exceeds the limit of 5MB.";
            }

            // Generate a unique file name to avoid conflicts
            var fileName = $"{Path.GetFileNameWithoutExtension(file.FileName)}_{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";

            // Define the file path
            var filePath = Path.Combine(uploadDirectory, fileName);

            // Ensure the directory exists
            Directory.CreateDirectory(uploadDirectory);

            // Save the file
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return $"File uploaded successfully: {filePath}";
        }
    }
    }
