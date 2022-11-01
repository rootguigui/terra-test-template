using Refit;
using terra_test_template.Repositories.V1.GithubServices.Models.CreateRepository;
using terra_test_template.Repositories.V1.GithubServices.Models.CreateWebhookRepository;
using terra_test_template.Repositories.V1.GithubServices.Models.ListBranchesRepository;
using terra_test_template.Repositories.V1.GithubServices.Models.ListWebhookRepository;
using terra_test_template.Repositories.V1.GithubServices.Models.UpdateWebhookRepository;

namespace terra_test_template.Repositories.V1.GithubServices
{
    [Headers("User-Agent: Refit")]
    public interface IGithubRepository
    {
        [Post("/user/repos")]
        Task<CreateRepostitoryResponse> CreateRepository([Authorize("Bearer")] string token,CreateRepositoryDTO body);

        [Get("/repos/{owner}/{repo}/branches")]
        Task<List<ListBranchesRepositoryResponse>> ListBranchesRepository([AliasAs("owner")] string owner, [AliasAs("repo")] string repo, [Authorize("Bearer")] string token);

        [Get("/repos/{owner}/{repo}/hooks")]
        Task<List<ListWebhooksRepositoryResponse>> ListListWebhooksRepository([AliasAs("owner")] string owner, [AliasAs("repo")] string repo, [Authorize("Bearer")] string token);

        [Post("/repos/{owner}/{repo}/hooks")]
        Task<CreateWebhookRepositoryResponse> CreateWebhookRepository([AliasAs("owner")] string owner, [AliasAs("repo")] string repo, [Authorize("Bearer")] string token, CreateWebhookRepositoryDto body);

        [Patch("/repos/{owner}/{repo}/hooks/{id}")]
        Task<UpdateWebhookRepositoryResponse> UpdateWebhookRepository([AliasAs("owner")] string owner, [AliasAs("repo")] string repo, [AliasAs("id")] string id, [Authorize("Bearer")] string token, UpdateWebhookRepositoryDto body);
    }
}
