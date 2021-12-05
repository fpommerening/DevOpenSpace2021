using System;
using System.Collections.Generic;
using System.Linq;
using FP.Monitoring.Metrics.Business;
using FP.Monitoring.Metrics.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FP.Monitoring.Metrics.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MeetupController : ControllerBase
    {
        private readonly ILogger<MeetupController> _logger;
        private readonly MeetupRepository _repository;

        public MeetupController(ILogger<MeetupController> logger, MeetupRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<MeetupViewModel> Get()
        {
            return _repository.GetMeetups().Select(x => new MeetupViewModel
            {
                Start = x.Start,
                End = x.End,
                Location = x.Location,
                Title = x.Title,
                Speaker = x.Speaker
            }).ToList();
        }
    }
}
