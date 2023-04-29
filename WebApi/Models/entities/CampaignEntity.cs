using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models.Entities
{
    public class CampaignEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public string CampaignName { get; set; }
        [ForeignKey("CampaignProductId")]
        public CampaignProductEntity CampingProduct { get; set; }

    }
}
