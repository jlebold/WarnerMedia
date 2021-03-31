using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using WarnerMedia.Models;
using WarnerMedia.Models.Dto;
using WarnerMedia.Services;

namespace WarnerMedia.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private IWebApiService client;

        public HomeController(ILogger<HomeController> logger, IWebApiService client)
        {
            this.logger = logger;
            this.client = client;
        }

        [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]
        public IActionResult Index()
        {
            ICollection<TitleDto> resultContent = null;
            try
            {
                resultContent = client.GetBasics();
            }
            catch (HttpRequestException ex)
            {
                logger.LogError(ex.Message);
            }
            return View(resultContent);
        }

        public IActionResult TitleDetail(int titleId)
        {
            TitleDto resultContent = null;
            try
            {
                resultContent = client.GetTitleDetail(titleId);
            }
            catch (HttpRequestException ex)
            {
                logger.LogError(ex.Message);
            }

            return View(resultContent);
        }

        public IActionResult Awards(int titleId)
        {
            ICollection<AwardDto> resultContent = null;
            try
            {
                resultContent = client.GetAwards(titleId);
            }
            catch (HttpRequestException ex)
            {
                logger.LogError(ex.Message);
            }
            return View(resultContent);
        }

        public IActionResult Participants(int titleId)
        {
            ICollection<TitleParticipantDto> resultContent = null;
            try
            {
                resultContent = client.GetParticipants(titleId);
            }
            catch (HttpRequestException ex)
            {
                logger.LogError(ex.Message);
            }
            return View(resultContent);
        }        
        
        public IActionResult OtherNames(int titleId)
        {
            ICollection<OtherNameDto> resultContent = null;
            try
            {
                resultContent = client.GetOtherNames(titleId);
            }
            catch (HttpRequestException ex)
            {
                logger.LogError(ex.Message);
            }
            return View(resultContent);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
