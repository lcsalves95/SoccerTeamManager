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
                var countries = (await _repository.Select(request.Id, request.Name)).OrderBy(x => x.Name);

                if (request.SingleData)
                {
                    var country = countries.FirstOrDefault();
                    if (country == null)
                        return new RequestResult<Country>(HttpStatusCode.NotFound, new Country(), Enumerable.Empty<ErrorModel>());
                    return new RequestResult<Country>(HttpStatusCode.OK, country, Enumerable.Empty<ErrorModel>());
                }

                return new RequestResult<Country>(HttpStatusCode.OK, countries, Enumerable.Empty<ErrorModel>());
            }
            catch
            {
                return new RequestResult<Country>(HttpStatusCode.InternalServerError, new Country(), Enumerable.Empty<ErrorModel>());
            }
        }
    }
}
