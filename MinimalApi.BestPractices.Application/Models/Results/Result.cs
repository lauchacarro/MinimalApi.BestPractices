﻿namespace MinimalApi.BestPractices.Application.Models.Results
{
    public class Result
    {

        public Result(bool isSuccess, List<string> errors)
        {
            IsSuccess = isSuccess;
            Errors = errors;
        }

        public Result()
        {
        }

        public bool IsSuccess { get; set; }

        public List<string> Errors { get; set; } = new();

        public static Result Success
            => new Result(true, new List<string>());

        public static Result Failure(IEnumerable<string> errors)
            => new Result(false, errors.ToList());

        public static implicit operator Result(string error)
            => Failure(new List<string> { error });

        public static implicit operator Result(List<string> errors)
            => Failure(errors.ToList());

        public static implicit operator Result(bool success)
            => success ? Success : Failure(new[] { "Unsuccessful operation." });

        public static implicit operator bool(Result result)
            => result.IsSuccess;
    }

    public class Result<TData> : Result where TData : class
    {

        public Result()
        {
        }


        public Result(bool isSuccess, TData? data, List<string> errors)
            : base(isSuccess, errors)
            => Data = data;

        public TData? Data { get; set; }

        public static Result<TData> SuccessWith(TData data)
            => new Result<TData>(true, data, new List<string>());

        public new static Result<TData> Failure(IEnumerable<string> errors)
            => new Result<TData>(false, default, errors.ToList());

        public static implicit operator Result<TData>(string error)
            => Failure(new List<string> { error });

        public static implicit operator Result<TData>(List<string> errors)
            => Failure(errors);

        public static implicit operator Result<TData>(TData data)
            => SuccessWith(data);

        public static implicit operator bool(Result<TData> result)
            => result.IsSuccess;
    }
}
