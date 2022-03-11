using FNews.ViewModels.Teams;

namespace FNews.Services.Teams
{
    public interface ITeamService
    {
        AllTeamsViewModel GetAll(AllTeamsViewModel query);
    }
}
