using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TatBlog.Core.Contracts
{
    //Chứa kết quả phân trang
    public interface IPagedList
    {
        //Tong so trang
        int PageCount { get;  }

        //tong so phan tu tra ve tu truy van
        int TotalItemCount { get;  }

        //chi so trang hien tai( bat dau tu 0)
        int PageIndex { get; }

        //Vi tri trang hien tai bat dau tu 1
        int PageNumber { get; }

        //so luong phan tu toi da tren 1 trang
        int PageSize { get; }

        //Ktra co trang tiep theo hay khong
        bool HasNextPage { get; }

        //Ktra co trang truoc hay khong
        bool HasPreviousPage { get; }

        //Trang hien tai co phai la trang dau tien
        bool IsFirstPage { get; }
        
        //Trang hien tai co phai la trang cuoi cung
        bool IsLastPage { get; }

        //thu tu cua phan tu dau trong trang truy van() bd tu 1
        int FirstItemIndex { get; }
        
        //thu tu cua phan tu cuoi trong trang truy van() bd tu 1
        int LastItemIndex { get; }
    }


    //dem so luong phan tu trong trang
    //Lay phan tu tai vi tri index
    public interface IPagedList<out T> : IPagedList, IEnumerable<T>
    {
        T this[int index] { get; }
        int Count { get; }
    }
}
