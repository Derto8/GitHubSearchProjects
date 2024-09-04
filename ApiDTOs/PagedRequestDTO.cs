using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDTOs
{
    public class PagedRequestDTO
    {
        public PagedRequestDTO() { }

        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public PagedRequestDTO(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber < 1 ? 1 : pageNumber;
            PageSize = pageSize > 100 ? 100 : pageSize;
        }
    }
}
