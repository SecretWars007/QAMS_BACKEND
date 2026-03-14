
# Script to verify TestCase creation
$baseUrl = "http://localhost:5000/api"

function Log-Error {
    param($msg)
    Write-Host $msg
    $msg | Out-File "c:\diplomado\QAMS\error.txt" -Append -Encoding ASCII
}

# Login to get token
$loginBody = @{
    username = "admin"
    password = "Admin123!"
} | ConvertTo-Json

try {
    $loginResponse = Invoke-WebRequest -Uri "$baseUrl/Auth/login" -Method Post -Body $loginBody -ContentType "application/json" -UseBasicParsing
    $token = ($loginResponse.Content | ConvertFrom-Json).accessToken
    $headers = @{ Authorization = "Bearer $token" }
    Write-Host "Login successful. Token acquired."
}
catch {
    Log-Error "Login failed: $_"
    exit
}

# Get a Project
try {
    $projects = Invoke-WebRequest -Uri "$baseUrl/Projects" -Method Get -Headers $headers -UseBasicParsing
    $projectId = ($projects.Content | ConvertFrom-Json)[0].id
    Write-Host "Using Project ID: $projectId"
}
catch {
    Log-Error "Failed to get projects: $_"
    if ($_.Exception.Response) {
        $reader = New-Object System.IO.StreamReader($_.Exception.Response.GetResponseStream())
        $errBody = $reader.ReadToEnd()
        Log-Error "Server Response: $errBody"
    }
    exit
}

# Create a TestSuite
try {
    $suiteBody = @{
        projectId   = $projectId
        name        = "Manual Suite $(Get-Date -Format 'yyyyMMddHHmmss')"
        description = "Suite for manual tests"
    } | ConvertTo-Json

    $suiteResponse = Invoke-WebRequest -Uri "$baseUrl/TestSuites" -Method Post -Body $suiteBody -Headers $headers -ContentType "application/json" -UseBasicParsing
    $suiteData = $suiteResponse.Content | ConvertFrom-Json
    $suiteId = $suiteData.id
    $statusName = $suiteData.statusName
    Write-Host "Created TestSuite ID: $suiteId, Status: $statusName"
    
    if ($statusName -ne "PENDIENTE") {
        Log-Error "Unexpected status name: $statusName (Expected: PENDIENTE)"
        exit
    }
}
catch {
    Log-Error "Failed to create TestSuite: $_"
    if ($_.Exception.Response) {
        $reader = New-Object System.IO.StreamReader($_.Exception.Response.GetResponseStream())
        $errBody = $reader.ReadToEnd()
        Log-Error "Server Response: $errBody"
    }
    exit
}

# Create a TestCase
try {
    $caseBody = @{
        projectId          = $projectId
        testSuiteId        = $suiteId
        title              = "Login Test $(Get-Date -Format 'yyyyMMddHHmmss')"
        description        = "Verify user login"
        preconditions      = "User must exist"
        expectedResult     = "Login successful"
        priorityId         = 2
        estimatedTimeHours = 0.5
        testTypeId         = 1
        steps              = @(
            @{ stepOrder = 1; action = "Open Login Page"; expectedResult = "Page loaded" },
            @{ stepOrder = 2; action = "Enter credentials"; expectedResult = "Credentials entered" },
            @{ stepOrder = 3; action = "Click Login"; expectedResult = "Dashboard displayed" }
        )
    } | ConvertTo-Json -Depth 5

    $caseResponse = Invoke-WebRequest -Uri "$baseUrl/TestCases" -Method Post -Body $caseBody -Headers $headers -ContentType "application/json" -UseBasicParsing
    $caseId = ($caseResponse.Content | ConvertFrom-Json).id
    Write-Host "SUCCESS: Created TestCase ID: $caseId"
    "SUCCESS" | Out-File "c:\diplomado\QAMS\success.txt" -Encoding ASCII

    # Verification of the new filtering endpoint
    Write-Host "Verifying new filtering endpoint..."
    $filterUri = "$baseUrl/TestCases/project/$projectId/suite/$suiteId"
    $filterResponse = Invoke-WebRequest -Uri $filterUri -Method Get -Headers $headers -UseBasicParsing
    $filteredCases = $filterResponse.Content | ConvertFrom-Json
    
    if ($filteredCases.Count -gt 0) {
        Write-Host "SUCCESS: Filtering working. Found $($filteredCases.Count) cases."
        "FILTER_SUCCESS" | Out-File "c:\diplomado\QAMS\filter_success.txt" -Encoding ASCII
    }
    else {
        Log-Error "Failed: No cases found with filter."
    }

    # Verification of the new steps endpoint
    Write-Host "Verifying dedicated steps endpoint..."
    $stepsUri = "$baseUrl/TestCases/$caseId/steps"
    $stepsResponse = Invoke-WebRequest -Uri $stepsUri -Method Get -Headers $headers -UseBasicParsing
    $steps = $stepsResponse.Content | ConvertFrom-Json
    
    if ($steps.Count -eq 3) {
        Write-Host "SUCCESS: Steps endpoint working. Found $($steps.Count) steps."
        "STEPS_SUCCESS" | Out-File "c:\diplomado\QAMS\steps_success.txt" -Encoding ASCII
    }
    else {
        Log-Error "Failed: Steps endpoint returned $($steps.Count) steps, expected 3."
    }
}
catch {
    Log-Error "Failed to create TestCase: $_"
    if ($_.Exception.Response) {
        $reader = New-Object System.IO.StreamReader($_.Exception.Response.GetResponseStream())
        $errBody = $reader.ReadToEnd()
        Log-Error "Server Response: $errBody"
    }
    exit
}
