using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Lab_13.Models
{
    public class Book
    {
         public int BookID { get; set; } // int
         public string Title { get; set; } // nvarchar(100)
         public string ISBN { get; set; } // nvarchar(20)
         public int? PublishedYear { get; set; } // int
    }
}
