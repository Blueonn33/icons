using AutoMapper;
using icons.Core.Contracts;
using icons.Core.DTO.Notes.Request;
using icons.Core.Mappings;
using icons.Core.ViewModels.Notes;
using icons.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace icons.Controllers
{
    public class NotesController(
        INoteService _notesService,
        UserManager<ApplicationUser> _userManager,
        IMapper _mapper,
        ILogger<NotesController> _logger) : BaseController
    {
        //[HttpGet]
        //public async Task<IActionResult> Index()
        //{
        //    string? userId = _userManager.GetUserId(User);

        //    if (userId == null)
        //    {
        //        return NotFound();
        //    }

        //    var notes = await _notesService.GetAllNotesByUserIdAsync(userId);
        //    var notesViewModel = _mapper.Map<IEnumerable<NoteViewModel>>(notes);

        //    AllNotesViewModel allNotes = new AllNotesViewModel()
        //    {
        //        Notes = notesViewModel
        //    };

        //    return View(allNotes);
        //}

        [HttpPost]
        public async Task<IActionResult> CreateNote(NoteInputModel model)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return NotFound();
            }

            try
            {
                var note = new AddNoteRequestData()
                {
                    Content = model.Content,
                    SenderId = user.Id,
                    ReceiverId = model.ReceiverId
                };

                await _notesService.AddNoteAsync(note);
                TempData["Success"] = "Успешно написа бележка";
            }
            catch (Exception e)
            {
                _logger.LogCritical("Възникна грешка. Провери logs");
                TempData["Error"] = "Възникна грешка при създаването на бележка";
            }

            return RedirectToAction(nameof(UserProfile), "Users", new
            {
                id = model.ReceiverId
            });
        }
    }
}
