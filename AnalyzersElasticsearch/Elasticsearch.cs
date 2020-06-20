using Nest;
using System;

namespace AnalysersElasticsearch
{
    /// <summary>
    /// Class to manage elasticsearch
    /// </summary>
    public class Elasticsearch
    {
        #region Properties
        /// <summary>
        /// Default name of index
        /// </summary>
        private static string _indexName = "sample-index";
        #endregion

        #region GetClient
        /// <summary>
        /// Get client to connect in elasticsearch
        /// </summary>
        /// <returns></returns>
        private static ElasticClient GetClient()
        {
            var uri = new Uri("http://localhost:9200");
            var settings = new ConnectionSettings(uri);
            var client = new ElasticClient();
            return client;
        }
        #endregion

        #region Index
        /// <summary>
        /// Index a document
        /// </summary>
        /// <param name="sampleClass"></param>
        public static void Index(SampleClass sampleClass)
        {
            var client = GetClient();

            var ret = client.Index(new IndexRequest<SampleClass>(sampleClass, _indexName));
        }
        #endregion

        #region CreateIndex
        /// <summary>
        /// Create indice with analyzer WordNet
        /// </summary>
        public static void CreateIndex()
        {
            var client = GetClient();

            client.DeleteIndexAsync(_indexName);

            var createIndexResponse = client.CreateIndex($"{_indexName}", c => c
                .Settings(s => s
                    .Analysis(a => a
                        .Analyzers(aa => aa
                            .Custom("synonym", sy => sy
                                .Tokenizer("whitespace")
                                .Filters("synonym", "porter_stem")
                            )
                            .Custom("word_delimiter", sy => sy
                                .Tokenizer("whitespace")
                                .Filters("word_delimiter_graph", "porter_stem")
                            )
                        )
                        .TokenFilters(tf => tf
                            .Synonym("synonym", s => s
                                .Format(SynonymFormat.WordNet)
                                .SynonymsPath("analysis/wn_s.pl")
                                )
                        )
                    )
                )
                .Mappings(m => m
                    .Map<SampleClass>(mm => mm
                        .AutoMap()
                    )
                )
            );
        }
        #endregion
    }
}
