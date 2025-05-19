﻿using equilog_backend.Common;
using equilog_backend.DTOs.CommentCompositionDTOs;
using equilog_backend.DTOs.CommentDTOs;
using equilog_backend.Interfaces;

namespace equilog_backend.Endpoints;

public class CommentEndpoints
{
	public static void RegisterEndpoints(WebApplication app)
	{
		// Get comments by StablePost id.
		app.MapGet("/api/comment/{id:int}", GetCommentsByStablePostId)
			.WithName("GetCommentByStableId");

		// Create comment.
		app.MapPost("/api/comment/create", CreateComment)
			.AddEndpointFilter<ValidationFilter<CommentCreateDto>>()
			.WithName("CreateComment");

		// Delete comment.
		app.MapDelete("/api/comment/delete/{id:int}", DeleteComment)
			.WithName("DeleteComment");

		// -- Endpoints for compositions --

		// create a comment with required components and relations.
		app.MapPost("/api/comment/create/composition", CreateCommentComposition)
			.AddEndpointFilter<ValidationFilter<CommentCompositionCreateDto>>()
			.WithName("CreateCommentComposition");
	}

	private static async Task<IResult> GetCommentsByStablePostId(
		ICommentService commentService,
		int id)
	{
		return Result.Generate(await commentService.GetCommentByStablePostId(id));
	}

	private static async Task<IResult> CreateComment(
		ICommentService commentService,
		CommentCreateDto commentCreateDto)
	{
		return Result.Generate(await commentService.CreateCommentAsync(commentCreateDto));
	}

	private static async Task<IResult> DeleteComment(
		ICommentService commentService,
		int id)
	{
		return Result.Generate(await commentService.DeleteCommentAsync(id));
	}

	// -- Result generators for composition --
	private static async Task<IResult> CreateCommentComposition(
		ICommentComposition commentComposition,
		CommentCompositionCreateDto commentCompositionCreateDto)
	{
		return Result.Generate(await commentComposition.CreateCommentComposition(commentCompositionCreateDto));
	}
}