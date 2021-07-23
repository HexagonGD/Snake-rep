using Snake.Maps;
using System.Collections.Generic;

namespace Snake.Collections
{
    public class LimitedQueue
    {
        private Queue<Location> _locations;

        private readonly int _maxCount;
        private int _count;

        public LimitedQueue(int maxCount)
        {
            _maxCount = maxCount;
        }

        public void Enqueue(Location location)
        {
            if(_count == _maxCount) Dequeue().Destroy();

            _locations.Enqueue(location);
            _count++;
        }

        public Location Dequeue()
        {
            if(_count <= 0)
            {
                throw new System.Exception(nameof(LimitedQueue) + "пуста");
            }

            _count--;
            return _locations.Dequeue();
        }
    }
}