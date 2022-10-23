using System;

namespace GenericScale
{
    class StartUp
    {
        static void Main(string[] args)
        {
            EqualityScale<int>  scale = new EqualityScale<int>(5 , 5);
            Console.WriteLine(scale.AreEqual());
        }
    }
    public class EqualityScale<T>
    {
        private T left;
        private T right;
        public EqualityScale(T left, T right)
        {
            this.left = left;
            this.right = right;
        }
        public bool AreEqual()
        {
            return this.left.Equals(this.right);
        }
    }
}
