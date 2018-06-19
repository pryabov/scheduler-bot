﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchedulerBot.Database.Core;
using SchedulerBot.Database.Entities;
using SchedulerBot.Database.Interfaces.Repositories;

namespace SchedulerBot.Database.Repositories
{
	/// <inheritdoc cref="IScheduledMessageDetailsRepository"/>
	public class ScheduledMessageDetailsRepository : BaseRepository<ScheduledMessageDetails>, IScheduledMessageDetailsRepository
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ScheduledMessageDetailsRepository"/> class.
		/// </summary>
		/// <param name="dbContext">The database context.</param>
		public ScheduledMessageDetailsRepository(SchedulerBotContext dbContext)
			: base(dbContext)
		{
		}

		/// <inheritdoc />
		public async Task<IList<ScheduledMessageDetails>> GetScheduledMessageDetails(
			string channelId,
			string conversationId,
			bool includeServiceUrls)
		{
			var scheduledMessageDetails = DbSet.Include(details => details.DetailsServiceUrls);

			IQueryable<ScheduledMessageDetails> result =
				includeServiceUrls
					? FilterByConversation(scheduledMessageDetails.ThenInclude(detailsServiceUrl => detailsServiceUrl.ServiceUrl), channelId, conversationId)
					: FilterByConversation(scheduledMessageDetails, channelId, conversationId);

			return await result.ToListAsync();
		}

		private static IQueryable<ScheduledMessageDetails> FilterByConversation(
			IQueryable<ScheduledMessageDetails> scheduledMessageDetails,
			string channelId,
			string conversationId)
		{
			return scheduledMessageDetails
				.Where(details =>
					details.ChannelId == channelId &&
					details.ConversationId == conversationId);
		}
	}
}
