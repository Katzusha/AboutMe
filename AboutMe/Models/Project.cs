using MySql.Data;
//using MySql.Data.MySqlClient;
using System.Threading.Tasks;
using MySqlConnector;

namespace AboutMe.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string Img { get; set; }
        public string ImgDesc { get; set; }
        public string Url { get; set; }

        public Project(int _Id, string _Title, string _ShortDescription, string _Description, string _Img, string _ImgDesc, string _Url)
        {
            Id = _Id;
            Title = _Title;
            ShortDescription = _ShortDescription;
            Description = _Description;
            Img = _Img;
            ImgDesc = _ImgDesc;
            Url = _Url;
        }

        public static List<Project> GetAll()
        {
            List<Project> projects = new List<Project>();
            
            try
            {
                string connstring = "server=127.0.0.1;database=AboutMe;user=neox;password=Sztvkvtcss#2253;";
                using (MySqlConnection connection = new MySqlConnection(connstring))
                {
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand("select * from Projects", connection);

                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        projects.Add(new Project((int)reader["Id"], 
                                                 (string)reader["Title"], 
                                                 (string)reader["ShortDescription"], 
                                                 (string)reader["Description"], 
                                                 (string)reader["ImgUrl"],
                                                 (string)reader["ImgDescription"], 
                                                 (string)reader["Url"]));
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                projects.Add(new Project(-1, "Error", ex.Message, "", "", "", ""));
            }

            return projects;
        }
    }
}
