dotnet ef migrations add InitialCreate --context MvcMovieContext

dotnet ef migrations add InitialCreate --context MvcSeriesContext

dotnet ef migrations add InitialCreate --context MvcActorContext

dotnet ef migrations add InitialCreate --context AuthUserDBContext

dotnet ef database update -c MvcSeriesContext

dotnet ef database update -c MvcActorContext

dotnet ef database update -c AuthUserDBContext