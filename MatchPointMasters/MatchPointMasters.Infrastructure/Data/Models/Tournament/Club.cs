using MatchPointMasters.Infrastructure.Data.Enums.Tournament;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static MatchPointMasters.Infrastructure.Constants.DataConstants;
namespace MatchPointMasters.Infrastructure.Data.Models.Tournament
{
    [Comment("Tennis club to host a tournament")]
    public class Club
    {
        [Key]
        [Comment("Tennis Club Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(TitleMaxLenght)]
        [Comment("Title")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(AddressMaxLenght)]
        [Comment("Club's address")]
        public string Address { get; set; } = string.Empty;

        [Comment("Tennis club's image url")]
        public string TennisClubImageUrl { get; set; } = string.Empty;

        public CourtSurface CourtSurface { get; set; }

    }
}
