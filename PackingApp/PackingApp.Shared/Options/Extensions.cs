using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackingApp.Shared.Options
{
    public static class Extensions
    {
        public static TOptions GetOptions<TOptions>(this IConfiguration configuration, string section) 
            where TOptions : new()
        {
            var options = new TOptions();
            configuration.GetSection(section).Bind(options);

            return options;
        }
    }
}
