Open a command prompt and navigate to the folder containing the **Class library name** project file (.csproj).
Run the NuGet CLI `spec` command to generate **Class library name**.nuspec:

	`nuget spec`

After all open any text editor to edit your settings in `.nuspec` file.

The file content will look like follows.

```xml
<?xml version="1.0"?>
<package>
    <metadata>
    <id>$id$</id>
    <version>$version$</version>
    <title>$title$</title>
    <authors>$author$</authors>
    <owners>$author$</owners>
    <licenseUrl>http://LICENSE_URL_HERE_OR_DELETE_THIS_LINE</licenseUrl>
    <projectUrl>http://PROJECT_URL_HERE_OR_DELETE_THIS_LINE</projectUrl>
    <iconUrl>http://ICON_URL_HERE_OR_DELETE_THIS_LINE</iconUrl>
    <requireLicenseAcceptance>false</requireLicenseAcceptance>
    <description>$description$</description>
    <releaseNotes>Summary of changes made in this release of the package.</releaseNotes>
    <copyright>Copyright 2016</copyright>
    <tags>Tag1 Tag2</tags>
    </metadata>
</package>
```

After editing run this command.

` nuget pack libName.csproj`

This creates a NuGet package file like libName.1.0.0.0.nupkg using the package name and version number from the .nuspec file.

And publish the package to [NuGet](NuGet.org)