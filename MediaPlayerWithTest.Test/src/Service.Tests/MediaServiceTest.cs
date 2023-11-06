using Moq;

using MediaPlayerWithTest.Domain.src.Core;
using MediaPlayerWithTest.Domain.src.RepositoryInterface;
using MediaPlayerWithTest.Business.src.Sevice;
using MediaPlayerWithTest.Business.src.ServiceInterface;

namespace MediaPlayerWithTest.Tests.src.Service.Tests
{
    public class MediaServiceTest
    {
        private Mock<IMediaRepository> _mockMediaRepo;
        private IMediaService _mediaService;

        public MediaServiceTest() 
        {
            _mockMediaRepo = new();
            _mediaService = new MediaService(_mockMediaRepo.Object);
        }

        [Fact]
        public void CreateNewFile_ValidData_ReturnNewFile()
        {
            //arrange
            _mockMediaRepo.Setup(x => x.CreateNewFile(It.IsAny<string>(), It.IsAny<string>(),It.IsAny<string>(),It.IsAny<TimeSpan>())).Returns((string type, string name, string path, TimeSpan duration) => new Audio(name,path,duration));
            var mediaService = new MediaService(_mockMediaRepo.Object);

            //act
            var newFile = _mediaService.CreateNewFile("audio","file1", "/path/to/file1", TimeSpan.FromMinutes(3));

            //assert
            Assert.NotNull(newFile); 
            _mockMediaRepo.Verify(x => x.CreateNewFile(It.IsAny<string>(),It.IsAny<string>(),It.IsAny<string>(),It.IsAny<TimeSpan>()), Times.Once());
        }

        [Fact]
        public void GetFileById_ValidData_ReturnFiles()
        {
            //arrange
            var expectedFile = new Audio("file1","/to/path/file1", TimeSpan.FromMinutes(3));
            _mockMediaRepo.Setup(x => x.GetFileById(1)).Returns(expectedFile);
            var mediaService = new MediaService(_mockMediaRepo.Object);

            //act
            var result = mediaService.GetFileById(1);

            //assert
            Assert.NotNull(result);
            Assert.Equal(expectedFile, result);
            _mockMediaRepo.Verify(x => x.GetFileById(1), Times.AtLeastOnce);
        }

        [Fact]
        public void DeleteFileById_ValidData_ReturnTrue()
        {
            //arrange
            _mockMediaRepo.Setup(x => x.GetFileById(1)).Returns(new Audio("file1","/to/path/file1", TimeSpan.FromMinutes(3)));
            _mockMediaRepo.Setup(x => x.DeleteFileById(1)).Returns(true);
            var mediaService = new MediaService(_mockMediaRepo.Object);

            //act
            var result = mediaService.DeleteFileById(1);

            //assert
            Assert.Equal(true, result);
        }

        [Fact]
        public void DeleteFileById_InValidData_ThrowError()
        {
            //arrange
            _mockMediaRepo.Setup(x => x.GetFileById(1)).Returns(new Audio("file1","/to/path/file1", TimeSpan.FromMinutes(3)));
            _mockMediaRepo.Setup(x => x.DeleteFileById(1)).Returns(true);
            var mediaService = new MediaService(_mockMediaRepo.Object);

            //assert
            Assert.Throws<FileNotFoundException>(() => mediaService.DeleteFileById(100));
        }

        [Fact]
        public void GetAllFiles_ValidData_ReturnFiles()
        {
            //arrange
            var expectedFiles = new List<MediaFile>
            {
                new Audio("file1","/to/path/file1", TimeSpan.FromMinutes(3)),
                new Audio("file2","/to/path/file2", TimeSpan.FromMinutes(3)),
                new Audio("file3","/to/path/file3", TimeSpan.FromMinutes(3))
            };
            _mockMediaRepo.Setup(x => x.GetAllFiles()).Returns(expectedFiles);
            var mediaService = new MediaService(_mockMediaRepo.Object);

            //act
            IEnumerable<MediaFile> resultList = mediaService.GetAllFiles();

            //assert
            Assert.NotEmpty(resultList);
            _mockMediaRepo.Verify(x => x.GetAllFiles(), Times.Once);
        }
    }
}