namespace EncyclopediaGalactica.SourceFormats.QA.E2E.BackgroundSteps;

using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Sdk.Models.SourceFormatNode;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Utils.Guards;

[Binding]
[ExcludeFromCodeCoverage]
public partial class BackgroundSteps
{
    private const string ENDPOINT_URL = "endpoint_url";
    private const string OPERATION_URL = "operation_url";
    private const string SOURCEFORMATNODE_NAME = "sourceformatnode_name";
    private readonly ScenarioContext _scenarioContext;

    [Given(@"there is the following endpoint")]
    public void GivenThereIsTheFollowingEndpoint(Table table)
    {
        Guards.IsNotNull(table);

        GivenThereIsTheFollowingEndpointEntity? ins = table.CreateInstance<GivenThereIsTheFollowingEndpointEntity>();
        Guards.IsNotNull(ins);
        Guards.StringIsNotNullOrEmptyOrWhitespace(ins.Url);

        _scenarioContext.Add(ENDPOINT_URL, ins.Url);
    }

    [Given(@"there is the operation endpoint")]
    public void GivenThereIsTheOperationEndpoint(Table table)
    {
        Guards.IsNotNull(table);
        GivenThereIsTheOperationEndpointEntity? entity = table.CreateInstance<GivenThereIsTheOperationEndpointEntity>();

        Guards.IsNotNull(entity);
        Guards.StringIsNotNullOrEmptyOrWhitespace(entity.Url);
        _scenarioContext.Add(OPERATION_URL, entity.Url);
    }

    [Given(@"the following SourceFormatNode data")]
    public void GivenTheFollowingSourceFormatNodeData(Table table)
    {
        Guards.IsNotNull(table);

        GivenTheFollowingSourceFormatNodeDataEntity entity = table
            .CreateInstance<GivenTheFollowingSourceFormatNodeDataEntity>();

        Guards.IsNotNull(entity);
        Guards.StringIsNotNullOrEmptyOrWhitespace(entity.Name);
        _scenarioContext.Add(SOURCEFORMATNODE_NAME, entity.Name);
    }

    [When(@"SourceFormatNode is sent to endpoint")]
    public async Task WhenSourceFormatNodeIsSentToEndpoint()
    {
        SourceFormatNodeAddRequestModel addRequestModel = ProvideSourceFormatNodeAddModel(_scenarioContext);
    }

    private SourceFormatNodeAddRequestModel ProvideSourceFormatNodeAddModel(ScenarioContext scenarioContext)
    {
        string name = GetValueFromSpecflowBucket<string>(SOURCEFORMATNODE_NAME);
        SourceFormatNodeAddRequestModel requestModel = new SourceFormatNodeAddRequestModel.Builder()
            .SetName(name)
            .Build();
        return requestModel;
    }

    private TType GetValueFromSpecflowBucket<TType>(string key)
    {
        Guards.StringIsNotNullOrEmptyOrWhitespace(key);
        TType result = (TType)_scenarioContext[key];
        return result;
    }

    private class GivenTheFollowingSourceFormatNodeDataEntity
    {
        public string Name { get; set; }
    }

    private class GivenThereIsTheOperationEndpointEntity
    {
        public string Url { get; set; }
    }

    private class GivenThereIsTheFollowingEndpointEntity
    {
        public string Url { get; set; }
    }
}