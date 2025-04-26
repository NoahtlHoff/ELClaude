﻿using System.Net;
using AutoMapper;
using equilog_backend.Common;
using equilog_backend.Data;
using equilog_backend.DTOs.CalendarEventDTOs;
using equilog_backend.Interfaces;
using equilog_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace equilog_backend.Services;

public class CalendarEventService(EquilogDbContext context, IMapper mapper) : ICalendarEventService
{
    public async Task<ApiResponse<List<CalendarEventDto>?>> GetCalendarEventsByStableIdAsync(int id)
    {
        try
        {
            var calendarEventDtos = mapper.Map<List<CalendarEventDto>>(await context.CalendarEvents
                .Where(ce => ce.StableIdFk == id)
                .ToListAsync());

            return ApiResponse<List<CalendarEventDto>>.Success(HttpStatusCode.OK,
                calendarEventDtos,
                null);
        }
        catch (Exception ex)
        {
            return ApiResponse<List<CalendarEventDto>?>.Failure(HttpStatusCode.InternalServerError,
                ex.Message);
        }
    }
    
    public async Task<ApiResponse<List<CalendarEventDto>?>> GetCalendarEventsAsync()
    {
        try
        {
            var calendarEventDtos = mapper.Map<List<CalendarEventDto>>(await context.CalendarEvents.ToListAsync());

            return ApiResponse<List<CalendarEventDto>>.Success(HttpStatusCode.OK,
                calendarEventDtos,
                null);
        }
        catch (Exception ex)
        {
            return ApiResponse<List<CalendarEventDto>>.Failure(HttpStatusCode.InternalServerError,
                ex.Message);
        }
    }
    
    public async Task<ApiResponse<CalendarEventDto?>> GetCalendarEventAsync(int id)
    {
        try
        {
            var calendarEvent = await context.CalendarEvents
                .Where(ce => ce.Id == id)
                .FirstOrDefaultAsync();

            if (calendarEvent == null) return ApiResponse<CalendarEventDto>.Failure(HttpStatusCode.NotFound,
                    "Error: Event not found");

            return ApiResponse<CalendarEventDto>.Success(HttpStatusCode.OK,
                mapper.Map<CalendarEventDto>(calendarEvent),
                null);
        }
        catch (Exception ex)
        {
            return ApiResponse<CalendarEventDto>.Failure(HttpStatusCode.InternalServerError,
                ex.Message);
        }
    }

    public async Task<ApiResponse<CalendarEventDto?>> CreateCalendarEventAsync(CalendarEventCreateDto calendarEventCreateDto)
    {
        try
        {
            var calendarEvent = mapper.Map<CalendarEvent>(calendarEventCreateDto);
            
            context.CalendarEvents.Add(calendarEvent);
            await context.SaveChangesAsync();

            return ApiResponse<CalendarEventDto>.Success(HttpStatusCode.Created,
                mapper.Map<CalendarEventDto>(calendarEvent),
                "New calendar event created successfully");
        }
        catch (Exception ex)
        {
            return ApiResponse<CalendarEventDto>.Failure(HttpStatusCode.InternalServerError,
                ex.Message);
        }
    }

    public async Task<ApiResponse<Unit>> UpdateCalendarEventAsync(CalendarEventUpdateDto calendarEventUpdateDto)
    {
        try
        {
            var calendarEvent = await context.CalendarEvents
                .Where(ce => ce.Id == calendarEventUpdateDto.Id)
                .FirstOrDefaultAsync();

            if (calendarEvent == null)
                return ApiResponse<Unit>.Failure(HttpStatusCode.NotFound,
                    "Error: Calendar event not found");

            mapper.Map(calendarEventUpdateDto, calendarEvent);
            await context.SaveChangesAsync();

            return ApiResponse<Unit>.Success(HttpStatusCode.OK,
                Unit.Value,
                null);
        }
        catch (Exception ex)
        {
            return ApiResponse<Unit>.Failure(HttpStatusCode.InternalServerError,
                ex.Message);
        }
    } 
    
    public async Task<ApiResponse<Unit>> DeleteCalendarEventAsync(int id)
    {
        try
        {
            var calendarEvent = await context.CalendarEvents
                .Where(ce => ce.Id == id)
                .FirstOrDefaultAsync();

            if (calendarEvent == null)
                return ApiResponse<Unit>.Failure(HttpStatusCode.NotFound,
                    "Error: Calendar event not found");

            context.CalendarEvents.Remove(calendarEvent);
            await context.SaveChangesAsync();

            return ApiResponse<Unit>.Success(HttpStatusCode.NoContent,
                Unit.Value,
                $"Calendar event with id '{id}' was deleted successfully");
        }
        catch (Exception ex)
        {
            return ApiResponse<Unit>.Failure(HttpStatusCode.InternalServerError,
                ex.Message);
        }
    }
}
