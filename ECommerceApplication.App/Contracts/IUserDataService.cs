using ECommerceApplication.App.Services.Responses;
using ECommerceApplication.App.ViewModels;
using System.Threading.Tasks;

namespace ECommerceApplication.App.Contracts
{
    public interface IUserDataService
    {
        Task<UserViewModel> GetUserByEmailAsync(string email);
        Task<List<UserViewModel>> GetAssignedUsersByProjectId(Guid projectId);
    }
}