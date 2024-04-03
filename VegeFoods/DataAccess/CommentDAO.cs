using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CommentDAO
    {
        public static List<Comment> GetComments()
        {
            var listComments = new List<Comment>();
            try
            {
                using (var context = new VegeFoodDBContext())
                {
                    listComments = context.Comments.Include(c => c.User).Include(c=>c.Product).ThenInclude(c=>c.Category).ToList();

                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return listComments;
        }
        public static void SaveComment(Comment c)
        {
            try
            {
                using (var context = new VegeFoodDBContext())
                {
                    context.Comments.Add(c);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static void UpdateComment(Comment c)
        {
            try
            {
                using (var context = new VegeFoodDBContext())
                {
                    context.Entry<Comment>(c).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static Comment GetCommentById(int cid)
        {
            Comment c = new Comment();
            try
            {
                using (var context = new VegeFoodDBContext())
                {
                    c = context.Comments.SingleOrDefault(x => x.CommentId == cid);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return c;
        }
        public static void DeleteComment(Comment c)
        {
            try
            {
                using (var context = new VegeFoodDBContext())
                {
                    var c1 = context.Comments.SingleOrDefault(
                        p => p.CommentId == c.CommentId);
                    context.Comments.Remove(c1);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static List<Comment> GetCommentByUserId(int uid)
        {
            List<Comment> c = new List<Comment>();
            try
            {
                using (var context = new VegeFoodDBContext())
                {
                    c = context.Comments.Include(c => c.User).Include(p=>p.Product).Include(p => p.Product.Category).Where(x => x.AccountId == uid).ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return c;
        }
    }
}
