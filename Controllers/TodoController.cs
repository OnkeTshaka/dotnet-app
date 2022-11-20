using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using coreApp.Services;
using coreApp.Models;

namespace coreApp.Controllers
{
    public class TodoController : Controller
    {
        //dependancy Injection
        private readonly ITodoItemService _todoItemService;

        //constructor - in order to create 
        public TodoController(ITodoItemService todoItemService){
            _todoItemService = todoItemService;
        }

        public async Task<IActionResult> Index()
        {
            // get to-do items from database
            var items = await _todoItemService.GetIncompleteItemsAsync();
            // Put items into a model
            var model = new TodoViewModel(){
                Items = items
            };

            //Render view using model
            return View(model);
        }
           [ValidateAntiForgeryToken]
           public async Task<IActionResult> AddItem(TodoItem newItem)
        {
            if (!ModelState.IsValid){
                return RedirectToAction("index");
            }
            // get to-do items from database
            var successful = await _todoItemService.AddItemAsync(newItem);
            // Put items into a model
            if(!successful){
                return BadRequest("Could not add item.");
            }

            //Render view using model
            return RedirectToAction("index");
        }

        [ValidateAntiForgeryToken]
           public async Task<IActionResult> MarkDone(Guid id)
        {
            if (id == Guid.Empty){
                return RedirectToAction("index");
            }
            // get to-do items from database
            var successful = await _todoItemService.MarkDoneAsync(id);
            // Put items into a model
            if(!successful){
                return BadRequest("Could not mark item.");
            }

            //Render view using model
            return RedirectToAction("index");
        }

    

    }
}
