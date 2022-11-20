using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using coreApp.Models;
using coreApp.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace coreApp.Services
{
    public class TodoItemService: ITodoItemService
    {
        //dependancy injection
        private readonly ApplicationDbContext _context;


        //construtor
        public TodoItemService(ApplicationDbContext context){
            _context = context;
        }

        public Task<TodoItem[]> GetIncompleteItemsAsync(){
           return _context.Items.Where(x=>x.isDone == false).ToArrayAsync();
        }

  public async  Task<bool> AddItemAsync(TodoItem newItem){
            newItem.id = Guid.NewGuid();
            newItem.isDone = false;
            newItem.DueAt = DateTimeOffset.Now.AddDays(3);

            _context.Items.Add(newItem);
            var saveResult = await _context.SaveChangesAsync();

           return saveResult == 1;
        }

    public async  Task<bool> MarkDoneAsync(Guid id){
         var item = await _context.Items.Where(x=>x.id == id).SingleOrDefaultAsync();
         if(item == null) return false;
         item.isDone=true;

            var saveResult = await _context.SaveChangesAsync();

           return saveResult == 1;
        }
    }
}