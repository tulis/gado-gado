Originally copied from https://gist.github.com/aaronpowell/048d2e7d6ccef8e2923737f3c6e48c76

The following is a list of resources that are useful to learn more about how to cut costs in the cloud and specifically Azure.

* [Azure Pricing Calculator](https://azure.microsoft.com/pricing/calculator?WT.mc_id=ndcsydney-event-aapowell)
  * This tool allows you to select different Azure services and the configurations of them that you're after to produce an estimate of what a monthly bill would look like. The prices I used in the talk are generated from this tool
* [Cutting DDD Sydney's Azure Cost blog post](https://www.aaron-powell.com/posts/2018-06-21-cutting-azure-costs/)
  * A blog post I wrote after initially converting the DDD Sydeny web platform to a low-cost static website (and the inspiration for the talk)
* [Azure Static Website docs](https://docs.microsoft.com/azure/storage/blobs/storage-blob-static-website?WT.mc_id=ndcsydney-event-aapowell)
  * A walkthrough of how to deploy a static website
  * [Scott Hanselmen](https://twitter.com/shanselman) did a [video on how to deploy a static site](https://www.youtube.com/watch?v=G_gDYlRBAZw)
  * [Pricing information for Azure Storage](https://azure.microsoft.com/pricing/details/storage/?WT.mc_id=ndcsydney-event-aapowell)
* [Azure CDN](https://docs.microsoft.com/azure/storage/blobs/storage-https-custom-domain-cdn?WT.mc_id=ndcsydney-event-aapowell)
  * Azure CDN is one option for creating a custom domain and routing over the storage account
  * [Pricing information for Azure CDN](https://azure.microsoft.com/en-us/pricing/details/cdn/?WT.mc_id=ndcsydney-event-aapowell)
  * [Azure Front Door](https://docs.microsoft.com/azure/frontdoor/?WT.mc_id=ndcsydney-event-aapowell) is another option, but it can be a bit expensive if you have a lot of routing rules ([Pricing information for Azure Front Door](https://azure.microsoft.com/pricing/details/frontdoor/?WT.mc_id=ndcsydney-event-aapowell))
  * [Cloudflare](https://www.cloudflare.com/) has a good free tier
* [Azure Functions docs](https://docs.microsoft.com/azure/azure-functions/?WT.mc_id=ndcsydney-event-aapowell)
  * [Troy Hunt](https://www.troyhunt.com) has a great post on using [CloudFlare workers to cut Functions costs](https://www.troyhunt.com/serverless-to-the-max-doing-big-things-for-small-dollars-with-cloudflare-workers-and-azure-functions/)
  * He also has a post on [a gotcha with scale](https://www.troyhunt.com/breaking-azure-functions-with-too-many-connections/)
  * I've written a post on [creating workflows with Durable Functions](https://www.aaron-powell.com/posts/2019-05-08-event-based-workflows-with-durable-functions/)
  * And a post on [caching data with Durable Entities](https://www.aaron-powell.com/posts/2019-09-27-using-durable-entities-and-orchestrators-to-create-an-api-cache/) to avoid hitting storage
  * [Pricing information for Azure Functions](https://azure.microsoft.com/pricing/details/functions/?WT.mc_id=ndcsydney-event-aapowell)
* Storage
  * [Streaming data from Event Hubs](https://docs.microsoft.com/azure/event-hubs/event-hubs-capture-overview?WT.mc_id=ndcsydney-event-aapowell) is a useful design pattern for high throughput data when you can handle eventual consistency
  * [Pricing information for Azure SQL](https://azure.microsoft.com/pricing/details/sql-database/managed/?WT.mc_id=ndcsydney-event-aapowell)
  * [Pricing information for Cosmos DB](https://azure.microsoft.com/pricing/details/cosmos-db/?WT.mc_id=ndcsydney-event-aapowell)
    * There is a [reserved units (RU) calculator](https://cosmos.azure.com/capacitycalculator/) that can be helpful to understand required capacity with Cosmos DB
* Monitoring
  * [AppInsights](https://docs.microsoft.com/azure/azure-monitor/app/app-insights-overview?WT.mc_id=ndcsydney-event-aapowell) has a simple integration with many platforms
  * [Here's an article](https://aka.ms/appinsights/react) that I wrote on using AppInsights to monitor a static application (built using Gatsby.js)
  * [Pricing information for AppInsights](https://azure.microsoft.com/pricing/details/monitor/?WT.mc_id=ndcsydney-event-aapowell)
  * AppInsights can integrate into other platforms [such as the ELK stack](https://blogs.msdn.microsoft.com/mattev/2015/02/12/analyzing-your-app-insights-data-with-the-elk-stack/?WT.mc_id=ndcsydney-event-aapowell) for analysis or [PowerBI](https://docs.microsoft.com/power-bi/service-connect-to-application-insights?WT.mc_id=ndcsydney-event-aapowell)
* [Azure DevOps](https://azure.microsoft.com/services/devops?WT.mc_id=ndcsydney-event-aapowell)
  * An all-in-one DevOps platform covering source control (Repos), backlog management (Boards) and CI/CD (Pipelines)
  * [Pricing information for Azure DevOps](https://azure.microsoft.com/pricing/details/devops/azure-devops-services/?WT.mc_id=ndcsydney-event-aapowell)
  * GitHub standard or [enterprise](https://github.com/enterprise) can be combined with [Actions](https://github.com/features/actions)
    * [Tierney Cyren](https://twitter.com/bitandbang) has a [comprehensive introduction to GitHub Actions](https://dev.to/bnb/an-unintentionally-comprehensive-introduction-to-github-actions-ci-blm)
* Cost Management
  * [Here's a quick overview](https://www.youtube.com/watch?v=ExIVG_Gr45A) of how to setup budgets in Azure Cost Management
  * [Pricing information for Azure Cost Management](https://azure.microsoft.com/en-us/pricing/details/cost-management/?WT.mc_id=ndcsydney-event-aapowell)
