namespace EncyclopediaGalactica.SourceFormats.SourceFormatsService.SourceFormatNodeService;

using Dtos;
using Interfaces;
using Interfaces.SourceFormatNode;

public partial class SourceFormatNodeService
{
    /// <inheritdoc />
    public async Task<SourceFormatNodeSingleResultResponseModel> DeleteAsync(
        SourceFormatNodeDto dto,
        CancellationToken cancellationToken = default)
    {
        try
        {
            _guards.NotNull(dto);
            _guards.IsNotEqual(dto.Id, 0);

            await _sourceFormatNodeRepository.DeleteAsync(dto.Id, cancellationToken).ConfigureAwait(false);

            SourceFormatNodeSingleResultResponseModel responseModel = PrepareSuccessResponseModelForDelete();
            return responseModel;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private SourceFormatNodeSingleResultResponseModel PrepareSuccessResponseModelForDelete()
    {
        SourceFormatNodeSingleResultResponseModel responseModel = new SourceFormatNodeSingleResultResponseModel
        {
            Result = null,
            Status = SourceFormatsServiceResultStatuses.Success,
            IsOperationSuccessful = true
        };

        return responseModel;
    }
}