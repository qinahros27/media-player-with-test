using Moq;

using MediaPlayerWithTest.Domain.src.Core;
using MediaPlayerWithTest.Domain.src.RepositoryInterface;
using MediaPlayerWithTest.Business.src.Sevice;
using MediaPlayerWithTest.Business.src.ServiceInterface;

namespace MediaPlayerWithTest.Tests.src.Service.Tests
{
    public class PlaylistServiceTest
    {
        private Mock<IPlayListRepository> _mockPlaylistRepo;
        private IPlayListService _playlistService;
        private Mock<IUserRepository> _mockUserInstance;

        private IUserService _userService;

        public PlaylistServiceTest() 
        {
           _mockPlaylistRepo = new();
           _mockUserInstance = new();
           _playlistService = new PlayListService(_mockPlaylistRepo.Object, _mockUserInstance.Object);
        }

        [Fact]
        public void AddNewFile_ValidData_ReturnConfirmMessage()
        {
            //arrange
            var message = "";
            var playList = new PlayList("playlist1", 1);
            _mockUserInstance.Setup(x => x.GetListById(1)).Returns(playList);
            _mockPlaylistRepo.Setup(x => x.AddNewFile(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Callback<int, int, int>((playListId, fileId, userId) => message = $"File {fileId} added to playlist {playListId}");
            var _playlistService = new PlayListService(_mockPlaylistRepo.Object , _mockUserInstance.Object);

            //act
            _playlistService.AddNewFile(1, 1, 1);

            //assert
            Assert.Equal("File 1 added to playlist 1", message);
            _mockUserInstance.Verify(x => x.GetListById(1), Times.AtLeastOnce());
            _mockPlaylistRepo.Verify(x => x.AddNewFile(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()), Times.Once());
        }

        [Fact]
        public void AddNewFile_InValidData_ThrowError()
        {
            //arrange
            var message = "";
            var playList = new PlayList("playlist1", 1);
            _mockUserInstance.Setup(x => x.GetListById(1)).Returns(playList);
            _mockPlaylistRepo.Setup(x => x.AddNewFile(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Callback<int, int, int>((playListId, fileId, userId) => message = $"File {fileId} added to playlist {playListId}");
            var _playlistService = new PlayListService(_mockPlaylistRepo.Object , _mockUserInstance.Object);

            //assert and act
            Assert.Throws<ArgumentException>(() => _playlistService.AddNewFile(2, 1, 1));
        }

        [Fact]
        public void RemoveFile_ValidData_ReturnCofirmMessage()
        {
            //arrange
            var message = "";
            var playList = new PlayList("playlist1", 1);
            _mockUserInstance.Setup(x => x.GetListById(1)).Returns(playList);
            _mockPlaylistRepo.Setup(x => x.RemoveFile(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Callback<int, int, int>((playListId, fileId, userId) => message = $"File {fileId} removed from playlist {playListId}");
            var _playlistService = new PlayListService(_mockPlaylistRepo.Object , _mockUserInstance.Object);

            //act
            _playlistService.RemoveFile(1, 1, 1);

            //assert
            Assert.Equal("File 1 removed from playlist 1", message);
            _mockUserInstance.Verify(x => x.GetListById(1), Times.AtLeastOnce());
            _mockPlaylistRepo.Verify(x => x.RemoveFile(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()), Times.Once());
        }

        [Fact]
        public void EmptyList_ValidData_ReturnCofirmMessage()
        {
            //arrange
            var message = "";
            var playList = new PlayList("playlist1", 1);
            _mockUserInstance.Setup(x => x.GetListById(1)).Returns(playList);
            _mockPlaylistRepo.Setup(x => x.EmptyList(It.IsAny<int>(), It.IsAny<int>())).Callback<int, int>((playListId, userId) => message = $"Playlist {playListId} is empty.");
            var _playlistService = new PlayListService(_mockPlaylistRepo.Object , _mockUserInstance.Object);

            //act
            _playlistService.EmptyList(1, 1);

            //assert
            Assert.Equal("Playlist 1 is empty.", message);
            _mockUserInstance.Verify(x => x.GetListById(1), Times.AtLeastOnce());
            _mockPlaylistRepo.Verify(x => x.EmptyList(It.IsAny<int>(), It.IsAny<int>()), Times.Once());
        }
    }
}