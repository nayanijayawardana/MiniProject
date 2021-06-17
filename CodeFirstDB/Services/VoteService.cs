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


        //for get alldownvote less than 0
        //public IEnumerable<Vote> getdownVote()
        //{

        //    var upvote = (from a in dbcontext.Votes
        //                  where a.Value == 1
        //                  select a.Value).Count();
        //    var downvote = (from a in dbcontext.Votes
        //                    where a.Value == -1
        //                    select a.Value).Count();

        //    if ( downvote > upvote)
        //    {
        //        var downlist =Convert.(from a in dbcontext.Votes
        //                       where a.Value == -1
        //                       select a.BookId).ToList();

        //        return (IEnumerable<Vote>) downlist;

        //    }

        //    return null;
        //}


        public List<DownvotedBooks> lessvote()
        {
            var obj = dbcontext.Votes.GroupBy(x => new
            {
                x.BookId,
            }).Select(grp => new
            {
                BookId = grp.Key.BookId,
                BookName = grp.Select(y => y.Book).First().Description,
                DownvotedUsers = grp.Select(y => y.User.UserName).ToArray(),
                TotalVoteVal = grp.Sum(y => y.Value)
            })
            .Where(r => r.TotalVoteVal < 0)
            .AsEnumerable()
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
            public string[] DownvotedUsers { get; set; }
            public int TotalVoteVal { get; set; }
        }


        //public List<Vote> userlist()
        //{
        //    var ulist = (from p in dbcontext.Votes
        //               where p.Value == -1
        //               select new
        //               {
        //                   ulist = p.UserId,
        //                   blist = p.BookId
        //               }).ToList();
            
        //    return List<int> ulist;
        //}

        public List<Vote> Getuserlist()
        {
            var results = dbcontext.Votes
                .Where(x => x.Value == -1)
                .Select(x => new Vote()
            {
                UserId = x.UserId,
                BookId= x.BookId,
                
            })
            .ToList();

            return results;
        }


    }
}

