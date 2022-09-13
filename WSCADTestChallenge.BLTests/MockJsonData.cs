using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSCADTestChallenge.BLTests
{
    public static class MockJsonData
    {
        public static string jsonLine =
@"
 {
 ""type"": ""line"",
 ""a"": ""-1,5; 3,4"",
 ""b"": ""2,2; 5,7"",
 ""color"": ""127; 255; 255; 255""
 }
";
        public static string jsonCircle =
            @"
{
 ""type"": ""circle"",
 ""center"": ""0; 0"",
 ""radius"": 15.0,
 ""filled"": false,
 ""color"": ""127; 255; 0; 0""
 }
";

        public static string jsonTriangle =
            @"
{
 ""type"": ""triangle"",
 ""a"": ""-15; -20"",
 ""b"": ""15; -20,3"",
 ""c"": ""0; 21"",
 ""filled"": true,
 ""color"": ""127; 255; 0; 255""
 }
";

        public static string jsonArray =
@"[
 {
 ""type"": ""line"",
 ""a"": ""-1,5; 3,4"",
 ""b"": ""2,2; 5,7"",
 ""color"": ""127; 255; 255; 255""
 },
 {
 ""type"": ""circle"",
 ""center"": ""0; 0"",
 ""radius"": 15.0,
 ""filled"": false,
 ""color"": ""127; 255; 0; 0""
 },
 {
 ""type"": ""triangle"",
 ""a"": ""-15; -20"",
 ""b"": ""15; -20,3"",
 ""c"": ""0; 21"",
 ""filled"": true,
 ""color"": ""127; 255; 0; 255""
 }
]
";
    }
}
