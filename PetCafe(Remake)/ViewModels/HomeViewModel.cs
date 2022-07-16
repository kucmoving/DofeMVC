using PetCafe_Remake_.Models;

namespace PetCafe_Remake_.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Event> Events { get; set; }
        public string Region { get; set; }

        public string TempC { get; set; }
        public string TempF { get; set; }
        public string LocalTime { get; set; }
        public string Address { get; set; }
    }
}
