using Lucene.Net.Analysis;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers;
using Lucene.Net.Search;
using Lucene.Net.Store;
using Plush.ApplicationLogger;
using Plush.DataAccessLayer.Domain.Domain;
using System;
using System.Collections.Generic;
using System.IO;

namespace Plush.Utils
{
    public class LuceneSearch : IDisposable
    {
        private readonly string path = @"C:\Users\marin\OneDrive\Documente\GitHub\PlushProject\Plush-API\Segments";
        private readonly ILoggerService logg;
        private readonly FSDirectory mIndexDirectory;
        private IndexReader mIndexReader;
        private readonly List<Product> products;
        public LuceneSearch(ILoggerService loggerService, List<Product> _products)
        {
            logg = loggerService;
            products = _products;

            CleanSegmentsDocument();
             mIndexDirectory = FSDirectory.Open(new DirectoryInfo(path));
        }

        private void CleanSegmentsDocument()
        {
            if (System.IO.Directory.Exists(path)) System.IO.Directory.Delete(path, true);
        }
        private void CreateIndex()
        {
            try
            {
                CleanSegmentsDocument();

                using Analyzer analyzer = new WhitespaceAnalyzer();

                using var writer = new IndexWriter(mIndexDirectory, analyzer, new IndexWriter.MaxFieldLength(1000));
                // the writer and analyzer will popuplate the directory with documents

                foreach (var row in products)
                {
                    var document = new Document();
                    var text = File.ReadAllText(@$"{ConstantString.pathInput}\{row.Name}.txt");
                    document.Add(new Field("ProductID", row.ProductID.ToString(), Field.Store.YES, Field.Index.ANALYZED));
                    document.Add(new Field("FullText", string.Format("{0} {1} {2} {3}", row.Name, text, row.Category?.Name, row.Provider?.Name).ToUpper(), Field.Store.YES, Field.Index.ANALYZED));
                    writer.AddDocument(document);
                }

                writer.Optimize();
                writer.Flush(true, true, true);
            }
            catch (Exception ex)
            {
                logg.LogError("LuceneSearch: ", ex.Message);
            }

        }

        public List<Guid> Search(string textSearch)
        {
            var newProductsList = new List<Guid>();
            try
            {
                CreateIndex();

                mIndexReader = IndexReader.Open(mIndexDirectory, true);
                using var searcher = new IndexSearcher(mIndexReader);
                using Analyzer analyzer = new WhitespaceAnalyzer();
                var queryParser = new QueryParser(Lucene.Net.Util.Version.LUCENE_30, "FullText", analyzer)
                {
                    AllowLeadingWildcard = true
                };

                var query = queryParser.Parse(textSearch);

                var collector = TopScoreDocCollector.Create(10000, true);

                searcher.Search(query, collector);

                var matches = collector.TopDocs().ScoreDocs;

                foreach (var item in matches)
                {
                    var id = item.Doc;
                    var doc = searcher.Doc(id);
                    newProductsList.Add(Guid.Parse(doc.GetField("ProductID").StringValue));
                }
            }
            catch (Exception ex)
            {
                logg.LogError("Lucene search: ", ex.Message);
            }

            return newProductsList;

        }

        public void Dispose()
        {
            if (mIndexReader != null) mIndexReader.Dispose();
            if (mIndexDirectory != null) mIndexDirectory.Dispose();
        }

    }

}
