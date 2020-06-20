using System;

namespace AnalysersElasticsearch
{
    class Program
    {
        static void Main(string[] args)
        {

            Elasticsearch.CreateIndex();

            IndexItems();

        }

        /// <summary>
        /// Index simple examples items
        /// </summary>
        static void IndexItems()
        {
            indexItem("a person sitting on a park, cars ");
            indexItem("Neighbours parking in your space or across your driveway, and people abandoning vehicles on the street can seem like a matter for the police. However, the first point of contact is very often your local authority. Here you can learn more about what constitutes nuisance parking and what to do if it’s affecting you.");
            indexItem("Abandoned vehicles can cause a nuisance by obstructing roads, traffic and pedestrians. The sight of a damaged or slowly rusting car can also be an eyesore in your community, so it’s understandable you might want it to be removed.");
            indexItem("car");
            indexItem("Since the 1990s, other traditional colours have resurfaced, such as the British racing green F1 Jaguar Racing cars and Aston Martin sports cars, and the white F1 BMW Sauber. German manufacturers like Mercedes-Benz and Audi (Auto Union) used silver paint when they returned to international racing in the 1990s. Many concept cars follow the old colour schemes, and most amateur racers prefer them as well.");
            indexItem("motorcar's");
            indexItem("automobile,");
            indexItem("If you find an abandoned vehicle that doesn’t appear to be stolen, please report an abandoned vehicle to us online.");
            indexItem("If you find an abandoned vehicle that you believe could be stolen, please report a crime to us.");
            indexItem("car parked");
            indexItem("From the beginning of organised motor sport events, in the early 1900s, until the late 1960s, before commercial sponsorship liveries came into common use, vehicles competing in Formula One, sports car racing, touring car racing and other international auto racing competitions customarily painted their cars in standardised racing colours that indicated the nation of origin of the car or driver. These were often quite different from the national colours used in other sports or in politics.");
        }

        private static void indexItem(string value)
        {
            var sampleClass = new SampleClass();
            sampleClass.Text = value;
            Elasticsearch.Index(sampleClass);

        }

    }
}
