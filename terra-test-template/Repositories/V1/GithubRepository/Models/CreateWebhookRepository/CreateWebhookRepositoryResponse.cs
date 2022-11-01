namespace terra_test_template.Repositories.V1.GithubServices.Models.CreateWebhookRepository
{
    public class CreateWebhookRepositoryResponse
    {
        public string type { get; set; }
        public long id { get; set; }
        public string name { get; set; }
        public bool active { get; set; }
        public List<string> events { get; set; }
        public CreateConfigResponse config { get; set; }
        public DateTime updated_at { get; set; }
        public DateTime created_at { get; set; }
        public string url { get; set; }
        public string test_url { get; set; }
        public string ping_url { get; set; }
        public string deliveries_url { get; set; }
        public CreateLastResponse last_response { get; set; }

        public class CreateConfigResponse
        {
            public string url { get; set; }
            public string insecure_ssl { get; set; }
            public string content_type { get; set; }
        }

        public class CreateLastResponse
        {
            public int? code { get; set; }
            public string status { get; set; }
            public string message { get; set; }
        }
    }
}
