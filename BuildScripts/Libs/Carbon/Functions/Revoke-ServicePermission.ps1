# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# 
#     http://www.apache.org/licenses/LICENSE-2.0
# 
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.

function Revoke-ServicePermission
{
    <#
    .SYNOPSIS
    Removes all permissions an identity has to manage a service.
    
    .DESCRIPTION
    No permissions are left behind.  This is an all or nothing operation, baby!
    
    .LINK
    Get-ServicePermission
    
    .LINK
    Grant-ServicePermission
    
    .EXAMPLE
    Revoke-ServicePermission -Name 'Hyperdrive` -Identity 'CLOUDCITY\LCalrissian'
    
    Removes all of Lando's permissions to control the `Hyperdrive` service.
    #>
    [CmdletBinding()]
    param(
        [Parameter(Mandatory=$true)]
        [string]
        # The service.
        $Name,
        
        [Parameter(Mandatory=$true)]
        [string]
        # The identity whose permissions are being revoked.
        $Identity
    )
    
    Set-StrictMode -Version 'Latest'

    Use-CallerPreference -Cmdlet $PSCmdlet -Session $ExecutionContext.SessionState

    $account = Resolve-Identity -Name $Identity
    if( -not $account )
    {
        return
    }
    
    if( -not (Assert-Service -Name $Name) )
    {
        return
    }
    
    if( (Get-ServicePermission -Name $Name -Identity $account.FullName) )
    {
        Write-Verbose ("Revoking {0}'s {1} service permissions." -f $account.FullName,$Name)
        
        $dacl = Get-ServiceAcl -Name $Name
        $dacl.Purge( $account.Sid )
        
        Set-ServiceAcl -Name $Name -Dacl $dacl
    }
 }
 
