using MediaPlayerWithTest.Domain.src.Core;

namespace MediaPlayerWithTest.Domain.src.RepositoryInterface
{
    public interface IUserRepository
    {
        PlayList AddNewList(string name, int userId);
        void RemoveOneList(int listId, int userId);
        void RemoveAllLists(int userId);
        void EmptyOneList(int listId, int userId);
        IEnumerable<PlayList> GetAllList(int userId);
        PlayList GetListById(int listId);
        int GetUserById();
    }
}