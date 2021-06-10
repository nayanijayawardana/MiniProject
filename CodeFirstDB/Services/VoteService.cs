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

        
        public IEnumerable<Vote> GetVote()
        {
            var vote = dbcontext.Votes.ToList();
            return vote;
        }

        public Vote addvote(Vote vote)
        {

            //var validvote = dbcontext.Votes.Any(y => y.UserId == vote.UserId && y.BookId == vote.BookId);
            //if (validvote == true)
            //{
            //    dbcontext.Votes.Entry(Vote);
            //    dbcontext.ObjectStateManager.ChangeObjectState(Vote, EntityState.Modified);
            //}
            //else
            //{
            //    dbcontext.Votes.Add(Vote);
            //}

            //dbcontext.SaveChanges();


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

    }
}
