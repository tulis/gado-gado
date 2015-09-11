<Query Kind="Program">
  <Reference>&lt;ProgramFilesX86&gt;\Microsoft SQL Server\110\SDK\Assemblies\Microsoft.ExceptionMessageBox.dll</Reference>
  <Reference>&lt;ProgramFilesX86&gt;\Microsoft SQL Server\110\SDK\Assemblies\Microsoft.SqlServer.ConnectionInfo.dll</Reference>
  <Reference>&lt;ProgramFilesX86&gt;\Microsoft SQL Server\110\SDK\Assemblies\Microsoft.SqlServer.ConnectionInfoExtended.dll</Reference>
  <Reference>&lt;ProgramFilesX86&gt;\Microsoft SQL Server\110\SDK\Assemblies\Microsoft.SqlServer.Dmf.Adapters.dll</Reference>
  <Reference>&lt;ProgramFilesX86&gt;\Microsoft SQL Server\110\SDK\Assemblies\Microsoft.SqlServer.Dmf.dll</Reference>
  <Reference>&lt;ProgramFilesX86&gt;\Microsoft SQL Server\110\SDK\Assemblies\Microsoft.SqlServer.DmfSqlClrWrapper.dll</Reference>
  <Reference>&lt;ProgramFilesX86&gt;\Microsoft SQL Server\110\SDK\Assemblies\Microsoft.SqlServer.Management.Collector.dll</Reference>
  <Reference>&lt;ProgramFilesX86&gt;\Microsoft SQL Server\110\SDK\Assemblies\Microsoft.SqlServer.Management.CollectorEnum.dll</Reference>
  <Reference>&lt;ProgramFilesX86&gt;\Microsoft SQL Server\110\SDK\Assemblies\Microsoft.SqlServer.Management.Sdk.Sfc.dll</Reference>
  <Reference>&lt;ProgramFilesX86&gt;\Microsoft SQL Server\110\SDK\Assemblies\Microsoft.SqlServer.Management.Utility.dll</Reference>
  <Reference>&lt;ProgramFilesX86&gt;\Microsoft SQL Server\110\SDK\Assemblies\Microsoft.SqlServer.Management.UtilityEnum.dll</Reference>
  <Reference>&lt;ProgramFilesX86&gt;\Microsoft SQL Server\110\SDK\Assemblies\Microsoft.SqlServer.Management.XEvent.dll</Reference>
  <Reference>&lt;ProgramFilesX86&gt;\Microsoft SQL Server\110\SDK\Assemblies\Microsoft.SqlServer.Management.XEventEnum.dll</Reference>
  <Reference>&lt;ProgramFilesX86&gt;\Microsoft SQL Server\110\SDK\Assemblies\Microsoft.SqlServer.PolicyEnum.dll</Reference>
  <Reference>&lt;ProgramFilesX86&gt;\Microsoft SQL Server\110\SDK\Assemblies\Microsoft.SqlServer.RegSvrEnum.dll</Reference>
  <Reference>&lt;ProgramFilesX86&gt;\Microsoft SQL Server\110\SDK\Assemblies\Microsoft.SqlServer.Rmo.dll</Reference>
  <Reference>&lt;ProgramFilesX86&gt;\Microsoft SQL Server\110\SDK\Assemblies\Microsoft.SqlServer.ServiceBrokerEnum.dll</Reference>
  <Reference>&lt;ProgramFilesX86&gt;\Microsoft SQL Server\110\SDK\Assemblies\Microsoft.SqlServer.Smo.dll</Reference>
  <Reference>&lt;ProgramFilesX86&gt;\Microsoft SQL Server\110\SDK\Assemblies\Microsoft.SqlServer.SmoExtended.dll</Reference>
  <Reference>&lt;ProgramFilesX86&gt;\Microsoft SQL Server\110\SDK\Assemblies\Microsoft.SqlServer.SqlEnum.dll</Reference>
  <Reference>&lt;ProgramFilesX86&gt;\Microsoft SQL Server\110\SDK\Assemblies\Microsoft.SqlServer.SqlWmiManagement.dll</Reference>
  <Reference>&lt;ProgramFilesX86&gt;\Microsoft SQL Server\110\SDK\Assemblies\Microsoft.SqlServer.SString.dll</Reference>
  <Reference>&lt;ProgramFilesX86&gt;\Microsoft SQL Server\110\SDK\Assemblies\Microsoft.SqlServer.TransactSql.ScriptDom.dll</Reference>
  <Reference>&lt;ProgramFilesX86&gt;\Microsoft SQL Server\110\SDK\Assemblies\Microsoft.SqlServer.Types.dll</Reference>
  <Reference>&lt;ProgramFilesX86&gt;\Microsoft SQL Server\110\SDK\Assemblies\Microsoft.SqlServer.WmiEnum.dll</Reference>
  <Namespace>Microsoft.SqlServer.Common</Namespace>
  <Namespace>Microsoft.SqlServer.Management.Smo</Namespace>
  <Namespace>Microsoft.SqlServer.Management.Smo.Agent</Namespace>
  <Namespace>Microsoft.SqlServer.Management.Smo.Broker</Namespace>
  <Namespace>Microsoft.SqlServer.Management.Smo.Mail</Namespace>
  <Namespace>Microsoft.SqlServer.Management.Smo.Wmi</Namespace>
  <Namespace>Microsoft.SqlServer.Types</Namespace>
</Query>

void Main()
{
	GetSqlServerList(false).Dump();
}

// Define other methods and classes here
public static string[] GetSqlServerList(bool isLocalOnly)
{
	var list = new List<string>();

	//Detect local services.
	var managedComputer = new ManagedComputer();
	foreach (ServerInstance serverInstance in managedComputer.ServerInstances)
	{
		serverInstance.Dump("default instance");
		var servername = (serverInstance.Name == "MSSQLSERVER") 
			? "."
			: ".\\" + serverInstance.Name;
			
		list.Add(servername);
	}

	if (!isLocalOnly)
	{
		var dataTable = SmoApplication.EnumAvailableSqlServers();
		dataTable.Dump("remote services");
		dataTable
			.Rows
			.Cast<DataRow>()
			.ToList()
			.ForEach(row => list.Add(row["Name"].ToString()));
	}

	return list.ToArray();
}