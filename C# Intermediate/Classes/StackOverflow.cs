using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StackPost
{
    public class Post
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PostDate { get; set; }
        public int VoteCount { get; set; }

        private bool _voteUp;
        private bool _voteDown;
        
        public Post(string title, string description)
        {
            Title = title;
            Description = description;
            PostDate = DateTime.Now;
            VoteCount = 0;
        }
        public void VoteUp()
        {
            if (_voteUp)
                Console.WriteLine("You have already vote up");
            else
            {
                VoteCount += 1;
                Console.WriteLine("Vote ({0})", VoteCount);
                _voteUp = true;
                _voteDown = false;
            }
        }
        public void VoteDown()
        {
            if (_voteDown)
                Console.WriteLine("You have already vote down");
            else
            {
                VoteCount -= 1;
                Console.WriteLine("Vote ({0})",VoteCount);
                _voteUp = false;
                _voteDown = true;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var post = new Post("MyNewPost", "DescriptionAboutPost");
            int ch;
            do
            {
                Console.WriteLine("Enter your Choice:\n1.VoteUp\n2.VoteDown\n3.Exit");
                ch = Convert.ToInt32(Console.ReadLine());
                switch (ch)
                {
                    case 1:
                        post.VoteUp();
                        break;
                    case 2:
                        post.VoteDown();
                        break;
                    default:
                        break;
                }
                if (ch == 3)
                    break;
            } while (true);
        }
    }
}
