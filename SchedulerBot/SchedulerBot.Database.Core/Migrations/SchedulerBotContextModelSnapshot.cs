﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace SchedulerBot.Database.Core.Migrations
{
    [DbContext(typeof(SchedulerBotContext))]
    partial class SchedulerBotContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("SchedulerBot.Database.Entities.ScheduledMessage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConversationId");

                    b.Property<string>("Cron");

                    b.Property<string>("Message");

                    b.HasKey("Id");

                    b.ToTable("ScheduledMessages");
                });
#pragma warning restore 612, 618
        }
    }
}
