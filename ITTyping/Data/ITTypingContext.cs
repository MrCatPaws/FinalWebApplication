using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ITTyping.Models;

namespace ITTyping.Data
{
    public class ITTypingContext : DbContext
    {
        public ITTypingContext (DbContextOptions<ITTypingContext> options)
            : base(options)
        {
        }

        public DbSet<ITTyping.Models.Typist> Typist { get; set; } = default!;
    }
}
