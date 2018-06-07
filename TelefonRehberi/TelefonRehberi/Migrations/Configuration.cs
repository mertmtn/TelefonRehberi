namespace TelefonRehberi.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TelefonRehberi.Models.Rehber>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(TelefonRehberi.Models.Rehber context)
        {
            base.Seed(context);
        }
    }
}
