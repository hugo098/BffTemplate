namespace BffTemplate.Application.Dtos;
public record TodoDto(
     int UserId,
     int Id,
     string Title,
     bool Completed
);