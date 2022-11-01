namespace terra_test_template.Repositories.V1.GithubServices.Models.UpdateWebhookRepository
{
    public class UpdateWebhookRepositoryDto
    {
        public bool active { get; set; }
        public List<string> events { get; set; }
        public ConfigUpdate config { get; set; }

        public class ConfigUpdate
        {
            public string url { get; set; }
            public string insecure_ssl { get; set; }
            public string content_type { get; set; }
        }
    }
}
