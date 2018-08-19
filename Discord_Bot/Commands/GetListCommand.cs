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
using Newtonsoft.Json;
using System.Linq;

namespace Discord_Bot.Commands
{
    public class GetListCommand
    {
        string Url = "http://www.delubear.com/api/SarahsItems";
        List<SarahsItem> Items = new List<SarahsItem>();

        [Command("GetList"), Description("Returns Sarah's Wishlist")]
        public async Task GetList(CommandContext ctx)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(Url);            

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                List<SarahsItem> items = JsonConvert.DeserializeObject<List<SarahsItem>>(json);

                Items.AddRange(items.Where(i => i.DateCompleted == null).ToList());
                Items.AddRange(items.Where(i => i.DateCompleted != null).ToList());
            }

            StringBuilder sb = new StringBuilder();
            foreach (var item in Items)
            {
                sb.Append($"```Name: {item.Name}" + Environment.NewLine +
                          $"Description: {item.Description}" + Environment.NewLine +
                          $"Type: {item.TypeOfItem}" + Environment.NewLine +
                          $"Added: {item.DateAdded} - Completed: {item.DateCompleted}" + Environment.NewLine + "```");
            }
            await ctx.RespondAsync(sb.ToString());

        }
    }
}
