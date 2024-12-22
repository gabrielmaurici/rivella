namespace Rivella.Application.Common;

public static class StorageFileName
{
    public static string Create(int idAlbum)
        => $"{idAlbum}_{DateTime.Now:yyyyMMddHHmmss}";
}