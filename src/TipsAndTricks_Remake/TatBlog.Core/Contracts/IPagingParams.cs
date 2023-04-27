using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TatBlog.Core.Contracts
{
    //Chứa thông tin cần thiết cho việc phân trang
    public interface IPagingParams
    {
        //số post trên 1 trang
        int PageSize { get; set; }

        //Số trang bắt đầu từ 1
        int PageNumber { get; set; }

        //Cột muốn sắp xếp
        string SortColumn { get; set; }

        //Chọn Sắp xếp tăng hay giảm
        string SortOrder { get; set; }
    }
}
