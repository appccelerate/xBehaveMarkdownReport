function Generate-Spec
{
    [CmdletBinding()]
    param(
        [Parameter(Mandatory=1)]
        [string]
        $assembly,
        
        [Parameter(Mandatory=1)]
        [string]
        $markdown,
        
        [Parameter()]
        [string]
        $markdownScript = "",
        
        [Parameter()]
        [string]
        $html = ""
    )
    
    Begin {
        $temp = "$env:TEMP\specs\"
        $xunit = "$temp\xunit.runner.console\tools\xunit.console.exe"
    }

    Process {
        "running"
        
        "installing xunit.runner.console to $temp"
        &nuget install xunit.runner.console -OutputDirectory $temp -ExcludeVersion
        
        "executing unit tests"
        &$xunit $assembly -xml "$temp\specs.xml"
        
        "generating markdown report at $markdown"
        &"C:\Projects\xBehaveMarkdownReport\source\xBehaveMarkdownReport\bin\Debug\xBehaveMarkdownReport.exe" -i "$temp\specs.xml" -o $markdown
        
        if ($html -ne "")
        {
            if ($markdownScript -ne "")
            {
                "generating HTML report at $html"
                &perl $markdownScript $markdown > $html
            }
            else
            {
                "please provide the path to the markdown perl script."
            }
        }
        else
        {
            "HTML generation skipped."
        }       
        
        "cleaning installation"
        Remove-Item $temp -Recurse
    }
    
    End {
        "done"
    }
}