namespace Almox.Application.Repository.ImageRepository;

public interface IImagesRepository
{
    Task<string?> Save(Stream file, string fileName);
    Task Delete(string? path);
}