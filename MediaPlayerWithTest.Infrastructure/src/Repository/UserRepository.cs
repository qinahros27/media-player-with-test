using MediaPlayerWithTest.Domain.src.Core;
using MediaPlayerWithTest.Domain.src.RepositoryInterface;

namespace MediaPlayerWithTest.Infrastructure.src.Repository
{
    public class UserRepository : IUserRepository
    {
        public UserRepository(){}

        public PlayList AddNewList(string name, int userId)
        {
            var newPlaylist = new PlayList(name,userId);
            User.Instance.AddNewList(newPlaylist);
            return newPlaylist;
        }

        public void EmptyOneList(int listId, int userId)
        {
            var foundList = GetListById(listId);
            User.Instance.EmptyOneList(foundList);
        }

        public IEnumerable<PlayList> GetAllList(int userId)
        {
            return User.Instance.GetAllList();
        }

        public PlayList GetListById(int listId)
        {
            return User.Instance.GetListById(listId);
        }

        public void RemoveAllLists(int userId)
        {
            User.Instance.RemoveAllLists();
        }

        public void RemoveOneList(int listId, int userId)
        {
            var foundList = GetListById(listId);
            User.Instance.RemoveOneList(foundList);
        }

        public int GetUserById()
        {
            return User.Instance.GetUserById();
        }

    }
}