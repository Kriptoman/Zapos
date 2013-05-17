﻿using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;

using NUnit.Framework;

using Zapos.Constructors.Razor.Generators;
using Zapos.Constructors.Razor.Tests.TestModels;

namespace Zapos.Constructors.Razor.Tests.GenerateTextTests
{
    [TestFixture]
    public class CreateTextTests
    {
        [Test]
        public void GenerateTextTest()
        {
            var rnd = new Random();

            var filePath = Path.Combine("Content", "SimpleReport.cshtml");
            var model = new TestReportModel
                {
                    Items = Enumerable.Range(0, 50).Select(id => new TestReportItemModel
                        {
                            Id = id,
                            Name = Guid.NewGuid().ToString(),
                            Value = rnd.Next(1000000, 10000000) / 1000.0
                        })
                };

            var generator = new RazorTextGenerator();

            var content = generator.Generate(filePath, model);

            var document = XDocument.Parse("<body>" + content + "</body>");

            // ReSharper disable PossibleNullReferenceException
            var style = document.Root.Element("style");
            var table = document.Root.Element("table");
            // ReSharper restore PossibleNullReferenceException

            Assert.IsNotNullOrEmpty(content, "Content is null or empty");
            Assert.IsNotNull(style, "Cant find 'style' tag");
            Assert.IsNotNull(table, "Cant find 'table' tag");
        }
    }
}