using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountSolution.FromAccountClassLibrary.Entities
{
    public class PriceGroup
    {
        public PriceGroup() { }

        public PriceGroup(string groupID, string groupName, string parentID, string parentName, bool internet, string path, string pict)
        {
            this.GroupID = groupID;
            this.GroupName = groupName;
            this.ParentID = parentID;
            this.ParentName = parentName;
            this.Internet = internet;
            this.Path = path;
            this.Pict = pict;
        }

        [StringLength(5)]
        [Display(Name = "Группа")]
        public string GroupID { get; set; } 
        public string GroupName { get; set; }
        [StringLength(5)]
        public string ParentID { get; set; }
        public string ParentName { get; set; }
        public bool Internet { get; set; }
        [Display(Name = "Путь хранения")]
        public string Path { get; set; }
        [Display(Name = "Рисунок")]
        public string Pict { get; set; }
    }
}
