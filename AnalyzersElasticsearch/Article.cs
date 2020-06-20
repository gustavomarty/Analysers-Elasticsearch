using Nest;

namespace AnalysersElasticsearch
{
    public class SampleClass
    {
        [Text(Index = true)]
        public string Id { get; set; }
        
        [Text(Analyzer = "word_delimiter", SearchAnalyzer = "synonym")]
        public string Text { get; set; }
        
    }
}
