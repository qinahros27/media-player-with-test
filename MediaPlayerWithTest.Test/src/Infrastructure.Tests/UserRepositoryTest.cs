using MediaPlayerWithTest.Infrastructure.src.Repository;
using MediaPlayerWithTest.Domain.src.Core;

namespace MediaPlayerWithTest.Tests.src.Infrastructure.Tests
{
    public class UserRepositoryTest
    {
        [Fact]
        public void AddNewList_ValidData_ReturnPlaylist()
        {
            //arrange
            var userRepository = new UserRepository();

            //act
            var playList1 = userRepository.AddNewList("playlist1", 1);

            //assert
            Assert.NotNull(playList1);
            Assert.Equal("playlist1", playList1.ListName);
        }

        [Fact]  
        public void GetAllList_ValidData_ReturnPlaylist()
        {
            //arrange
            var userRepository = new UserRepository();

            //act
            var playList1 = userRepository.AddNewList("playlist1", 1);
            IEnumerable<PlayList> allPlaylists =  userRepository.GetAllList(1);

            //assert
            Assert.NotEmpty(allPlaylists);
        }
    }
}