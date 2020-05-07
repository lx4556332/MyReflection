using Minio;
using Minio.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace MyReflection
{
    public class FileUpload
    {
        public async static Task Run(MinioClient minio)
        {
            var bucketName = "mymusic";
            var location = "us-east-1";
            var objectName = "hello.txt";
            var filePath = "E:\\MinIO\\hello.txt";
            var contentType = "application/zip";

            try
            {
                //上传

                // Make a bucket on the server, if not already present.
                //bool found = await minio.BucketExistsAsync(bucketName);
                //if (!found)
                //{
                //    await minio.MakeBucketAsync(bucketName, location);
                //}

                //byte[] binaryData = Encoding.ASCII.GetBytes("hello word");
                //var stream = new MemoryStream(binaryData);

                //await minio.PutObjectAsync(bucketName,"hello.txt", filePath);
                // Upload a file to bucket.
                //await minio.PutObjectAsync(bucketName, objectName, filePath, contentType);


                //下载
                await minio.StatObjectAsync(bucketName, objectName);
                await minio.GetObjectAsync(bucketName, objectName,
                (stream) =>
                {

                    using (var requestStream = stream)
                    {
                        using (var fs = File.Open("D:\\999.txt", FileMode.OpenOrCreate))
                        {
                            int length = 4 * 1024;
                            var buf = new byte[length];
                            do
                            {
                                length = requestStream.Read(buf, 0, length);
                                fs.Write(buf, 0, length);
                            } while (length != 0);
                        }
                    }
                  });

                    //var fileStream = File.Create(objectName);
                    //stream.CopyTo(fileStream);
                    //fileStream.Dispose();
                    //var writtenInfo = new FileInfo(objectName);
                    //long file_read_size = writtenInfo.Length;
                    //writtenInfo.CopyTo("D:\\golden-oldies.zip", true);
                    //// Uncomment to print the file on output console
                    //// stream.CopyTo(Console.OpenStandardOutput());
                    //Console.WriteLine($"Successfully downloaded object with requested offset and length {writtenInfo.Length} into file");
                    //stream.Dispose();


                    Console.WriteLine("Successfully uploaded " + objectName);
            }
            catch (MinioException e)
            {
                Console.WriteLine("File Upload Error: {0}", e.Message);
            }
        }
    }
}
