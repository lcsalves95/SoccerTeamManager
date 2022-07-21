﻿using SoccerTeamManager.Domain.Entities;
using SoccerTeamManager.Infra.Messages;
using SoccerTeamManager.Infra.Responses;

namespace SoccerTeamManager.Application.Queries
{
    public class GetPlayerQuery : IQuery<RequestResult<Player>>
    {
        public Guid? Id { get; private set; }
        public string? Name { get; private set; }
        public long? CbfCode { get; private set; }

        public GetPlayerQuery(Guid? id = null, string? name = null, long? cbfCode = null)
        {
            Id = id;
            Name = name;
            CbfCode = cbfCode;
        }
    }
}
