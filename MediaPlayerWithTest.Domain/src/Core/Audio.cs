using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaPlayerWithTest.Domain.src.Core
{
    public class Audio : MediaFile
    {
        public Audio(string fileName, string filePath, TimeSpan duration) : base(fileName, filePath, duration)
        {
        }
    }
}