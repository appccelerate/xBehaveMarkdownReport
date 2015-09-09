# xBehaveMarkdownReport
Creates a markdown report from an xBehave (xUnit) XML report.

## Installation ##
### NuGet ###
Execute `nuget install xBehaveMarkdownReport`. Afterwards the executable is at `xBehaveMarkdownReport-<version>\tools\xBehaveMarkdownReport.exe`

### Chocolatey ###
Execute `choco install xBehaveMarkdownReport -source "https://www.myget.org/F/xbehavemarkdownreport/api/v2"` (case-sensitive!). Afterwards you can directly use `xBehaveMarkdownReport.exe` because chocolatey updated the path environment variable.

The source has to be specified because the package is not listed on the chocolatey gallery.

## Usage ##
 1. run your xBehave specifications with `xUnit.Console.exe <specs.dll> -xml <specs.xml>`
 2. run `xBehaveMarkdownReport -i <specs.xml> -o <specs.md>`
  - -i, --input: input path (.xml)
  - -o, --output: output path (.md))
   
## What is generated ##
The generated markdown file is structured as follows:

```
Assembly Name (camel case as spaces)
====================================

Namespace (without common prefix with assembly name and dots as spaces) Class Name (camel case as spaces)
---------------------------------------------------------------------------------------------------------

### Scenario Name (camel case as spaces)

- step 1
- step 2
- step 3

### Scenario With Example

#### example values (comma delimited)

- step 1
- step 2

#### example values

- step 1
- step 2
```
