namespace terra_test_template.Repositories.V1.GithubServices.Models.CreateRepository
{
    public class CreateRepositoryDTO
    {
        public string name { get; set; }
        public string description { get; set; }
        public string homepage { get; set; }
        public bool has_issues { get; set; }
        public bool has_projects { get; set; }
        public bool has_wiki { get; set; }
    }
}
