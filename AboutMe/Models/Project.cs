namespace AboutMe.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Img { get; set; }
        public string ImgDesc { get; set; }
        public string Url { get; set; }

        public Project(int _Id, string _Title, string _Description, string _Img, string _ImgDesc, string _Url)
        {
            Id = _Id;
            Title = _Title;
            Description = _Description;
            Img = _Img;
            ImgDesc = _ImgDesc;
            Url = _Url;
        }
    }
}
