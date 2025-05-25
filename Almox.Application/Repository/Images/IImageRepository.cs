namespace Almox.Application.Repository.Images;

public interface IImagesRepository
{
    Task<string?> Save(Stream file, string fileName);
    Task Delete(string? path);
}