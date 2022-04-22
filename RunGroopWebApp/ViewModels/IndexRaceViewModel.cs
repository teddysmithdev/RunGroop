using RunGroopWebApp.Models;

namespace RunGroopWebApp.ViewModels;

public class IndexRaceViewModel
{
    public IEnumerable<Race> Races { get; set; }
    public int PageSize { get; set; }
    public int Page { get; set; }
    public int TotalPages { get; set; }
    public int TotalRaces { get; set; }
    public int Category { get; set; }
    public bool HasPreviousPage => Page > 1;
    public bool HasNextPage => Page < TotalPages;
}