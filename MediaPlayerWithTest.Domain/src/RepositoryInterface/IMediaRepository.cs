using MediaPlayerWithTest.Domain.src.Core;

namespace MediaPlayerWithTest.Domain.src.RepositoryInterface
{
    public interface IMediaRepository
    {
        void Play(int fileId);
        void Pause(int fileId);
        void Stop(int fileId);
        MediaFile CreateNewFile(string type,string fileName, string filePath, TimeSpan duration);
        bool DeleteFileById(int fileId);
        IEnumerable<MediaFile> GetAllFiles();
        MediaFile GetFileById(int fileId);
    }
}