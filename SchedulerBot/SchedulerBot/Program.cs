﻿using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureKeyVault;

namespace SchedulerBot
{
	public class Program
	{
		public static void Main(string[] args)
		{
			BuildWebHost(args).Run();
		}

		public static IWebHost BuildWebHost(string[] args) =>
			WebHost.CreateDefaultBuilder(args)
				.ConfigureAppConfiguration((ctx, builder) =>
				{
					string keyVaultEndpoint = GetKeyVaultEndpoint();
					if (!string.IsNullOrEmpty(keyVaultEndpoint))
					{
						AzureServiceTokenProvider azureServiceTokenProvider = new AzureServiceTokenProvider();
						KeyVaultClient keyVaultClient = new KeyVaultClient(
							new KeyVaultClient.AuthenticationCallback(
								azureServiceTokenProvider.KeyVaultTokenCallback));
						builder.AddAzureKeyVault(
							keyVaultEndpoint, keyVaultClient, new DefaultKeyVaultSecretManager());
					}
					else
					{
						builder.AddUserSecrets<Startup>();
					}
				})
				.UseStartup<Startup>()
				.Build();

		private static string GetKeyVaultEndpoint() => Environment.GetEnvironmentVariable("KEYVAULT_ENDPOINT");
	}
}
