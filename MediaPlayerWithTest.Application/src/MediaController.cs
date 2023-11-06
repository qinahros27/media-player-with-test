using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaPlayerWithTest.Business.src.ServiceInterface;
using MediaPlayerWithTest.Domain.src.Core;

namespace MediaPlayerWithTest.Application.src
{
    public class MediaController
    {
        private readonly IMediaService _mediaService;

        public MediaController(IMediaService mediaService)
        {
            _mediaService = mediaService;
        }

        public MediaFile CreateNewFile(string type, string fileName, string filePath, TimeSpan duration)
        {
            return _mediaService.CreateNewFile(type, fileName, filePath, duration);
        }

        public bool DeleteFileById(int id)
        {
            return _mediaService.DeleteFileById(id);
        }

        public IEnumerable<MediaFile> GetAllFiles()
        {
            return _mediaService.GetAllFiles();
        }

        public MediaFile GetFileById(int id)
        {
            return _mediaService.GetFileById(id);
        }
    }
}