using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnualLists.Model
{
    public class WineModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Year { get; set; }
        public string Name { get; set; }
        public string Variety { get; set; }
        public string Vineyard { get; set; }
        public string ProductionSize { get; set; }
    }
}
