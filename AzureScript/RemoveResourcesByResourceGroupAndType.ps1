Param(
[Parameter(Mandatory = $false,position=0)]
[string[]]$resource_types = @('Microsoft.Web/sites' ,'Microsoft.Sql/servers/databases' ),
[string]$resource_group
)
$resource = Get-AzureRmResource -ResourceGroupName $resource_group


$message = 'found ' + $resource.Lenght + ' resources in ' + $resource_group + ' resource group'
echo $message

$removedResources = 0

if($resource.Length -gt 0){
    for($i = 0; $i -lt $resource.Length; $i++){
    
        if($resource_types.Contains($resource[$i].ResourceType )){
            Remove-AzureRmResource -ResourceId $resource[$i].ResourceId -Force
            $removedResources++
        }
    }
    $afterRemoveMsg =$removedResources.ToString() + ' resources has been removed'
    echo $afterRemoveMsg
}
else{
    $resourceGroupNotFoundMsg = $resource_group + ' has not been found '
    echo $resourceGroupNotFoundMsg
}