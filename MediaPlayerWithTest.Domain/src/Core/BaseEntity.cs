using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaPlayerWithTest.Domain.src.Core
{
    public abstract class BaseEntity
    {
        private static int _id = 0;

        //I used setter for using in test because i dont know exactly what the id of the item , I used setter to set id to 1 for testing easier.
        public int GetId { 
            get 
            {
                return _id;
            }
            set
            {
                if(value < 0)
                {
                    throw new ArgumentException("Invalid value");
                }
                else 
                {
                    _id = value;
                }
            }
        }
        public BaseEntity()
        {
            _id++;
        }
    }
}