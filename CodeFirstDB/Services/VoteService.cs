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
        //public Vote tvote(string isbn)
        //public IEnumerable<Vote> tvote(string isbn)

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

            //var totalupvote = count.Count();
            //int total = dbcontext.Votes.Count(count);
            //var totalAge = (from s in dbcontext.Votes
            //                select s.Value).Count();
            //return totalupvote == null ? 0 : totalupvote.Value;
        }

    }
}

