﻿using GenericStructure.Dal.Context.Contracts;
using GenericStructure.Dal.Context.EndObjects;
using GenericStructure.Dal.Manipulation.Repositories.Implementation.Base;
using GenericStructure.Dal.Models.CoreBusiness;
using GenericStructure.Dal.Tests.Data.Database.DataSets;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericStructure.Dal.Tests.Testing.Manipulation.Repositories
{
    [TestFixture]
    public class DBaseArticleRepositoryTest
    {
        private ICoreBusinessContext context;
        private GenericRepository<Article> repository;
        private PersistentCoreBusinessDataSet dataSet;
        private Article addArticle;

        public DBaseArticleRepositoryTest() 
        {
            this.dataSet = new PersistentCoreBusinessDataSet();
        }

        [OneTimeSetUp]
        public void Init()
        {
            this.context = new CoreBusinessTestContext();
            this.repository = new GenericRepository<Article>(this.context);
            this.dataSet.Initialize();
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            this.dataSet.Destroy();
            this.dataSet.Dispose();
            this.context.Dispose();
        }

        [Test, Order(1)]
        public void Db_Repository_AddArticle()
        {
            this.addArticle = new Article
            {
                IdCategory = this.dataSet.CategoriesIds.ElementAt(0),
                Title = "Test Article 4",
                Description = "Description 4",
                ImagesPath = Guid.NewGuid(),
                Price = 1000.0m
            };

            repository.Insert(this.addArticle);
            int result = this.context.SaveChanges();

            Assert.AreEqual(1, result);
        }

        [Test, Order(2)]
        public void Db_Repository_UpdateArticle()
        {
            this.addArticle.Title = "Article 4 updated";

            this.repository.Update(this.addArticle);
            int result = this.context.SaveChanges();

            Assert.AreEqual(1, result);

        }

        [Test, Order(3)]
        public void Db_Repository_GetArticleById()
        {
            Article article = this.repository.GetByID(this.addArticle.Id);

            Assert.IsNotNull(article);
            Assert.AreEqual(this.addArticle.Title, article.Title);
            Assert.AreEqual(this.addArticle.Description, article.Description);
            Assert.AreEqual(this.addArticle.RowVersion, article.RowVersion);
        }

        [Test]
        public void Db_Repository_GetArticleById_DoesntExist()
        {
            Article article = this.repository.GetByID(0);

            Assert.AreEqual(null, article);
        }

        [Test, Order(4)]
        public void Db_Repository_DeleteArticle()
        {
            this.repository.Delete(this.addArticle);
            int result = this.context.SaveChanges();

            Assert.AreEqual(1, result);
        }

        //sql test
    }
}
