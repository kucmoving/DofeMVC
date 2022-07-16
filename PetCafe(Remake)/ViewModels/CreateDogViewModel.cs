using PetCafe_Remake_.Models;
using PetCafe_Remake_.Models.Data.Enum;

namespace PetCafe_Remake_.ViewModels
{
    public class CreateDogViewModel
    {
        public int Id { get; set; }
        public string DogName { get; set; }

        public string Introduction { get; set; }
        public IFormFile Image { get; set; }
        public int VisitTimeId { get; set; }

        public VisitTime VisitTime { get; set; }
        public DogCategory DogCategory { get; set; }
        public string AppUserId { get; set; }
    }
}
