using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Dtos
{
    public class CreateOverviewDto
    {
        public string Title { get; set; }
        public string? ImageUrl { get; set; }
    }
    public class UpdateOverviewDto
    {
        public string Title { get; set; }
        public string? ImageUrl { get; set; }
    }
    public class OverviewResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string? ImageUrl { get; set; }=null;




    }
}
