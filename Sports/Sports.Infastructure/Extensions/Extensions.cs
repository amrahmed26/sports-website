using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Http;

namespace Sports.Infastructure.Extensions
{
public static class DbContextExtensions
    {
        public static string GetTableName<TEntity>(this DbContext context) where TEntity : class
        {
            IEntityType entityType = context.Model.FindEntityType(typeof(TEntity));
            return entityType.GetTableName();
        }
        public static string GetPrimaryKeyColumnName<TEntity>(this DbContext context) where TEntity : class
        {
            IEntityType entityType = context.Model.FindEntityType(typeof(TEntity));
            return entityType.FindPrimaryKey().Properties.First().Name;
        }
    }
public static class FileUploadExtension
{
   public static string UploadFile(this IFormFile file)
        {
            var uploadsFolder = Path.Combine("wwwroot", "uploads");

            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            var uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            return uniqueFileName;
        }
}
}
