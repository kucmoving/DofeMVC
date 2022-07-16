using Microsoft.AspNetCore.Mvc;
using PetCafe_Remake_.Extension;
using PetCafe_Remake_.Interface;
using PetCafe_Remake_.Models;
using PetCafe_Remake_.ViewModels;

namespace PetCafe_Remake_.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventRepository _eventRepository;
        private readonly IPhotoService _photoService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public EventController(IEventRepository eventRepository, IPhotoService photoService,
            IHttpContextAccessor httpContextAccessor)
        {
            _eventRepository = eventRepository;
            _photoService = photoService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Event> events = await _eventRepository.GetAll();
            return View(events);
        }

        public async Task<IActionResult> Detail(int id)
        {
            Event _event = await _eventRepository.GetByIdAsync(id);
            return View(_event);
        }
        public IActionResult Create()
        {
            var curUserId = _httpContextAccessor.HttpContext.User.GetUserId();
            var createEventViewModel = new CreateEventViewModel { AppUserId = curUserId };
            return View(createEventViewModel);

        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateEventViewModel eventVM)
        {
            if (ModelState.IsValid)
            {
                var result = await _photoService.AddPhotoAsync(eventVM.Image);
                var _event = new Event
                {
                    EventName = eventVM.EventName,
                    Introduction = eventVM.Introduction,
                    Image = result.Url.ToString(),
                    EventTime = eventVM.EventTime,
                    Region = eventVM.Region,
                    AppUserId = eventVM.AppUserId

                };
                _eventRepository.Add(_event);
                return RedirectToAction("index");
            }
            else
            {
                ModelState.AddModelError("", "Photo upload failed");
            }
            return View(eventVM);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id) //to copy message as a form data
        {
            var _event = await _eventRepository.GetByIdAsync(id);
            if (_event == null) return View("Error");
            var _eventVM = new EditEventViewModel
            {
                EventName = _event.EventName,
                Introduction = _event.Introduction,
                EventTime = _event.EventTime,
                URL = _event.Image,
                EventCategory = _event.EventCategory,
                Region = _event.Region

            };
            return View(_eventVM);
        }
        [HttpPost] //to update
        public async Task<IActionResult> Edit(int id, EditEventViewModel eventVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(" ", "Failed to edit club");
                return View("Edit", eventVM);
            }

            var eventId = await _eventRepository.GetByIdAsyncNoTracking(id);

            if (eventId != null)
            {
                try
                {
                    await _photoService.DeletePhotoAsync(eventId.Image);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Could not delete photo");
                    return View(eventVM);
                }

                var photoResult = await _photoService.AddPhotoAsync(eventVM.Image);
                if (photoResult.Error != null)
                {
                    ModelState.AddModelError("Image", "Photo upload failed");
                    return View(eventVM);
                }
                var _event = new Event //no need to put foreign inside
                {
                    Id = id,
                    EventName = eventVM.EventName,
                    EventCategory = eventVM.EventCategory,
                    Introduction = eventVM.Introduction,
                    Image = photoResult.Url.ToString(),
                    EventTime = (DateTime)eventVM.EventTime,
                    AppUserId = eventId.AppUserId,
                    Region = eventVM.Region
                };
                _eventRepository.Update(_event);
                return RedirectToAction("index");
            }
            else
            {
                return View(eventVM);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var eventDetails = await _eventRepository.GetByIdAsync(id);
            if (eventDetails == null) return View("Error");
            return View(eventDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            var eventDetails = await _eventRepository.GetByIdAsync(id);
            if (eventDetails == null) return View("Error");
            _eventRepository.Delete(eventDetails);
            return RedirectToAction("Index");
        }


    }
}


