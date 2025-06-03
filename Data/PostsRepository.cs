using Microsoft.EntityFrameworkCore;

namespace aspnetserver.Data
{
    internal static class PostsRepository
    {
        internal async static Task<List<Post>> GetPostsAsync()
        {
            using (var db = new AppDBContext())
            {
                return await db.Posts.ToListAsync();
            }
        }

        internal async static Task<Post> GetPostByIdAsync(int postID)
        {
            using (var db = new AppDBContext())
            {
                return await db.Posts.FirstOrDefaultAsync(post => post.PostID == postID);
            }
        }

        internal async static Task<bool> CreatePostAsync(Post toCreate)
        {
            using (var db = new AppDBContext())
            {
                try
                {
                    await db.Posts.AddAsync(toCreate);
                    return await db.SaveChangesAsync() >= 1;
                }
                catch (System.Exception)
                {
                    return false;
                }
            }
        }

        internal async static Task<bool> UpdatePostAsync(Post toUpdate)
        {
            using (var db = new AppDBContext())
            {
                try
                {
                    db.Posts.Update(toUpdate);
                    return await db.SaveChangesAsync() >= 1;
                }
                catch (System.Exception)
                {
                    return false;
                }
            }
        }

        internal async static Task<bool> DeletePostAsync(int postID)
        {
            using (var db = new AppDBContext())
            {
                try
                {
                    db.Remove(await GetPostByIdAsync(postID));
                    return await db.SaveChangesAsync() >= 1;
                }
                catch (System.Exception)
                {
                    return false;
                }
            }
        }
    }
}