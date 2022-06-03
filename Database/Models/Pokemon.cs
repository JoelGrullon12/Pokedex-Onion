using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class Pokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }


        #region relaciones
        public int PrimaryType { get; set; }
        public int SecondaryType { get; set; }
        public int RegionId { get; set; }

        //Navigation Properties
        public PokemonType PrimTypes { get; set; }
        public PokemonType SecTypes { get; set; }
        public Region Region { get; set; }
        #endregion
    }
}
