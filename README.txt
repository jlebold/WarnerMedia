Run instructions:
On a Windows 10 PC with .net sdk 5.0+ installed...

1.) Clone or download the zip this repo
2.) Open Visual Studio as Administrator
3.) Open this solution's .sln
4.) Right click the 'WarnerMedia' solution (NOT THE PROJECT FILE)
5.) Click 'Properties'
6.) Check the box for multiple startup projects and move the Web API to the top priority. Set from "None" to "Start without debugging" on the dropdown for both projects.
7.) Click Apply
8.) Clean the solution (in the Build Tab)
9.) Build the solution (in the Build Tab)
10.) Click Start without debugging under the "Debug" tab
11.) Two tabs should open up in your browser. One serves as the API and will display a 404, leave it open on the side. The second serves as the user interface.

Try using the Microsoft Edge browser if you run into any issues in your native browser.

Cheers,
Joe
