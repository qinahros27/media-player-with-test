using MediaPlayerWithTest.Domain.src.Core;

namespace MediaPlayerWithTest.Business.src.ServiceInterface
{
    public interface IUserService
    {
        PlayList AddNewList(string name, int userId);
        void RemoveOneList(int listId, int userId);
        void RemoveAllLists(int userId);
        void EmptyOneList(int listId, int userId);
        IEnumerable<PlayList> GetAllList(int userId);
        PlayList GetListById(int listId);
    }
}