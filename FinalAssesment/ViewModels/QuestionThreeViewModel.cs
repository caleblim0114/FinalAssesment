using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FinalAssesment.MobileApp.ViewModels;
using FinalAssesment.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FinalAssesment.ViewModels
{
    public partial class QuestionThreeViewModel : BaseViewModel
    {
        private const string BaseUrl = "https://jsonplaceholder.typicode.com/posts";

        [ObservableProperty]
        bool _showAdd = false;

        [ObservableProperty]
        string _title = null;

        [ObservableProperty]
        string _description = null;

        [ObservableProperty]
        ObservableCollection<PostRecord> _record = new ();

        public QuestionThreeViewModel()
        {
            ReadPostsCommand.ExecuteAsync(null);
        }

        [RelayCommand(AllowConcurrentExecutions = false)]
        async Task AddPost()
        {
            if (ShowAdd == false)
            {
                ShowAdd = true;
            }
            else
            {
                ShowAdd = false;
            }
        }

        [RelayCommand(AllowConcurrentExecutions = false)]
        async Task CreatePostAsync()
        {
            if(Title != null && Description != null)
            {
                if(await Shell.Current.DisplayAlert("Confirm","Are you sure you want to create this post?", "Yes", "No"))
                {
                    Record.Add(new PostRecord
                    {
                        Title = Title,
                        Body = Description
                    });

                    using (HttpClient client = new HttpClient())
                    {
                        var json = Newtonsoft.Json.JsonConvert.SerializeObject(Record);
                        var content = new StringContent(json, Encoding.UTF8, "application/json");

                        var response = await client.PostAsync(BaseUrl, content);

                        if (response.IsSuccessStatusCode)
                        {
                            await Shell.Current.DisplayAlert("Success", "Post created.", "OK");
                        }
                        else
                        {
                            var createdPost = Newtonsoft.Json.JsonConvert.DeserializeObject(response.Content.ReadAsStringAsync().Result);
                            await Shell.Current.DisplayAlert("Failed", createdPost.ToString(), "OK");
                        }
                    }
                }
                else
                {
                    return;
                }
            }
            else
            {
                await Shell.Current.DisplayAlert("Action", "Please enter the title and body.", "OK");
            }
        }

        [RelayCommand(AllowConcurrentExecutions = false)]
        async Task ReadPosts()
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetStringAsync(BaseUrl);

                var posts = JsonConvert.DeserializeObject<ObservableCollection<PostRecord>>(response);

                if (posts!= null)
                {
                    foreach (var post in posts)
                    {
                        Record.Add(post);
                    }
                }
            }
        }

        [RelayCommand(AllowConcurrentExecutions = false)]
        async Task UpdatePostAsync()
        {
            var updateData = new PostRecord
            {
                Id = 100,
                UserId = "Caleb",
                Title = Title,
                Body = Description
            };

            using (HttpClient client = new HttpClient())
            {
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(updateData);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PutAsync($"{BaseUrl}/{updateData.Id}", content);

                if (response.IsSuccessStatusCode)
                {
                    var updatedPost = Newtonsoft.Json.JsonConvert.DeserializeObject(response.Content.ReadAsStringAsync().Result);
                }
                else
                {

                }
            }
        }

        [RelayCommand(AllowConcurrentExecutions = false)]
        async Task DeletePostAsync()
        {
            var postToDeleteId = 1;

            using (HttpClient client = new HttpClient())
            {
                var response = await client.DeleteAsync($"{BaseUrl}/{postToDeleteId}");

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Post successfully deleted.");
                }
                else
                {
                    Console.WriteLine($"Failed to delete post. Status Code: {response.StatusCode}");
                }
            }
        }
    }
}

