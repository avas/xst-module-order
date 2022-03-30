using VirtoCommerce.ExperienceApiModule.XOrder;
using VirtoCommerce.ExperienceApiModule.XOrder.Queries;
using VirtoCommerce.OrdersModule.Core.Search.Indexed;
using VirtoCommerce.SearchModule.Core.Services;

namespace Training.OrdersModule.Xapi.Queries
{
    public class TrainingSearchOrderQueryHandler : SearchOrderQueryHandler
    {
        private readonly ICustomerOrderAggregateRepository _customerOrderAggregateRepository;
        private readonly ISearchPhraseParser _searchPhraseParser;
        private readonly IIndexedCustomerOrderSearchService _customerOrderSearchService;

        public TrainingSearchOrderQueryHandler(ISearchPhraseParser searchPhraseParser, ICustomerOrderAggregateRepository customerOrderAggregateRepository, IIndexedCustomerOrderSearchService customerOrderSearchService)
            : base(searchPhraseParser, customerOrderAggregateRepository, customerOrderSearchService)
        {
            _searchPhraseParser = searchPhraseParser;
            _customerOrderAggregateRepository = customerOrderAggregateRepository;
            _customerOrderSearchService = customerOrderSearchService;
        }

        public override async Task<SearchOrderResponse> Handle(SearchOrderQuery request, CancellationToken cancellationToken)
        {
            // TODO: code of this method is mostly copied from SearchOrderQueryHandler.Handle() - is there any other way to fill yet another field in search criteria without copying the code?..

            var searchCriteria = new CustomerOrderSearchCriteriaBuilder(_searchPhraseParser)
                .ParseFilters(request.Filter)
                .WithCustomerId(request.CustomerId)
                .WithPaging(request.Skip, request.Take)
                .WithSorting(request.Sort)
                .Build();

            var searchResult = await _customerOrderSearchService.SearchCustomerOrdersAsync(searchCriteria);
            var aggregates = await _customerOrderAggregateRepository.GetAggregatesFromOrdersAsync(searchResult.Results, request.CultureName);

            return new SearchOrderResponse { TotalCount = searchResult.TotalCount, Results = aggregates };
        }
    }
}
