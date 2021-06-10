using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeFirstDB.IServices;
using CodeFirstDB.ViewModle;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeFirstDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoteController : ControllerBase
    {
        private readonly IVoteService voteService;
        private string message;

        public VoteController(IVoteService user)
        {
            voteService = user;
        }

        [HttpGet]
        [Route("[action]")]
        [Route("api/Vote/GetVote")]
        public IEnumerable<Vote> GetVote()
        {
            return voteService.GetVote();
        }

        [HttpPost]
        [HttpPut]
        [Route("[action]")]
        [Route("api/Vote/VoteBook")]

        public Vote VoteBook(Vote vote)
        {
            return voteService.addvote(vote);
        }
    }
}
