using MediaPlayerWithTest.Business.src.ServiceInterface;
using MediaPlayerWithTest.Domain.src.RepositoryInterface;
using MediaPlayerWithTest.Domain.src.Core;

namespace MediaPlayerWithTest.Business.src.Sevice
{
    public class PlayListService : IPlayListService
    {
        private readonly IPlayListRepository _playList;
        private readonly IUserRepository _user;

        public PlayListService(IPlayListRepository playList, IUserRepository user)
        {
            _playList = playList;
            _user = user;
        }

        public void AddNewFile(int playListId, int fileId, int userId)
        {
            if(_user.GetListById(playListId) != null)
            {
                _playList.AddNewFile(playListId, fileId, userId);
            }
            else 
            {
                throw new ArgumentException("Id of the playlist not found");
            }
        }

        public void EmptyList(int playListId, int userId)
        {
            if(_user.GetListById(playListId) != null)
            {
                _playList.EmptyList(playListId, userId);
            }
            else 
            {
                throw new ArgumentException("Id of the playlist not found");
            }   
        }

        public void RemoveFile(int playListId, int fileId, int userId)
        {
            if(_user.GetListById(playListId) != null)
            {
                _playList.RemoveFile(playListId, fileId, userId);
            }
            else 
            {
                throw new ArgumentException("Id of the playlist not found");
            }
        }
    }
}