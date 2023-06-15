using System;

namespace Payment.Core.Utils
{
    public abstract class Result<T, E> where E : Exception
    {
        public T Value { get; }
        public E Error { get; }

        protected Result(T value = default, E error = null)
        {
            if ((value != null && !value.Equals(default(T))) && error != null)
            {
                throw new Exception("Both value and error cannot be defined");
            }

            Value = value;
            Error = error;
        }

        public bool IsRight()
        {
            return Value != null && !Value.Equals(default(T));
        }

        public bool IsLeft()
        {
            return Error != null;
        }

        public void Fold(Action<T> onRight, Action<E> onLeft)
        {
            if (IsRight())
            {
                onRight(Value);
            }
            else
            {
                onLeft(Error);
            }
        }

        public void FoldRight(Action<T> onRight)
        {
            if (IsRight())
            {
                onRight(Value);
            }
        }

        public void FoldLeft(Action<E> onLeft)
        {
            if (IsLeft())
            {
                onLeft(Error);
            }
        }
    }

    public class Right<T> : Result<T, Exception>
    {
        public Right(T value) : base(value, null)
        {
        }
    }

    public class Left<T, E> : Result<T, E> where E : Exception
    {
        public Left(E error) : base(error: error)
        {
        }
    }
}