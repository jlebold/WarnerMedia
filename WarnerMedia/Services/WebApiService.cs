using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using WarnerMedia.Models.Dto;

namespace WarnerMedia.Services
{
    public class WebApiService : IWebApiService
    {
        public static HttpClient Client = new HttpClient();
        public WebApiService(){}

        public ICollection<TitleDto> GetBasics()
        {
            var result = Client.GetAsync("api/titles/basics").GetAwaiter().GetResult();
            var resultContentJson = result.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var resultContent = JsonConvert.DeserializeObject<ICollection<TitleDto>>(resultContentJson);
            return resultContent;
        }

        public TitleDto GetTitleDetail(int titleId)
        {
            //title only has the basics here since we are lazy loading, let's get the rest.
            var result = Client.GetAsync($"api/titles/detail/{titleId}").GetAwaiter().GetResult();
            var resultContentJson = result.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var resultContent = JsonConvert.DeserializeObject<TitleDto>(resultContentJson);
            return resultContent;
        }

        public ICollection<AwardDto> GetAwards(int titleId)
        {
            var result = Client.GetAsync($"api/titles/awards/{titleId}").GetAwaiter().GetResult();
            var resultContentJson = result.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var resultContent = JsonConvert.DeserializeObject<ICollection<AwardDto>>(resultContentJson);
            return resultContent;
        }

        public ICollection<TitleParticipantDto> GetParticipants(int titleId)
        {
            var result = Client.GetAsync($"api/titles/participants/{titleId}").GetAwaiter().GetResult();
            var resultContentJson = result.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var resultContent = JsonConvert.DeserializeObject<ICollection<TitleParticipantDto>>(resultContentJson);
            return resultContent;
        }        
        
        public ICollection<OtherNameDto> GetOtherNames(int titleId)
        {
            var result = Client.GetAsync($"api/titles/othernames/{titleId}").GetAwaiter().GetResult();
            var resultContentJson = result.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var resultContent = JsonConvert.DeserializeObject<ICollection<OtherNameDto>>(resultContentJson);
            return resultContent;
        }

        public static void SetupClient()
        {
            Client.BaseAddress = new Uri("https://localhost:44365/titles");
        }

    }
}
