using System.ComponentModel.DataAnnotations;

namespace PetCafe_Remake_.Models
{
    public class VisitTime
    {
        [Key]
        public int Id { get; set; }

        public string Day { get; set; }

        public string TimeFrame { get; set; }

    }
}
