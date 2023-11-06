using Moq;

using MediaPlayerWithTest.Domain.src.Core;
using MediaPlayerWithTest.Domain.src.RepositoryInterface;
using MediaPlayerWithTest.Business.src.Sevice;
using MediaPlayerWithTest.Business.src.ServiceInterface;

namespace MediaPlayerWithTest.Tests.src.Service.Tests
{
    public class UserServiceTest
    {
        private Mock<IUserRepository> _mockUserRepo;
        private IUserService _userService;

        public UserServiceTest() 
        {
           _mockUserRepo = new();
           _userService = new UserService(_mockUserRepo.Object);
        }

        [Fact]
        public void AddNewList_ValidData_ReturnPlaylist()
        {
            //arrange
            var playList = new PlayList("playlist1" , 1);
            _mockUserRepo.Setup(x => x.GetUserById()).Returns(1);
            _mockUserRepo.Setup(x => x.AddNewList("playlist1",1)).Returns(playList);
            var userService = new UserService(_mockUserRepo.Object);

            //act
            var newList = _userService.AddNewList("playlist1",1);

            //assert
            Assert.NotNull(newList); 
            _mockUserRepo.Verify(x => x.AddNewList("playlist1",1), Times.Once());
        }

        [Fact]
        public void AddNewList_InValidData_ThrowError()
        {
            //arrange
            var playList = new PlayList("playlist1" , 1);
            _mockUserRepo.Setup(x => x.GetUserById()).Returns(1);
            _mockUserRepo.Setup(x => x.AddNewList("playlist1",1)).Returns(playList);
            var userService = new UserService(_mockUserRepo.Object);

            //assert and act
            Assert.Throws<ArgumentException>(() => _userService.AddNewList("playlist1",2));
        }

        [Fact]
        public void EmptyOneList_ValidData_ReturnMessage()
        {
            //arrange
            var message = "";
            _mockUserRepo.Setup(x => x.GetUserById()).Returns(1);
            _mockUserRepo.Setup(x => x.EmptyOneList(1,1)).Callback<int,int>((listId,userId) => message = "List empty.");
            var userService = new UserService(_mockUserRepo.Object);

            //act
            _userService.EmptyOneList(1,1);

            //assert
            Assert.Equal("List empty.", message); 
            _mockUserRepo.Verify(x => x.EmptyOneList(1,1), Times.Once());
        }

        [Fact]
        public void GetAllList_ValidData_ReturnAllPlaylist()
        {
            //arrange
            var allPlayList = new List<PlayList> 
            {
                new PlayList("playlist1", 1),
                new PlayList("playlist2",1),
                new PlayList("playlist3",1)
            };
            _mockUserRepo.Setup(x => x.GetUserById()).Returns(1);
            _mockUserRepo.Setup(x => x.GetAllList(1)).Returns(allPlayList);
            var userService = new UserService(_mockUserRepo.Object);

            //act
            var result = _userService.GetAllList(1);

            //assert
            Assert.NotEmpty(result);
            Assert.Equal(3, result.Count()); 
            _mockUserRepo.Verify(x => x.GetAllList(1), Times.Once());
        }

        [Fact]
        public void GetListById_ValidData_ReturnPlaylist()
        {
            //arrange
            var playList = new PlayList("playlist1" , 1);
            _mockUserRepo.Setup(x => x.GetListById(1)).Returns(playList);
            var userService = new UserService(_mockUserRepo.Object);

            //act
            var findList = _userService.GetListById(1);

            //assert
            Assert.NotNull(findList); 
            _mockUserRepo.Verify(x => x.GetListById(1), Times.AtLeastOnce());
        }

        [Fact]
        public void RemoveAllLists_ValidData_ReturnMessage()
        {
            //arrange
            var message = "";
            _mockUserRepo.Setup(x => x.GetUserById()).Returns(1);
            _mockUserRepo.Setup(x => x.RemoveAllLists(1)).Callback<int>((userId) => message = "All lists removed.");
            var userService = new UserService(_mockUserRepo.Object);

            //act
            _userService.RemoveAllLists(1);

            //assert
            Assert.Equal("All lists removed.", message); 
            _mockUserRepo.Verify(x => x.RemoveAllLists(1), Times.Once());
        }

        [Fact]
        public void RemoveOneList_ValidData_ReturnMessage()
        {
            //arrange
            var message = "";
            var playList = new PlayList("playlist1" , 1);
            _mockUserRepo.Setup(x => x.GetUserById()).Returns(1);
            _mockUserRepo.Setup(x => x.GetListById(1)).Returns(playList);
            _mockUserRepo.Setup(x => x.RemoveOneList(1,1)).Callback<int,int>((listId,userId) => message = $"List {listId} removed.");
            var userService = new UserService(_mockUserRepo.Object);

            //act
            _userService.RemoveOneList(1,1);

            //assert
            Assert.Equal("List 1 removed.", message); 
            _mockUserRepo.Verify(x => x.RemoveOneList(1,1), Times.Once());
        }
    }
}