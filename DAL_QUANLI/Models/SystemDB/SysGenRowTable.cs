using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QUANLI.Models.SystemDB
{
    public class SysGenRowTable
    {
        public string? id {  get; set; }
        public string? table_name {  get; set; }
        public string? dataField {  get; set; }
        public string? caption {  get; set; }
        public string? caption_VN {  get; set; }
        public string? name {  get; set; }
        public string? dataType {  get; set; }
        public string? format {  get; set; }
        public decimal? width {  get; set; }
        public bool? visible {  get; set; }
        public decimal? minWidth {  get; set; }
        public string? alignment {  get; set; }
        public bool? allowEditing {  get; set; }
        public bool? allowFiltering {  get; set; }
        public bool? allowFixing {  get; set; }
        public bool? allowGrouping {  get; set; }
        public bool? allowHeaderFiltering {  get; set; }
        public bool? allowHiding {  get; set; }
        public bool? allowSearch {  get; set; }
        public bool? allowSorting {  get; set; }
        public bool? autoExpandGroup {  get; set; }
        [NotMapped]
        public List<SysGenRowTable>? columns {  get; set; } // Column Child
        public string? column_child {  get; set; }
        public string? cssClass {  get; set; }
        public DateTime? create_date { get; set; }
        public DateTime? update_date { get; set; }
        public string? companyCode { get; set; }
        public int? orderNo { get; set; }
    }
}
