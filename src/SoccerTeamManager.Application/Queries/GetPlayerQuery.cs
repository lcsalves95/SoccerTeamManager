﻿using SoccerTeamManager.Domain.Entities;
using SoccerTeamManager.Infra.Messages;
using SoccerTeamManager.Infra.Responses;

namespace SoccerTeamManager.Application.Queries
{
    public class GetPlayerQuery : IQuery<RequestResult<Player>>
    {
        public Guid PlayerId { get; private set; }

        public GetPlayerQuery(Guid playerId)
        {
            PlayerId = playerId;
        }
    }
}
