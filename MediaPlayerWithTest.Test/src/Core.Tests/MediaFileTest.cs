using MediaPlayerWithTest.Domain.src.Core;

namespace MediaPlayerWithTest.Tests.src.Core.Tests
{
    public class MediaFileTest
    {
        public static TimeSpan duration = TimeSpan.FromMinutes(3);
        MediaFile mediaFile = new Audio("file1", "/path/to/file1", duration);

        [Fact]
        public void CreateFile_CheckValidSpeed_ThrowError()
        {
            Assert.Throws<ArgumentException>(()=> mediaFile.Speed = 0.2);
        }

        [Theory]
        [InlineData(0.25)]
        [InlineData(0.5)]
        public void CreateFile_CheckValidSpeed_ReturnSpeed(double a)
        {
            mediaFile.Speed = a;
            Assert.Equal(a, mediaFile.Speed);
        }

        [Fact]
        public void PlayFile_CheckPlaying_ReturnTrue()
        {
            mediaFile.Play();
            Assert.Equal(true, mediaFile.IsPlaying);
        }

        [Fact]
        public void PlayFile_CheckPausing_ReturnFalse()
        {
            mediaFile.Pause();
            Assert.Equal(false,mediaFile.IsPlaying);
        }

        [Fact]
        public void PlayFile_CheckStoping_CurrentPositionEqualZero()
        {
            mediaFile.Stop();
            Assert.Equal(TimeSpan.Zero, mediaFile.CurrentPosition);
        }
    }
}