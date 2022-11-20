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

    

    }
}
