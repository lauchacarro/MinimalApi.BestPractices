﻿using MinimalApi.BestPractices.Application.Models.Results;

namespace MinimalApi.BestPractices.Api.Extensions
{
    public static class ResultExtensions
    {
        public static async Task<IResult> ToHttpResult<TData>(this Task<TData> resultTask)
        {
            var result = await resultTask;

            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }

        public static async Task<IResult> ToHttpResult(this Task<Result> resultTask)
        {
            var result = await resultTask;

            if (!result.IsSuccess)
            {
                return Results.BadRequest(result);
            }

            return Results.Ok(result);
        }

        public static async Task<IResult> ToHttpResult<TData>(this Task<Result<TData>> resultTask) where TData : class
        {
            var result = await resultTask;

            if (!result.IsSuccess)
            {
                return Results.BadRequest(result);
            }

            return Results.Ok(result);
        }


        public static IResult ToHttpResult<TData>(this TData result)
        {
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }

        public static IResult ToHttpResult(this Result result)
        {
            if (!result.IsSuccess)
            {
                return Results.BadRequest(result);
            }

            return Results.Ok(result);
        }

        public static IResult ToHttpResult<TData>(this Result<TData> result) where TData : class
        {
            if (!result.IsSuccess)
            {
                return Results.BadRequest(result);
            }

            return Results.Ok(result);
        }


    }
}
