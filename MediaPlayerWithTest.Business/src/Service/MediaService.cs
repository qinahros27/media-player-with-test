using MediaPlayerWithTest.Business.src.ServiceInterface;
using MediaPlayerWithTest.Domain.src.Core;
using MediaPlayerWithTest.Domain.src.RepositoryInterface;

namespace MediaPlayerWithTest.Business.src.Sevice
{
    public class MediaService : IMediaService
    {
        private readonly IMediaRepository _mediaRepository;

        public MediaService(IMediaRepository mediaRepository)
        {
            _mediaRepository = mediaRepository; 
        }

        public MediaFile CreateNewFile(string type, string fileName, string filePath, TimeSpan duration)
        {
            return _mediaRepository.CreateNewFile(type, fileName, filePath, duration);
        }

        public bool DeleteFileById(int id)
        {
            var foundFile = _mediaRepository.GetFileById(id);
            if(foundFile == null) 
            {
                throw new FileNotFoundException();
            }
            else 
            {
                return _mediaRepository.DeleteFileById(id);
            }  
        }

        public IEnumerable<MediaFile> GetAllFiles()
        {
            return _mediaRepository.GetAllFiles();
        }

        public MediaFile GetFileById(int id)
        {
            var foundFile = _mediaRepository.GetFileById(id);
            if(foundFile != null)
            {
                return _mediaRepository.GetFileById(id);
            }
            else 
            {
                throw new FileNotFoundException();
            }
        }
    }
}