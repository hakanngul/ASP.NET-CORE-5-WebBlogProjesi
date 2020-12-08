using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Data.Abstract
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IArticleRepository Articles { get; }  // unitofwork.Articles ile erişim sağlıyacağız
        ICategoryRepository Categories { get; } // _unitOfWork.Categories.AddAsync(); örneklendirmesi
        ICommentRepository Comments { get; }
        IRoleRepository Roles { get; }
        IUserRepository Users { get; }
        // _unitOfWork.Categories.AddAsync(category);
        // _unitOfWork.User.AddAsync(user)
        // _unitOfWork.SaveAsync() bütün durumların doğru gitmesi durumunda
        // transaction veritabanına SaveAsync ile verileri işlemektedir.
        Task<int> SaveAsync();

    }
}
