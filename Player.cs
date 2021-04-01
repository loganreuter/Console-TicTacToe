using System;

namespace Program
{
    class Player
    {
        public void Init(){
            Console.WriteLine("Hello");
        }

        public int Move(){
            int pos = Int32.Parse(Console.ReadLine());
            return pos;
        }
    }
}