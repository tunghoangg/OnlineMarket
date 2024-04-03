using BusinessObjects;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class CommentRepository : ICommentRepository
    {
        public void DeleteComment(Comment c)
        {
            CommentDAO.DeleteComment(c);
        }

        public Comment GetCommentById(int cid)
        {
            return CommentDAO.GetCommentById(cid);
        }

        public List<Comment> GetCommentByUserId(int uid)
        {
           return CommentDAO.GetCommentByUserId(uid);
        }

        public List<Comment> GetComments()
        {
            return CommentDAO.GetComments();
        }

        public void SaveComment(Comment c)
        {
            CommentDAO.SaveComment(c);
        }
    

        public void UpdaterComment(Comment c)
        {
            CommentDAO.UpdateComment(c);
        }
    }
}
