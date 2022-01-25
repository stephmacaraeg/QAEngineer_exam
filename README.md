# fastjobsexam
Exam for QA Engineer role.
Pre-Requisite/s:
VS Studio should be installed.

SetUp Steps/Running the test in VS Studio
1. Once you're on this link: https://github.com/stephmacaraeg/fastjobsexam
2. Click the Code button and choose Download Zip.
3. Extract the downloaded file.
4. Navigate to the FastJobsExam.sln file. Sample path: C:\Users\User\fastjobsexam\FastJobsExam
5. Open the FastJobsExam.sln file.
6. If a security warning is displayed, click the OK button.
7. Once the the project is fully loaded, navigate to the Solution Explorer, right click the Solution 'Exam' and choose Manage Nuget Packages for Solution.
8. On the Nuget - Solution page click the Installed tab.
9. Make sure that the following packages are installed:
- Microsoft.NET.Test.Sdk
- NUnit
- NUnit3TestAdapter
- Selenium.Support
- Selenium.WebDriver
- Selenium.WebDriver.ChromeDriver
- SeleniumExtras.WaitHelpers
10. Once the packages are confirmed complete. Navigate to the Test Explorer (To open test explorer: Click the Test Tab > Test Explorer)
11. You'll be able to see the 8 tests for this project.
12. Choose one test to run by right clicking a test and choose run. You can run all the test by choosing to run the 'MainTest (8)' OR the 'FastJobsExam (8)'.

Command-line instructions:
I tried using the NUnit Console to run the tests however I kept on getting these errors:
System.InvalidCastException : Unable to cast transparent proxy to type 'System.Web.UI.ICallbackEventHandler'.
Apparently, this is a limitation of the NUnit with regards to handling NUnit Standard.
See reference links below:
- https://docs.nunit.org/articles/nunit/getting-started/dotnet-core-and-dotnet-standard.html
- https://github.com/nunit/nunit-console/issues/487

A simple work around is to use dotnet test. See instructions below.

Pre-requisite: Your local should have the selenium webdriver package: 
https://api.nuget.org/v3-flatcontainer/selenium.webdriver.chromedriver/97.0.4692.7100/selenium.webdriver.chromedriver.97.0.4692.7100.nupkg
1. Open command prompt and input the following: 
dotnet test <file path of the FastJobsExam.csproj> Ex.:
```
dotnet test C:\Users\user\Documents\test\Exam\Exam\FastJobsExam.csproj
```
