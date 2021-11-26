using Keepnote.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Keepnote.Repository;
using System.Diagnostics;
using System;

namespace Keepnote.Controllers
{
    public class NoteController : Controller
    {
        /*
	     From the problem statement, we can understand that the application
	     requires us to implement the following functionalities.
	     1. display the list of existing notes from the collection. Each note 
	        should contain Note Id, title, content, status and created date.
	     2. Add a new note which should contain the title, content and status.
	     3. Delete an existing note.
         4. Update an existing Note.
	    */

        private readonly INoteRepository _noteRepo;

        public NoteController(INoteRepository repo)
        {
            _noteRepo = repo;
        }

        public IActionResult Index()
        {
            List<Note> objNote = _noteRepo.GetAllNotes();
            return View(objNote);
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Note note)
        {
            if (ModelState.IsValid)
            {
                _noteRepo.AddNote(note);
                return RedirectToAction("Index");
            }
            else
            {
                return View(note);
            }
        }

        //public ActionResult Delete(int id)
        //{
        //    Note ns = _noteRepo.GetNoteById(id);
        //    return View(ns);
        //}


        public ActionResult Delete(int id, Note n = null)
        {
            Note obj = _noteRepo.GetNoteById(id);
            return View(obj);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {

            if(_noteRepo.DeletNote(id) == 1)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
            
        }

        public ActionResult Edit(int id)
        {
            Note ns = _noteRepo.GetNoteById(id);
            return View(ns);
        }

        [HttpPost]
        public ActionResult Edit(Note n)
        {
            _noteRepo.UpdateNote(n);
            return RedirectToAction("Index");
        }


        //Inject the noteRepository instance through constructor injection.

        /*
      * Define a handler method to read the existing notes from the database and add
      * it to the ModelMap which is an implementation of Map, used when building
      * model data for use with views. it should map to the default URL i.e. "/index"
      */

        /*
         * Define a handler method which will read the NoteTitle, NoteContent,
         * NoteStatus from request parameters and save the note in note table in
         * database. Please note that the CreatedAt should always be auto populated with
         * system time and should not be accepted from the user. Also, after saving the
         * note, it should show the same along with existing messages. Hence, reading
         * note has to be done here again and the retrieved notes object should be sent
         * back to the view. This handler method should map to the URL "/create".
         */

        /*
         * Define a handler method which will read the NoteId from request parameters
         * and remove an existing note by calling the deleteNote() method of the
         * NoteRepository class.".
         */

        /*
         * Define a handler method which will update the existing note.
         */
    }
}