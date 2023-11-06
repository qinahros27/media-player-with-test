using MediaPlayerWithTest.Infrastructure.src.Repository;
using MediaPlayerWithTest.Domain.src.Core;

namespace MediaPlayerWithTest.Tests.src.Infrastructure.Tests
{
    public class MediaRepositoryTest
    {
        [Fact]
        public void CreateNewFile_ValidData_ReturnMediaFile()
        {
            //arrange
            var mediaRepository = new MediaRepository();

            //act
            var newFile = mediaRepository.CreateNewFile("audio","filename1","to/path/filename1", TimeSpan.FromMinutes(3));

            //assert
            Assert.NotNull(newFile); 
            Assert.Equal("filename1", newFile.FileName);
            Assert.Equal("to/path/filename1", newFile.FilePath);
            Assert.Equal(TimeSpan.FromMinutes(3), newFile.Duration);
        }

        [Fact]
        public void DeleteFileById_ValidData_ReturnMediaFile()
        {
            //arrange
            var mediaRepository = new MediaRepository();

            //act
            var newFile = mediaRepository.CreateNewFile("audio","filename1","to/path/filename1", TimeSpan.FromMinutes(3));
            newFile.GetId = 2;
            var deleteFile = mediaRepository.DeleteFileById(2);

            //assert
            Assert.Equal(true, deleteFile); 
        }

        [Fact]
        public void GetFileById_ValidData_ReturnMediaFile()
        {
            //arrange
            var mediaRepository = new MediaRepository();

            //act
            var newFile = mediaRepository.CreateNewFile("audio","filename1","to/path/filename1", TimeSpan.FromMinutes(3));
            newFile.GetId = 3;
            var findFile = mediaRepository.GetFileById(3);

            //assert
            Assert.NotNull(findFile); 
        }

        [Fact]
        public void GetAllFiles_ValidData_ReturnMediaFile()
        {
            //arrange
            var mediaRepository = new MediaRepository();

            //act
            var addFile = mediaRepository.CreateNewFile("audio","filename1","to/path/filename1", TimeSpan.FromMinutes(3));
            IEnumerable<MediaFile> AllFiles = mediaRepository.GetAllFiles();

            //assert
            Assert.NotEmpty(AllFiles); 
            Assert.NotEqual(0,AllFiles.Count());
        }

        [Fact]
        public void Playing_ValidData_ReturnTrue()
        {
            //arrange
            var mediaRepository = new MediaRepository();

            //act
            var playFile = mediaRepository.CreateNewFile("audio","filename1","to/path/filename1", TimeSpan.FromMinutes(3));
            playFile.GetId= 20;
            mediaRepository.Play(20);

            //assert
            Assert.Equal(true, playFile.IsPlaying);
        }
        
        [Fact]
        public void Pausing_ValidData_ReturnFalse()
        {
            //arrange
            var mediaRepository = new MediaRepository();

            //act
            var playFile = mediaRepository.CreateNewFile("audio","filename1","to/path/filename1", TimeSpan.FromMinutes(3));
            playFile.GetId= 22;
            mediaRepository.Play(22);
            mediaRepository.Pause(22);

            //assert
            Assert.Equal(false, playFile.IsPlaying);
        }
    }
}