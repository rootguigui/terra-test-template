namespace terra_test_template.Repositories.V1.GithubServices.Models.ListWebhookRepository
{

    public class ListWebhooksRepositoryResponse
    {
        public class ListConfigResponse
        {
            public string content_type { get; set; }
            public string insecure_ssl { get; set; }
            public string url { get; set; }
        }

        public class ListLastResponse
        {
            public int code { get; set; }
            public string status { get; set; }
            public string message { get; set; }
        }

        public string type { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public bool active { get; set; }
        public List<string> events { get; set; }
        public ListConfigResponse config { get; set; }
        public DateTime updated_at { get; set; }
        public DateTime created_at { get; set; }
        public string url { get; set; }
        public string test_url { get; set; }
        public string ping_url { get; set; }
        public string deliveries_url { get; set; }
        public ListLastResponse last_response { get; set; }
    }
}
