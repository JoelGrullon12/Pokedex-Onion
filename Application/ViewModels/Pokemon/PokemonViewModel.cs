using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.Pokemon
{
    public class PokemonViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage="Debe colocar el nombre del Pokemon")]
        public string Name { get; set; }
        [Required(ErrorMessage="Debe colocarle una descripcion al Pokemon")]
        public string Description { get; set; }
        [Required(ErrorMessage="Debe colocar el link de una imagen online para el Pokemon")]
        public string ImgUrl { get; set; }
        public int PrimaryTypeId { get; set; }
        public int SecondaryTypeId { get; set; }
        public int RegionId { get; set; }
    }
}
