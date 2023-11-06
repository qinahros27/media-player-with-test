namespace MediaPlayerWithTest.Domain.src.Core
{
    public class User : BaseEntity
    {
        private readonly List<PlayList> _lists = new();
        private static readonly Lazy<User> lazyInstance = new(() => new User());

        public string Name { get; set; } = string.Empty;

        private User(){}

        public static User Instance => lazyInstance.Value;

        public void AddNewList(PlayList list)
        {
            _lists.Add(list);
        }

        public void RemoveOneList(PlayList list)
        {
            _lists.Remove(list);
        }

        public void EmptyOneList(PlayList list)
        {
            if (_lists.Contains(list))
                list.EmptyList(GetId);
            else
                throw new ArgumentNullException("Playlist is not found");
        }

        public IEnumerable<PlayList> GetAllList()
        {
            return _lists;
        }

        public PlayList GetListById(int listId)
        {
            return _lists.Find(l => l.GetId == listId);
        }

        public void RemoveAllLists()
        {
            _lists.Clear();
        }

        public int GetUserById()
        {
            return User.Instance.GetId;
        }
    }
}