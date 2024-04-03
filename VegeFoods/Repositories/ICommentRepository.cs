using BusinessObjects;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface ICommentRepository
    {
        List<Comment> GetComments();
        void SaveComment(Comment c);
        void UpdaterComment(Comment c);
        Comment GetCommentById(int cid);
        void DeleteComment(Comment c);
        List<Comment> GetCommentByUserId(int uid);

    }
}
