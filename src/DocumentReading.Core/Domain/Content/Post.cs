using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DocumentReading.Core.Domain.Content
{
    [Table("Posts")]
    [Index(nameof(Slug), IsUnique = true)]
    public class Post
    {
        [Key]
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Slug { get; set; }
        public string? Description { get; set; }
        public Guid CategoryId { get; set; }
        public string? Thumbnail { get; set; }
        public string? Author { get; set; }
        public string? Tags { get; set; }

        public int ViewCount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }
    public enum PostStatus
    {
        Draft = 1,
        Cancelled = 2,
        WaitingForApprovall = 3,
        Rejected = 4,
        WaitingForPublishing = 5,
        Published = 6
    }
}
