namespace Model.Response.Common
{
    public class FileItem
    {
        public string extension { get; set; }
        public string OriginalFileName { get; set; }
        public int ContentLength { get; set; }
        public string ContentType { get; set; }
        public byte[] InputStream { get; set; }
    }
}
