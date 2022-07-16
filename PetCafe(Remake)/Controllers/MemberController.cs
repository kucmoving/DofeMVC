using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PetCafe_Remake_.Extension;
using PetCafe_Remake_.Interface;
using PetCafe_Remake_.Models;
using PetCafe_Remake_.ViewModels;

namespace PetCafe_Remake_.Controllers
{
    public class MemberController : Controller
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IPhotoService _photoService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<AppUser> _userManager;

        public MemberController(IMemberRepository memberRepository, IPhotoService photoService,
            IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager)
        {
            _memberRepository = memberRepository;
            _photoService = photoService;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var userEvents = await _memberRepository.GetAllUserEvents();
            var userDogs = await _memberRepository.GetAllUserDogs();
            var memberViewModel = new MemberViewModel()
            {
                Events = userEvents,
                Dogs = userDogs,
            };
            return View(memberViewModel);

        }

        public async Task<IActionResult> EditProfile()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return View("Error");
            }
            var editUserViewModel = new EditProfileViewModel()
            {
                Gender = user.Gender,
                ProfileImageUrl = user.ProfileImageUrl,
                Occupation = user.Occupation,
                Region = user.Region,
                AboutMe = user.AboutMe,


            };
            return View(editUserViewModel);
        }

        //receive form
        [HttpPost]
        public async Task<IActionResult> EditProfile(EditProfileViewModel editVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit profile");
                return View("EditProfile", editVM);
            }

            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return View("Error");
            }

            if (editVM.Image != null) // only update profile image
            {
                var photoResult = await _photoService.AddPhotoAsync(editVM.Image);

                if (photoResult.Error != null)
                {
                    ModelState.AddModelError("Image", "Failed to upload image");
                    return View("EditProfile", editVM);
                }

                if (!string.IsNullOrEmpty(user.ProfileImageUrl))
                {
                    _ = _photoService.DeletePhotoAsync(user.ProfileImageUrl);
                }

                user.ProfileImageUrl = photoResult.Url.ToString();
                editVM.ProfileImageUrl = user.ProfileImageUrl;

                await _userManager.UpdateAsync(user);

                return View(editVM);
            }
            user.Gender = editVM.Gender;
            user.Region = editVM.Region;
            user.UserName = editVM.UserName;
            user.Occupation = editVM.Occupation;
            user.AboutMe = editVM.AboutMe;
            await _userManager.UpdateAsync(user);

            return RedirectToAction("Detail", "User", new { user.Id });
        }



    }
}
