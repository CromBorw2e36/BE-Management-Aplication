using quan_li_app.Models.SystemDB;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QUANLI.Models.CustomModel
{
    public class Sys_Menu_Tree_View_MODEL :SysMenu
    {
        
        public List<Sys_Menu_Tree_View_MODEL> ?items { get; set; }
        public bool? expanded {  get; set; }
        public bool? selected { get; set; }
        public string? account { get; set; }

        public Sys_Menu_Tree_View_MODEL() { }

    }
}
