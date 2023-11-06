using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaPlayerWithTest.Domain.src.RepositoryInterface;
using MediaPlayerWithTest.Domain.src.Core;

namespace MediaPlayerWithTest.Infrastructure.src.Repository
{
    public class MediaRepository : IMediaRepository
    {
        private readonly List<MediaFile> _mediaFiles;

        public MediaRepository() 
        {
            _mediaFiles = new();
        }
        public MediaFile CreateNewFile(string type,string fileName, string filePath, TimeSpan duration)
        {
            if(type == "audio")
            {
                var mediaFile = new Audio(fileName,filePath,duration);
                _mediaFiles.Add(mediaFile);
                return mediaFile;
            }
            else 
            {
                var mediaFile = new Video(fileName,filePath,duration);
                _mediaFiles.Add(mediaFile);
                return mediaFile;
            }
        }

        public bool DeleteFileById(int fileId)
        {
            return _mediaFiles.Remove(GetFileById(fileId));  
        }

        public IEnumerable<MediaFile> GetAllFiles()
        {
            return _mediaFiles;
        }

        public MediaFile GetFileById(int fileId)
        {
            return _mediaFiles.Find(f => f.GetId == fileId);
        }

        public void Pause(int fileId)
        {
            var foundFile = GetFileById(fileId);
            foundFile.Pause();
        }

        public void Play(int fileId)
        {
            var foundFile = GetFileById(fileId);
            foundFile.Play();
        }

        public void Stop(int fileId)
        {
            var foundFile = GetFileById(fileId);
            foundFile.Stop();
        }
    }
}