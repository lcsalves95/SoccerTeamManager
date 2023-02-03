using MediatR;
using SoccerTeamManager.Application.Queries;
using SoccerTeamManager.Domain.Entities;
using SoccerTeamManager.Domain.Interfaces;
using SoccerTeamManager.Domain.Outputs;
using SoccerTeamManager.Infra.Responses;
using System.Net;

namespace SoccerTeamManager.Application.QueryHandlers
{
    internal class CountryQueryHandler : IRequestHandler<GetCountryQuery, RequestResult<CountryOutput>>
    {
        private readonly ICountryRepository _repository;

        public CountryQueryHandler(ICountryRepository repository)
        {
            _repository = repository;
        }

        public async Task<RequestResult<CountryOutput>> Handle(GetCountryQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var countries = (await _repository.Select(request.Id, request.Name)).OrderBy(x => x.Name);

                if (request.SingleData)
                {
                    var country = countries.FirstOrDefault();
                    if (country == null)
                        return new RequestResult<CountryOutput>(HttpStatusCode.NotFound, default(CountryOutput), Enumerable.Empty<ErrorModel>());
                    return new RequestResult<CountryOutput>(HttpStatusCode.OK, new CountryOutput(country.Id, country.Name), Enumerable.Empty<ErrorModel>());
                }
                var output = countries.Select(c => new CountryOutput(c.Id, c.Name));
                return new RequestResult<CountryOutput>(HttpStatusCode.OK, output, Enumerable.Empty<ErrorModel>());
            }
            catch
            {
                return new RequestResult<CountryOutput>(HttpStatusCode.InternalServerError, default(CountryOutput), Enumerable.Empty<ErrorModel>());
            }
        }
    }
}
