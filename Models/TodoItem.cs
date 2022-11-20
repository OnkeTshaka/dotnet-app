using System;
using System.ComponentModel.DataAnnotations;

namespace coreApp.Models
{
    public class TodoItem
    {
        

        public Guid id {get;set;}
        public bool isDone {get;set;}
        [Required]
        public string title {get;set;}

        public DateTimeOffset? DueAt{get;set;}

    }
}
