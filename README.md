# Analyzers Elasticsearch
Indexing data using Elasticsearch and Analyzers as WordNet to apply synonyms.

## Structure:

### /Analyzers-Elasticsearch
    Console application (C# and .Net Core) to create and manage the index of elasticsearch.
    Just execute it!!

### /Elasticsearch
    Docker compose to up elasticsearch service.
    
    > How to:
    1. Open cmd prompt in this folder
    2. Run docker-compose up
    
## Testing our index
    1. Execute a [GET] request to this address: http://localhost:9200/sample-index
        Here we need to see the structure of the index created when we have executed the application.
    2. Execute a [POST] request to this address: http://localhost:9200/sample-index/_search. Use the body below:
        {
          "query": {
            "match": {
              "body": {
                "query": "car"
              }
            }
          }
        }
        
        We need to see three items returned in this request: car, motorcar and automobile.
    


TODO: extract content from files


## References

https://www.elastic.co/guide/en/elasticsearch/reference/current/index.html

https://wordnet.princeton.edu/
