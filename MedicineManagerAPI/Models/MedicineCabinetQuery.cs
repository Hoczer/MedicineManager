using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicineManagerAPI.Models
{
    public class MedicineCabinetQuery
    {
        public string SearchPhrase { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string SortBy { get; set; }
        public SortDirection SortDirection { get; set; }
    }
}
