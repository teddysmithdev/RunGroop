using RunGroopWebApp.Models;

namespace RunGroopWebApp.ViewModels;

public class IndexClubViewModel
{
    public IEnumerable<Club> Clubs { get; set; }
    public int PageIndex { get; set; }
    public int TotalPages { get; set; }
    public int TotalClubs { get; set; }
    public int PageSize { get; set; }

    public IndexClubViewModel(IEnumerable<Club> clubs, int pageIndex, int pageSize)
    {
        Clubs = clubs;
        PageIndex = pageIndex;
        TotalClubs = clubs.Count();
        TotalPages = (int)Math.Ceiling(TotalClubs / (double)pageSize);
        PageSize = pageSize;
        Clubs = clubs.Skip((pageIndex - 1) * pageSize).Take(pageSize);
    }

    public bool HasPreviousPage => PageIndex > 1;

    public bool HasNextPage => PageIndex < TotalPages;
}