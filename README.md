# ExtRS.NET48
ExtRS.NET48 is a .NET Framework 4.8 class library for extending the capabilities of Reporting Services. With ExtRS.NET48, (pronounced "extras dot net 48"), common public API endpoints and SDK clients are consolidated into a utility .dll containing features that can compliment your SSRS custom assemblies and other .NET Framework development. ExtRS.NET48 also contains a simplified interface to the SSRS v2 API for programmatically managing SSRS catalog item types (CatalogItem, Report, DataSource, DataSet, etc.).

SSRS ain't dead- it's just a niche tool that hasn't fully realized its potential- yet. 🤷‍♂️

# Requirements
This plug-in works as a drop-in Nuget package for .NET Framework 4.8 projects as well an SSRS Custom Assembly as described by Microsoft here: https://docs.microsoft.com/en-us/sql/reporting-services/custom-assemblies/using-custom-assemblies-with-reports?view=sql-server-ver15

# Contents
This package includes the following components:
- Sonrai.ExtRSNET48.dll

# Examples

```
        [TestInitialize]
        public async Task InitializeTests()
        {
            httpClient = new HttpClient();
            SSRSConnection connection = new SSRSConnection("localhost", "ExtRSAuth", 
            AuthenticationType.ExtRSAuth);
            connection.SqlAuthCookie = await SSRSService.GetSqlAuthCookie(httpClient, 
            connection.Administrator, "", connection.ServerName);
            ssrs = new SSRSService(connection);
        }

       [TestMethod]
        public async Task CreateGetDeleteReportSucceeds()
        {
            string content = ssrsReportItemJsonString; // ie:  { "@odata.type": "#Model.Report", "id":...

            var postResp = await ssrs.CallApi("POST", "Reports", "{" + content + "}");
            Assert.IsTrue(postResp.IsSuccessStatusCode);   
            
            var getResponse = await ssrs.CallApi("GET", postResp.Headers.Location.Segments[4]);
            Assert.IsTrue(getResponse.IsSuccessStatusCode);

            var deleteResp = await ssrs.CallApi("DELETE", postResp.Headers.Location.Segments[4]);
            Assert.IsTrue(deleteResp.IsSuccessStatusCode);
        }
        
        public SSRSService(SSRSConnection connection)
        {          
            conn = connection;
            client = new HttpClient();
            cookieContainer.Add(new Cookie("sqlAuthCookie", conn.SqlAuthCookie, "/", "localhost"));
            serverUrl = string.Format("https://{0}/reports/api/v2.0/", conn.ServerName);
        }
```

# Related SSRS Tools
- [ExtRSAuth](https://github.com/sonrai-LLC/ExtRSAuth) for enabling further extension of the SSRS Microsoft Custom Security Sample.
