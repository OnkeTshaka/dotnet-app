using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using coreApp.Models;

namespace coreApp.Services
{
    public interface ITodoItemService
    {
        
        Task<TodoItem[]> GetIncompleteItemsAsync();
        Task<bool> AddItemAsync(TodoItem newItem);
                Task<bool> MarkDoneAsync(Guid id);
        

    }
}
