param (
    [Parameter(Mandatory=$true)]
    [ValidateSet('dev','test','prod')]
    [string]$environment)

$plate="0198bb"
# change to the target env
oc project $plate-$environment 2>&1 | Out-Null

if ($LastExitCode -eq 0) {
  # install or upgrade the application
  helm upgrade ocr form-recognizer --install --values form-recognizer-$environment-values.yaml
} else {
    Write-Error "Could not change to project $plate-$environment"
}
