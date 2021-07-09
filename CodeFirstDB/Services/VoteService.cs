using CodeFirstDB.DataLayer;
using CodeFirstDB.IServices;
using CodeFirstDB.ViewModle;
using Microsoft.EntityFrameworkCore;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CodeFirstDB.Services
{
    public class VoteService : IVoteService
    {

        VotingDbContext dbcontext;

        public VoteService(VotingDbContext _db)
        {
            dbcontext = _db;
        }

        //for get API
        public IEnumerable<Vote> GetVote()
        {
            var vote = dbcontext.Votes.ToList();
            return vote;
        }

        //for add vote API
        public Vote addvote(Vote vote)
        {
            var validvote = dbcontext.Votes.FirstOrDefault(y => y.UserId == vote.UserId && y.BookId == vote.BookId);
            if (validvote != null)
            {
                validvote.Value = vote.Value;
                //dbcontext.Entry(vote).State = EntityState.Modified;
                dbcontext.SaveChanges();
                return vote;
            }
            else 
            {
                dbcontext.Votes.Add(vote);
                dbcontext.SaveChanges();
                return vote;
            }
            return null;
        }

        //for get total vote by isbn API
        public int tvote(string isbn)
        {
            var count = from b in dbcontext.Books
                        join v in dbcontext.Votes
                        on b.BookId equals v.BookId
                        where v.Value == 1 && b.ISBN == isbn
                        select new
                        {
                            tv = v.Value,
                        };
            var totalupvote = count.Count();
            return totalupvote;
        }

        //list of books where the total vote < 0 with Users
        public List<DownvotedBooks> lessvote()
        {
            var obj = dbcontext.Votes.Include(x => x.Book).Include(x => x.User).ToList()
                .GroupBy(x => new
                {
                    x.BookId,
                }).Select(grp => new
                {
                    BookId = grp.Key.BookId,
                    BookName = grp.Select(y => y.Book)?.FirstOrDefault()?.Description,
                    DownvotedUsers = grp.Select(y => y.User?.UserName)?.ToList(),
                    TotalVoteVal = grp.Sum(y => y.Value)
                })
                .Where(r => r.TotalVoteVal < 0)
                .Select(z => new DownvotedBooks
                {
                    BookId = z.BookId,
                    BookName = z.BookName,
                    DownvotedUsers = z.DownvotedUsers
                }).ToList();

            return obj;
        }

        public class DownvotedBooks
        {
            public int BookId { get; set; }
            public string BookName { get; set; }
            public List<string> DownvotedUsers { get; set; }
        }


        //get the list of users and their upvoted
        public List<UpvotedUserList> Getuserlist(string name)
        {
            var results = dbcontext.Votes.Include(x => x.Book).Include(x => x.User).ToList()
                          .Where(c => c.Value == 1 && c.User.UserName.Contains(name))
                          .Select(gr => new UpvotedUserList
                          {
                              UserNames = gr.User.UserName,
                              Description = gr.Book.Description
                          })
                          
                          .ToList();
            return results;
        }

        public class UpvotedUserList
        {
            public string Description { get; set; }
            public string UserNames { get; set; }
        }


    }
}

