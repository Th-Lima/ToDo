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
        [MinLength(2, ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E002")]
        [MaxLength(20, ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E003")]
        public string Title { get; set; }

        [Display(Name = "Subtitulo")]
        [MinLength(2, ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E002")]
        [MaxLength(20, ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E003")]
        public string Subtitle { get; set; }

        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E001")]
        [MinLength(10, ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E002")]
        [MaxLength(200, ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E003")]
        [Display(Name = "Descrição")]
        public string Description { get; set; }

        [Display(Name = "Data de conclusão")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ConclusionDate { get; set; }

        public bool IsDone { get; set; }
    }
}
