using System;
using System.Net;
using System.IO;

namespace myCalibrationAPISimpleSample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var baseUrl = "https://mycalibrationapi.azurewebsites.net/v1/CalibrationData";
            var baseUrlExport = "https://mycalibrationapi.azurewebsites.net/v1/CalibrationData/Export";

            var filterParameters = "?DateFilterType=greaterThan&Date=2022-01-01&ProductSeries=17SHX";

            var url = baseUrl + filterParameters;

            var httpRequest = (HttpWebRequest)WebRequest.Create(url);

            httpRequest.Headers["accept"] = "text/plain";
            // This bearer token will be invalid in 4 hours
            httpRequest.Headers["Authorization"] = "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImtpZCI6Ilg1ZVhrNHh5b2pORnVtMWtsMll0djhkbE5QNC1jNTdkTzZRR1RWQndhTmsifQ.eyJleHAiOjE2NTY0NjE2MzcsIm5iZiI6MTY1NjQyNTYzNywidmVyIjoiMS4wIiwiaXNzIjoiaHR0cHM6Ly9rZWxsZXJkcnVja2Nsb3VkLmIyY2xvZ2luLmNvbS82YWYzZmU4Mi0xNzE5LTRiNjMtYWE4Yy1iNzc4ZjcwYzg1NDUvdjIuMC8iLCJzdWIiOiIwOWIyZTQxMC1hOTAwLTRkZTAtODkyMy1kMTFlMjQxYzM1MmMiLCJhdWQiOiJjMjVlZDNkMi1mZWJlLTQ3MzUtODM2Ni0zYzI2OTg4YjkzNmQiLCJub25jZSI6ImU1ZGYyY2NlLWEwYTktNGY1Yi1hOGQ1LWY4MGU4YTYzNTFkYSIsImlhdCI6MTY1NjQyNTYzNywiYXV0aF90aW1lIjoxNjU2NDI1NjM3LCJvaWQiOiIwOWIyZTQxMC1hOTAwLTRkZTAtODkyMy1kMTFlMjQxYzM1MmMiLCJlbWFpbHMiOlsiZW5naW5lZXJpbmdAa2VsbGVyLWRydWNrLmNvbSJdLCJ0ZnAiOiJCMkNfMV9teUNhbGlicmF0aW9uX1NJIn0.KVORuz7JBm8zLHl_czOdtKs_GMTglOlgkEx-75feFVbOyqbi9HEAM16Lky4ExCInpY0XV_SPxllLFHAaPJiAv8wxYYR7cR0koApVYFrZTMLtXt10Tu06BZyF3fb6GZTpXOwumg6I6ObZTzuYtKa_JG6q2m3eNdJLEjPy-XpKbs7rT1gGc38VWOxxRm2x9_0zHEkPRpyarIxabmWTckCu9OA9VhSF6wVqrh3XH8-VejN1fbtdxl8x0WGBBHcGUv1tzFvS5fCCCL4_ewtyO706Gk3Xzv0t7q9M_G1v7Dp9QYoUy3N-SQB1i1TEfx2TyhdbTgurxYhJ1RjMgAuppfYlhw";


            string result = "";
            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }

            Console.WriteLine(httpResponse.StatusCode);

            Console.WriteLine("Result : " + result);
            Console.ReadLine();
        }
    }
}
