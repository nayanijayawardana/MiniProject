using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeFirstDB.IServices;
using CodeFirstDB.ViewModle;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static CodeFirstDB.Services.VoteService;

namespace CodeFirstDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoteController : ControllerBase
    {
        private readonly IVoteService voteService;
        private string message;

        public VoteController(IVoteService vote)
        {
            voteService = vote;
        }
        [Authorize]
        [HttpGet]
        [Route("[action]")]
        [Route("api/Vote/getvote")]
        public IEnumerable<Vote> GetVote()
        {
            return voteService.GetVote();
        }

        [HttpPost]
        //[HttpPut]
        [Route("[action]")]
        [Route("api/Vote/VoteBook")]

        public Vote VoteBook(Vote vote)
        {
            return voteService.addvote(vote);
        }

        [Authorize]
        [HttpGet]
        [Route("[action]")]
        [Route("api/Vote/tvote")]

        public int tvote(string isbn)
        {
            return voteService.tvote(isbn);
        }

        //[HttpGet]
        //[Route("[action]")]
        //[Route("api/Vote/getdownvote")]

        //public IEnumerable<Vote> getdownvote()
        //{
        //    return voteService.getdownVote();
        //}

        [HttpGet]
        [Route("[action]")]
        [Route("api/Vote/lessvote")]

        public List<DownvotedBooks> lessvote()
        {
            return voteService.lessvote();
        }

        [HttpGet]
        [Route("[action]")]
        [Route("api/Vote/Getuserlist")]

        public List<UpvotedUserList> Getuserlist(string name)
        {
            return voteService.Getuserlist(name);
        }
    }
}
