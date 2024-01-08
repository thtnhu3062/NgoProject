namespace NgoProject.ViewModel
{
    public class ViewModelAbout
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public IFormFile? Photo { get; set; }
    }
}
