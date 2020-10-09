﻿// Copyright (c) IEvangelist. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.CosmosRepository;
using Microsoft.Azure.CosmosRepository.Options;
using Microsoft.Azure.CosmosRepository.Providers;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Xunit;

namespace Microsoft.Azure.CosmosRepositoryTests.Providers
{
    public class DefaultCosmosContainerProviderTests
    {
        readonly ILoggerFactory _loggerFactory = new LoggerFactory();

        [Fact]
        public void NewDefaultCosmosContainerProviderThrowsWithNullCosmosClient() =>
            Assert.Throws<ArgumentNullException>(
                () => new DefaultCosmosContainerProvider<TestItem>(
                    null,
                    new DefaultCosmosPartitionKeyPathProvider(),
                    Options.Create(new RepositoryOptions
                    {
                        CosmosConnectionString = "pickles",
                        DatabaseId = "data",
                        ContainerId = "container"
                    }),
                    _loggerFactory.CreateLogger<DefaultCosmosContainerProvider<TestItem>>()));

        [Fact]
        public void NewDefaultCosmosContainerProviderThrowsWithNullCosmosPartitionKeyNameProvider() =>
            Assert.Throws<ArgumentNullException>(
                () => new DefaultCosmosContainerProvider<TestItem>(
                    new DefaultCosmosClientProvider(
                        new CosmosClientOptions(),
                        Options.Create(new RepositoryOptions
                        {
                            CosmosConnectionString = "pickles",
                            DatabaseId = "data",
                            ContainerId = "container"
                        })),
                    null,
                    Options.Create(new RepositoryOptions
                    {
                        DatabaseId = "data",
                        ContainerId = "container"
                    }),
                    _loggerFactory.CreateLogger<DefaultCosmosContainerProvider<TestItem>>()));

        [Fact]
        public void NewDefaultCosmosContainerProviderThrowsWithNullOptions() =>
            Assert.Throws<ArgumentNullException>(
                () => new DefaultCosmosContainerProvider<TestItem>(
                    new DefaultCosmosClientProvider(
                        new CosmosClientOptions(),
                        Options.Create(new RepositoryOptions
                        {
                            CosmosConnectionString = "pickles",
                            DatabaseId = "data",
                            ContainerId = "container"
                        })),
                    new DefaultCosmosPartitionKeyPathProvider(),
                    null,
                    _loggerFactory.CreateLogger<DefaultCosmosContainerProvider<TestItem>>()));

        [Fact]
        public void NewDefaultCosmosContainerProviderThrowsWithNullConnectionString() =>
            Assert.Throws<ArgumentNullException>(
                () => new DefaultCosmosContainerProvider<TestItem>(
                    new DefaultCosmosClientProvider(
                        new CosmosClientOptions(),
                        Options.Create(new RepositoryOptions
                        {
                            CosmosConnectionString = "pickles",
                            DatabaseId = "data",
                            ContainerId = "container"
                        })),
                    new DefaultCosmosPartitionKeyPathProvider(),
                    Options.Create(new RepositoryOptions
                    {
                        DatabaseId = "data",
                        ContainerId = "container"
                    }), null));
        [Fact]
        public void NewDefaultCosmosContainerProviderThrowsWithNullDatabaseId() =>
            Assert.Throws<ArgumentNullException>(
                () => new DefaultCosmosContainerProvider<TestItem>(
                    new DefaultCosmosClientProvider(
                        new CosmosClientOptions(),
                        Options.Create(new RepositoryOptions
                        {
                            CosmosConnectionString = "pickles",
                            DatabaseId = "data",
                            ContainerId = "container"
                        })),
                    new DefaultCosmosPartitionKeyPathProvider(),
                    Options.Create(new RepositoryOptions
                    {
                        CosmosConnectionString = "pickles",
                        ContainerId = "container"
                    }), null));

        [Fact]
        public void NewDefaultCosmosContainerProviderThrowsWithNullContainerId() =>
            Assert.Throws<ArgumentNullException>(
                () => new DefaultCosmosContainerProvider<TestItem>(
                    new DefaultCosmosClientProvider(
                        new CosmosClientOptions(),
                        Options.Create(new RepositoryOptions
                        {
                            CosmosConnectionString = "pickles",
                            DatabaseId = "data",
                            ContainerId = "container"
                        })),
                    new DefaultCosmosPartitionKeyPathProvider(),
                    Options.Create(new RepositoryOptions
                    {
                        CosmosConnectionString = "pickles",
                        DatabaseId = "data"
                    }), null));

        [Fact]
        public void NewDefaultCosmosContainerProviderThrowsWithNullLogger() =>
            Assert.Throws<ArgumentNullException>(
                () => new DefaultCosmosContainerProvider<TestItem>(
                    new DefaultCosmosClientProvider(
                        new CosmosClientOptions(),
                        Options.Create(new RepositoryOptions
                        {
                            CosmosConnectionString = "pickles",
                            DatabaseId = "data",
                            ContainerId = "container"
                        })),
                    new DefaultCosmosPartitionKeyPathProvider(),
                    Options.Create(new RepositoryOptions
                    {
                        CosmosConnectionString = "pickles",
                        DatabaseId = "data",
                        ContainerId = "container"
                    }), null));
    }

    public class TestItem : Item { }
}