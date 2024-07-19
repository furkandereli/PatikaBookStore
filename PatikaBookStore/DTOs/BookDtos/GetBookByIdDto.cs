namespace PatikaBookStore.DTOs.BookDtos
{
    public class GetBookByIdDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int PageCount { get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
    }
}
