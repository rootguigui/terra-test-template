namespace terra_test_template.Repositories.V1.GithubServices.Models.ListBranchesRepository
{
    public class ListBranchesRepositoryResponse
    {
        public string name { get; set; }
        public BranchesCommitResponse commit { get; set; }
        public bool @protected { get; set; }
    }

    public class BranchesCommitResponse
    {
        public string sha { get; set; }
        public string url { get; set; }
    }
}
