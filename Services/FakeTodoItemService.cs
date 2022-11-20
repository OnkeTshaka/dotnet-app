using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using coreApp.Models;

namespace coreApp.Services
{
    public class FakeTodoItemService: ITodoItemService
    {
        

        public Task<TodoItem[]> GetIncompleteItemsAsync(){
            var item1 = new TodoItem{
                title="dsaasdas",
                DueAt = DateTimeOffset.Now.AddDays(1)
            };
              var item2 = new TodoItem{
                title="Hello world",
                DueAt = DateTimeOffset.Now.AddDays(2)
            };
            return Task.FromResult(new[]{item1,item2});
        }

    }
}
