using System;

namespace week_05_lab
{
    class Post
    {
        private string title;
        private string description;
        public DateTime Created { get; private set; } = DateTime.Now;
        public int Vote { get; private set; } = 0;

        public Post()
        {
            this.Title = "Default";
            this.Description = "Default";
        }

        public Post(string title, string description)
        {
            this.Title = title;
            this.Description = description;
        }

        public string Title
        {
            get
            {
                return this.title;
            }
            set
            {
                this.title = value.Trim().Length > 0 ? value : this.title ?? "Default";
            }
        }

        public string Description
        {
            get
            {
                return this.description;
            }
            set
            {
                this.description = value.Trim().Length > 0 ? value : this.description ?? "Default";
            }
        }

        public static void Upvote(ref Post arg)
        {
            arg.Vote++;
        }

        public static void Downvote(ref Post arg)
        {
            arg.Vote--;
        }
    }
}
