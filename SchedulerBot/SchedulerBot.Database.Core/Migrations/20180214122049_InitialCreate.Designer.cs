﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace SchedulerBot.Database.Core.Migrations
{
	[DbContext(typeof(SchedulerBotContext))]
	[Migration("20180214122049_InitialCreate")]
	partial class InitialCreate
	{
		protected override void BuildTargetModel(ModelBuilder modelBuilder)
		{
#pragma warning disable 612, 618
			modelBuilder
				.HasAnnotation("ProductVersion", "2.0.1-rtm-125");

			modelBuilder.Entity("SchedulerBot.Database.Entities.ScheduledMessage", b =>
				{
					b.Property<Guid>("Id")
						.ValueGeneratedOnAdd();

					b.Property<string>("Schedule")
						.IsRequired();

					b.Property<string>("Text")
						.IsRequired();

					b.HasKey("Id");

					b.ToTable("ScheduledMessages");
				});

			modelBuilder.Entity("SchedulerBot.Database.Entities.ScheduledMessageDetails", b =>
				{
					b.Property<Guid>("ScheduledMessageId");

					b.Property<string>("ChannelId")
						.IsRequired();

					b.Property<string>("ConversationId")
						.IsRequired();

					b.Property<string>("FromId")
						.IsRequired();

					b.Property<string>("FromName")
						.IsRequired();

					b.Property<string>("Locale")
						.IsRequired();

					b.Property<string>("RecipientId")
						.IsRequired();

					b.Property<string>("RecipientName")
						.IsRequired();

					b.Property<string>("ServiceUrl");

					b.HasKey("ScheduledMessageId");

					b.ToTable("ScheduledMessageDetails");
				});

			modelBuilder.Entity("SchedulerBot.Database.Entities.ScheduledMessageEvent", b =>
				{
					b.Property<Guid>("Id")
						.ValueGeneratedOnAdd();

					b.Property<DateTime>("CreatedOn");

					b.Property<DateTime>("NextOccurence");

					b.Property<Guid>("ScheduledMessageId");

					b.Property<int>("State");

					b.HasKey("Id");

					b.HasIndex("ScheduledMessageId");

					b.ToTable("ScheduledMessageEvents");
				});

			modelBuilder.Entity("SchedulerBot.Database.Entities.ScheduledMessageDetails", b =>
				{
					b.HasOne("SchedulerBot.Database.Entities.ScheduledMessage", "ScheduledMessage")
						.WithOne("Details")
						.HasForeignKey("SchedulerBot.Database.Entities.ScheduledMessageDetails", "ScheduledMessageId")
						.OnDelete(DeleteBehavior.Cascade);
				});

			modelBuilder.Entity("SchedulerBot.Database.Entities.ScheduledMessageEvent", b =>
				{
					b.HasOne("SchedulerBot.Database.Entities.ScheduledMessage", "ScheduledMessage")
						.WithMany("Events")
						.HasForeignKey("ScheduledMessageId")
						.OnDelete(DeleteBehavior.Cascade);
				});
#pragma warning restore 612, 618
		}
	}
}
