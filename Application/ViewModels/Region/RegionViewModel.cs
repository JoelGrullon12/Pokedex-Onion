using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Core.Application.ViewModels.Region
{
    public class RegionViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Debe colocar el nombre de la region")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Debe colocarle una descripcion a la region")]
        public string Description { get; set; }
    }
}
