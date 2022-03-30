﻿using ASP_NET_Video_Games_API.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP_NET_Video_Games_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GamesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetPublishers()
        {
            var videoGamePublishers = _context.VideoGames.Select(vg => vg.Publisher).Distinct();

            return Ok(videoGamePublishers);
        }

        [HttpGet("{pubName}")] // this is a 'get by id' example
        public IActionResult GetGamesByPublisher(string pubName)
        {
            int? maxYear = _context.VideoGames.Select(vg => vg.Year).Max(); //added from tutorial for years between search
            int? minYear = _context.VideoGames.Select(vg => vg.Year).Min();

            var videoGames = _context.VideoGames.Where(vg => vg.Publisher == pubName);
            return Ok(videoGames);
        }

        [HttpGet("{id}")] 
        public IActionResult GetGamesById(int id)
        {
            var videoGames = _context.VideoGames.Where(vg => vg.Id == id);
            return Ok(videoGames);
        }
    }
}