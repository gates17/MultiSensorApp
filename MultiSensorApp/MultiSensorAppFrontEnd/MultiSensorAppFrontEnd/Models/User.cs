using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Http.Headers;
using System.Text;

namespace MultiSensorAppFrontEnd.Models
{
    public class User
    {
        [Key, Required]
        public int Id { get; set; }


        [Required, StringLength(45)]
        [RegularExpression(@"[A-Za-z\ ]{2,45}$",
            ErrorMessage = "The inserted Name does not respect the rules!")]
        public string? Name { get; set; }


        [Required, StringLength(45)]
        [RegularExpression(@"[A-Za-z\ ]{2,45}$",
            ErrorMessage = "The inserted Department does not respect the rules!")]
        public string? Department { get; set; }


        [Required, StringLength(45)]
        [RegularExpression(@"[A-Za-z\ ]{2,45}$",
            ErrorMessage = "The inserted Function does not respect the rules!")]
        public string? Function { get; set; }


        [Required, StringLength(45)]
        [RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?",
            ErrorMessage = "The inserted email adress does not respect the rules!")]
        public string? EmailAdress { get; set; }


        [Required]
        public int Contact { get; set; }


        [Required]
        public DateTime CreationDate { get; set; }


        [Required]
        public DateTime UpdateDate { get; set; }


        public bool IsInactive { get; set; }


        [Required, ForeignKey("Role")]
        public int RoleId { get; set; }

        public Role? Role { get; set; }


        /// <summary>
        /// Use this method to Get a list of all users
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public static async Task<IEnumerable<User>> GetUsers(string uri)
        {
            IEnumerable<User> users = new List<User>();

            HttpClient client = Helper.GetHttpClient(uri);

            HttpResponseMessage response = await client.GetAsync("User");

            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                var res = await response.Content.ReadFromJsonAsync<List<User>>();

                if (res != null)
                {
                    users = res;
                }
            }

            return users;
        }


        /// <summary>
        /// Use this method to create a user
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public static async Task<User> CreateUser(string uri, User user)
        {

            HttpClient client = Helper.GetHttpClient(uri);

            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync(uri + "user", httpContent);

            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                var res = JsonConvert.DeserializeObject<User>(await response.EnsureSuccessStatusCode().Content.ReadAsStringAsync());

                if (res != null)
                {
                    user = res;
                }
            }

            return user;
        }
    }
}
