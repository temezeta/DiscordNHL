using Common.Models;
using Common.Services;
using Discord;

namespace NHLStats.Extensions
{
    public static class NHLEmbedBuilderExtensions
    {

        public static EmbedBuilder AddGeneralFields(this EmbedBuilder builder)
        {
            builder
                .WithThumbnailUrl(StaticDiscordDataService.BotAvatarUrl)
                .WithColor(new Color(164, 169, 173))
                .WithFooter("Data provided by NHL API", StaticDiscordDataService.BotAvatarUrl);

            return builder;
        }

        public static EmbedBuilder AddNHLDataFields(this EmbedBuilder builder, EmbedData embedData) {

            builder
                .WithTitle(embedData.Title)
                .WithDescription(embedData.Description);

            foreach(var data in embedData.Data)
            {
                builder.AddFieldIfNotNull($"{data.Name}:", data.Value, data.Inline);
            }

            builder.WithUrl(embedData.Url);
            builder.WithCurrentTimestamp();
            

            return builder;
        }

        public static EmbedBuilder AddFieldIfNotNull(this EmbedBuilder builder, string name, object value, bool inline = false)
        {
            if (name != null && value != null) {
                builder.AddField(name, value, inline);
            }

            return builder;
        }
    }
}
