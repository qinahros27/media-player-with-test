using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaPlayerWithTest.Domain.src.RepositoryInterface;
using MediaPlayerWithTest.Domain.src.Core;


namespace MediaPlayerWithTest.Infrastructure.src.Repository
{
    public class PlayListRepository : IPlayListRepository
    {
        private readonly MediaRepository _mediaRepository;
        private readonly UserRepository _userRepository;
        public void AddNewFile(int playListId, int fileId, int userId)
        {
            var foundFile = _mediaRepository.GetFileById(fileId);
            var foundPlaylist = _userRepository.GetListById(playListId);
            if(foundFile != null && foundPlaylist != null)
            {
                foundPlaylist.AddNewFile(foundFile,userId);
            }
            else 
            {
                throw new ArgumentException("File or playlist not found");
            }
        }

        public void EmptyList(int playListId, int userId)
        {
            var foundPlaylist = _userRepository.GetListById(playListId);
            if(foundPlaylist != null)
            {
                foundPlaylist.EmptyList(userId);
            }
            else 
            {
                throw new ArgumentException("Playlist not found");
            }
        }

        public void RemoveFile(int playListId, int fileId, int userId)
        {
            var foundFile = _mediaRepository.GetFileById(fileId);
            var foundPlaylist = _userRepository.GetListById(playListId);
            if(foundFile != null && foundPlaylist != null)
            {
                foundPlaylist.RemoveFile(foundFile,userId);
            } 
            else
            {
                throw new ArgumentException("File or playlist not found");
            }
        }
    }
}