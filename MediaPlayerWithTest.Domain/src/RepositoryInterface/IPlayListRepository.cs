using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaPlayerWithTest.Domain.src.Core;

namespace MediaPlayerWithTest.Domain.src.RepositoryInterface
{
    public interface IPlayListRepository
    {
        void AddNewFile(int playListId, int fileId, int userId);
        void RemoveFile(int playListId, int fileId, int userId);
        void EmptyList(int playListId, int userId);
    }
}