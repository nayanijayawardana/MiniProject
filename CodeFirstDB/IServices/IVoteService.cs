using CodeFirstDB.ViewModle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirstDB.IServices
{
    public interface IVoteService
    {
        IEnumerable<Vote> GetVote();

        Vote addvote(Vote vote);

        int tvote(string isbn);

        List<int> lessvote();
        

       //IEnumerable<Vote> getdownVote();
       //int getdownVote();

    }
}
