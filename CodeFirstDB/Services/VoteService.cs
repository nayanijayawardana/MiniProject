using CodeFirstDB.DataLayer;
using CodeFirstDB.IServices;
using CodeFirstDB.ViewModle;
using Microsoft.EntityFrameworkCore;
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

        //public Vote VoteBook(Vote vote)
        //{
        //    dbcontext.Entry(vote).State = EntityState.Modified;
        //    dbcontext.SaveChanges();
        //    return vote;
        //}
        public IEnumerable<Vote> GetVote()
        {
            var vote = dbcontext.Votes.ToList();
            return vote;
        }

        public Vote addvote(Vote vote)
        {
            if (vote != null)
            {
                dbcontext.Votes.Add(vote);
                dbcontext.SaveChanges();
                return vote;
            }
            return null;
        }

    }
}
