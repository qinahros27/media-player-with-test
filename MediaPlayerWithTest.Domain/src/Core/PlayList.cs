namespace MediaPlayerWithTest.Domain.src.Core
{
    public class PlayList : BaseEntity
    {
        private readonly List<MediaFile> _files = new();
        private readonly int _userId;

        public string ListName { get; set; }

        public PlayList(string name, int userId)
        {
            ListName = name;
            _userId = userId;
        }

        public IReadOnlyList<MediaFile> GetFilesList()
        {
            return _files.AsReadOnly();
        }

        public void AddNewFile(MediaFile file, int userId)
        {
            if (CheckUserId(userId))
            {
                _files.Add(file);
            }
            else 
            {
                throw new ArgumentException("User not found");
            }        
        }

        public void RemoveFile(MediaFile file, int userId)
        {
            if (CheckUserId(userId))
            {
                _files.Remove(file);
            }
            else 
            {
                throw new ArgumentException("User not found");
            }       
        }

        public void EmptyList(int userId)
        {
            if (CheckUserId(userId))
            {
                _files.Clear();
            }
            else 
            {
                throw new ArgumentException("User not found");
            }     
        }

        private bool CheckUserId(int userId)
        {
            if (userId == _userId) return true;
            return false;
        }
    }
}