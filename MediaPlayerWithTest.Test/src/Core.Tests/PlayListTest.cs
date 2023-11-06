using MediaPlayerWithTest.Domain.src.Core;

namespace MediaPlayerWithTest.Tests.src.Core
{
    public class PlayListTest
    {
        PlayList playList = new PlayList("Workspace", 1);
        MediaFile audio1 = new Audio("audio1", "/path/to/audio1", TimeSpan.FromMinutes(3));
        
        [Fact]
        public void CreatePlaylist_ValidData_ReturnPlaylist()
        {   
            Assert.Equal("Workspace", playList.ListName);
        }

        [Fact]
        public void AddNewFileToPlayList_ValidData_FileAdded() 
        {
            playList.AddNewFile(audio1,1);
            Assert.Equal(true, playList.GetFilesList().Contains(audio1));
        }

        [Fact]
        public void AddNewFileToPlayList_InValidData_ThrowError()
        {
            Assert.Throws<ArgumentException>(()=> playList.AddNewFile(audio1, 3)); 
        }

        [Fact]
        public void RemoveFile_ValidData_FileRemoved() 
        {
            playList.RemoveFile(audio1,1);
            Assert.Equal(false, playList.GetFilesList().Contains(audio1));
        }

        [Fact]
        public void EmptyList_ValidData_ListEmpty()
        {
            playList.AddNewFile(audio1,1);
            playList.EmptyList(1);
            Assert.Empty(playList.GetFilesList());
        }
    }
}