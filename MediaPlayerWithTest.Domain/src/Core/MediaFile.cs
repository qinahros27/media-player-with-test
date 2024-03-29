namespace MediaPlayerWithTest.Domain.src.Core
{
    public abstract class MediaFile : BaseEntity
    {
        private double _playbackSpeed;
        private bool _isPlaying;
        private TimeSpan _currentPosition;
        private Timer? _timer;

        public string FileName { get; set; }
        public string FilePath { get; set; }
        public TimeSpan Duration { get; set; }
        public double Speed
        {
            get
            {
                return _playbackSpeed;
            }
            set
            {
                if (IsValidPlaybackSpeed(value))
                {
                    _playbackSpeed = value;
                    //re play to get new speed
                    Pause();
                    Play();
                }
                else
                {
                    throw new ArgumentException("Not a valid speed value");
                }
            }
        }

        public bool IsPlaying
        {
            get
            {
                return _isPlaying;
            }
        }

        public TimeSpan CurrentPosition
        {
            get
            {
                return _currentPosition;
            }
        }

        public MediaFile(string fileName, string filePath, TimeSpan duration)
        {
            FileName = fileName;
            FilePath = filePath;
            Duration = duration;
            Speed = 1;
            _isPlaying = false;
            _currentPosition = TimeSpan.Zero;
        }

        public void Play()
        {
            if (!_isPlaying)
            {
                _isPlaying = true;
                Console.WriteLine("Playing...");

                // Start a timer to increase the current position every second
                _timer = new Timer(UpdatePosition, null, TimeSpan.Zero, TimeSpan.FromSeconds(1));
            }
        }

        public void Pause()
        {
            if (_isPlaying)
            {
                _isPlaying = false;
                Console.WriteLine("Paused.");

                // Stop the timer when pausing the playback
                _timer?.Change(Timeout.Infinite, Timeout.Infinite);
            }
        }

        public void Stop()
        {
            if (_isPlaying)
            {
                _isPlaying = false;
                Console.WriteLine("Stopped.");

                // Stop the timer and reset the current position
                _timer?.Change(Timeout.Infinite, Timeout.Infinite);
                _currentPosition = TimeSpan.Zero;
            }
        }

        private static bool IsValidPlaybackSpeed(double speed)
        {
            double[] validSpeeds = { 0.25, 0.5, 1, 1.25, 1.5, 1.75, 2 };
            return validSpeeds.Contains(speed);
        }

        private void UpdatePosition(object? state)
        {
            if (_isPlaying)
            {
                _currentPosition += TimeSpan.FromSeconds(Speed);

                if (_currentPosition >= Duration)
                {
                    Stop();
                }
            }
        }
    }
}