namespace EncyclopediaGalactica.SourceFormats.Sdk.SourceFormatNode;

using Api;
using Dtos;
using Exceptions;
using Models.SourceFormatNode;

public partial class SourceFormatNodeSdk
{
    public async Task<SourceFormatNodeAddResponseModel> AddAsync(
        SourceFormatNodeAddRequestModel addRequestModel,
        CancellationToken cancellationToken = default)
    {
        try
        {
            if (addRequestModel is null)
                throw new ArgumentNullException(nameof(addRequestModel));
            if (addRequestModel.Payload is null)
                throw new ArgumentNullException(nameof(addRequestModel.Payload));

            const string url = SourceFormatNode.Route + SourceFormatNode.Add;
            HttpRequestMessage message = _sdkCore.PreparePost(addRequestModel.Payload, url);

            SourceFormatNodeAddResponseModel response = (SourceFormatNodeAddResponseModel)await _sdkCore
                .SendAsync<SourceFormatNodeAddResponseModel, SourceFormatNodeDto>(
                    message,
                    cancellationToken)
                .ConfigureAwait(false);
            return response;
        }
        catch (Exception e)
        {
            string msg = $"Error happened while executing {nameof(SourceFormatNodeSdk)}.{nameof(AddAsync)}. " +
                         "For further information see inner exception.";
            throw new SdkException(msg, e);
        }
    }
}