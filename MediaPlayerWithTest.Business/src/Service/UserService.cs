using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaPlayerWithTest.Business.src.ServiceInterface;
using MediaPlayerWithTest.Domain.src.RepositoryInterface;
using MediaPlayerWithTest.Domain.src.Core;

namespace MediaPlayerWithTest.Business.src.Sevice
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public PlayList AddNewList(string name, int userId)
        {
            if(userId == _userRepository.GetUserById())
            {
                return _userRepository.AddNewList(name, userId);
            }
            else 
            {
                throw new ArgumentException("User id not found");
            }
        }

        public void EmptyOneList(int listId, int userId)
        {
            if(userId == _userRepository.GetUserById())
            {
                _userRepository.EmptyOneList(listId, userId);
            }
            else
            {
                throw new ArgumentException("User Id not found");
            }
        }

        public IEnumerable<PlayList> GetAllList(int userId)
        {
            if(userId == _userRepository.GetUserById())
            {
                return _userRepository.GetAllList(userId);
            }
            else
            {
                throw new ArgumentException("User Id not found");
            }
        }

        public PlayList GetListById(int listId)
        {
            var foundList = _userRepository.GetListById(listId);
            if(foundList != null)
            {
                return _userRepository.GetListById(listId);
            }
            else 
            {
                throw new ArgumentException("Playlist not found");
            }
        }

        public void RemoveAllLists(int userId)
        {
            if(userId == _userRepository.GetUserById())
            {
                _userRepository.RemoveAllLists(userId);
            }
            else 
            {
                throw new ArgumentException("User id not found");
            }
        }

        public void RemoveOneList(int listId, int userId)
        {
            var foundList = _userRepository.GetListById(listId);
            if(foundList != null && userId == _userRepository.GetUserById())
            {
                _userRepository.RemoveOneList(listId, userId);
            }
            else
            {
                throw new ArgumentException("User Id or File Id not found");
            }
        }
    }
}