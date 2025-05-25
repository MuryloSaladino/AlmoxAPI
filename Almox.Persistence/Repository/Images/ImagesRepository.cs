using System.Net;
using Almox.Application.Common.Exceptions;
using Almox.Application.Repository.Images;
using Almox.Domain.Common.Messages;
using Almox.Persistence.Config;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace Almox.Persistence.Repository.Images;

public class ImagesRepository : IImagesRepository
{
    private readonly Cloudinary Cloudinary = new(DotEnv.Get("CLOUDINARY_URL"));

    public async Task<string?> Save(Stream file, string fileName)
    {
        var uploadParams = new ImageUploadParams()
        {
            File = new FileDescription(fileName, file),
            UniqueFilename = true,
        };

        var uploadResult = await Cloudinary.UploadAsync(uploadParams);

        if (uploadResult.StatusCode != HttpStatusCode.OK)
            return null;

        return uploadResult.SecureUrl.ToString();
    }

    public async Task Delete(string? path)
    {
        if (string.IsNullOrWhiteSpace(path))
            return;

        var uri = new Uri(path);
        var segments = uri.AbsolutePath.Split('/');

        var fileName = segments.Last();
        var publicId = fileName.Contains('.')
            ? fileName[..fileName.LastIndexOf('.')] 
            : fileName;

        var deleteParams = new DeletionParams(publicId);
        var result = await Cloudinary.DestroyAsync(deleteParams);

        if (result.Result != "ok")
            throw AppException.NotFound(ExceptionMessages.NotFound.Image);
    }
}