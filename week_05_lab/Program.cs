using System;
using System.Threading;

namespace week_05_lab
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();

            try
            {
                stopwatch.Start();
                // test.Start();
                Thread.Sleep(1000);
                stopwatch.Stop();

                stopwatch.Start();
                Thread.Sleep(2000);
                stopwatch.Stop();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Post post = new Post("test", "testing");
            Post.Upvote(ref post);
            Post.Upvote(ref post);
            Post.Upvote(ref post);
            Post.Downvote(ref post);
            // post.Vote = 100;
            Console.WriteLine($"\n\t{post.Created}, {post.Title}, { post.Description }, {post.Vote}");

            Console.ReadKey();
        }
    }
}
