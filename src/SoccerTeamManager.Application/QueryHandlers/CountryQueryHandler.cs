using MediatR;
using SoccerTeamManager.Application.Queries;
using SoccerTeamManager.Domain.Entities;
using SoccerTeamManager.Domain.Interfaces;
using SoccerTeamManager.Infra.Responses;
using System.Net;

namespace SoccerTeamManager.Application.QueryHandlers
{
    internal class CountryQueryHandler : IRequestHandler<GetCountryQuery, RequestResult<Country>>
    {
        private readonly ICountryRepository _repository;

        public CountryQueryHandler(ICountryRepository repository)
        {
            _repository = repository;
        }

        public async Task<RequestResult<Country>> Handle(GetCountryQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var countries = await _repository.Select(request.Id, request.Name);
                if (!countries.Any())
                    return new RequestResult<Country>(HttpStatusCode.NotFound, new Country(), Enumerable.Empty<ErrorModel>());

                if (request.SingleData)
                {
                    var country = countries.FirstOrDefault();
                    return new RequestResult<Country>(HttpStatusCode.Created, country, Enumerable.Empty<ErrorModel>());
                }

                return new RequestResult<Country>(HttpStatusCode.Created, countries, Enumerable.Empty<ErrorModel>());
            }
            catch
            {
                return new RequestResult<Country>(HttpStatusCode.InternalServerError, new Country(), Enumerable.Empty<ErrorModel>());
            }
        }
    }
}
