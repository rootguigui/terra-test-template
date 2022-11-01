namespace terra_test_template.Repositories.V1.GithubServices.Models.CreateWebhookRepository
{
    public class CreateWebhookRepositoryDto
    {
        public string name { get; set; }
        public bool active { get; set; }
        public List<string> events { get; set; }
        public Config config { get; set; }
        public class Config
        {
            public string url { get; set; }
            public string insecure_ssl { get; set; }
            public string content_type { get; set; }
        }

        public class LastResponse
        {
            public int code { get; set; }
            public string status { get; set; }
            public string message { get; set; }
        }
    }

}
