using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Transfer;
using Ecommerce.API.Contracts;
using Ecommerce.API.Models;

namespace Ecommerce.API.Services;

public class AwsS3StorageImagesService
{
    private readonly IConfiguration _configuration;

    public AwsS3StorageImagesService(IConfiguration configuration)
    {
        this._configuration = configuration;
    }

    public async Task<S3Object> UploadFileAsync(S3Object s3Object, AwsData awsData)
    {
        var accessKey = this._configuration["AwsConfiguration : AWSAccessKey"];
        var secretKey = this._configuration["AwsConfiguration : AWSSecretKey"];

        var credentials = new BasicAWSCredentials(accessKey, secretKey);
        var config = new AmazonS3Config() { RegionEndpoint = Amazon.RegionEndpoint.USEast1 };
        var uploadRequest = new TransferUtilityUploadRequest()
        {
            InputStream = s3Object.InputStream,
            Key = s3Object.Name,
            BucketName = s3Object.BucketName,
            CannedACL = S3CannedACL.NoACL
        };
        using var client = new AmazonS3Client(credentials, config);

        var transferUtility = new TransferUtility(client);

        await transferUtility.UploadAsync(uploadRequest);

        return s3Object;
    }
}