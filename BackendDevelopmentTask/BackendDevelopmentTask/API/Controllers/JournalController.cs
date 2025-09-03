using BackendDevelopmentTask.API.Constants;
using BackendDevelopmentTask.API.QueryParameters;
using BackendDevelopmentTask.BLL.Models;
using BackendDevelopmentTask.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackendDevelopmentTask.API.Controllers;

[ApiController]
public class JournalController(IExceptionJournalService exceptionJournalService) : ControllerBase
{
    [HttpPost($"{ApiRoutes.JournalGetRangeEndpoint}")]
    public async Task<PagedEntityModel<ExceptionJournalModel>> GetRangeAsync([FromQuery] PagingParameters pagingParameters, CancellationToken cancellationToken)
    {
       var exceptions = await exceptionJournalService.GetPagedAsync(pagingParameters.PageNumber, pagingParameters.PageSize, cancellationToken);
       return exceptions;
    }
    
    [HttpPost($"{ApiRoutes.JournalGetSingleEndpoint}")]
    public async Task<ExceptionJournalModel> GetSingleAsync([FromQuery] Guid id, CancellationToken cancellationToken)
    {
        var exception = await exceptionJournalService.GetByIdAsync(id, cancellationToken);
        return exception;
    }
}