using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TatBlog.Data.Seeders
{
    //bắt buộc các lớp kế thừa từ Iterface này phải tạo ra lớp khởi tạo
    public interface IDataSeeder
    {
        void Initialize();
    }
}
