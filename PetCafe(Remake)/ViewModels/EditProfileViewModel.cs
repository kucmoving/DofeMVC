namespace PetCafe_Remake_.ViewModels
{
    public class EditProfileViewModel
    {
        public string Id { get; set; }
        public string? UserName { get; set; }
        public string? Gender { get; set; }
        public string? ProfileImageUrl { get; set; }
        public string? Occupation { get; set; }
        public string? Region { get; set; }
        public IFormFile? Image { get; set; }
        public string? AboutMe { get; set; }
    }
}
