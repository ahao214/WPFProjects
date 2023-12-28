using MyToDo.Api.Service;
using RestSharp;


namespace MyToDo.Services
{
  public  class HttpRestClient
    {
        private readonly string apiUrl;
        protected readonly RestClient client;

        public HttpRestClient( string apiUrl)
        {
            this.apiUrl = apiUrl;
            client = new RestClient();
        }

        public async Task<ApiResponse> ExecuteAsync(BaseRequest request)
        {

        }

    }
}
