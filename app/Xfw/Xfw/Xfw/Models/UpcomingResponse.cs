using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xfw.Models
{

    public class UpcomingResponse
    {
        [JsonProperty("results")]
        public List<Movie> Movies{ get; set; }
        [JsonProperty("page")]
        public int Page { get; set; }
        [JsonProperty("total_results")]
        public int TotalResults { get; set; }
        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }
    }
}
