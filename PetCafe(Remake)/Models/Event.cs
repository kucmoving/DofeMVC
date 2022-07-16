using PetCafe_Remake_.Models.Data.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetCafe_Remake_.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }

        public string EventName { get; set; }

        public string Introduction { get; set; }

        public string Image { get; set; }

        public string Region { get; set; }
        public DateTime EventTime { get; set; }

        public EventCategory EventCategory { get; set; }
        [ForeignKey("AppUser")]
        public string? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
    }

}
