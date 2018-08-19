using Discord_Bot.Models;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace Discord_Bot.Commands
{
    public class GetListCommand
    {
        string Url = "http://www.delubear.com/Home/SList";
        List<SarahsItem> Items { get; set; }

        [Command("GetList"), Description("Returns Sarah's Wishlist")]
        public async Task GetList(CommandContext ctx)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(Url);
            string test = "replace me";
            if (response.IsSuccessStatusCode)
            {
                
                test = await response.Content.ReadAsStringAsync();
            }
            await ctx.RespondAsync(test);
        }
    }
}
