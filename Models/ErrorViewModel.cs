using System.Collections.Generic;

namespace MovLov.Models
{
    public class TrendingMoviesResponse
    {
        public List<Movie>? results { get; set; }
        public TrendingMoviesResponse() { 
        results = new List<Movie>();
        }
        public int page { get; set; } // Add this property
        public int total_pages { get; set; } // Add this property
        // Diğer gerekli alanları da buraya ekleyebilirsiniz
    }

    public class Movie
    {
        public string? title { get; set; }
        public string? overview { get; set; }
        public string? poster_path { get; set; }
        public int? page { get; set; }
        public int? total_pages { get; set; }
    }


       public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }


}