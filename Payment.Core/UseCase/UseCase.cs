namespace Payment.Core.UseCase
{
    public abstract class UseCase<Result, Param>
    {
        public abstract Result execute(Param param);
    }
}