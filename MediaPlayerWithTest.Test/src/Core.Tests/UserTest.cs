using System.Collections;
using MediaPlayerWithTest.Domain.src.Core;

namespace MediaPlayerWithTest.Tests.src.Core.Tests
{
    public class UserTest
    {
        PlayList testPlaylist = new PlayList("test1", 3);

        [Fact]
        public void CreateUser_ValidData_ReturnUser()
        {
            var newUser = User.Instance;
            newUser.GetId = 1;
            Assert.Equal(1, newUser.GetId);
            newUser.Name = "Anh";
            Assert.Equal("Anh", newUser.Name);
        }

        [Fact]
        public void AddNewList_ValidData_ListAdded()
        {
            var listCollection = User.Instance.GetAllList();
            User.Instance.AddNewList(testPlaylist);
            Assert.Equal(true, listCollection.Contains(testPlaylist));
        }

        [Fact]
        public void GetAllList_ValidData_ListsCountNotEqualZero()
        {
            User.Instance.AddNewList(new PlayList("test2", 3));
            Assert.NotEmpty(User.Instance.GetAllList());
        }

        [Fact]
        public void RemoveOneList_ValidData_ListRemoved()
        {
            var listCollection = User.Instance.GetAllList();
            User.Instance.RemoveOneList(testPlaylist);
            Assert.Equal(false, listCollection.Contains(testPlaylist));
        }

        [Fact]
        public void RemoveAllLists_Data_ListsEmpty()
        {
            var listCollection = User.Instance.GetAllList();
            User.Instance.RemoveAllLists();
            Assert.Empty(listCollection);
        }
    }
}