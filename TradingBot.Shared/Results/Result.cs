namespace TradingBot.Shared.Results
{
    public class Result<T>
    {
        public bool IsSuccess { get; }
        public T? Value { get; }
        public string? Error { get; }

        protected Result(bool isSuccess, T? value, string? error)
        {
            IsSuccess = isSuccess;
            Value = value;
            Error = error;
        }

        public static Result<T> Success(T value) => new(true, value, null);

        public static Result<T> Failure(string error) => new(false, default, error);

        // Métodos para composição
        public Result<TOut> OnSuccess<TOut>(Func<T, TOut> onSuccess)
        {
            if (!IsSuccess) return Result<TOut>.Failure(Error!);
            return Result<TOut>.Success(onSuccess(Value!));
        }

        public Result<T> OnFailure(Action<string> onFailure)
        {
            if (!IsSuccess) onFailure(Error!);
            return this;
        }
    }
}
