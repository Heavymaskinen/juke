using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using JukeApiModel;

namespace CliClient
{
    public class ApiClient
    {
        private string url;
        private HttpClient client;

        public ApiClient(string url)
        {
            this.url = url;
            client = new HttpClient();
            SetupHeaders();
        }

        public LoginToken Login(string userName, string password){
            return ProcessLogin(userName, password).Result;
        }

        public List<Song> GetSongList(LoginToken token) {
            return ProcessSongList(token).Result;
        }

        public List<User> GetUsers() {
            return ProcessGetUsers().Result;
        }

        public string Logout(LoginToken token) {
            ProcessLogout(url + "login/" + token.Id);
            return "Logged out.";
        }

        private async Task<string> ProcessValidate(LoginToken token) {
            return await client.GetStringAsync(url + "login/" + token.Id);
        }

        private async Task<List<User>> ProcessGetUsers()
        {
            var task = CreateStreamTask(url + "login/users");
            return await GetObject(task, typeof(List<User>)) as List<User>;
        }

        private async Task<LoginToken> ProcessLogin(string userName, string password)
        {
            var task = CreateStreamTask(url + "login?userName=" + userName+"&password="+password);
            return await GetObject(task, typeof(LoginToken)) as LoginToken;
        }

        private async Task<List<Song>> ProcessSongList(LoginToken token)
        {
            var task = CreateStreamTask(url + "library/?id=" + token.Id);
            return await GetObject(task, typeof(List<Song>)) as List<Song>;
        }

        private async void ProcessLogout(string requestUri)
        {
            await client.DeleteAsync(requestUri);
        }

        protected static async Task<object> GetObject(Task<Stream> task, Type type)
        {
            var serializer = new DataContractJsonSerializer(type);
            object unserialized = serializer.ReadObject(await task);
            return unserialized;
        }

        private Task<Stream> CreateStreamTask(string requestUri)
        {
            return client.GetStreamAsync(requestUri);
        }

        private void SetupHeaders()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("User-Agent", "Petanque JUKE client");
        }
    }

}
