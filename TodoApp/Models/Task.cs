using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.Libraries.Messages;

namespace TodoApp.Models
{
    public class Task
    {
        //PK
        public int Id { get; set; }

        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E001")]
        [Display(Name = "Título")]
        public string Title { get; set; }
        
        public string Subtitle { get; set; }

        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E001")]
        [Display(Name = "Descrição")]
        public string Description { get; set; }
        
        public bool IsDone { get; set; }
    }
}
